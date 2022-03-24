using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages.Titels
{
    public class EditModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IStripboekRepository stripboekRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.stripboekRepository = stripboekRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Stripboek Stripboek { get; set; }

        [BindProperty]
        public IFormFile? Cover { get; set; }
        
        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Stripboek = stripboekRepository.GetStripboek(id.Value);
            }
            else
            {
                Stripboek = new Stripboek();
            }

            if (Stripboek == null)
            {
                return RedirectToPage("/NietGevonden");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) {
                if (Cover != null)
                {
                    if (Stripboek.CoverImageUrl != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Stripboek.CoverImageUrl);
                        System.IO.File.Delete(filePath);
                    }
                    Stripboek.CoverImageUrl = ProcessUploadedFile();
                }

                if (Stripboek.Id > 0)
                {
                    Stripboek = stripboekRepository.Update(Stripboek);
                }
                else
                {
                    Stripboek = stripboekRepository.Add(Stripboek);
                }

                return RedirectToPage("Index");
            }

            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Cover != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Cover.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Cover.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
