using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class ConnectionString
    {
        public static string stringConnection = @"Data Source=DESKTOP-I1MCBOK\LAP;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
