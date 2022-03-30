using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace projectwebdev.Pages;
[Authorize]
public class Auteurs : PageModel
{
    public IEnumerable<Auteur> Auteurs2
    {
        get
        {
            return new AuteurRepository().Get();
        }
    }

    public void OnGet()
    {
    }

    public void OnPostDelete(int auteurId)
    {
        new AuteurRepository().Delete(auteurId);
    }
    
    [BindProperty]
    public Auteur NewAuteur { get; set; }

    public IActionResult OnPostCreate()
    {
        if (ModelState.IsValid)
        {
            new AuteurRepository().Add(NewAuteur);
        }

        return Page();
    }

   
}