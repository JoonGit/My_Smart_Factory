using Microsoft.AspNetCore.Identity;
using System;
using My_Smart_Factory.Data.Enums;
using My_Smart_Factory.Models;

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
    }
}
