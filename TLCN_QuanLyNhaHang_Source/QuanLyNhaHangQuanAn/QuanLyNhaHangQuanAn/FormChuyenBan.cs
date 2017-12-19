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
    public partial class FormChuyenBan : Form
    {
        BUSNV nv = new BUSNV();
        DataTable dtNV = null;
        DataTable dtDO = null;

        public FormChuyenBan()
        {
            InitializeComponent();
        }

        string MaBan;
        string KhuVuc;
        string TrangThai;
        public FormChuyenBan(string maban, string khuvuc, string trangthai)
            : this()
        {
            MaBan = maban;
            KhuVuc = khuvuc;
            TrangThai = trangthai;
        }
        void LoadData_Ban()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                dtNV = nv.LayDuLieuBan();



                cmbBan.DataSource = dtNV;
                cmbMaBan.DataSource = dtNV;



                cmbMaBan.DisplayMember = dtNV.Columns["KhuVuc"].ToString();
                cmbBan.DisplayMember = dtNV.Columns["MaBan"].ToString();

                cmbMaBan.ValueMember = dtNV.Columns["KhuVuc"].ToString();
                cmbBan.ValueMember = dtNV.Columns["MaBan"].ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung lên combobox. Lỗi rồi!!!");
            }
        }
        string mahd;

        private void FormChuyenBan_Load(object sender, EventArgs e)
        {
            LoadData_Ban();
        }
        void CapNhatTrangThaiBan_Trong()
        {
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                bool f = nv.CapNhatTrangThaiBan(ref err, MaBan, "Trống");


                if (f)
                {
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
        void CapNhatTrangThaiBan_CoKhach()
        {
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                bool f = nv.CapNhatTrangThaiBan(ref err, cmbBan.SelectedValue.ToString(), "Mở bàn");


                if (f)
                {
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
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string err = "";
           
            //bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                //bool f = nv.ChuyenBan(ref err, mahd, cmbBan.SelectedValue.ToString());
                bool f;
                if (cmbBan.SelectedValue.ToString() == "Trống")
                    f = false;
                else
                    f = true;
                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 

                    // Thông báo 
                    //LoadData_MaChiTietPhieuNhap();
                    CapNhatTrangThaiBan_Trong();
                    CapNhatTrangThaiBan_CoKhach();
                    
                    MessageBox.Show("Đã chuyển bàn thành công xong!");


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

        private void FormChuyenBan_FormClosing(object sender, FormClosingEventArgs e) 
        {
           
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            fManager frmManager = new fManager();
            frmManager.closeForm();


            //this.Close();
        }
        
    }
}
