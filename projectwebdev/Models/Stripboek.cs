using System.ComponentModel.DataAnnotations;

namespace projectwebdev.Models
{
    public class Stripboek
    {
        public int? Id { get; set; }
        [Required]
        public string Titel { get; set; }
        public int? Aantal_Blz { get; set; }
        [Required]
        public int Isbn { get; set; }
        public int? Jaar_Van_Uitgave { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
