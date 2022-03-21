using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectwebdev.Pages
{
    [Authorize]
    public class MijnCollectiesModel : PageModel
    {
        public List<string> Collections = new List<string>();

        public void OnGet()
        {
        }
        
        //TODO add a way to fill up collections with the form
    }
}