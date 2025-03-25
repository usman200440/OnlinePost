using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ONLINE_POST.Models;
using ONLINE_POST.Models.filters;
using ONLINE_POST.Models.functionality;
using System.Diagnostics;

namespace ONLINE_POST.Controllers
{
    [TypeFilter(typeof(Secure))]
    public class HomeController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();

        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
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
            var package = db.Packages.ToList();
            TempData["package"] = package;
            return View();
        }


   
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
