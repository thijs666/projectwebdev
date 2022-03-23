using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace projectwebdev.Models
{
    public class Stripboek
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        public string Titel { get; set; }
        [ValidateNever]
        public int Aantal_Blz { get; set; }
        [Required]
        public int Isbn { get; set; }
        [ValidateNever]
        public int Jaar_Van_Uitgave { get; set; }
        [ValidateNever]
        public string CoverImageUrl { get; set; }
    }
}
