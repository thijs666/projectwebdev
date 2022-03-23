using projectwebdev.Models;

namespace projectwebdev
{
    public interface IStripboekRepository
    {
        IEnumerable<Stripboek> GetAllStripboeken();

        Stripboek GetStripboek(int isbn);
    }
}
