using projectwebdev.Data;
using projectwebdev.Models;
using System.Linq;

namespace projectwebdev.Services
{
    public class MySQLStripboekRepository : IStripboekRepository
    {
        private readonly ApplicationDbContext context;
        public MySQLStripboekRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Stripboek> GetAllStripboeken()
        {
            return context.Stripboeken;
        }

        public Stripboek GetStripboek(int isbn)
        {
            return context.Stripboeken.Find(isbn);
        }
    }
}
