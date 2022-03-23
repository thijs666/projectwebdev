using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;

namespace projectwebdev.Pages.Titels
{
    public class DetailModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;
        public DetailModel(IStripboekRepository stripboekRepository)
        {
            this.stripboekRepository = stripboekRepository;
        }

        public Stripboek Stripboek { get; private set; }

        public void OnGet(int isbn)
        {
            Stripboek = stripboekRepository.GetStripboek(isbn);
        }
    }
}
