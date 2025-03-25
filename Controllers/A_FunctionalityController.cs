using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ONLINE_POST.Models;
using System.Xml.Linq;

namespace ONLINE_POST.Controllers
{
    //Admin Functionality
    public class A_FunctionalityController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();

        [HttpPost]
        public IActionResult b_create(branch b, int city)
        {
            if (b != null)
            {
                db.branches.Add(b);
                b.c_id = city;
                db.SaveChanges();
                SetCookie("success-msg", "Branch Created Successfully");
                return RedirectToAction("b_create", "Admin");
            }
            else
            {
                SetCookie("error-msg", "Please fill fields");
                return RedirectToAction("b_create", "Admin");
            }
        }
        public IActionResult del_branch(int id)
        {
            var emp_information = db.EmployeeInformations.Where(x => x.Branch == id).FirstOrDefault();
            var delivery = db.Deliverables.Where(x => x.branch_id == id).FirstOrDefault();
            var condition = db.branches.Find(id);
            if (delivery == null || delivery.status == "Completed")
            {
                if (emp_information == null)
                {
                    db.branches.Remove(condition);
                    db.SaveChanges();
                    SetCookie("success-msg", "Delete Branch Successfully");
                }
                else
                {
                    SetCookie("error-msg", "Branch contains many employee please remove employee first");
                }
            }
            else
            {
                SetCookie("error-msg", "Branch contains many Orders");
            }
            return RedirectToAction("b_create", "Admin");
        }

        [HttpPost]
        public IActionResult upd_branch(branch b, int city)
        {
            var condition = db.branches.Where(x => x.b_id == b.b_id).FirstOrDefault();
            var b_name = db.branches.Where(x => x.b_name == b.b_name).FirstOrDefault();
            var d_history = db.Delivery_Histories.Where(x => x.branch_name == condition.b_name).ToList();
            if (condition != null && b != null)
            {
                if (b_name == null)
                {
                    condition.b_name = b.b_name;
                    condition.c_id = city;
                    foreach (var d in d_history)
                    {
                        d.branch_name = b.b_name;
                    }
                    db.SaveChanges();
                    SetCookie("success-msg", "Branch Updated Successfully");
                    return RedirectToAction("b_create", "Admin");
                }
                else
                {
                    SetCookie("error-msg", "Name Already Inserted");
                    return RedirectToAction("b_create", "Admin");
                }
            }
            else
            {
                SetCookie("error-msg", "Please fill fields");
                return RedirectToAction("b_create", "Admin");
            }
        }
        [HttpPost]
        public IActionResult e_create(EmployeeInformation e, int branch)
        {
            if (e != null)
            {
                var condititon = db.PersonalInformations.Where(x => x.PEmail == e.EEmail || x.PUserName == e.EUserName).FirstOrDefault();
                var e_condititon = db.EmployeeInformations.Where(x => x.EEmail == e.EEmail || x.EUserName == e.EUserName).FirstOrDefault();
                var e_log = db.emplogs.Where(x => x.EEmail == e.EEmail || x.EUserName == e.EUserName).FirstOrDefault();
                if (condititon == null && e_condititon == null && e_log == null)
                {
                    db.EmployeeInformations.Add(e);
                    e.Branch = branch;
                    db.SaveChanges();
                    SetCookie("success-msg", "Employee Created Successfully");
                    return RedirectToAction("e_create", "Admin");
                }
                else
                {
                    SetCookie("error-msg", "This Email Already Registered");
                    return RedirectToAction("e_create", "Admin");
                }
            }
            else
            {
                SetCookie("error-msg", "Please fill fields");
                return RedirectToAction("e_create", "Admin");
            }
        }
        public IActionResult del_emp(int id)
        {
            var condition = db.EmployeeInformations.Find(id);
            if (condition != null)
            {
                emplog emp = new emplog()
                {
                    EUserName = condition.EUserName,
                    EEmail = condition.EEmail,
                    EPassword = condition.EPassword,
                    Branch = condition.Branch,
                    ERoleId = condition.ERoleId,
                };
                db.emplogs.Add(emp);
                db.EmployeeInformations.Remove(condition);
                db.SaveChanges();
                SetCookie("success-msg", "Delete employee Successfully and Saved in Employee log table");
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("e_view", "Admin");
        }

        [HttpPost]
        public IActionResult upd_emp(EmployeeInformation e, int branch)
        {
            var condition = db.EmployeeInformations.Where(x => x.EId == e.EId).FirstOrDefault();
            var emp = db.EmployeeInformations.Where(x => x.EEmail == e.EEmail || x.EUserName==e.EUserName).FirstOrDefault();
            if (condition != null && e != null)
            {
                if (emp == null)
                {
                    condition.EUserName = e.EUserName;
                    condition.EEmail = e.EEmail;
                    condition.EPassword = e.EPassword;
                    condition.Branch = branch;
                    db.SaveChanges();
                    SetCookie("success-msg", "employee Updated Successfully");
                    return RedirectToAction("e_view", "Admin");
                }
                else
                {
                    SetCookie("error-msg", "Alreay Exist");
                    return RedirectToAction("e_view", "Admin");
                }
            }
            else
            {
                SetCookie("error-msg", "Please fill fields");
                return RedirectToAction("e_view", "Admin");
            }
        }

        public IActionResult del_emp_log(int id)
        {
            var condition = db.emplogs.Find(id);
            if (condition != null)
            {
                db.emplogs.Remove(condition);
                db.SaveChanges();
                SetCookie("success-msg", "Delete employee in Log Table Successfully");
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("emp_log", "Admin");
        }
        public IActionResult recover_emp(int id)
        {
            var condition = db.emplogs.Find(id);
            if (condition != null)
            {
                EmployeeInformation emp = new EmployeeInformation()
                {
                    EUserName = condition.EUserName,
                    EEmail = condition.EEmail,
                    EPassword = condition.EPassword,
                    Branch = condition.Branch,
                    ERoleId = condition.ERoleId,
                };
                db.EmployeeInformations.Add(emp);
                db.emplogs.Remove(condition);
                db.SaveChanges();
                SetCookie("success-msg", "Recover employee in Log Table Successfully");
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("e_view", "Admin");
        }
        public IActionResult del_user(int id)
        {
            var condition = db.PersonalInformations.Find(id);
            var delivery = db.Deliverables.Where(x => x.User_id == id).FirstOrDefault();
            if (delivery == null || delivery.status == "Completed")
            {
                if (condition != null)
                {
                    db.PersonalInformations.Remove(condition);
                    db.SaveChanges();
                    SetCookie("success-msg", "Delete User Successfully");
                }
                else
                {
                    SetCookie("error-msg", "error");
                }
            }
            else
            {
                SetCookie("error-msg", "User Contain Orders");
            }
            return RedirectToAction("users", "Admin");
        }
        public IActionResult upd_user(int id)
        {
            var condition = db.PersonalInformations.Find(id);
            if (condition != null)
            {
                if (condition.status == "on")
                {
                    condition.status = "off";
                    db.SaveChanges();
                    SetCookie("success-msg", condition.PUserName + " is Now Disactivated");
                }
                else
                {
                    condition.status = "on";
                    db.SaveChanges();
                    SetCookie("success-msg", condition.PUserName + " is Now Activated");
                }
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("users", "Admin");
        }

        [HttpPost]
        public IActionResult packages(package p)
        {
            var count = db.Packages.Count();
            var package = db.Packages.Where(x => x.p_name == p.p_name).FirstOrDefault();
            if (count < 3)
            {
                if (package == null)
                {
                    db.Packages.Add(p);
                    db.SaveChanges();
                    SetCookie("success-msg", "Package Created Successfully");
                }
                else
                {
                    SetCookie("error-msg", "Package already inserted");
                }
            }
            else
            {
                SetCookie("info-msg", "Cannot insert more than 3 packages");
            }
            return RedirectToAction("packages", "Admin");
        }
        public IActionResult del_package(int id)
        {
            var condition = db.Packages.Find(id);
            if (condition != null)
            {
                db.Packages.Remove(condition);
                db.SaveChanges();
                SetCookie("success-msg", "Package Delete Successfully");
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("packages", "Admin");
        }
        public IActionResult upd_package(package p)
        {
            var condition = db.Packages.Where(x => x.p_id == p.p_id).FirstOrDefault();
            if (condition != null)
            {
                condition.p_name = p.p_name;
                condition.p_dis = p.p_dis;
                condition.p_price = p.p_price;
                db.SaveChanges();
                SetCookie("success-msg", "Package update Successfully");
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("packages", "Admin");
        }

        [HttpPost]
        public IActionResult s_charge(charge c)
        {
            var condition = db.Charges.Where(x => x.min_weight == c.min_weight || x.max_weight == c.max_weight).FirstOrDefault();
            if (condition != null)
            {
                SetCookie("error-msg", "Charge Already Inserted");
            }
            else
            {
                if (c.min_weight < c.max_weight)
                {
                    db.Charges.Add(c);
                    db.SaveChanges();
                    SetCookie("success-msg", "Charge Insert Successfully");
                }
                else
                {
                    SetCookie("error-msg", "Min weight is greater then max");
                }
            }
            return RedirectToAction("s_charge", "Admin");
        }

        public IActionResult del_charge(int id)
        {
            var delivery = db.Deliverables.Where(x => x.c_id == id).FirstOrDefault();
            var condition = db.Charges.Find(id);
            if (delivery == null || delivery.status == "Completed")
            {
                if (condition != null)
                {
                    db.Charges.Remove(condition);
                    db.SaveChanges();
                    SetCookie("success-msg", "Service Charges Delete Successfully");
                }
                else
                {
                    SetCookie("error-msg", "error");
                }
            }
            else
            {
                SetCookie("error-msg", "This Charge Contain Orders");
            }
            return RedirectToAction("s_charge", "Admin");
        }

        [HttpPost]
        public IActionResult upd_charge(charge c)
        {
            var condition = db.Charges.Where(x => x.c_id == c.c_id).FirstOrDefault();
            if (condition == null)
            {
                SetCookie("error-msg", "error");
            }
            else
            {
                if (c.min_weight < c.max_weight)
                {
                    condition.min_weight = c.min_weight;
                    condition.max_weight = c.max_weight;
                    condition.c_rate = c.c_rate;
                    db.SaveChanges();
                    SetCookie("success-msg", "Charge Update Successfully");
                }
                else
                {
                    SetCookie("error-msg", "Min weight is greater then max");
                }
            }
            return RedirectToAction("s_charge", "Admin");
        }

        [HttpPost]
        public IActionResult s_type(servicetype c)
        {
            var condition = db.servicetypes.Where(x => x.service_name == c.service_name).FirstOrDefault();
            if (condition != null)
            {
                SetCookie("error-msg", "Service Already Inserted");
            }
            else
            {
                db.servicetypes.Add(c);
                db.SaveChanges();
                SetCookie("success-msg", "Service Insert Successfully");
            }
            return RedirectToAction("s_type", "Admin");
        }

        public IActionResult del_service(int id)
        {
            var delivery = db.Deliverables.Where(x => x.c_id == id).FirstOrDefault();
            var condition = db.servicetypes.Find(id);
            if (delivery == null || delivery.status == "Completed")
            {
                if (condition != null)
                {
                    db.servicetypes.Remove(condition);
                    db.SaveChanges();
                    SetCookie("success-msg", "Service Delete Successfully");
                }
                else
                {
                    SetCookie("error-msg", "error");
                }
            }
            else
            {
                SetCookie("error-msg", "This Delivery_Type Contain Orders");
            }
            return RedirectToAction("s_type", "Admin");
        }

        [HttpPost]
        public IActionResult upd_service(servicetype c)
        {
            var condition = db.servicetypes.Where(x => x.s_id == c.s_id).FirstOrDefault();
            if (condition == null)
            {
                SetCookie("error-msg", "error");
            }
            else
            {
                condition.service_name = c.service_name;
                condition.service_charges = c.service_charges;
                db.SaveChanges();
                SetCookie("success-msg", "Service Update Successfully");
            }
            return RedirectToAction("s_type", "Admin");
        }

        [HttpPost]
        public IActionResult payment(payment p)
        {
            var condition = db.payments.Where(x => x.p_name == p.p_name).FirstOrDefault();
            if (condition != null)
            {
                SetCookie("error-msg", p.p_name + " Already Inserted");
            }
            else
            {
                if (p.p_name == "Stripe")
                {
                    db.payments.Add(p);
                    db.SaveChanges();
                    SetCookie("success-msg", "Payment Type Insert Successfully");
                }
                else
                {
                    SetCookie("error-msg", "Please enter Payment Type only Stripe");
                }
            }
            return RedirectToAction("payment", "Admin");
        }

        public IActionResult del_pay(int id)
        {
            var delivery = db.Deliverables.Where(x => x.pay_id == id).FirstOrDefault();
            var condition = db.payments.Find(id);
            if (delivery == null || delivery.status == "Completed")
            {
                if (condition != null)
                {
                    db.payments.Remove(condition);
                    db.SaveChanges();
                    SetCookie("success-msg", "Payment Type Delete Successfully");
                }
                else
                {
                    SetCookie("error-msg", "error");
                }
            }
            else
            {
                SetCookie("error-msg", "This Payment Type Contains Order");
            }
            return RedirectToAction("payment", "Admin");
        }

        public IActionResult del_msg(int id)
        {
            var condition = db.Contacts.Find(id);
           
                if (condition != null)
                {
                    db.Contacts.Remove(condition);
                    db.SaveChanges();
                    SetCookie("success-msg", "Feedback Delete Successfully");
                }
                else
                {
                    SetCookie("error-msg", "error");
                }
         
            return RedirectToAction("Feedback", "Admin");
        }

        public IActionResult Profile(PersonalInformation p)
        {
            var user = db.PersonalInformations.Find(p.PId);
            if (user != null)
            {
                user.PPassword = p.PPassword;
                db.SaveChanges();
                SetCookie("success-msg", "Change Password Successfully");
                var user_data = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("User", user_data);
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("Profile", "Admin");
        }


        public IActionResult del_order(int id)
        {
            var condition = db.Deliverables.Where(x=>x.DeliverableId==id).FirstOrDefault();
            var condition_h = db.Delivery_Histories.Where(x => x.DeliverableId == id).FirstOrDefault();
            if (condition != null)
                {
                    db.Deliverables.Remove(condition);
                    db.Delivery_Histories.Remove(condition_h);
                    db.SaveChanges();
                    SetCookie("success-msg", "Delivery Delete Successfully");
                }
                else
                {
                    SetCookie("error-msg", "error");
                }
            
            return RedirectToAction("payment", "Admin");
        }

        public IActionResult f_view(int id)
        {
            var condition = db.Forms.Find(id);
            if (condition != null)
            {
                if (condition.status == "on")
                {
                    condition.status = "off";
                    db.SaveChanges();
                    SetCookie("success-msg", "Status is Now Disactivated");
                }
                else
                {
                    condition.status = "on";
                    db.SaveChanges();
                    SetCookie("success-msg", "Status is Now Activated");
                }
            }
            else
            {
                SetCookie("error-msg", "error");
            }

            return RedirectToAction("f_view", "Admin");
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
