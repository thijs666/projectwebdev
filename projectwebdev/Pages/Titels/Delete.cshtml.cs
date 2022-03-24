using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages.Titels
{
    [Authorize(Roles = "Administrator")]
    public class DeleteModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;
        public DeleteModel(IStripboekRepository stripboekRepository)
        {
            this.stripboekRepository = stripboekRepository;
        }

        [BindProperty]
        public Stripboek Stripboek { get; set; }
        public IActionResult OnGet(int id)
        {
            Stripboek = stripboekRepository.GetStripboek(id);

            if(Stripboek == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Stripboek deletedStripboek = stripboekRepository.Delete(Stripboek.Id);

            if (deletedStripboek == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return RedirectToPage("Index");
        }
    }
}
