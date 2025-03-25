using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ONLINE_POST.Models;
using ONLINE_POST.Models.extras.join;
using ONLINE_POST.Models.filters;

namespace ONLINE_POST.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [TypeFilter(typeof(UserAuthenticationFilter))]
    public class AdminController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();

        public IActionResult Index()
        {
            var total_packages=db.Packages.Count();
            TempData["package"] = total_packages;
            var user = db.PersonalInformations.Where(x=>x.PRoleId==2).Count();
            TempData["user"] = user;
            var branch = db.branches.Count();
            TempData["branch"] = branch;
            var emp = db.EmployeeInformations.Count();
            TempData["emp"] = emp;
            var charge = db.Charges.Count();
            TempData["charge"] = charge;
            var s_type = db.servicetypes.Count();
            TempData["s_type"] = s_type;
            var admins = db.PersonalInformations.Where(x => x.PRoleId == 1).ToList();
            TempData["admin"] = admins;

            var delivery = db.Delivery_Histories.Where(x=>x.status=="Completed").Sum(x=>x.Total_Price);
            TempData["completed"] = delivery;
            var delivery1 = db.Delivery_Histories.Where(x => x.status != "Completed").Sum(x => x.Total_Price);
            TempData["pending"] = delivery1;
            return View();
        }
        public IActionResult e_create()
        {
            var branch = db.branches.ToList();
            TempData["branch"] = branch;
            return View();
        }
        public IActionResult e_view()
        {
            var emp = db.EmployeeInformations.Include(x => x.branch).ThenInclude(x => x.city).Select(y => new emp_branch
            {
                e_id=y.EId,
                emp_name=y.EUserName,
                emp_email=y.EEmail,
                branch=y.branch.b_name,
                City = y.branch.city.c_name
            }).ToList();
            return View(emp);
        }
        public IActionResult upd_emp(int id)
        {
            
            if (id == null)
            {

                SetCookie("error-msg", "select one for update Employee");
                return RedirectToAction("e_view", "Admin");
            }
            else
            {
                var branch = db.branches.ToList();
                TempData["branch"] = branch;
                var data = db.EmployeeInformations.Find(id);
                return View(data);
            }
        }
        public IActionResult b_create()
        {
            
            var city = db.cities.ToList();
            TempData["city"] = city;
            var branch = db.branches.Include(x=>x.city).Select(y=> new branch_city
            {
                b_id=y.b_id,
                Branch=y.b_name,
                city_name=y.city.c_name
            }).ToList();
            TempData["branch"] = branch;
            return View();
        }
        public IActionResult upd_branch(int id)
        {
            
            if (id == null)
            {
                SetCookie("error-msg", "select one for update branch");
                return RedirectToAction("b_create", "Admin");
            }
            else
            {
                var city = db.cities.ToList();
                TempData["city"] = city;
                var data = db.branches.Find(id);
                return View(data);
            }
        }
        public IActionResult emp_log()
        {
            
            var emp = db.emplogs.Include(x => x.branch).ThenInclude(x => x.city).Select(y => new emp_branch
            {
                e_id = y.EId,
                emp_name = y.EUserName,
                emp_email = y.EEmail,
                branch = y.branch.b_name,
                City = y.branch.city.c_name
            }).ToList();
            return View(emp);
        }
        public IActionResult users()
        {
            
            var user = db.PersonalInformations.Where(x => x.PRoleId == 2).ToList();
            return View(user);
        }
        public IActionResult packages()
        {
            
            var package = db.Packages.ToList();
            TempData["package"] = package;
            var cus_package = db.Customer_Packages.ToList();
            TempData["cus"] = cus_package;
            return View();
        }
        public IActionResult upd_package(int id)
        {
            
            var package = db.Packages.Find(id);
            return View(package);
        }
        public IActionResult s_charge()
        {
            var charge=db.Charges.ToList();
            TempData["charge"] = charge;
            return View();
        }
        public IActionResult upd_charge(int id)
        {
            var charge = db.Charges.Find(id);
            return View(charge);
        }
        public IActionResult s_type()
        {
            var s_type = db.servicetypes.ToList();
            TempData["service"] = s_type;
            return View();
        }
        public IActionResult upd_service(int id)
        {
            var service = db.servicetypes.Find(id);
            return View(service);
        }

        public IActionResult payment()
        {
            var pay = db.payments.ToList();
            TempData["pay"] = pay;
            return View();
        }
        public IActionResult Feedback()
        {
            var contact = db.Contacts.ToList();
            TempData["contact"] = contact;
            return View();
        }
        public IActionResult Profile()
        {
            var user_data = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<PersonalInformation>(user_data);
            return View(user);
        }
        public IActionResult f_view()
        {
            var form = db.Forms.Where(x => x.f_name == "form").FirstOrDefault();
            return View(form);
        }

        public IActionResult s_view()
        {
            var order = fullorder();
            return View(order);
        }

        public IActionResult view_details(int id)
        {
            if (id != null)
            {
                var details = orders(id);
                return View(details);
            }
            else
            {
                return RedirectToAction("view_details", "Admin");
            }

        }

        public List<orders> fullorder()
        {
            var orders = db.Delivery_Histories.Select(y => new orders
            {

                DeliverableId = y.DeliverableId,
                Tracking_Number = y.Tracking_Number,
                DateOfPosting = y.DateOfPosting,
                Weight = y.Weight,
                DestinationAddress = y.DestinationAddress,
                SenderAddress = y.SenderAddress,
                Contact_Number = y.Contact_Number,
                DateReceived = y.DateReceived,
                DateDelivered = y.DateDelivered,
                package_type = y.package_type,
                normal_charges = y.normal_charges,
                service_charges = y.service_charges,
                Total_Price = y.Total_Price,
                status = y.status,
                branch_name = y.branch_name

            }).ToList();

            return orders;
        }

        public orders orders(int id)
        {
            var orders = db.Delivery_Histories.Where(x=>x.DeliverableId == id).Select(y => new orders
            {

                DeliverableId = y.DeliverableId,
                Tracking_Number = y.Tracking_Number,
                DateOfPosting = y.DateOfPosting,
                Weight = y.Weight,
                DestinationAddress = y.DestinationAddress,
                SenderAddress = y.SenderAddress,
                Contact_Number = y.Contact_Number,
                DateReceived = y.DateReceived,
                DateDelivered = y.DateDelivered,
                package_type = y.package_type,
                normal_charges = y.normal_charges,
                service_charges = y.service_charges,
                Total_Price = y.Total_Price,
                status = y.status,
                branch_name = y.branch_name

            }).FirstOrDefault();

            return orders;
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
