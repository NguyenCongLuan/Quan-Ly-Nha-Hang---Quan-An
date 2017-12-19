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
    public partial class fDangNhap : Form
    {
        DataTable dt;
        BUSNV nv = new BUSNV();
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //fManager f = new fManager();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();

            if (txtDangNhap.Text == "")
            {
                MessageBox.Show("Chưa nhập tên người dùng", "Thông báo");
            }
            else if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu", "Thông báo");
            }
            else
            {
                if (cbChuQuan.Checked == true)
                {
                    if (txtDangNhap.Text == "admin" && txtMatKhau.Text == "admin")
                    {
                        fManager fr = new fManager(true, "admin");
                        this.Hide();
                        fr.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "Thông báo");
                    }
                }
                else
                {
                    KiemTraDangNhap();
                }

            }
        }
        string MaNV;
        public void KiemTraDangNhap()
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                dt = nv.LayDuLieuBangNguoiDung(txtDangNhap.Text, txtMatKhau.Text);

                if (dt.Rows.Count > 0)
                {
                    //textBox1.Text = dr["MaNhanVien"].ToString();
                    DataRow dr = dt.Rows[0];
                    MaNV = dr["MaNV"].ToString();
                    fManager frm = new fManager(false, MaNV);
                    frm.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "Thông báo");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung .......... Lỗi rồi!!!");
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMatKhau.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            cbChuQuan.Checked = true;
        }
    }
}
