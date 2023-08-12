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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Modify2 modify;
        People people;
        private void Form2_Load(object sender, EventArgs e)
        {
            modify = new Modify2();
            try
            {
                dataPeople.DataSource = modify.getAllPeople();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hiện cho người dùng biết bị lỗi gì
            }
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (this.maM.Text.Trim().CompareTo("") != 0 && this.name.Text.Trim().CompareTo("") != 0 && this.diachi.Text.Trim().CompareTo("") != 0 &&
                this.sdt.Text.Trim().CompareTo("") != 0 && this.maS.Text.Trim().CompareTo("") != 0)
            {
                string ma = this.maM.Text;
                string ten = this.name.Text;
                string diachi = this.diachi.Text;
                string sdt = this.sdt.Text;
                string maS = this.maS.Text;
                string maM = ma;
                DateTime muon = this.muon.Value;
                DateTime tra = this.tra.Value;
                people = new People(ma, ten, diachi, sdt, maS, maM, muon, tra);

                if (modify.insert(people))
                {
                    dataPeople.DataSource = modify.getAllPeople();
                    this.maM.Text = "";
                    this.name.Text = "";
                    this.diachi.Text = "";
                    this.sdt.Text = "";
                    this.maS.Text = "";
                }
                else
                {
                    MessageBox.Show("Lỗi: " + "Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
        }

        private void sua_Click(object sender, EventArgs e)
        {
            if (this.maM.Text.Trim().CompareTo("") != 0 && this.name.Text.Trim().CompareTo("") != 0 && this.diachi.Text.Trim().CompareTo("") != 0 &&
                this.sdt.Text.Trim().CompareTo("") != 0 && this.maS.Text.Trim().CompareTo("") != 0)
            {
                string ma = this.maM.Text;
                string ten = this.name.Text;
                string diachi = this.diachi.Text;
                string sdt = this.sdt.Text;
                string maS = this.maS.Text;
                string maM = ma;
                DateTime muon = this.muon.Value;
                DateTime tra = this.tra.Value;
                people = new People(ma, ten, diachi, sdt, maS, maM, muon, tra);
                DialogResult dr = MessageBox.Show("Xác nhận đã cập nhật đúng thông tin!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (modify.update(people))
                    {
                        dataPeople.DataSource = modify.getAllPeople();
                        {
                            this.maM.Text = "";
                            this.name.Text = "";
                            this.diachi.Text = "";
                            this.sdt.Text = "";
                            this.maS.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + "Không chỉnh sữa vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận đã cập nhật đúng thông tin!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string ma = dataPeople.SelectedRows[0].Cells[0].Value.ToString();
                if (modify.delete(ma))
                {
                    dataPeople.DataSource = modify.getAllPeople();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + "Không thể xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string ten = this.name.Text;
            dataPeople.DataSource = modify.LookUp(ten);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn muốn quay lại trang chính!!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataPeople.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataPeople.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataPeople.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataPeople.Columns.Count; j++)
                {
                    if (dataPeople.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataPeople.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void muon_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
