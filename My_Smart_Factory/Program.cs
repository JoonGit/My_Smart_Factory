using BaseProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// DB 연결
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<My_Smart_Factory.Data.MyDbContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection))
    );

// 유저 권한
builder.Services.AddIdentity<UserIdentity, IdentityRole>(
    options => options.SignIn.RequireConfirmedAccount = false
    )
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(options =>
    {
        //options.ExpireTimeSpan = timespan.fromminutes(60);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/user/accessdenied";
        options.LoginPath = "/user/login";
    });

//builder.Services.AddSession();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseSession();

app.UseAuthentication(); // User, ClaimsPrincipal 생성을 위해 활성화

app.UseAuthorization();

AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 app.Run();
