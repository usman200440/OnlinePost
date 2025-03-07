using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ONLINE_POST.Models.functionality
{
    public class user_secured
    {
        public IActionResult CheckUserRolesAndRedirect(IHttpContextAccessor httpContextAccessor, string Page)
        {
            IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
            var user_data = _httpContextAccessor.HttpContext.Session.GetString("User");


            if (user_data == null)
            {
                return new RedirectToActionResult("Index", "Home", null);
            }
           

            return new ViewResult { ViewName = Page };
        }
    }
}
