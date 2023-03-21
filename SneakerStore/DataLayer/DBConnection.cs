using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBConnection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi481968;User Id=dbi481968;Password=parola;");
        }
    }
}
