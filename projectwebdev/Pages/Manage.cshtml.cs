using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectwebdev.Pages
{
    [Authorize(Roles = "Administrator")]
    public class ManageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
