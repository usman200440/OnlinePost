using Microsoft.AspNetCore.Mvc.Filters;
using ONLINE_POST.Models;

public class packageexpired : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        post_management_systemContext db = new post_management_systemContext(); // Replace YourDbContext with your actual database context class
        var currentDate = DateTime.Now;

        var expiredPackages = db.Customer_Packages
            .Where(p => p.expired < currentDate)
            .ToList();

        foreach (var expiredPackage in expiredPackages)
        {
            db.Customer_Packages.Remove(expiredPackage);
        }

        db.SaveChanges();

        base.OnActionExecuting(filterContext);
    }
}



