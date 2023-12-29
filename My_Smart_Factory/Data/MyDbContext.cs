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
        public DbSet<UserIdentity> UserIdentities { get; set; }
        public DbSet<OqcModel> OqcModels { get; set; }
        public DbSet<PiModel> PiModels { get; set; }
        public DbSet<PpsModel> PpsModels { get; set; }

    }
}
