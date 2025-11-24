using System.ComponentModel.DataAnnotations;

namespace _3045_002_FinalApiProject
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }

        [Required]
        public required string PetName { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool Adopted { get; set; } = false;
    }
}
