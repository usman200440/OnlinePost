using Microsoft.AspNetCore.Mvc;
using ONLINE_POST.Models.filters;
using Stripe;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ONLINE_POST.Models;

var builder = WebApplication.CreateBuilder(args);
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["SecretKey"];

// Add services to the container
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ResponseCacheAttribute
    {
        Location = ResponseCacheLocation.None,
        NoStore = true
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddControllersWithViews(x => x.Filters.Add(typeof(filter), order: 1));
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

// Add your DbContext with direct connection string
builder.Services.AddDbContext<post_management_systemContext>(options =>
    options.UseSqlServer("workstation id=online_post.mssql.somee.com;packet size=4096;user id=usman2004_SQLLogin_1;pwd=q4thld64uq;data source=online_post.mssql.somee.com;persist security info=False;initial catalog=online_post;TrustServerCertificate=True")
);

var app = builder.Build();

// Run database migrations automatically on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<post_management_systemContext>();
    dbContext.Database.Migrate(); // This will apply any pending migrations
}



// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
