using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Models;
namespace ProjectJunior.Data
{
    public class ProjectContext : DbContext
    {

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdDrug>().HasKey(p => new { p.DiscountId, p.OrdId, p.DrugId });
            modelBuilder.Entity<RecipeDrug>().HasKey(p => new { p.RecipeId, p.DrugId });
            modelBuilder.Entity<Availability>().HasKey(p => new { p.DeliveryId, p.PharmacyId, p.DrugId });
        }

        public DbSet<Web> Webs { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ord> Ords { get; set; }
        public DbSet<OrdDrug> OrdsDrugs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDrug> RecipesDrugs { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
