using System.ComponentModel.DataAnnotations;

namespace _3045_002_FinalApiProject
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string ESRBRating { get; set; }

        [Required]
        public required string Platform { get; set; }

        [Required]
        public required string Publisher { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
