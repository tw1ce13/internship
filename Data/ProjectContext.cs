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
            modelBuilder.Entity<OrdDrug>().HasIndex(p => new { p.DiscountId, p.OrdId, p.DrugId }).IsUnique(true);
            modelBuilder.Entity<RecipeDrug>().HasIndex(p => new { p.RecipeId, p.DrugId }).IsUnique(true);
            modelBuilder.Entity<Availability>().HasIndex(p => new { p.DeliveryId, p.PharmacyId, p.DrugId }).IsUnique(true);
        }

        public DbSet<Web> Webs { get; set; } = null!;
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

