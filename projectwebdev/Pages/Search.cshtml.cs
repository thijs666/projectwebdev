using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;
using projectwebdev.Services;

namespace projectwebdev.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;
        public IEnumerable<Stripboek> Stripboeken { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        public SearchModel(IStripboekRepository stripboekRepository)
        {
            this.stripboekRepository = stripboekRepository;
        }

        public void OnGet()
        {
            Stripboeken = stripboekRepository.Search(SearchQuery);
        }
    }
}
