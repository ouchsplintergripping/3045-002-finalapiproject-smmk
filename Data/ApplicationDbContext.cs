using Microsoft.EntityFrameworkCore;
using _3045_002_finalapiproject_smmk.Models;

namespace _3045_002_finalapiproject_smmk.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Pet>().HasData(
                new Pet { PetID = 1, PetName = "Buddy", Type = "Dog", Age = 3, Adopted = true },
                new Pet { PetID = 2, PetName = "Whiskers", Type = "Cat", Age = 2, Adopted = false },
                new Pet { PetID = 3, PetName = "Goldie", Type = "Fish", Age = 1, Adopted = true }
            );
        }
    }
}
