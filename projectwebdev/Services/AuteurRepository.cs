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
    public class AuteurRepository
    {
        private IDbConnection Connect()
        {
            return new MySqlConnection(
                @"Server=127.0.0.1;Port=3306;
                Database=auteurs;
                Uid=root;Pwd=root;"
            );
        }

        public List<Auteur> Get()
        {
            using var connection = Connect();
            var auteurs = connection
                .Query<Auteur>("SELECT * FROM auteur");
            return auteurs.ToList();
        }

        public List<Auteur> SorteerAuteur()
        {
            using var connection = Connect();
            var q = "SELECT AuteurID FROM auteur ORDER BY AuteursNaam DESC";
            var auteursorteer = connection.Query<Auteur>(q).ToList();
            return auteursorteer;
        }

        public void InsertInto(Auteur auteur)
        {
            using var connection = Connect();
            connection.Execute("INSERT INTO auteur (AuteursNaam, Geboortejaar) VALUES (@AuteursNaam, @Geboortejaar)",
                new {AuteursNaam = auteur.AuteursNaam, Geboortedatum = auteur.Geboortejaar});
        }

        public void GetAllAuteurs()
        {
            using var connection = Connect();
        }

        public bool Delete(int auteurId)
        {
            using var connection = Connect();
            int numRowsEffected = connection.Execute(
                "DELETE FROM auteur WHERE AuteurID = @AuteurID",
                new {AuteurID = auteurId});
            return numRowsEffected == 1;
        }

        public Auteur Add(Auteur auteur)
        {
            using var connection = Connect();
            int numRowsEffected = connection.Execute(
                "INSERT INTO auteur (AuteursNaam, Geboortejaar) VALUES (@AuteursNaam, @Geboortejaar)",
                new {AuteursNaam = auteur.AuteursNaam, Geboortejaar = auteur.Geboortejaar});

            if (numRowsEffected == 1)
            {
                var newAuteur = connection.QuerySingle<Auteur>(
                    "SELECT * FROM auteur WHERE AuteurID = LAST_INSERT_ID()");
                return newAuteur;
            }

            return null;
        }

        public Auteur Update(Auteur auteur)
        {
            using var connection = Connect();
            int numRowsEffected = connection.Execute(
                @"UPDATE auteur SET AuteursNaam = @AuteursNaam, Geboortejaar = @Geboortejaar WHERE AuteurID = @AuteurID",
                new
                {
                    AuteurID = auteur.AuteurID,
                    AuteursNaam = auteur.AuteursNaam,
                    Geboortejaar = auteur.Geboortejaar
                }
            );

            if (numRowsEffected == 1)
            {
                var newAuteur = connection.QuerySingle<Auteur>(
                    "SELECT * FROM auteur WHERE AuteurID = LAST_INSERT_ID()");
                return newAuteur;
            }

            throw new Exception("Update Error!");
        }
    }
}

