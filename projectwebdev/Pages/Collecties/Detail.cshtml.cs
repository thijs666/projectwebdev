using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages.Collecties
{
    public class DetailModel : PageModel
    {
        private readonly ICollectieRepository collectieRepository;

        public DetailModel(ICollectieRepository collectieRepository)
        {
            this.collectieRepository = collectieRepository;
        }
        
        public Collectie Collectie { get; private set; }

        public void OnGet(int collectieid)
        {
            Collectie = collectieRepository.GetCollectie(collectieid);
        }
        
    }
    
    public class TitelsModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;
        public IEnumerable<Stripboek> Stripboeken { get; set; }

        public TitelsModel(IStripboekRepository stripboekRepository)
        {
            this.stripboekRepository = stripboekRepository;
        }
        
        public void AddStripboek()
        {
            
        }

        public void OnGet()
        {
            Stripboeken = stripboekRepository.GetAllStripboeken();
        }
    }
}

