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
    public partial class FormGoiMon : Form
    {
        BUSNV nv = new BUSNV();
        DataTable dtMaOrder = null;
        DataTable dtMonGoi = null;
        public FormGoiMon()
        {
            InitializeComponent();
        }
        string strTrangThaiBan;
        string MaNhanVien;
        public FormGoiMon(string mess1, string mess2, string mess3)
            : this()
        {
            txtMaBan.Text = mess1;
            strTrangThaiBan = mess2;
            MaNhanVien = mess3;
        }

        DataTable dtGm = null;
        DataTable dtMa = null;
        void LoadData_LoaiMonAn()
        {
            try
            {
                dtGm = new DataTable();
                dtGm.Clear();
                dtGm = nv.LayDuLieu_LoaiMonAn();



                cmbLoaiMonAn.DataSource = dtGm;
                cmbMaLoai.DataSource = dtGm;



                cmbLoaiMonAn.DisplayMember = dtGm.Columns["TenLoai"].ToString();
                cmbMaLoai.DisplayMember = dtGm.Columns["MaLoai"].ToString();

                cmbLoaiMonAn.ValueMember = dtGm.Columns["TenLoai"].ToString();
                cmbMaLoai.ValueMember = dtGm.Columns["MaLoai"].ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung lên combobox Loai mon an. Lỗi rồi!!!");
            }
        }
        //string err;
        void LoadData_MonAn()
        {
            try
            {
                int r = Convert.ToInt32(cmbMaLoai.SelectedValue.ToString());
                dtMa = new DataTable();
                dtMa.Clear();
                dtMa = nv.LayDuLieu_MonAn(r);

                dgvMonAn.DataSource = dtMa;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung lên combobox Loai mon an. Lỗi rồi!!!");
            }
        }

        //void AddData_CTO()
        //{
        //    try
        //    {
        //        int r = dgvMonAn.CurrentCell.RowIndex;
        //        string strMaMon = dgvMonAn.Rows[r].Cells[0].Value.ToString();
        //        MessageBox.Show(strMaMon);
        //        //AddDuLieu_CTO()
        //        //int r = Convert.ToInt32(cmbMaLoai.SelectedValue.ToString());
        //        dtMa = new DataTable();
        //        dtMa.Clear();
        //        dtMa = nv.LayDuLieu_MonAn(r);

        //        dgvMonAn.DataSource = dtMa;

        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show("Không lấy được nội dung lên combobox Loai mon an. Lỗi rồi!!!");
        //    }
        //}

        void ThemPhieuOrder()
        {
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                bool f = nv.ThemPhieuOrder(ref err, txtMaBan.Text, MaNhanVien);

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
                bool f = nv.CapNhatTrangThaiBan(ref err, txtMaBan.Text, "Đang gọi món");


                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 

                    // Thông báo 
                    //LoadData_MaHoaDon();

                    //LoadData_PhieuNhapVuaThem();
                    MessageBox.Show("Đã thêm Phiếu Order cho: Bàn " + txtMaBan.Text);


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

        void LoadData_MaPhieuOrder_0()
        {
            try
            {
                dtMaOrder = new DataTable();
                dtMaOrder.Clear();
                dtMaOrder = nv.LayDuLieuMaOrder();
                // Đưa dữ liệu lên DataGridView  
                // DataTable tbl = ds.Tables["DSTinh"];
                DataRow dr = dtMaOrder.Rows[0];
                txtMaPhieuOrder.Text = dr["MaPhieuOrder"].ToString();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table PhieuOrder. Lỗi rồi!!!");
            }
        }
        void LoadData_MaPhieuOrder_1()
        {
            try
            {
                dtMaOrder = new DataTable();
                dtMaOrder.Clear();
                dtMaOrder = nv.LayDuLieu_MaPhieuOrder_TheoMaBan(txtMaBan.Text);
                // Đưa dữ liệu lên DataGridView  
                // DataTable tbl = ds.Tables["DSTinh"];
                DataRow dr = dtMaOrder.Rows[0];
                txtMaPhieuOrder.Text = dr["MaPhieuOrder"].ToString();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table PhieuOrder. Lỗi rồi!!!");
            }
        }
        void LoadData_DanhSachMonGoi()
        {
            try
            {
                dtMonGoi = new DataTable();
                dtMonGoi.Clear();
                dtMonGoi = nv.LayDuLieuDanhSachMonGoi(txtMaPhieuOrder.Text);
                // Đưa dữ liệu lên DataGridView  

                dgvChiTietOrder.DataSource = dtMonGoi;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table ChiTietHoaDon. Lỗi rồi!!!");
            }
        }
        private void FormGoiMon_Load(object sender, EventArgs e)
        {
            LoadData_LoaiMonAn();
            lbMaNV.Text = MaNhanVien;
            if (strTrangThaiBan == "Mở bàn")
            {
                ThemPhieuOrder();
                LoadData_MaPhieuOrder_0();
                //LoadData_TenNhanVien();
                CapNhatTrangThaiBan();
                //TinhTongTien();
            }

            if (strTrangThaiBan == "Đang gọi món")
            {
                LoadData_MaPhieuOrder_1();
                //btnThemHoaDon.Enabled = false;
                //LoadData_MaHoaDon_1();
                LoadData_DanhSachMonGoi();
                //TinhTongTien();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadData_MonAn();
        }

        private void Chon_Click(object sender, EventArgs e)
        {
            //string x = dgvChiTietOrder.RowCount.ToString();
            //MessageBox.Show(x);
            int r = dgvMonAn.CurrentCell.RowIndex;
            string strMaMon = dgvMonAn.Rows[r].Cells[0].Value.ToString();
            string strTenMon = dgvMonAn.Rows[r].Cells[1].Value.ToString();
            string strDonViTinh = dgvMonAn.Rows[r].Cells[2].Value.ToString();
            string strDonGiaHienTai0 = dgvMonAn.Rows[r].Cells[3].Value.ToString();

            txtMaMon.Text = strMaMon;
            txtTenMon.Text = strTenMon;
            txtDonViTinh.Text = strDonViTinh;
            txtDonGiaHienTai.Text = strDonGiaHienTai0;

            /// bo ham load data mon theo strMaMon zo day
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        void KiemTraSoLuong()
        {
            int r = int.Parse(dgvChiTietOrder.RowCount.ToString());
            //if(txtMaMon)
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng cho món ăn ! Mời nhập ", "Lỗi");
                txtSoLuong.Focus();
            }
            else if(IsNumber(txtSoLuong.Text) == false)
            {
                MessageBox.Show("Vui lòng nhập số lượng kiểu số!", "Lỗi");
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
            }
            else
            {
                string err = "";
                bool kt = true;
                try
                {


                    // Lệnh Insert InTo 
                    bool f = nv.ThemChiTietPhieuOrder(ref err, int.Parse(txtMaPhieuOrder.Text), int.Parse(txtMaMon.Text), int.Parse(txtDonGiaHienTai.Text), int.Parse(txtSoLuong.Text));
                    if (f)
                    {
                        LoadData_DanhSachMonGoi();
                        //TinhTongTien();
                        MessageBox.Show("Đã thêm xong!");
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
            // Thêm dữ liệu 
            
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Chắc thoát  không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            string err = "";
            if (traloi == DialogResult.Yes)
            {
                this.Close();
                Global.GlobalVar = -1;
            }
            else
            {
                //MessageBox.Show("Lần sau nhớ suy nghĩ kỹ trước khi thoát nha!!!");
            }
        }
        
        private void FormGoiMon_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void FormGoiMon_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
