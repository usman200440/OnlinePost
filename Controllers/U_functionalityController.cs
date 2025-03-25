using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ONLINE_POST.Models;
using ONLINE_POST.Models.functionality;
using Stripe;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_POST.Controllers
{
    public class U_functionalityController : Controller
    {
        post_management_systemContext db =new post_management_systemContext();
        private readonly IHttpContextAccessor _httpContextAccessor;
        public U_functionalityController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public IActionResult CreatePayment(string stripeToken ,package p,int id)
        {
            var user_data = db.PersonalInformations.Find(id);
            var check = db.Customer_Packages.Where(x=>x.user_id==id).FirstOrDefault();
            if (check == null)
            {
                customer_package package = new customer_package()
                {
                    user_id = user_data.PId,
                    user_name = user_data.PUserName,
                    package_name = p.p_name,
                    package_discount = p.p_dis,
                    package_price = p.p_price,
                    expired = DateTime.Now.AddDays(10)
                };
                var options = new ChargeCreateOptions
                {
                    Amount = p.p_price * 100,
                    Currency = "usd",
                    Description = "Online Post Package",
                    Source = stripeToken,
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);
                db.Customer_Packages.Add(package);
                db.SaveChanges();
                SetCookie("success-msg","You have obtained " + p.p_name + " Package Congratz!");
            }
            else
            {
                SetCookie("error-msg", "Package already in Use");
            }
            // Handle the charge response as needed

            return RedirectToAction("Index","User");
        }
        [HttpPost]
        public IActionResult courier_details(Deliverable d)
        {
          if (d.Weight > 0 && d.Weight <= 500)
            {
                var data = HttpContext.Session.GetString("User");
                var user = JsonConvert.DeserializeObject<PersonalInformation>(data);
                var package = db.Customer_Packages.Where(x => x.user_id == user.PId).FirstOrDefault();
                var charges = db.Charges.FirstOrDefault(c => d.Weight >= c.min_weight && d.Weight <= c.max_weight);
                var service_type = db.servicetypes.Where(x => x.s_id == d.TypeOfDelivery).FirstOrDefault();
                var status = db.Statuses.Where(x => x.s_type == "Pending" || x.s_type == "pending").FirstOrDefault();
                var package_name = "null";
                var package_discount = 0;

                if (package != null)
                {
                    package_name = package.package_name;
                    package_discount = package.package_discount;
                    SetCookie("success-msg", "Package_Applied");
                }
                string tracking_id = Guid.NewGuid().ToString();
                DateTime date = DateTime.Now;

                decimal charge = charges.c_rate;
                decimal s_charges = service_type.service_charges;
                decimal discount = 0m;
                if (package_discount != 0)
                {
                    decimal dis = (package_discount / 100m);
                    discount = (charge + s_charges) * (dis+0m);
                }
                var total_price = ((int)((charge + s_charges) - (discount)));
                Deliverable newDeliverable = new Deliverable
                {
                    Tracking_Number = tracking_id,
                    User_id = user.PId,
                    DateOfPosting = DateTime.Now,
                    Weight = d.Weight,
                    TypeOfDelivery = service_type.s_id,
                    pay_id = d.pay_id,
                    DestinationAddress = d.DestinationAddress,
                    SenderAddress = d.SenderAddress,
                    Contact_Number = d.Contact_Number,
                    DateReceived = DateTime.Now,
                    DateDelivered = DateTime.Now,
                    package_type = package_name,
                    branch_id = d.branch_id,
                    c_id = charges.c_id,
                    status = "Pending",
                    Total_Price = total_price
                };
                var delivery=JsonConvert.SerializeObject(newDeliverable);
                HttpContext.Session.SetString("delivery", delivery);
                return RedirectToAction("confirmation_bill", "User");
            }
            else
            {
                SetCookie("error-msg", "Please Insert weight between  1 to 500 kg");
            }
            return RedirectToAction("Index", "User");
        }


        [HttpPost]
        public IActionResult confirmation_bill(string stripeToken)
        {
            var u_data = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<PersonalInformation>(u_data);
            var data = HttpContext.Session.GetString("delivery");
            var delivery = JsonConvert.DeserializeObject<Deliverable>(data);
            var charges = db.Charges.FirstOrDefault(c => delivery.Weight >= c.min_weight && delivery.Weight <= c.max_weight);
            var service_type = db.servicetypes.Where(x => x.s_id == delivery.TypeOfDelivery).FirstOrDefault();
            if (delivery != null)
            {
                var options = new ChargeCreateOptions
                {
                    Amount = delivery.Total_Price * 100,
                    Currency = "usd",
                    Description = "Online Post System",
                    Source = stripeToken,
                };
                methods body_method = new methods();
                var b_data= body_method.body_data(_httpContextAccessor);
                var body = b_data;
                verifyemail emailsend = new verifyemail(user.PEmail,body,"PostTech Couier for " + user.PUserName);

                var service = new ChargeService();
                Charge charge = service.Create(options);
                db.Deliverables.Add(delivery);
                var count=db.SaveChanges();
                if (count > 0)
                {
                    var branch = db.branches.Where(x => x.b_id == delivery.branch_id).FirstOrDefault();
                    delivery_history d_history = new delivery_history
                    {
                        Tracking_Number = delivery.Tracking_Number,
                        DateOfPosting = delivery.DateOfPosting,
                        Weight = delivery.Weight,
                        DestinationAddress = delivery.DestinationAddress,
                        SenderAddress = delivery.SenderAddress,
                        Contact_Number = delivery.Contact_Number,
                        DateReceived = delivery.DateReceived,
                        DateDelivered = delivery.DateDelivered,
                        package_type = delivery.package_type,
                        normal_charges= charges.c_rate,
                        service_charges= service_type.service_charges,
                        Total_Price =delivery.Total_Price,
                        status="Pending",
                        branch_name=branch.b_name
                    };
                    db.Delivery_Histories.Add(d_history);
                    db.SaveChanges();
                }
                
                SetCookie("success-msg", "Courier Placed Successfully");
            }
            else
            {
                SetCookie("error-msg", "Please fill courier form");
            }
            return RedirectToAction("Index", "User");
        }

        public IActionResult c_pass(int id)
        {
            var user_data = HttpContext.Session.GetString("User");
            var user_detail = JsonConvert.DeserializeObject<PersonalInformation>(user_data);
            var user = db.PersonalInformations.Where(x => x.PId == id).FirstOrDefault();
            if (user != null)
            {
                if (user.PId == user_detail.PId)
                {
                    Random random = new Random();
                    var code = random.Next(100000, 999999).ToString();
                    verifyemail verifyemail = new verifyemail(user.PEmail,"code Verification code is " + code, user.PUserName + " Account verification Code");
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMinutes(2);
                    HttpContext.Response.Cookies.Append("usercode", code, cookie);
                    HttpContext.Response.Cookies.Append("userid", user.PId.ToString(), cookie);
                    SetCookie("success-msg", "Code Send in you email");
                    return RedirectToAction("code_verify", "User");
                }
                else
                {
                    SetCookie("error-msg", "User not Found");
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpPost]
        public IActionResult code_verify(string code)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(1);
            HttpContext.Response.Cookies.Append("secured", "secured", cookie);
            var codeaccess = HttpContext.Request.Cookies["usercode"];
            if (code== codeaccess)
            {
                SetCookie("success-msg", "correct code");
                return RedirectToAction("change_password", "User");
            }
            else
            {
                SetCookie("error-msg", "Invalid Code");
            }
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult change_password(string newPassword,string confirmPassword)
        {
            var user_id = HttpContext.Request.Cookies["userid"];
            var user = db.PersonalInformations.Where(x => x.PId == int.Parse(user_id)).FirstOrDefault();
            if (newPassword == confirmPassword)
            {
                user.PPassword = newPassword;
                db.SaveChanges();
                SetCookie("success-msg", "Password Change SuccessFully");
            }
            else
            {
                SetCookie("error-msg", "Invalid Code");
            }
            return RedirectToAction("Index", "User");
        }

        private void SetCookie(string cookieName, string cookieValue)
        {
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(3) // Expires in 3 seconds
            };
            HttpContext.Response.Cookies.Append(cookieName, cookieValue, option);
        }
    }
}
