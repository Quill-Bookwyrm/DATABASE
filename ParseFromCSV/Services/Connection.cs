using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFromCSV.Services
{
    public abstract class Connection
    {
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\spac-50\Desktop\Projekter\CerealAPI\DATABASE\CerealDatabase\CerealDatabase.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
