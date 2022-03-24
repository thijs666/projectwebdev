using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectwebdev.Pages
{
    [Authorize]
    public class CollectiesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
    
}
