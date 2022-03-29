using System.ComponentModel.DataAnnotations;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime? Verschijningsdatum { get; set; }
        public string? Uitgever { get; set; }
        public string? CoverImageUrl { get; set; }
        
    }
    
}
