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
    public partial class F_ChiTietPhieuNhap : Form
    {
        BUSNV nv = new BUSNV();
        DataTable dtCT = null;
        DataTable dtNL = null;
        string MaPNK, TenNV, NgayNhap;
        string mact;
        public F_ChiTietPhieuNhap(string mapnk, string tennv, DateTime ngaynhap)
        {
            InitializeComponent();
            MaPNK = mapnk;
            TenNV = tennv;
            NgayNhap = ngaynhap.ToShortDateString();
        }
        void Load_CTPN()
        {
            try
            {
                dtCT = new DataTable();
                dtCT.Clear();
                dtCT = nv.LayBangCTPN(MaPNK);

                dtgvChiTiet.DataSource = dtCT;
                if(dtCT.Rows.Count == 0)
                {
                    dtgvChiTiet.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void load_TenNguyenLieu()
        {
            try
            {
                dtNL = new DataTable();
                dtNL.Clear();
                dtNL = nv.LayBangNguyenLieu();

                cmbTenNL.DataSource = dtNL;
                cmbTenNL.DisplayMember = dtNL.Columns["TenNguyenLieu"].ToString();
                cmbTenNL.ValueMember = dtNL.Columns["TenNguyenLieu"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void F_ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            lbMaPNK.Text = MaPNK;
            lbTenNV.Text = TenNV;
            lbNgayLap.Text = NgayNhap;
            Load_CTPN();
            load_TenNguyenLieu();
            cmbTenNL.SelectedIndex = 0;
        }

        private void dtgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvChiTiet.CurrentCell.RowIndex;
            mact = dtgvChiTiet.Rows[r].Cells[0].Value.ToString();
            cmbTenNL.SelectedValue = dtgvChiTiet.Rows[r].Cells[1].Value.ToString();
            txtDonGia.Text = dtgvChiTiet.Rows[r].Cells[2].Value.ToString();
            txtSLNhap.Text = dtgvChiTiet.Rows[r].Cells[3].Value.ToString();
        }

        private void btnNL_Click(object sender, EventArgs e)
        {
            FormNguyenLieu f = new FormNguyenLieu();
            f.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_CTPN();
            load_TenNguyenLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                bool f = nv.ThemCTPN(ref err, MaPNK, cmbTenNL.SelectedValue.ToString(), int.Parse(txtDonGia.Text), int.Parse(txtSLNhap.Text));
                if(f)
                {
                    MessageBox.Show("Thêm thành công");
                    Load_CTPN();
                }
                else
                {
                    MessageBox.Show("Không thêm được!\n\r" + "Lỗi! " + err);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                bool f = nv.SuaCTPN(ref err, mact, MaPNK, cmbTenNL.SelectedValue.ToString(), int.Parse(txtDonGia.Text), int.Parse(txtSLNhap.Text));
                if (f)
                {
                    MessageBox.Show("Thêm thành công");
                    Load_CTPN();
                }
                else
                {
                    MessageBox.Show("Không thêm được!\n\r" + "Lỗi! " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dia; 
            dia = MessageBox.Show("Chắc chắn muốn xóa không?", "Trả lời",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.Yes)
            {
                string err = "";
                try
                {
                    bool f = nv.XoaCTPN(ref err, mact, MaPNK);
                    if (f)
                    {
                        MessageBox.Show("Đã xóa");
                        Load_CTPN();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi! " + err);
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
                F_PhieuNhapKho f = new F_PhieuNhapKho();
                this.Close();
                f.Show();
            }
            else
            {
                //MessageBox.Show("Lần sau nhớ suy nghĩ kỹ trước khi thoát nha!!!");
            }
        }


    }
}
