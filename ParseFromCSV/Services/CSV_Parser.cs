using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;




namespace ParseFromCSV.Services
{
    public class CSV_Parser : Connection
    {
        string filePath = @"C:\Users\spac-50\Desktop\Projekter\CerealAPI\DATABASE\ParseFromCSV\Data\Cereal.csv";
        private string insertSql = "insert into Cereals Values" +
            "(@NAME, @MFR, @TYPE, @CALORIES, @PROTEIN, @FAT, @SODIUM, @FIBER, " +
            "@CARBS, @SUGARS, @POTASSIUM, @VITAMINS, @SHELF, @WEIGHT, @CUPS, @RATING)";

        public int insertSqlFromCSV()
        {
            int result = 0;
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
                    string insertScript = "insert into Cereals Values(";
                    int index = 0;
                    foreach (string s in array)
                    {
                        index++;
                        if (index < 4)
                        {
                            insertScript +="\"" + s + "\"" + ", ";
                        } else if (index < 16 && index > 3)
                        {
                            insertScript += s + ", ";
                        } else
                        {
                            insertScript += s + ");";

                            int y = insertScript.Length - 6;
                            insertScript = insertScript.Remove(y, 1);
                        }
                    }
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(insertScript, connection);
                        command.Parameters.AddWithValue();
                        command.Connection.Open();
                        int x = command.ExecuteNonQuery();
                    }
                }
            }
                return result;
        }
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
        public int InsertCereals(List<string> data)
        {
            return 1;
        }
    }
}
