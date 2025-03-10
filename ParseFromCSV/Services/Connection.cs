using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFromCSV.Services
{
    public abstract class Connection
    {
        protected string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\SPAC-50\DESKTOP\PROJEKTER\CEREALAPI\DATABASE\CEREALDATABASE\CEREALDATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}
