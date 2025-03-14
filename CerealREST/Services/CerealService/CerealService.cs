using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CerealREST.Models;
using CerealREST.Services.Interfaces;

namespace CerealREST.Services.CerealService
{
    public class CerealService : Connection, ICerealService
    {
        private string insertSql = "insert into Cereals Values" +
            "(@NAME, @MFR, @TYPE, @CALORIES, @PROTEIN, @FAT, @SODIUM, @FIBER, " +
            "@CARBS, @SUGARS, @POTASSIUM, @VITAMINS, @SHELF, @WEIGHT, @CUPS, @RATING)";
        private string queryString = "select * from Cereals";
        private string queryStringFromId = "select * from Cereals where Id = @ID";
        private string queryStringFromMfc = "select * from Cereals where Mfr = @MFR";
        private string queryStringFromVariable = "select * from Cereals where @VARIABLE = @TARGET";
        private string queryStringFromName = "select * from Cereals where Name = @NAME";
        private string updateSql = "update Cereals set Name = @NAME, Mfr = @MFR, Type = @TYPE, Calories = @CALORIES," +
            "Protein = @PROTEIN, Fat = @FAT, Sodium = @SODIUM, Fiber = @FIBER, Carbs = @CARBS, Sugars = @SUGARS, Potassium = @POTASSIUM," +
            "Vitamins = @VITAMINS, Shelf = @SHELF, Weight = @WEIGHT, Cups = @CUPS, Rating = @RATING where Id = @ID";
        private string deleteSql = "delete from Cereals where Id = @ID";

        public CerealService(IConfiguration configuration) : base(configuration)
        {
        }
        public CerealService(string connectionString) : base(connectionString)
        {
        }

        public bool CreateCereal(Cereal cereal)
        {
            throw new NotImplementedException();
        }

        public Cereal DeleteCereal(int Id)
        {
            Cereal c = GetCerealFromId(Id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(deleteSql, connection);
                command.Parameters.AddWithValue("@ID", Id);
                command.Connection.Open();
                int noOfRows = command.ExecuteNonQuery();
                if (noOfRows != 1)
                {
                    return null;
                }
                return c;
            }
        }

        public List<Cereal> GetAllCereal()
        {
            List<Cereal> cereals = new List<Cereal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cereal c = new Cereal();
                    c.Name = reader.GetString(1);
                    c.Category = reader.GetChar(2);
                    c.Type = reader.GetChar(3);
                    c.Calories = reader.GetInt32(4);
                    c.Protein = reader.GetInt32(5);
                    c.Fat = reader.GetInt32(6);
                    c.Sodium = reader.GetInt32(7);
                    c.Fiber = reader.GetDouble(8);
                    c.Carbohydrates = reader.GetDouble(9);
                    c.Sugars = reader.GetInt32(10);
                    c.Potassium = reader.GetInt32(11);
                    c.Vitamins = reader.GetInt32(12);
                    c.Shelf = reader.GetInt32(13);
                    c.Weight = reader.GetDouble(14);
                    c.Cups = reader.GetDouble(15);
                    c.Rating = reader.GetDouble(16);
                    cereals.Add(c);
                }
                command.Connection.Close();
            }
            return cereals;
        }

        public Cereal GetCerealFromId(int Id)
        {
            Cereal c = new Cereal();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringFromId, connection);
                command.Parameters.AddWithValue("@ID", Id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    c.Name = reader.GetString(1);
                    c.Category = reader.GetChar(2);
                    c.Type = reader.GetChar(3);
                    c.Calories = reader.GetInt32(4);
                    c.Protein = reader.GetInt32(5);
                    c.Fat = reader.GetInt32(6);
                    c.Sodium = reader.GetInt32(7);
                    c.Fiber = reader.GetDouble(8);
                    c.Carbohydrates = reader.GetDouble(9);
                    c.Sugars = reader.GetInt32(10);
                    c.Potassium = reader.GetInt32(11);
                    c.Vitamins = reader.GetInt32(12);
                    c.Shelf = reader.GetInt32(13);
                    c.Weight = reader.GetDouble(14);
                    c.Cups = reader.GetDouble(15);
                    c.Rating = reader.GetDouble(16);
                }
                command.Connection.Close();
            }
                return c;
        }

        public Cereal GetCerealFromManufacturer(char mfc)
        {
            Cereal c = new Cereal();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringFromMfc, connection);
                command.Parameters.AddWithValue("@MFR", mfc);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    c.Name = reader.GetString(1);
                    c.Category = reader.GetChar(2);
                    c.Type = reader.GetChar(3);
                    c.Calories = reader.GetInt32(4);
                    c.Protein = reader.GetInt32(5);
                    c.Fat = reader.GetInt32(6);
                    c.Sodium = reader.GetInt32(7);
                    c.Fiber = reader.GetDouble(8);
                    c.Carbohydrates = reader.GetDouble(9);
                    c.Sugars = reader.GetInt32(10);
                    c.Potassium = reader.GetInt32(11);
                    c.Vitamins = reader.GetInt32(12);
                    c.Shelf = reader.GetInt32(13);
                    c.Weight = reader.GetDouble(14);
                    c.Cups = reader.GetDouble(15);
                    c.Rating = reader.GetDouble(16);
                }
                command.Connection.Close();
            }
            return c;
        }

        public Cereal GetCerealFromVariable(string variable, string target)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCereal(Cereal cereal, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
