using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Member_Info_Table.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string YearInProgram { get; set; }

        [Required]
        public string CollegeProgram { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
