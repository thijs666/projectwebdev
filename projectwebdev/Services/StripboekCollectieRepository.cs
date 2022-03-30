using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using projectwebdev.Models;

namespace projectwebdev.Services
{
    public class StripboekCollectieRepository
    {
        private IDbConnection Connect()
        {
            return new MySqlConnection(
                @"Server=127.0.0.1;Port=3306;
                Database=stripboekcollectie;
                Uid=root;Pwd=root;"
            );
        }

        public List<StripboekCollectie> Get()
        {
            using var connection = Connect();
            var stripboeken = connection
                .Query<StripboekCollectie>("SELECT * FROM stripboekcollectie");
            return stripboeken.ToList();
        }

        public void InsertInto(StripboekCollectie stripboekCollectie)
        {
            using var connection = Connect();
            connection.Execute(
                "INSERT INTO stripboekcollectie (Titel, Aantal_blz, Schrijver, Tekenaar, ISBN) VALUES (@Titel, @Aantal_blz, @Schrijver, @Tekenaar, @ISBN)",
                new {Titel = stripboekCollectie.Titel, Aantal_blz = stripboekCollectie.Aantal_Blz, Schrijver = stripboekCollectie.Schrijver, Tekenaar = stripboekCollectie.Tekenaar, ISBN = stripboekCollectie.ISBN});
        }

        public void GetAllStripboeken()
        {
            using var connection = Connect();
        }

        public bool Delete(int stripboekId)
        {
            using var connection = Connect();
            int numRowsEffected = connection.Execute(
                "DELETE FROM stripboekcollectie WHERE StripboekID = @StripboekID",
                new {StripboekID = stripboekId});
            return numRowsEffected == 1;
        }

        public StripboekCollectie Add(StripboekCollectie stripboekCollectie)
        {
            using var connection = Connect();
            int numRowsEffected = connection.Execute(
                "INSERT INTO stripboekcollectie (Titel, Aantal_blz, Schrijver, Tekenaar, ISBN) VALUES (@Titel, @Aantal_blz, @Schrijver, @Tekenaar, @ISBN)",
                new
                {
                    Titel = stripboekCollectie.Titel, Aantal_blz = stripboekCollectie.Aantal_Blz,
                    Schrijver = stripboekCollectie.Schrijver, Tekenaar = stripboekCollectie.Tekenaar,
                    ISBN = stripboekCollectie.ISBN
                });

            if (numRowsEffected == 1)
            {
                var newStripboek = connection.QuerySingle<StripboekCollectie>(
                    "SELECT * FROM stripboekcollectie WHERE StripboekID = LAST_INSERT_ID()");
                return newStripboek;
            }

            return null;
        }
        
        
        
    }
}

