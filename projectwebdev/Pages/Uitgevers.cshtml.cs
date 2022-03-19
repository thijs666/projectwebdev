using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectwebdev.Pages
{
    [Authorize]
    public class UitgeversModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
