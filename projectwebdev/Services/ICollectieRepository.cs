using projectwebdev.Models;

namespace projectwebdev.Services
{
    public interface ICollectieRepository
    {
        IEnumerable<Collectie> Search(string searchQuery);
        IEnumerable<Collectie> GetAllCollecties();
        Collectie GetCollectie(int collectieid);
        Collectie Update(Collectie updatedCollectie);
        Collectie Add(Collectie newCollectie);
        Collectie Delete(int collectieid);
    }
}