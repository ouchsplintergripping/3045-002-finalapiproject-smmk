using System;
using System.ComponentModel.DataAnnotations;

namespace _3045_002_FinalApiProject
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public required string YearInProgram { get; set; } = "Freshman";

        [Required]
        public required string CollegeProgram { get; set; } = "Undeclared";

        [Required]
        public int Age { get; set; }
    }
}
