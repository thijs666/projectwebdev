using projectwebdev.Data;
using projectwebdev.Models;
using System.Linq;

namespace projectwebdev.Services
{
    public class MySQLCollectieRepository : ICollectieRepository
    {
        private readonly ApplicationDbContext context;

        public MySQLCollectieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Collectie Add(Collectie newCollectie)
        {
            context.Collecties.Add(newCollectie);
            context.SaveChanges();
            return newCollectie;
        }

        public Collectie Delete(int collectieid)
        {
            Collectie collectie = context.Collecties.Find(collectieid);
            if (collectie != null)
            {
                context.Collecties.Remove(collectie);
                context.SaveChanges();
            }
            return collectie;
        }

        public IEnumerable<Collectie> GetAllCollecties()
        {
            return context.Collecties;
        }

        public Collectie GetCollectie(int collectieid)
        {
            return context.Collecties.Find(collectieid);
        }

        public IEnumerable<Collectie> Search(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return context.Collecties;
            }

            return context.Collecties.Where(e => e.CollectieNaam.Contains(searchQuery));
        }

        public Collectie Update(Collectie updatedCollectie)
        {
            var collectie = context.Collecties.Attach(updatedCollectie);
            collectie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedCollectie;
        }
    }
}

