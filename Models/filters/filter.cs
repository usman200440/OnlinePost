using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
namespace ONLINE_POST.Models.filters
{
    public class filter : IActionFilter
    {
        private readonly List<string> auth = new List<string>()
        {
            "Index","About","Contact","Service"
        };
        private readonly List<string> user = new List<string>()
        {
            "Index","About","Contact","Service","place_courier",
            "courier_details","confirmation_bill","Profile","CreatePayment",
            "code_verify","c_pass","change_password","tracking_details"
        };
        private readonly List<string> admin = new List<string>()
        {
            "Index","e_create","b_create","del_branch","del_emp",
            "upd_branch","upd_emp","e_view","emp_log","del_emp_log",
            "recover_emp","users","del_user","upd_user","packages","del_package",
            "upd_package","s_charge","del_charge","upd_charge","s_type","del_service",
            "upd_service","payment","del_pay","Feedback","del_msg","Profile","s_view",
            "view_details","del_order","f_view"

        };
        private readonly List<string> emp = new List<string>()
        {
            "Index","pending_delivery","onway_delivery","completed_delivery",
            "view_details","GenerateWordDocument","delivery_list"
        };

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var users = context.HttpContext.Session.GetString("User");
            var emps = context.HttpContext.Session.GetString("Emp");
            var controller = (string)context.RouteData.Values["controller"];
            var action = (string)context.RouteData.Values["action"];

            if (!string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(controller))
            {
                if (users == null && emps == null)
                {
                    if (!(auth.Contains(action) && controller == "Home"))
                    {
                        context.Result = new RedirectToActionResult("Index", "Home", null);
                    }
                }
                else if (users != null && emps == null)
                {
                    var user_data = JsonConvert.DeserializeObject<PersonalInformation>(users);
                    if (user_data.PRoleId == 1)
                    {
                        if (!(admin.Contains(action) && (controller == "Admin" || controller == "A_Functionality")))
                        {
                            context.Result = new RedirectToActionResult("Index", "Admin", null);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (!(user.Contains(action) && (controller == "User" || controller == "U_functionality")))
                        {
                            context.Result = new RedirectToActionResult("Index", "User", null);
                        }
                        else
                        {

                        }
                    }

                }
                else
                {
                   if (!(emp.Contains(action) && controller == "Employee" ))
                   {
                            context.Result = new RedirectToActionResult("Index", "Employee", null);
                   }
                   else
                   {

                   }
                }
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
        
    }
}