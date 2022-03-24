using System.ComponentModel.DataAnnotations;

namespace projectwebdev.Models
{
    public class Stripboek
    {
        public int Id { get; set; }
        [Required]
        public string Titel { get; set; }
        public int? Aantal_Blz { get; set; }
        public string? Schrijver { get; set; }
        public string? Tekenaar { get; set; }

        // todo make ISBN int - temp fix for searchquery
        [Required]
        public string Isbn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Verschijningsdatum { get; set; }
        public string? Uitgever { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
