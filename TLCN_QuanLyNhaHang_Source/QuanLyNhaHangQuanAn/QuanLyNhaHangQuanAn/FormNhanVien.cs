using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QuanLyNhaHangQuanAn
{
    public partial class FormNhanVien : Form
    {
        BUSNV nv = new BUSNV();

        // Chuỗi kết nối 
        string strConnectionString = @"Data Source=DESKTOP-B1PMH13\SQLEXPRESS;Initial Catalog=NhaHangQuanAn;Integrated Security=True";

        SqlConnection conn = null;
        SqlDataAdapter daNV = null;
        DataTable dtNV = null;


        public FormNhanVien()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                //dtNV = nv.LayBangNhanVien().Tables[0];
                dtNV = nv.LayBangNhanVien();
                // Đưa dữ liệu lên DataGridView  
                dtgvNhanVien.DataSource = dtNV;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien. Lỗi rồi!!!");
            }
        }

        
        

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            //txtMaNV.Enabled = false;
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0;
            txtMaNV.Focus();
            dtpNgaySinh.ResetText();
            LoadData();
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dtgvNhanVien.CurrentCell.RowIndex;
            //0
            this.txtMaNV.Text =
            dtgvNhanVien.Rows[r].Cells[0].Value.ToString();
            //1
            this.txtTenNV.Text =
            dtgvNhanVien.Rows[r].Cells[1].Value.ToString();
            //2
            this.txtLuong.Text = dtgvNhanVien.Rows[r].Cells[2].Value.ToString();
            //3
            this.txtSDT.Text = dtgvNhanVien.Rows[r].Cells[3].Value.ToString();
            //4
            dtpNgaySinh.Text = dtgvNhanVien.Rows[r].Cells[4].Value.ToString();
            //5
            this.txtDiaChi.Text = dtgvNhanVien.Rows[r].Cells[5].Value.ToString();
            //6
            this.cmbGioiTinh.Text = dtgvNhanVien.Rows[r].Cells[6].Value.ToString();
        }

        private void btnDongNV_Click(object sender, EventArgs e)
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

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            // Thêm dữ liệu 
            string err = "";
            // bool kt = true;
            try
            {
                if (txtTenNV.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên nhân viên", "Lỗi");
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Chưa nhập địa chỉ", "Lỗi");
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Chưa nhập SDT", "Lỗi");
                }
                else if (txtLuong.Text == "")
                {
                    MessageBox.Show("Chưa nhập lương", "Lỗi");
                }
                else
                {

                    if (IsNumber(txtSDT.Text) == false)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại kiểu số!", "Lỗi");
                        txtSDT.Text = "";
                        txtSDT.Focus();
                    }
                    else if (IsNumber(txtLuong.Text) == false)
                    {
                        MessageBox.Show("Vui lòng nhập lương kiểu số!", "Lỗi");
                        txtLuong.Text = "";
                        txtLuong.Focus();
                    }
                    else
                    {
                        // Lệnh Insert InTo 
                        bool f = nv.ThemNhanVien(ref err, this.txtTenNV.Text, this.dtpNgaySinh.Value,
                        this.txtDiaChi.Text, this.cmbGioiTinh.SelectedItem.ToString(), txtSDT.Text,
                        int.Parse(txtLuong.Text));

                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadData();
                            // Thông báo 
                            MessageBox.Show("Đã thêm xong!");
                        }
                        else
                        {
                            MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                if (txtTenNV.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên nhân viên", "Lỗi");
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Chưa nhập địa chỉ", "Lỗi");
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Chưa nhập SDT", "Lỗi");
                }
                else if (txtLuong.Text == "")
                {
                    MessageBox.Show("Chưa nhập lương", "Lỗi");
                }
                else
                {
                    if (IsNumber(txtSDT.Text) == false)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại kiểu số!", "Lỗi");
                        txtSDT.Text = "";
                        txtSDT.Focus();
                    }
                    else if (IsNumber(txtLuong.Text) == false)
                    {
                        MessageBox.Show("Vui lòng nhập lương kiểu số!", "Lỗi");
                        txtLuong.Text = "";
                        txtLuong.Focus();
                    }
                    else
                    {
                        // Lệnh Update 
                        bool f = nv.SuaNhanVien(ref err, txtMaNV.Text,
                        this.txtTenNV.Text, this.dtpNgaySinh.Value,
                        this.txtDiaChi.Text, this.cmbGioiTinh.SelectedItem.ToString(), txtSDT.Text, int.Parse(txtLuong.Text));
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadData();
                            // Thông báo 
                            MessageBox.Show("Đã cập nhật xong!");
                        }
                        else
                        {
                            MessageBox.Show("Đã cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không cập nhật được. Lỗi rồi!");
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dtgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMaNV =
                dtgvNhanVien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = nv.XoaNhanVien(ref err, strMaNV);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
        }
    }
}
