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
    public partial class FormNguyenLieu : Form
    {
        BUSNV nv = new BUSNV();
        DataTable dt = null;

        public FormNguyenLieu()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                //dtNV = nv.LayBangNhanVien().Tables[0];
                dt = nv.LayBangNguyenLieu();
                // Đưa dữ liệu lên DataGridView  
                dtgvNguyenLieu.DataSource = dt;
                if(dt.Rows.Count == 0)
                {
                    dtgvNguyenLieu.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void FormNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = "";
            if (txtTenNL.Text == "")
            {
                MessageBox.Show("Nhập tên nguyên liệu");
            }
            else if (txtDonVi.Text == "")
            {
                MessageBox.Show("Nhập đơn vị tính");
            }
            else
            {
                try
                {
                    bool f = nv.ThemNguyenLieu(ref err, txtTenNL.Text, txtDonVi.Text);
                    if (f)
                    {
                        MessageBox.Show("Thêm thành công");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thêm được! Lỗi!\n\r" + err);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc thoát  không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                
            }
        }

        private void dtgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvNguyenLieu.CurrentCell.RowIndex;
            lbMaNL.Text = dtgvNguyenLieu.Rows[r].Cells[0].Value.ToString();
            txtTenNL.Text = dtgvNguyenLieu.Rows[r].Cells[1].Value.ToString();
            txtDonVi.Text = dtgvNguyenLieu.Rows[r].Cells[2].Value.ToString();
            txtSLTon.Text = dtgvNguyenLieu.Rows[r].Cells[3].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string err = "";
            if (lbMaNL.Text=="")
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu muốn sửa");
            }
            else if (txtTenNL.Text == "")
            {
                MessageBox.Show("Nhập tên nguyên liệu");
            }
            else if (txtDonVi.Text == "")
            {
                MessageBox.Show("Nhập đơn vị tính");
            }
            else if (txtSLTon.Text == "" || IsNumber(txtSLTon.Text) == false)
            {
                MessageBox.Show("Nhập số lượng tồn là kiểu số");
            }
            else
            {
                try
                {
                    bool f = nv.SuaNguyenLieu(ref err, lbMaNL.Text, txtTenNL.Text, txtDonVi.Text, int.Parse(txtSLTon.Text));
                    if (f)
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không sửa được! Lỗi!\n\r" + err);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string err = "";
            if (lbMaNL.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu muốn xóa");
            }
            else
            {
                DialogResult xoa;
                xoa = MessageBox.Show("Chắc chắn xóa nguyên liệu '" + lbMaNL + "' không?", "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(xoa == DialogResult.Yes)
                {
                    try
                    {
                        bool f = nv.XoaNguyenLieu(ref err, lbMaNL.Text);
                        if(f)
                        {
                            MessageBox.Show("Đã xóa xong");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa! Lỗi!\n\r" + err);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
