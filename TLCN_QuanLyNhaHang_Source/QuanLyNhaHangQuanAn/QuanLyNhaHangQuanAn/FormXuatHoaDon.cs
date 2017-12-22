using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using System.Data.SqlClient;

namespace QuanLyNhaHangQuanAn
{
    public partial class FormXuatHoaDon : Form
    {
        BUSNV nv = new BUSNV();

        DataTable dtMaHD = null;
        DataTable dtMonGoi2 = null;
        public FormXuatHoaDon()
        {
            InitializeComponent();
        }
        string strTrangThaiBan;
        string MaNhanVien;
        string MaBan;
        public FormXuatHoaDon(string mess1, string mess2, string mess3, string mess4)
            : this()
        {
            MaBan = mess1;
            strTrangThaiBan = mess2;
            MaNhanVien = mess3;
            txtMaPhieuOrder.Text = mess4;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            lbNhanVien.Text = MaNhanVien;
            txtMaBan.Text = MaBan;
            ThemHoaDon();
            CapNhatTrangThaiBan();
            LoadData_MaHoaDon();
            LoadData_DanhSachMonGoi();
            TinhTongTien();

        }

        void LoadData_DanhSachMonGoi()
        {
            try
            {
                dtMonGoi2 = new DataTable();
                dtMonGoi2.Clear();
                dtMonGoi2 = nv.LayDuLieuDanhSachMonGoi(txtMaPhieuOrder.Text);
                // Đưa dữ liệu lên DataGridView  

                dgvHoaDon.DataSource = dtMonGoi2;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table ChiTietHoaDon. Lỗi rồi!!!");
            }
        }

        void TinhTongTien()
        {

            int TongTien = 0;
            for (int i = 0; i < dgvHoaDon.Rows.Count ; i++)
            {
                TongTien += int.Parse(dgvHoaDon.Rows[i].Cells[5].Value.ToString());
            }
            txtTongTien.Text = TongTien.ToString();
            
            //if(cbVAT.Checked == true)
            //{
            //    txtTongThanhToan.Text = (int.Parse(txtTongTien.Text) + int.Parse(txtVAT.Text)).ToString();
            //}else
            //    txtTongThanhToan.Text = txtTongTien.Text;
        }
        void LoadData_MaHoaDon()
        {
            try
            {
                dtMaHD = new DataTable();
                dtMaHD.Clear();
                dtMaHD = nv.LayDuLieu_MaHoaDon_TheoMaBan(MaBan);
                // Đưa dữ liệu lên DataGridView  
                // DataTable tbl = ds.Tables["DSTinh"];
                DataRow dr = dtMaHD.Rows[0];
                lbHoaDon.Text = dr["MaHD"].ToString();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table PhieuOrder. Lỗi rồi!!!");
            }
        }
        void ThemHoaDon()
        {
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                //bool f = nv.ThemPhieuOrder(ref err, txtMaBan.Text, MaNhanVien);
                bool f = nv.ThemHoaDon(ref err, txtMaBan.Text, MaNhanVien, dtpNgayLap.Value);

                if (f)
                {
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa x00000000ong!\n\r" + "Lỗi:" + err);
                }

            }

            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }
        void CapNhatTrangThaiBan()
        {
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                bool f = nv.CapNhatTrangThaiBan(ref err, txtMaBan.Text, "Trống");


                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 

                    // Thông báo 
                    //LoadData_MaHoaDon();

                    //LoadData_PhieuNhapVuaThem();
                    MessageBox.Show("Đã thêm Hóa Đơn cho: Bàn " + txtMaBan.Text);


                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                }

            }

            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }

        }

        private void FormHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbVAT_CheckedChanged(object sender, EventArgs e)
        {

            gbThongTin.Visible = !gbThongTin.Visible;
            txtVAT.Visible = !txtVAT.Visible;
            txtVAT.Text = ((int.Parse(txtTongTien.Text)) * 10 / 100).ToString();
            if (cbVAT.Checked == true)
            {
                txtTongThanhToan.Text = (int.Parse(txtTongTien.Text) + int.Parse(txtVAT.Text)).ToString();
            }
            else
                txtTongThanhToan.Text = txtTongTien.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInHoaDon frmInHD = new FormInHoaDon(txtMaPhieuOrder.Text, lbNhanVien.Text, txtMaBan.Text, txtTongThanhToan.Text);
            frmInHD.ShowDialog();
        }
    }
}
