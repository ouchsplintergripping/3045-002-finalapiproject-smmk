using System;
using System.ComponentModel.DataAnnotations;

namespace _3045_002_finalapiproject_smmk.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }

        [Required]
        public string PetName { get; set; }

        [Required]
        public string Type { get; set; }

        public int Age { get; set; }

        public bool Adopted { get; set; }
    }
}
