using projectwebdev.Models;

namespace projectwebdev.Services
{
    public interface IStripboekRepository
    {
        IEnumerable<Stripboek> Search(string searchQuery);
        IEnumerable<Stripboek> GetAllStripboeken();
        Stripboek GetStripboek(int id);
        Stripboek Update(Stripboek updatedStripboek);
        Stripboek Add(Stripboek newStripboek);
        Stripboek Delete(int? id);
    }
}
