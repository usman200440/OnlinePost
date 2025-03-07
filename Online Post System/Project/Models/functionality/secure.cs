using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ONLINE_POST.Models.functionality
{
    public class Secure : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user_data = context.HttpContext.Session.GetString("User");
            var emp_data = context.HttpContext.Session.GetString("Emp");
            if (user_data != null && emp_data==null)
            {
                var user_check=JsonConvert.DeserializeObject<PersonalInformation>(user_data);
                if (user_check.PRoleId == 1)
                {
                    context.Result = new RedirectToActionResult("Index", "Admin", null);
                }
                else
                {
                    context.Result = new RedirectToActionResult("Index", "User", null);
                }
            }
            else if (user_data == null && emp_data != null)
            {
                context.Result = new RedirectToActionResult("Index", "Employee", null);
            }
        }
    }
}
