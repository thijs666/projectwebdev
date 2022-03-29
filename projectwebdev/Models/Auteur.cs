using System.ComponentModel.DataAnnotations;

namespace projectwebdev.Models;

public class Auteur
{
    public int AuteurID { get; set; }
    [Required]
    public string AuteursNaam { get; set; }
    public int Geboortejaar { get; set; }
}