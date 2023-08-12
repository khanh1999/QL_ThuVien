using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyThuVien
{
    class Modify
    {
       SqlDataAdapter dataAdapter; // Hoạt động như một cầu kết nối giữa Dataset/Datatable vào nguồn dữ liệu để truy xuất dữ liệu
       SqlCommand sqlCommand; // Dùng để truy vấn và cập nhật tới CSDL
        public Modify()
        {
        }
        // Dataset tra ve nhieu bang
        // Datatable tra ve mot bang
        public DataTable getAllSach()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Sach";
            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool insert(Book book)
        {
            SqlConnection sqlConnection = ConnectionString.getConnection();
            string query = "insert into Sach values (@MaSach,@TenSach,@MaLoai,@SoLuong,@TenTgia,@Gia)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaSach", SqlDbType.NChar).Value =book.Ma;
                sqlCommand.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = book.Ten;
                sqlCommand.Parameters.Add("@MaLoai", SqlDbType.NChar).Value = book.Loai;
                sqlCommand.Parameters.Add("@SoLuong", SqlDbType.Int).Value = book.Num;
                sqlCommand.Parameters.Add("@TenTgia", SqlDbType.NVarChar).Value = book.TenTgia;
                sqlCommand.Parameters.Add("@Gia", SqlDbType.Money).Value = book.Gia;
                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch //Nếu có lỗi trả về false
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool update(Book book)
        {
            SqlConnection sqlConnection = ConnectionString.getConnection();
            string query = "update Sach set TenSach = @TenSach, MaLoai = @MaLoai, SoLuong = @SoLuong, TenTgia =@TenTgia, Gia =@Gia Where MaSach=@MaSach";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaSach", SqlDbType.NChar).Value = book.Ma;
                sqlCommand.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = book.Ten;
                sqlCommand.Parameters.Add("@MaLoai", SqlDbType.NChar).Value = book.Loai;
                sqlCommand.Parameters.Add("@SoLuong", SqlDbType.Int).Value = book.Num;
                sqlCommand.Parameters.Add("@TenTgia", SqlDbType.NVarChar).Value = book.TenTgia;
                sqlCommand.Parameters.Add("@Gia", SqlDbType.Money).Value = book.Gia;
                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch //Nếu có lỗi trả về false
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool delete(string ma)
        {
            SqlConnection sqlConnection = ConnectionString.getConnection();
            string query = "delete Sach where MaSAch =@MaSach";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaSach", SqlDbType.NChar).Value = ma;
                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch //Nếu có lỗi trả về false
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
       
        public DataTable LookUp(string field)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Sach";
            if (field != null || field.Length>0)
            {
                query += " Where TenSach like '%" + field + "%'";
            }
            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public DataTable QuickLK(string field)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Sach";
            if (field != null || field.Length > 0)
            {
                query += " Where MaLoai = '" + field + "'";
            }
            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
    }
}
