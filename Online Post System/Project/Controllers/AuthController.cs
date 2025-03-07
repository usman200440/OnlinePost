using Microsoft.AspNetCore.Mvc;
using ONLINE_POST.Models;
using ONLINE_POST.Models.functionality;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;
namespace ONLINE_POST.Controllers
{
    public class authController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();

        [HttpPost]
        public IActionResult register(authentication p)
        {
            var condititon = db.PersonalInformations.Where(x => x.PEmail == p.register.PEmail || x.PUserName == p.register.PUserName).FirstOrDefault();
            var e_condititon = db.EmployeeInformations.Where(x => x.EEmail == p.register.PEmail || x.EUserName == p.register.PUserName).FirstOrDefault();
            if (condititon != null || e_condititon != null)
            {
                SetCookie("error-msg", "User Already Registered");
            }
            else
            {
                var body = $"Please click <b>OK</b> and verify your email <br/><br/><a href='https://localhost:7082/Auth/VerifyEmail/?email={Uri.EscapeDataString(p.register.PEmail)}&username={Uri.EscapeDataString(p.register.PUserName)}&password={Uri.EscapeDataString(p.register.PPassword)}'>\r\n  <button type='submit' style='background-color: #0d6efd; color: white; font-weight: bold; padding: 10px 15px; border: none; border-radius: 5px; text-decoration: none; display: inline-block;'>\r\n    Verify Your Account\r\n  </button>\r\n</a>\r\n";

                var personal_data = JsonConvert.SerializeObject(p.register);
                HttpContext.Session.SetString("p_data", personal_data);
                verifyemail emailverify = new verifyemail(p.register.PEmail, body, "Online Post Email Verification");
                SetCookie("info-msg", "Email Request Send");
            }
            return RedirectToAction("index", "Home");
        }

        public IActionResult VerifyEmail([FromQuery] string email, [FromQuery] string username, [FromQuery] string password)
        {
            var condition = db.PersonalInformations.Where(x => x.PEmail == email || x.PUserName == username).FirstOrDefault();
            if (condition != null)
            {
                SetCookie("error-msg", "User Already Registered");
            }
            else
            {
                PersonalInformation p = new PersonalInformation();
                db.PersonalInformations.Add(p);
                p.PEmail = email;
                p.PUserName = username;
                p.PPassword = password;
                p.status = "on";
                p.PRoleId = 2;
                db.SaveChanges();
                ModelState.Clear();
                SetCookie("success-msg", "User Registered Successfully");
            }
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public IActionResult login(authentication l)
        {
            var p_data = db.PersonalInformations.Where(x =>x.PUserName == l.login.Username || x.PEmail == l.login.Username).FirstOrDefault();
            var e_data = db.EmployeeInformations.Where(x =>x.EUserName == l.login.Username || x.EEmail == l.login.Username).FirstOrDefault();
            if (p_data == null && e_data == null)
            {
                SetCookie("error-msg", "User Not Found");
                return RedirectToAction("index", "Home");
            }
            else if (p_data != null && e_data == null) {

                if (p_data.PPassword == l.login.Password)
                {
                    if (p_data.status=="on")
                    {
                        if (p_data.PRoleId == 1)
                        {
                            var admin = JsonConvert.SerializeObject(p_data);
                            HttpContext.Session.SetString("User", admin);
                            return RedirectToAction("index", "Admin");
                        }
                        else
                        {
                            var user = JsonConvert.SerializeObject(p_data);
                            HttpContext.Session.SetString("User", user);
                            return RedirectToAction("index", "User");
                        } 
                    }
                    else
                    {
                        SetCookie("error-msg", "Email blocked");
                        return RedirectToAction("index", "Home");
                    }
                }
                else
                {
                    SetCookie("error-msg", "Invalid Password");
                    return RedirectToAction("index", "Home");
                }

            }
            else {
            if (e_data.EPassword == l.login.Password)
                {
                    if (e_data.ERoleId == 3)
                    {
                        var emp = JsonConvert.SerializeObject(e_data);
                        HttpContext.Session.SetString("Emp", emp);
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        SetCookie("error-msg", "Invalid role");
                        return RedirectToAction("index", "Home");
                    }
                }
                else
                {
                    SetCookie("error-msg", "Invalid Password");
                    return RedirectToAction("index", "Home");
                }
            }
         

        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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