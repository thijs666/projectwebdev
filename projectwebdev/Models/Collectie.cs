using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectwebdev.Models
{
    public class Collectie
    {
        public string CollectieNaam { get; set; }
        public int CollectieID { get; set; }
        
        public List<Stripboek> Stripboeken { get; set; }
        
    }

}
