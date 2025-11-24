using Microsoft.EntityFrameworkCore;

namespace _3045_002_FinalApiProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Breakfast> Breakfast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Pets
            modelBuilder.Entity<Pet>().HasData(
                new Pet { PetID = 1, PetName = "Buddy", Type = "Dog", Age = 3, Adopted = true },
                new Pet { PetID = 2, PetName = "Whiskers", Type = "Cat", Age = 2, Adopted = false },
                new Pet { PetID = 3, PetName = "Goldie", Type = "Fish", Age = 1, Adopted = true },
                new Pet { PetID = 4, PetName = "Nemo", Type = "Cat", Age = 4, Adopted = true }
            );

            // Seed data for TeamMembers
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Kelsey Freeman", BirthDate = new DateTime(2005, 8, 31), CollegeProgram = "Games and Animation", YearInProgram = "Sophomore", Age = 20 },
                new TeamMember { Id = 2, FullName = "Max Hicks", BirthDate = new DateTime(2005, 1, 1), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Age = 20 },
                new TeamMember { Id = 3, FullName = "Michael Burnett", BirthDate = new DateTime(2005, 1, 1), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Age = 20 },
                new TeamMember { Id = 4, FullName = "Samuel Brzezicki", BirthDate = new DateTime(1999, 6, 30), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Age = 26 }
            );

            // Seed data for VideoGames
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Minecraft Java Edition", ESRBRating = "E10+", Platform = "PC", Publisher = "Mojang", Cost = 26.95m },
                new VideoGame { Id = 3, Title = "Call of Duty: Black Ops 2", ESRBRating = "M", Platform = "Multi-Platform", Publisher = "Activision", Cost = 59.99m },
                new VideoGame { Id = 5, Title = "Super Mario Galaxy", ESRBRating = "E", Platform = "Nintendo Wii", Publisher = "Nintendo", Cost = 49.99m },
                new VideoGame { Id = 6, Title = "Helldivers 2", ESRBRating = "M", Platform = "PC/PS5", Publisher = "Sony Interactive Entertainment", Cost = 39.99m },
                new VideoGame { Id = 7, Title = "The Elder Scrolls V: Skyrim", ESRBRating = "M", Platform = "Multi-Platform", Publisher = "Bethesda", Cost = 39.99m }
            );

            // Seed data for Breakfast
            modelBuilder.Entity<Breakfast>().HasData(
                new Breakfast { ID = 1, Name = "Pancakes", Calories = 350, IsVegetarian = true, IsWarm = true},
                new Breakfast { ID = 2, Name = "Omelette", Calories = 250, IsVegetarian = false, IsWarm = true },
                new Breakfast { ID = 3, Name = "Fruit Salad", Calories = 150, IsVegetarian = true, IsWarm = false },
                new Breakfast { ID = 4, Name = "Bacon and Eggs", Calories = 400, IsVegetarian = false, IsWarm = false }
            );
        }
    }
}
