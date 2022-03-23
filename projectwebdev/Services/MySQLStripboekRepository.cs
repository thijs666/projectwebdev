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

        public Stripboek Add(Stripboek newStripboek)
        {
            context.Stripboeken.Add(newStripboek);
            context.SaveChanges();
            return newStripboek;
        }

        public IEnumerable<Stripboek> GetAllStripboeken()
        {
            return context.Stripboeken;
        }

        public Stripboek GetStripboek(int id)
        {
            return context.Stripboeken.Find(id);
        }

        public Stripboek Update(Stripboek updatedStripboek)
        {
            var stripboek = context.Stripboeken.Attach(updatedStripboek);
            stripboek.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedStripboek;
        }
    }
}
