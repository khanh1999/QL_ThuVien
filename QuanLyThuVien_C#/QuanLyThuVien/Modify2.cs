using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyThuVien
{
    class Modify2
    {
       SqlDataAdapter dataAdapter; // Hoạt động như một cầu kết nối giữa Dataset/Datatable vào nguồn dữ liệu để truy xuất dữ liệu
       SqlCommand sqlCommand; // Dùng để truy vấn và cập nhật tới CSDL
        public Modify2()
        {
        }
        // Dataset tra ve nhieu bang
        // Datatable tra ve mot bang
        public DataTable getAllPeople()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT NgMuon.*, Muon.MaSach, Muon.NgayMuon, Muon.NgayTra FROM NgMuon, Muon where NgMuon.MaMuon = Muon.MaMuon";
            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public bool insert(People people)
        {
            SqlConnection sqlConnection = ConnectionString.getConnection();
            string query = "insert into NgMuon values (@MaMuon,@HoTen,@DiaChi,@SDT)";
            string query2 = "insert into Muon values (@MaSach, @MaMuon, @NgayMuon, @NgayTra)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMuon", SqlDbType.NChar).Value = people.Ma;
                sqlCommand.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = people.Ten;
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = people.Diachi;
                sqlCommand.Parameters.Add("@SDT", SqlDbType.NChar).Value = people.Sdt;
                sqlCommand.ExecuteNonQuery();
            
                sqlCommand = new SqlCommand(query2, sqlConnection);
                sqlCommand.Parameters.Add("@MaSach", SqlDbType.NChar).Value = people.MaS;
                sqlCommand.Parameters.Add("@MaMuon", SqlDbType.NChar).Value = people.MaM;
                sqlCommand.Parameters.Add("@NgayMuon", SqlDbType.DateTime).Value = people.Muon.ToShortDateString();
                sqlCommand.Parameters.Add("@NgayTra", SqlDbType.DateTime).Value = people.Tra.ToShortDateString();
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
        public bool update(People people)
        {
            SqlConnection sqlConnection = ConnectionString.getConnection();
            string query = "update NgMuon set HoTen = @HoTen, DiaChi = @DiaChi, SDT = @SDT Where MaMuon=@MaMuon";
            string query2 = "update Muon set MaSach = @MaSach, NgayMuon = @NgayMuon, NgayTra = @NgayTra Where MaMuon=@MaMuon";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMuon", SqlDbType.NChar).Value = people.Ma;
                sqlCommand.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = people.Ten;
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = people.Diachi;
                sqlCommand.Parameters.Add("@SDT", SqlDbType.NChar).Value = people.Sdt;
                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
                
                sqlCommand = new SqlCommand(query2, sqlConnection);
                sqlCommand.Parameters.Add("@MaSach", SqlDbType.NChar).Value = people.MaS;
                sqlCommand.Parameters.Add("@MaMuon", SqlDbType.NChar).Value = people.MaM;
                sqlCommand.Parameters.Add("@NgayMuon", SqlDbType.DateTime).Value = people.Muon.ToShortDateString();
                sqlCommand.Parameters.Add("@NgayTra", SqlDbType.DateTime).Value = people.Tra.ToShortDateString();
                sqlCommand.ExecuteNonQuery(); 
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
            string query = "delete NgMuon where MaMuon =@MaMuon";
            string query2 = "delete Muon where MaMuon =@MaMuon";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query2, sqlConnection);
                sqlCommand.Parameters.Add("@MaMuon", SqlDbType.NChar).Value = ma;
                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn

                
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMuon", SqlDbType.NChar).Value = ma;
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
            string query = "SELECT NgMuon.*, Muon.MaSach, Muon.NgayMuon, Muon.NgayTra FROM NgMuon, Muon where NgMuon.MaMuon = Muon.MaMuon";
            if (field != null || field.Length > 0)
            {
                query += " And HoTen like '%" + field + "%'";
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
