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
    public partial class FormTaiKhoan : Form
    {
        BUSNV nv = new BUSNV();
        bool Them;
        // Chuỗi kết nối 
        string strConnectionString = @"Data Source=DESKTOP-B1PMH13\SQLEXPRESS;Initial Catalog=NhaHangQuanAn;Integrated Security=True";
        // Đối tượng kết nối 
        SqlConnection conn = null;

        SqlDataAdapter daNV = null;

        DataTable dtNV = null;
        public FormTaiKhoan()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                dtNV = nv.LayBangNguoiDung();
                // Đưa dữ liệu lên DataGridView  
                dtgvTaiKhoan.DataSource = dtNV;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NguoiDung. Lỗi rồi!!!");
            }
        }
        void LoadData_TenNhanVien()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                dtNV = nv.LayDuLieuTenNhanVien();



                cmbTenNV.DataSource = dtNV;
                cmbMaNV.DataSource = dtNV;



                cmbMaNV.DisplayMember = dtNV.Columns["MaNV"].ToString();
                cmbTenNV.DisplayMember = dtNV.Columns["TenNV"].ToString();

                cmbMaNV.ValueMember = dtNV.Columns["MaNV"].ToString();
                cmbTenNV.ValueMember = dtNV.Columns["TenNV"].ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung lên combobox. Lỗi rồi!!!");
            }
        }
        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData_TenNhanVien();
            //txtMaTK.Enabled = false;
        }

        private void btnDongTK_Click(object sender, EventArgs e)
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
            }
            else
            {
                //MessageBox.Show("Lần sau nhớ suy nghĩ kỹ trước khi thoát nha!!!");
            }
        }

        //private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int r = dtgvTaiKhoan.CurrentCell.RowIndex;
        //    this.txtMaTK.Text =
        //    dtgvTaiKhoan.Rows[r].Cells[0].Value.ToString();
        //    this.txtTenDN.Text =
        //    dtgvTaiKhoan.Rows[r].Cells[1].Value.ToString();
        //    this.txtPass.Text =
        //   dtgvTaiKhoan.Rows[r].Cells[2].Value.ToString();
        //    this.cmbTenNV.SelectedValue =
        //   dtgvTaiKhoan.Rows[r].Cells[3].Value.ToString();
        //}

        //private void btnThemTK_Click(object sender, EventArgs e)
        //{
        //    // Thêm dữ liệu 
        //    string err = "";
        //    // bool kt = true;
        //    try
        //    {
        //        if (txtTenDN.Text == "")
        //        {
        //            MessageBox.Show("Chưa nhập tên đăng nhập", "Lỗi");

        //        }
        //        else if (txtPass.Text == "")
        //        {
        //            MessageBox.Show("Chưa nhập mật khẩu", "Lỗi");
        //        }

        //        else
        //        {

        //            // Lệnh Insert InTo 
        //            bool f = nv.ThemTaiKhoan(ref err,txtMaTK.Text, txtTenDN.Text, txtPass.Text, cmbMaNV.SelectedValue.ToString());

        //            if (f)
        //            {
        //                // Load lại dữ liệu trên DataGridView 
        //                LoadData();
        //                // Thông báo 
        //                MessageBox.Show("Đã thêm xong!");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
        //            }
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show("Không thêm được. Lỗi rồi!");
        //    }
        //}
    }
}
