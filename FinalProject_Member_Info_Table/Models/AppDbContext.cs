using Microsoft.EntityFrameworkCore;

namespace FinalProject_Member_Info_Table.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Kelsey Freeman", BirthDate = new DateTime(2005, 8, 31), CollegeProgram = "Games and Animation", YearInProgram = "Sophomore", Age = (20) },
                new TeamMember { Id = 2, FullName = "Max Hicks", BirthDate = new DateTime(), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Age = (20) },
                new TeamMember { Id = 3, FullName = "Michael Burnett", BirthDate = new DateTime(), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Age = (20) },
                new TeamMember { Id = 4, FullName = "Samuel Brzezicki", BirthDate = new DateTime(), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Age = (20) }
            );
        }
    }
}
