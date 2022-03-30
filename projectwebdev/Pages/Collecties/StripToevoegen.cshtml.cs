using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace projectwebdev.Pages.Collecties
{
    [Authorize]

    public class StripToevoegen : PageModel
    {
        public IEnumerable<StripboekCollectie> StripboekCollecties
        {
           get
            {
                return new StripboekCollectieRepository().Get();
            }
        }

        public void OnGet()
        {
        }

        public void OnPostDelete(int stripboekId)
        {
            new StripboekCollectieRepository().Delete(stripboekId);
        }
        
        [BindProperty]
        public StripboekCollectie NewStripboekCollectie { get; set; }

        public IActionResult OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                new StripboekCollectieRepository().Add(NewStripboekCollectie);
            }

            return Page();
        }
        
    }
}

