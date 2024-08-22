using BulkyBook1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BulkyBook1.Data
{
    public class ApplicationDbContext : DbContext
    {
        //pass that configuration to DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        //tell to Entity framework that on cateogry we want to create these 3 records...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder=1},
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
               );
        }
    }
}
