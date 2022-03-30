using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages.Collecties
{
    [Authorize]

    public class EditModel : PageModel
    {
        private readonly ICollectieRepository collectieRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(ICollectieRepository collectieRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.collectieRepository = collectieRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Collectie Collectie { get; set; }

        public IActionResult OnGet(int? collectieid)
        {
            if (collectieid.HasValue)
            {
                Collectie = collectieRepository.GetCollectie(collectieid.Value);
            }
            else
            {
                Collectie = new Collectie();
            }

            if (Collectie == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Collectie.CollectieID > 0)
                {
                    Collectie = collectieRepository.Update(Collectie);
                }
                else
                {
                    Collectie = collectieRepository.Add(Collectie);
                }

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}

