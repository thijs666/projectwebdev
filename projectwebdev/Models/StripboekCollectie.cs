using Microsoft.Build.Framework;

namespace projectwebdev.Models;

public class StripboekCollectie
{
    public int StripboekID { get; set; }
    [Required]
    public string Titel { get; set; }
    public int? Aantal_Blz { get; set; }
    public string? Schrijver { get; set; }
    public string? Tekenaar { get; set; }
    
    [Required]
    public string ISBN { get; set; }
}