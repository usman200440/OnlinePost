using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ONLINE_POST.Models.filters
{
    public class UserAuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var data = context.HttpContext.Session.GetString("User");

            if (data == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
