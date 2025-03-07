using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ONLINE_POST.Models;
using ONLINE_POST.Models.filters;
using System.Globalization;

namespace ONLINE_POST.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [TypeFilter(typeof(UserAuthenticationFilter))]
    public class UserController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();
       
        public IActionResult Index()
        {
            var package = db.Packages.ToList();
            TempData["package"] = package;
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }
       
        public IActionResult Service()
        {
            var user_data = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<PersonalInformation>(user_data);
            var package_list = db.Customer_Packages.Where(x => x.user_id == user.PId).ToList();
            var package = db.Packages.ToList();
            TempData["package_list"] = package_list;
            TempData["package"] = package;
            return View();
        }
        public IActionResult place_courier()
        {
            var form = db.Forms.Where(x => x.f_name == "form").FirstOrDefault();
            TempData["form"] = form;
            var d_type=db.servicetypes.ToList();
            TempData["d_type"] = d_type;
            var pay = db.payments.ToList();
            TempData["pay"] = pay;
            var branch = db.branches
                .Include(b => b.employees)
                .Where(b => b.employees.Any())
                .ToList();
            TempData["branch"] = branch;

            return View();
        }
        public IActionResult confirmation_bill()
        {
            var data = HttpContext.Session.GetString("delivery");
            var delivery = JsonConvert.DeserializeObject<Deliverable>(data);
            if (delivery != null)
            {
                var b=db.branches.Where(x => x.b_id == delivery.branch_id).FirstOrDefault();
                var p=db.payments.Where(x => x.p_id == delivery.pay_id).FirstOrDefault();
                var s=db.servicetypes.Where(x => x.s_id == delivery.TypeOfDelivery).FirstOrDefault();
                var c = db.Charges.Where(x => x.c_id == delivery.c_id).FirstOrDefault();
                TempData["branch"] = b;
                TempData["pay"] = p;
                TempData["s_type"] = s;
                TempData["charge"] = c;
                return View(delivery);
            }
            else
            {
                SetCookie("error-msg", "Please Fill First Courier Form");
                return RedirectToAction("Index", "User");
            }
        }
        public IActionResult Profile()
        {
            var user_data = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<PersonalInformation>(user_data);
            return View(user);
        }
        public IActionResult code_verify()
        {
            return View();
        }
        public IActionResult change_password()
        {
            var codeaccess = HttpContext.Request.Cookies["secured"];
            if (codeaccess != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        public IActionResult tracking_details(string tracking)
        {
            if (tracking != null) 
            {
                var d_history = db.Delivery_Histories.Where(x => x.Tracking_Number == tracking).FirstOrDefault();
                if (d_history != null)
                {
                    return View(d_history);
                }
                else
                {
                    SetCookie("error-msg", "Invalid Tracking Number");
                    return RedirectToAction("Index", "User");
                }
                
            }
            else
            {
                SetCookie("error-msg", "Please Fill First Tracking number");
                return RedirectToAction("Index", "User");
            }
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
