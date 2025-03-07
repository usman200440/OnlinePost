using Microsoft.AspNetCore.Mvc;
using ONLINE_POST.Models;

namespace ONLINE_POST.Controllers
{
    public class ContactController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();
        public IActionResult contact_form(string name , string email , string msg)
        {
            contact con = new contact
            {
                Name = name,
                Email = email,
                Message = msg
            };
            db.Contacts.Add(con);
            db.SaveChanges();
            SetCookie("success-msg", "Msg Sent Successfully");
            return RedirectToAction("Index","Home");
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
