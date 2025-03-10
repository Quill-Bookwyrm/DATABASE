using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using ParseFromCSV.Services;

namespace ParseFromCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filepath = @"c:\users\spac-50\desktop\projekter\cerealapi\database\parsefromcsv\data\cereal.csv";
            //{
            //    try
            //    {
            //        using (streamreader reader = new streamreader(filepath))

            //        {
            //            string line;
            //            while ((line = reader.readline()) != null)
            //            {
            //                console.writeline(line);
            //            }
            //        }
            //    }
            //    catch (exception ex)
            //    {
            //        console.writeline(ex.message);
            //    }
            //    console.readkey();
            //}

            CSV_Parser parser = new CSV_Parser();

            int x = parser.insertSqlFromCSV();
            Console.WriteLine($"{x} rows affected!");
        }
    }
}
