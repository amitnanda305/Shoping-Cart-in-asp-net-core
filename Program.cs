using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mycloth_website.Areas.Identity.Data;
using Mycloth_website.Data;
using Mycloth_website.Interfaces;
using Mycloth_website.Services;
using System.Configuration;
using WebApplication1.NewFolder;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");

builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthDbContext>();

// Register your service implementation
builder.Services.AddScoped<ItemService1>();
builder.Services.AddScoped<IItemService1, ItemService1>();


builder.Services.AddDbContext<ApplicationDbContex>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbContextConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "AddMen",
        pattern: "Home/AddMen",
        defaults: new { controller = "Home", action = "AddMen" });

    endpoints.MapControllerRoute(
            name: "AddWomen",
            pattern: "Home/AddWomen",
            defaults: new { controller = "Home", action = "AddWomen" });

    endpoints.MapControllerRoute(
        name: "AddKid",
        pattern: "Home/AddKid",
        defaults: new { controller = "Home", action = "AddKid" });


    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
