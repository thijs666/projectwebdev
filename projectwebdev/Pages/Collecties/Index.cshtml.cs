using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages
{
    [Authorize]
    public class CollectiesModel : PageModel
    {
        private readonly ICollectieRepository collectieRepository;
        
        public IEnumerable<Collectie> Collecties { get; set; }

        public CollectiesModel(ICollectieRepository collectieRepository)
        {
            this.collectieRepository = collectieRepository;
        }

        public void OnGet()
        {
            Collecties = collectieRepository.GetAllCollecties();
        }
    }
}

