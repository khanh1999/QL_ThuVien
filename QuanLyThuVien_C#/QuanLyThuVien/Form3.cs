using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string login = "admin";
        string pass = "123456";

        private void In_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            if (login == this.dnhap.Text.ToString() && pass == this.mkhau.Text.ToString())
            {         
                MessageBox.Show("Đăng nhập thành công!!!");
                this.Hide();
                form1.ShowDialog();         
            }
            else
            {
                MessageBox.Show(@"Đăng nhập thất bại. Tên đăng nhập\ Mật khẩu không đúng!!","Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dnhap.Text = "";
                this.mkhau.Text = "";
            }
        }

        private void Out_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn muốn thoát chương trình!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
        }
    }
}
