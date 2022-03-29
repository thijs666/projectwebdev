using System.Data;
using projectwebdev.Data;
using projectwebdev.Models;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

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

        public Stripboek Delete(int id)
        {
            Stripboek stripboek = context.Stripboeken.Find(id);
            if(stripboek != null)
            {
                context.Stripboeken.Remove(stripboek);
                context.SaveChanges();
            }
            return stripboek;
        }

        public IEnumerable<Stripboek> GetAllStripboeken()
        {
            return context.Stripboeken;
        }

        public Stripboek GetStripboek(int id)
        {
            return context.Stripboeken.Find(id);
        }

        public IEnumerable<Stripboek> Search(string searchQuery)
        {
            if(string.IsNullOrEmpty(searchQuery))
            {
                return context.Stripboeken;
            }

            return context.Stripboeken.Where(e => e.Titel.Contains(searchQuery) || e.Isbn.Contains(searchQuery));
        }

        public Stripboek Update(Stripboek updatedStripboek)
        {
            var stripboek = context.Stripboeken.Attach(updatedStripboek);
            stripboek.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedStripboek;
        }
        
        public List<Stripboek> SorteerAuteur()
        {
            using IDbConnection connection =
                new SqlConnection("Server=localhost;User=root;Password=1234;Database=prototype;");

            var q = "SELECT Id FROM Stripboek ORDER BY Schrijver DESC";
            var stripboek = connection.Query<Stripboek>(q).ToList();
            return stripboek;
        }

        public void InsertInto(Conditie conditie)
        {
            using IDbConnection connection = new SqlConnection("Server=localhost;User=root;Password=1234;Database=prototype;");
            
            connection.Execute("INSERT INTO Conditie (ISBN, ConditieStripboek, Gesigneerd, Gesealed, Kaft) VALUES (@ISBN, @Conditie, @Gesigneerd, @Gesealed, @Kaft)",
                new {ISBN = conditie.ISBN, ConditieStripboek = conditie.ConditieStripboek, Gesigneerd = conditie.Gesigneerd, Gesealed = conditie.Gesealed, Kaft = conditie.Kaft });
        }

        public void GetAllStripboeken2()
        {
            using IDbConnection connection = new SqlConnection("Server=localhost;User=root;Password=1234;Database=prototype;");
            
        }
    }
}
