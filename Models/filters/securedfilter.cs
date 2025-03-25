using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ONLINE_POST.Models.filters
{
    public class securedfilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessionUser = context.HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(sessionUser))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            else
            {
                base.OnActionExecuted(context);
            }
        }
    }
}
