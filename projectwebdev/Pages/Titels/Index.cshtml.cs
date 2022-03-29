using System.Data;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using projectwebdev.Models;
using projectwebdev.Services;

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
        
        public void AddStripboek()
        {
            
        }

        public void OnGet()
        {
            Stripboeken = stripboekRepository.GetAllStripboeken();
        }
    }
}
