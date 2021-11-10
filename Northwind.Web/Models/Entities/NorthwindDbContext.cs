using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
            this.Database.Connection.ConnectionString = "Server=.;Database=NorthwindDev2;User Id=sa;Password=123;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent Kullanım.. cascade silmeye izin vermesin diye yapıldı

            modelBuilder.Entity<Product>()
                .HasRequired<Category>(s => s.Category)
                .WithMany(g => g.Products)
                .HasForeignKey<int>(s => s.CategoryId)
                .WillCascadeOnDelete(false);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        // enable-migrations
        // add-migration MigrName
        // update-database 
    }
}