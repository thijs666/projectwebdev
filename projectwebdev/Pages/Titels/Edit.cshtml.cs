using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;

namespace projectwebdev.Pages.Titels
{
    public class EditModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;

        public EditModel(IStripboekRepository stripboekRepository)
        {
            this.stripboekRepository = stripboekRepository;
        }

        public Stripboek Stripboek { get; set; }
        
        public IActionResult OnGet(int isbn)
        {
            Stripboek = stripboekRepository.GetStripboek(isbn);

            if (Stripboek == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return Page();
        }
    }
}
