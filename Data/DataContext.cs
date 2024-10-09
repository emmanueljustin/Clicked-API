//using Microsoft.AspNet.Identity.EntityFramework;
using ClickedApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClickedApi.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Services>().HasKey(x => x.Id);
            modelBuilder.Entity<Services>().HasOne(e => e.Pricing).WithMany(e => e.Services).HasForeignKey(e => e.PricingId);

            modelBuilder.Entity<Pricing>().HasKey(x => x.Id);
            modelBuilder.Entity<Pricing>().HasMany(e => e.Services).WithOne(e => e.Pricing).HasForeignKey(e => e.PricingId);
        }
    }
}
