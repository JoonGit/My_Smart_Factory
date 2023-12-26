using Microsoft.AspNetCore.Authentication;
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

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
