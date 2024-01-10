using Microsoft.AspNetCore.Identity;
using System;
using My_Smart_Factory.Data.Enums;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Service.Insp;
using Microsoft.AspNetCore.Authentication;
using My_Smart_Factory.Data;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Migrations;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Vo;

namespace BaseProject.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserRoles[] roles = (UserRoles[])Enum.GetValues(typeof(UserRoles));
                foreach (var role in roles)
                {
                    bool roleExists = await roleManager.RoleExistsAsync(role.ToString());
                    if (!roleExists)
                    {

                        var newRole = new IdentityRole(role.ToString());
                        await roleManager.CreateAsync(newRole);
                    }
                }


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<UserIdentity>>();
                string adminId = "admin";

                var adminUser = await userManager.FindByIdAsync(adminId);
                if (adminUser == null)
                {
                    var newAdminUser = new UserIdentity()
                    {
                        UserName = "admin-user",
                        Id = adminId,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Dkagh1234!?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin.ToString());
                }


                string memberId = "user";

                var appUser = await userManager.FindByIdAsync(memberId);
                if (appUser == null)
                {
                    var newMemberUser = new UserIdentity()
                    {
                        UserName = "member",
                        Id = memberId,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newMemberUser, "Dkagh1234!");
                    await userManager.AddToRoleAsync(newMemberUser, UserRoles.Member.ToString());
                }
            }
        }

        public static async Task SeedDataAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<UserIdentity>>();

                if (!context.InspEquipModels.Any())
                {
                    await context.InspEquipModels.AddRangeAsync(new List<InspEquipModel>()
                    {
                        new InspEquipModel
                        {
                            InspEquipName = "무게 측정 장비",
                            Unit = "Unit"
                        }
                    });
                    await context.SaveChangesAsync();
                }
                if (!context.ProdInfoModels.Any())
                {
                    await context.ProdInfoModels.AddRangeAsync(new List<ProdInfoModel>()
                    {
                        new ProdInfoModel
                        {
                            ProdName = "장난감 자동차",
                            ProdCode = "ToyCar",
                            ProdWeight = 10
                        }
                    });
                    await context.SaveChangesAsync();
                }
                if (!context.InspSpecModels.Any())
                {
                    await context.InspSpecModels.AddRangeAsync(new List<InspSpecModel>()
                    {
                        new InspSpecModel
                        {
                            InspSpecName = "장난감 자동차 무제 측정",
                            ProdInfo = await context.ProdInfoModels.Where(x => x.ProdName == "장난감 자동차").FirstOrDefaultAsync(),
                            InspEquip = await context.InspEquipModels.Where(x => x.InspEquipName == "무게 측정 장비").FirstOrDefaultAsync(),
                            ETR = 5
                        }
                    });
                    await context.SaveChangesAsync();
                }
                if (!context.ProdCtrlNoModels.Any())
                {
                    await context.ProdCtrlNoModels.AddRangeAsync(new List<ProdCtrlNoModel>()
                    {
                        new ProdCtrlNoModel
                        {
                            ProdCtrlNo = "장난감 자동차 1",
                            ProdInfo = await context.ProdInfoModels.Where(x => x.ProdName == "장난감 자동차").FirstOrDefaultAsync()
                        },
                        new ProdCtrlNoModel
                        {
                            ProdCtrlNo = "장난감 자동차 2",
                            ProdInfo = await context.ProdInfoModels.Where(x => x.ProdName == "장난감 자동차").FirstOrDefaultAsync()
                        }
                    });
                    await context.SaveChangesAsync();
                }
               
                if (!context.WorkOrderModels.Any())
                {
                    await context.WorkOrderModels.AddRangeAsync(new List<WorkOrderModel>()
                    {
                        new WorkOrderModel
                        {
                            WorkOrderNo = "장난감 생성 작업 지시 1",
                            WorkOrderDate = DateTime.Now,
                            WorkQuantity = 100,
                            Status = WorkOrderStatus.Waiting,
                            CurrentWorkQuantity = 0,
                            FullInspection = null,
                            WorkOrderIssuer = await userManager.FindByNameAsync("member"),
                            ProdInfo = await context.ProdInfoModels.Where(x => x.ProdName == "장난감 자동차").FirstOrDefaultAsync(),
                            QRURL = "/qrimg/장난감 생성 작업 지시 1.png"
                        },
                        new WorkOrderModel
                        {
                            WorkOrderNo = "장난감 생성 작업 지시 2",
                            WorkOrderDate = DateTime.Now,
                            WorkQuantity = 100,
                            Status = WorkOrderStatus.Waiting,
                            CurrentWorkQuantity = 0,
                            FullInspection = null,
                            WorkOrderIssuer = await userManager.FindByNameAsync("member"),
                            ProdInfo = await context.ProdInfoModels.Where(x => x.ProdName == "장난감 자동차").FirstOrDefaultAsync(),
                            QRURL = "/qrimg/장난감 생성 작업 지시 2.png"
                        }
                    });
                    await context.SaveChangesAsync();
                }
                if (!context.FullInspRecordModels.Any())
                {
                    await context.FullInspRecordModels.AddRangeAsync(new List<FullInspRecordModel>()
                    {

                        new FullInspRecordModel
                        {
                            FullInspNo = "장난감 자동차 전수 검사 번호",
                            WorkOrder = await context.WorkOrderModels.Where(w => w.WorkOrderNo == "장난감 생성 작업 지시 1").FirstOrDefaultAsync(),
                            InspEquipSettingRecords = await context.InspEquipSettingRecordModels.Where(x => x.FullInspRecord.FullInspNo == "장난감 자동차 전수 검사 번호").ToListAsync(),
                            InspProdRecords = await context.InspProdRecordModels.Where(x => x.FullInspRecord.FullInspNo == "장난감 자동차 전수 검사 번호").ToListAsync()
                        }
                    });
                    await context.SaveChangesAsync();
                }
                var workOrder = context.WorkOrderModels.Where(w => w.WorkOrderNo == "장난감 생성 작업 지시 1").FirstOrDefault();
                if (workOrder.FullInspection == null)
                {
                    var fullInspRecord = context.FullInspRecordModels.Where(f => f.FullInspNo == "장난감 자동차 전수 검사 번호").FirstOrDefault();
                    workOrder.FullInspection = fullInspRecord;

                }
                if (!context.InspEquipSettingRecordModels.Any())
                {
                    await context.InspEquipSettingRecordModels.AddRangeAsync(new List<InspEquipSettingRecordModel>()
                    {
                        new InspEquipSettingRecordModel
                        {
                            InspectionDateTime = DateTime.Now,
                            IES = 5,
                            Accuracy = ((decimal)5 / (decimal)10) * 100,
                            InspEquip = await context.InspEquipModels.Where(x => x.InspEquipName == "무게 측정 장비").FirstOrDefaultAsync(),
                            InspSpec = await context.InspSpecModels.Where(x => x.InspSpecName == "장난감 자동차 무제 측정").FirstOrDefaultAsync(),
                            FullInspRecord = await context.FullInspRecordModels.Where(x => x.FullInspNo == "장난감 자동차 전수 검사 번호").FirstOrDefaultAsync()
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.InspProdRecordModels.Any())
                {
                    await context.InspProdRecordModels.AddRangeAsync(new List<InspProdRecordModel>()
                    {
                        new InspProdRecordModel
                        {
                            InspectionDateTime = DateTime.Now,
                            MeasuredValue = 5,
                            Accuracy = 50,
                            IsPassed = false,
                            InspSpec = await context.InspSpecModels.Where(x => x.InspSpecName == "장난감 자동차 무제 측정").FirstOrDefaultAsync(),
                            ProdCtrlNo = await context.ProdCtrlNoModels.Where(x => x.ProdCtrlNo == "장난감 자동차 1").FirstOrDefaultAsync(),
                            FullInspRecord = await context.FullInspRecordModels.Where(x => x.FullInspNo == "장난감 자동차 전수 검사 번호").FirstOrDefaultAsync()
                        },
                        new InspProdRecordModel
                        {
                            InspectionDateTime = DateTime.Now,
                            MeasuredValue = 5,
                            Accuracy = 50,
                            IsPassed = false,
                            InspSpec = await context.InspSpecModels.Where(x => x.InspSpecName == "장난감 자동차 무제 측정").FirstOrDefaultAsync(),
                            ProdCtrlNo = await context.ProdCtrlNoModels.Where(x => x.ProdCtrlNo == "장난감 자동차 2").FirstOrDefaultAsync(),
                            FullInspRecord = await context.FullInspRecordModels.Where(x => x.FullInspNo == "장난감 자동차 전수 검사 번호").FirstOrDefaultAsync()
                        }
                    });
                    context.SaveChanges();
                }








            }
        }
    }
}
