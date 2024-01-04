using BaseProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Service;
using My_Smart_Factory.Data.Service.Insp;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Service.Interface.Prod;
using My_Smart_Factory.Data.Service.Prod;
using My_Smart_Factory.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// DB ����
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<My_Smart_Factory.Data.MyDbContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection))
    );

// ���� ����
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

builder.Services.AddScoped<IOutgoingInspService, OutgoingInspService>();
builder.Services.AddScoped<IProcessStatusService, ProcessStatusService>();
builder.Services.AddScoped<IProdInfoService, ProdInfoService>();
builder.Services.AddScoped<IInspEquipService, InspEquipService>();
builder.Services.AddScoped<IInspEquipSettingRecordService, InspEquipSettingRecordService>();
builder.Services.AddScoped<IInspProdRecordService, InspProdRecordService>();
builder.Services.AddScoped<IInspSpecService, InspSpecService>();
builder.Services.AddScoped<ICaseLotService, CaseLotService>();
builder.Services.AddScoped<IFullInspRecordService, FullInspRecordService>();
builder.Services.AddScoped<IProdCtrlNoService, ProdCtrlNoService>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();
builder.Services.AddScoped<QrCodeService>();



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

app.UseAuthentication(); // User, ClaimsPrincipal ������ ���� Ȱ��ȭ

app.UseAuthorization();

AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
AppDbInitializer.SeedDataAsync(app).Wait();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 app.Run();
