using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.SqlClient;




namespace ParseFromCSV.Services
{
    public class CSV_Parser : Connection
    {
        string filePath = @"C:\Users\spac-50\Desktop\Projekter\CerealAPI\DATABASE\ParseFromCSV\Data\Cereal.csv";
        private string insertSql = "insert into Cereals Values" +
            "(@NAME, @MFR, @TYPE, @CALORIES, @PROTEIN, @FAT, @SODIUM, @FIBER, " +
            "@CARBS, @SUGARS, @POTASSIUM, @VITAMINS, @SHELF, @WEIGHT, @CUPS, @RATING)";
        private string queryString = "select * from Cereals";
        private string queryStringFromId = "select * from Cereals where Id = @ID";
        private string queryStringFromIdName = "select * from Cereals where Name = @NAME";
        private string updateSql = "update Cereals set Name = @NAME, Mfr = @MFR, Type = @TYPE, Calories = @CALORIES," +
            "Protein = @PROTEIN, Fat = @FAT, Sodium = @SODIUM, Fiber = @FIBER, Carbs = @CARBS, Sugars = @SUGARS, Potassium = @POTASSIUM," +
            "Vitamins = @VITAMINS, Shelf = @SHELF, Weight = @WEIGHT, Cups = @CUPS, Rating = @RATING where Id = @ID";
        private string deleteSql = "delete from Cereals where Id = @ID";
        public List<Cereal> CreateCerealListFromCsv()
        {
            List<Cereal> cereals = File.ReadAllLines("C:\\Users\\spac-50\\Desktop\\Projekter\\CerealAPI\\DATABASE\\ParseFromCSV\\Data\\Cereal.csv")
                .Skip(2)
                .Select(v => Cereal.FromCsv(v))
                .ToList();
            return cereals;
        }
        public int InsertCerealListSql(List<Cereal> cereals)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int noOfRows = 0;
                while (i < cereals.Count)
                    foreach (Cereal c in cereals)
                    {
                        SqlCommand command = new SqlCommand(insertSql, connection);

                        command.Parameters.AddWithValue("@NAME", c.Name);
                        command.Parameters.AddWithValue("@MFR", c.Category);
                        command.Parameters.AddWithValue("@TYPE", c.Type);
                        command.Parameters.AddWithValue("@CALORIES", c.Calories);
                        command.Parameters.AddWithValue("@PROTEIN", c.Protein);
                        command.Parameters.AddWithValue("@FAT", c.Fat);
                        command.Parameters.AddWithValue("@SODIUM", c.Sodium);
                        command.Parameters.AddWithValue("@FIBER", c.Fiber);
                        command.Parameters.AddWithValue("@CARBS", c.Carbohydrates);
                        command.Parameters.AddWithValue("@SUGARS", c.Sugars);
                        command.Parameters.AddWithValue("@POTASSIUM", c.Potassium);
                        command.Parameters.AddWithValue("@VITAMINS",c.Vitamins);
                        command.Parameters.AddWithValue("@SHELF",c.Shelf);
                        command.Parameters.AddWithValue("@WEIGHT",c.Weight);
                        command.Parameters.AddWithValue("@CUPS",c.Cups);
                        command.Parameters.AddWithValue("@RATING",c.Rating);

                        command.Connection.Open();
                        noOfRows += command.ExecuteNonQuery();
                        command.Connection.Close();
                        i++;
                    }
                return noOfRows;
            }
        }
        public List<Cereal> GetAllCereals()
        {
            List<Cereal> list = new List<Cereal>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Cereal c = new Cereal();
                    c.Name = reader.GetString(0);
                    c.Category = reader.GetChar(1);
                    c.Type = reader.GetChar(2);
                    c.Calories = reader.GetInt32(3);
                    c.Protein = reader.GetInt32(4);
                    c.Fat = reader.GetInt32(5);
                    c.Sodium = reader.GetInt32(6);
                    c.Fiber = reader.GetDouble(7);
                    c.Carbohydrates = reader.GetDouble(8);
                    c.Sugars = reader.GetInt32(9);
                    c.Potassium = reader.GetInt32(10);
                    c.Vitamins = reader.GetInt32(11);
                    c.Shelf = reader.GetInt32(12);
                    c.Weight = reader.GetDouble(13);
                    c.Cups = reader.GetDouble(14);
                    c.Rating = reader.GetDouble(15);

                    list.Add(c);
                }
            }
            return list;
        }
        public int DeleteCereal(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(deleteSql, connection);
                command.Parameters.AddWithValue("@ID", Id);
                command.Connection.Open();
                int noOfRows = command.ExecuteNonQuery();
                return noOfRows;
            }
        }

        //public void CreateCerealListFromCSV()
        //{
        //    TextFieldParser parser = new TextFieldParser(filePath);
        //    parser.TextFieldType = FieldType.Delimited;
        //    parser.SetDelimiters(";");

        //    if (parser.PeekChars(4) == "name");
        //    {
        //        parser.ReadLine(); parser.ReadLine();
        //    }

        //    while (!parser.EndOfData)
        //    {

        //    }
        //}



        //public int insertSqlFromCSV()
        //{
        //    int result = 0;
        //    TextFieldParser parser = new TextFieldParser(filePath);
        //    parser.TextFieldType = FieldType.Delimited;
        //    parser.SetDelimiters(";");

        //    if (parser.PeekChars(4) == "name")
        //    {
        //        parser.ReadLine(); parser.ReadLine();
        //    }
        //    while (!parser.EndOfData)
        //    {
        //        List<string[]> cerealsList = new List<string[]>
        //        {
        //            parser.ReadFields()
        //        };
        //        foreach (string[] array in cerealsList)
        //        {
        //            string insertScript = "insert into Cereals Values(";
        //            int index = 0;
        //            foreach (string s in array)
        //            {
        //                index++;
        //                if (index < 4)
        //                {
        //                    insertScript +="\"" + s + "\"" + ", ";
        //                } else if (index < 16 && index > 3)
        //                {
        //                    insertScript += s + ", ";
        //                } else
        //                {
        //                    insertScript += s + ");";

        //                    int y = insertScript.Length - 6;
        //                    insertScript = insertScript.Remove(y, 1);
        //                }
        //            }
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                SqlCommand command = new SqlCommand(insertScript, connection);
        //                command.Parameters.AddWithValue();
        //                command.Connection.Open();
        //                int x = command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //        return result;
        //}
        public void ReadAndDisplayCSV()
        {
            TextFieldParser parser = new TextFieldParser(filePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");
            if (parser.PeekChars(4) == "name")
            {
                parser.ReadLine(); parser.ReadLine();
            }
            while (!parser.EndOfData)
            {
                List<string[]> cerealsList = new List<string[]>
                {
                    parser.ReadFields()
                };
                foreach (string[] array in cerealsList)
                {
                    int index = 0;
                    foreach (string s in array)
                    {
                        index++;
                        if (index < 16)
                        {
                            Console.Write(s + ", ");
                        } else
                        {
                            Console.Write(s);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

    }

    public class Cereal
    {
         string _name;
         char _category;
         char _type;
         int _calories;
         int _protein;
         int _fat;
         int _sodium;
         double _fiber;
         double _carbohydrates;
         int _sugars;
         int _potassium;
         int _vitamins;
         int _shelf;
         double _weight;
         double _cups;
         double _rating;

        public string Name { get => _name; set => _name = value; }
        public char Category { get => _category; set => _category = value; }
        public char Type { get => _type; set => _type = value; }
        public int Calories { get => _calories; set => _calories = value; }
        public int Protein { get => _protein; set => _protein = value; }
        public int Fat { get => _fat; set => _fat = value; }
        public int Sodium { get => _sodium; set => _sodium = value; }
        public double Fiber { get => _fiber; set => _fiber = value; }
        public double Carbohydrates { get => _carbohydrates; set => _carbohydrates = value; }
        public int Sugars { get => _sugars; set => _sugars = value; }
        public int Potassium { get => _potassium; set => _potassium = value; }
        public int Vitamins { get => _vitamins; set => _vitamins = value; }
        public int Shelf { get => _shelf; set => _shelf = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Cups { get => _cups; set => _cups = value; }
        public double Rating { get => _rating; set => _rating = value; }

        public static Cereal FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Cereal cereal = new Cereal();
            cereal.Name = Convert.ToString(values[0]);
            cereal.Category = Convert.ToChar(values[1]);
            cereal.Type = Convert.ToChar(values[2]);
            cereal.Calories = Convert.ToInt32(values[3]);
            cereal.Protein = Convert.ToInt32(values[4]);
            cereal.Fat = Convert.ToInt32(values[5]);
            cereal.Sodium = Convert.ToInt32(values[6]);
            cereal.Fiber = Convert.ToDouble(values[7]);
            cereal.Carbohydrates = Convert.ToDouble(values[8]);
            cereal.Sugars = Convert.ToInt32(values[9]);
            cereal.Potassium = Convert.ToInt32(values[10]);
            cereal.Vitamins = Convert.ToInt32(values[11]);
            cereal.Shelf = Convert.ToInt32(values[12]);
            cereal.Weight = Convert.ToDouble(values[13]);
            cereal.Cups = Convert.ToDouble(values[14]);
            cereal.Rating = Convert.ToDouble(values[15]);
            return cereal;
        }
    }
}
