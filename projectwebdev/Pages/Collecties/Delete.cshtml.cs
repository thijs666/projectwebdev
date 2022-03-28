using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages.Collecties
{
    [Authorize]

    public class DeleteModel : PageModel
    {
        private readonly ICollectieRepository collectieRepository;

        public DeleteModel(ICollectieRepository collectieRepository)
        {
            this.collectieRepository = collectieRepository;
        }
        
        [BindProperty]
        public Collectie Collectie { get; set; }

        public IActionResult OnGet(int collectieid)
        {
            Collectie = collectieRepository.GetCollectie(collectieid);

            if (Collectie == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Collectie deletedCollectie = collectieRepository.Delete(Collectie.CollectieID);

            if (deletedCollectie == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return RedirectToPage("Index");
        }
    }
}

