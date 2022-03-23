using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectwebdev.Models;

namespace projectwebdev.Pages
{
    [Authorize]
    public class TitelsModel : PageModel
    {
        private readonly IStripboekRepository stripboekRepository;
        public IEnumerable<Stripboek> Stripboeken { get; set; }

        public TitelsModel(IStripboekRepository stripboekRepository)
        {
            this.stripboekRepository = stripboekRepository;
        }

        public void OnGet()
        {
            Stripboeken = stripboekRepository.GetAllStripboeken();
        }
    }
}
