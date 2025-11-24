using System.ComponentModel.DataAnnotations;

namespace _3045_002_FinalApiProject
{
    public class Breakfast
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int Calories { get; set; }

        [Required]
        public required bool IsVegetarian { get; set; }

        [Required]
        public required bool IsWarm { get; set; }
    }
}

