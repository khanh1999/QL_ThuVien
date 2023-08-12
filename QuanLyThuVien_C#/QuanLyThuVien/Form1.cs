using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;

namespace QuanLyThuVien
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            listS.Items.Add("Khoa Học");
            listS.Items.Add("Giáo Dục");
            listS.Items.Add("Văn Học");
            listS.Items.Add("Ngoại Ngữ");
        }
        Modify modify;
        Book sach;
        SqlDataAdapter dataAdapter;

        private void Form1_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataSach.DataSource = modify.getAllSach();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                // Hiện cho người dùng biết bị lỗi gì
            }

        }
        //Kiểm tra dữ liệu nhập vào đúng kiểu không
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
       /* private void button1_Click(object sender, EventArgs e)
        {
            if (this.maS.Text.Trim().CompareTo("") != 0 && this.tenS.Text.Trim().CompareTo("") != 0 && this.loaiS.Text.Trim().CompareTo("") != 0 &&
                this.soluong.Text.Trim().CompareTo("") != 0 && this.tenTg.Text.Trim().CompareTo("") != 0 && this.money.Text.Trim().CompareTo("") != 0)
            {
               if (IsNumber(this.soluong.Text) == true && IsNumber(this.money.Text) == true)
                {
                    string ma = this.maS.Text;
                    string ten = this.tenS.Text;
                    string loai = this.loaiS.Text;
                    int soluong = Int32.Parse(this.soluong.Text);
                    string tenTgia = this.tenTg.Text;
                    int gia = Int32.Parse(this.money.Text);
                    sach = new Book(ma, ten, loai, soluong, tenTgia, gia);
                    if (modify.insert(sach))
                    {
                        dataSach.DataSource = modify.getAllSach();
                        this.maS.Text = "";
                        this.tenS.Text = "";
                        this.loaiS.Text = "";
                        this.soluong.Text = "";
                        this.tenTg.Text = "";
                        this.money.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + "Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(@"Dữ liệu nhập vào Số lượng\ Giá Tiền không đúng!!!");             
                
            }

            else
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.maS.Text.Trim().CompareTo("") != 0 && this.tenS.Text.Trim().CompareTo("") != 0 && this.loaiS.Text.Trim().CompareTo("") != 0 &&
                this.soluong.Text.Trim().CompareTo("") != 0 && this.tenTg.Text.Trim().CompareTo("") != 0 && this.money.Text.Trim().CompareTo("") != 0)
            {
                if (IsNumber(this.soluong.Text) == true && IsNumber(this.money.Text) == true)
                {
                    string ma = this.maS.Text;
                    string ten = this.tenS.Text;
                    string loai = this.loaiS.Text;
                    int soluong = Int32.Parse(this.soluong.Text);
                    string tenTgia = this.tenTg.Text;
                    int gia = Int32.Parse(this.money.Text);
                    sach = new Book(ma, ten, loai, soluong, tenTgia, gia);
                    DialogResult dr = MessageBox.Show("Xác nhận đã cập nhật đúng thông tin!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (modify.update(sach))
                        {
                            dataSach.DataSource = modify.getAllSach();
                            this.maS.Text = "";
                            this.tenS.Text = "";
                            this.loaiS.Text = "";
                            this.soluong.Text = "";
                            this.tenTg.Text = "";
                            this.money.Text = "";    
                        }
                        else
                        {
                            MessageBox.Show("Lỗi: " + "Không chỉnh sửa vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show(@"Dữ liệu nhập vào Số lượng\ Giá Tiền không đúng!!!");
            }
            else
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa thông tin này!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string ma = dataSach.SelectedRows[0].Cells[0].Value.ToString();
                dataSach.DataSource = modify.getAllSach();
                if (modify.delete(ma))
                {
                    dataSach.DataSource = modify.getAllSach();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + "Không thể xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ten = this.tenS.Text;
            dataSach.DataSource = modify.LookUp(ten);
        }

        private void listS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string click;
            click = listS.SelectedItem.ToString();
            /*
            if (click == "Khoa Học")
                click = "KH";
            else if (click == "Giáo Dục")
                click = "GD";
            else if (click == "Văn Học")
                click = "VH";
            else if (click == "Ngoại Ngữ")
                click = "NN";*/
            
            switch (click)
            {
                case "Khoa Học":
                    click = "KH";
                    break;
                case "Giáo Dục":
                    click = "GD";
                    break;
                case "Văn Học":
                    click = "VH";
                    break;
                case "Ngoại Ngữ":
                    click = "NN";
                    break;
            }
            dataSach.DataSource = modify.QuickLK(click);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn muốn thoát chương trình không!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();           
        }

        private void inData_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataSach.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataSach.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataSach.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataSach.Columns.Count; j++)
                {
                    if (dataSach.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataSach.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
           }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.maS.Text.Trim().CompareTo("") != 0 && this.tenS.Text.Trim().CompareTo("") != 0 && this.loaiS.Text.Trim().CompareTo("") != 0 &&
                this.soluong.Text.Trim().CompareTo("") != 0 && this.tenTg.Text.Trim().CompareTo("") != 0 && this.money.Text.Trim().CompareTo("") != 0)
            {
                if (IsNumber(this.soluong.Text) == true && IsNumber(this.money.Text) == true)
                {
                    string ma = this.maS.Text;
                    string ten = this.tenS.Text;
                    string loai = this.loaiS.Text;
                    int soluong = Int32.Parse(this.soluong.Text);
                    string tenTgia = this.tenTg.Text;
                    int gia = Int32.Parse(this.money.Text);
                    sach = new Book(ma, ten, loai, soluong, tenTgia, gia);
                    if (modify.insert(sach))
                    {
                        dataSach.DataSource = modify.getAllSach();
                        this.maS.Text = "";
                        this.tenS.Text = "";
                        this.loaiS.Text = "";
                        this.soluong.Text = "";
                        this.tenTg.Text = "";
                        this.money.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + "Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(@"Dữ liệu nhập vào Số lượng\ Giá Tiền không đúng!!!");

            }

            else
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
        }

        }
        

    
}
