using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data
{
    public class MyDbContext : IdentityDbContext<IdentityUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> option) : base(option)
        {
        }
        public DbSet<UserIdentity> UserIdentitys { get; set; }
        public DbSet<OutgoingInspModel> OqcModels { get; set; }
        public DbSet<ProdInfoModel> PiModels { get; set; }
        public DbSet<ProcessStatusModel> PpsModels { get; set; }

    }
}
