using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WasteIS.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WasteIS.DAL
{
    public class WasteISContext : IdentityDbContext<ApplicationUser>
    {
        public WasteISContext()
            : base("WasteISContext")
        {
        }

        public static WasteISContext Create()
        {
            return new WasteISContext();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Zuj> Zujs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Orp> Orps { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<Subject> Subject { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}