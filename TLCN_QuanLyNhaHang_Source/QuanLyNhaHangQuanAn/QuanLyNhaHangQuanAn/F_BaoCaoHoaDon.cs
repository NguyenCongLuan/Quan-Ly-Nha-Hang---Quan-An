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
    public partial class F_BaoCaoHoaDon : Form
    {
        public F_BaoCaoHoaDon()
        {
            InitializeComponent();
        }

        BUSNV nv = new BUSNV();
        DataTable dtHD = null;
        DataTable dtNV = null;
        DataTable dtCT = null;
        string ma = "";
        int dem;
        int doanhthu;

        void Load_TenNV()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                dtNV = nv.LayBangNhanVien();
                cmbTenNV.DataSource = dtNV;
                cmbTenNV.DisplayMember = dtNV.Columns["TenNV"].ToString();
                cmbTenNV.ValueMember = dtNV.Columns["TenNV"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Load_HD(string tennv, string thang, string nam)
        {
            try
            {
                dtHD = new DataTable();
                dtHD.Clear();
                dtHD = nv.BaoCaoHD(tennv, thang, nam);
                dtgvHoaDon.DataSource = dtHD;
                dem = dtHD.Rows.Count;
                if (dem == 0)
                {
                    dtgvHoaDon.Enabled = false;
                }
                else
                {
                    dtgvHoaDon.Enabled = true;
                }
                doanhthu = (from DataGridViewRow row in dtgvHoaDon.Rows
                            where row.Cells[5].FormattedValue.ToString() != string.Empty
                            select Convert.ToInt32(row.Cells[5].FormattedValue)).Sum();
                lbDoanhThu.Text = doanhthu.ToString();
                lbTongHD.Text = dem.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Load_HD_TenNV(string tennv)
        {
            try
            {
                dtHD = new DataTable();
                dtHD.Clear();
                dtHD = nv.BaoCaoHD_TenNV(tennv);
                dtgvHoaDon.DataSource = dtHD;
                dem = dtHD.Rows.Count;
                if (dem == 0)
                {
                    dtgvHoaDon.Enabled = false;
                }
                else
                {
                    dtgvHoaDon.Enabled = true;
                }
                doanhthu = (from DataGridViewRow row in dtgvHoaDon.Rows
                            where row.Cells[5].FormattedValue.ToString() != string.Empty
                            select Convert.ToInt32(row.Cells[5].FormattedValue)).Sum();
                lbDoanhThu.Text = doanhthu.ToString();
                lbTongHD.Text = dem.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Load_HD_Thang(string thang, string nam)
        {
            try
            {
                dtHD = new DataTable();
                dtHD.Clear();
                dtHD = nv.BaoCaoHD_Thang(thang, nam);
                dtgvHoaDon.DataSource = dtHD;
                dem = dtHD.Rows.Count;
                if(dem == 0)
                {
                    dtgvHoaDon.Enabled = false;
                }
                else
                {
                    dtgvHoaDon.Enabled = true;
                }
                doanhthu = (from DataGridViewRow row in dtgvHoaDon.Rows
                            where row.Cells[5].FormattedValue.ToString() != string.Empty
                            select Convert.ToInt32(row.Cells[5].FormattedValue)).Sum();
                lbDoanhThu.Text = doanhthu.ToString();
                lbTongHD.Text = dem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BaoCaoHD_Load(object sender, EventArgs e)
        {
            Load_TenNV();
            dtgvCTHD.Visible = false;
            btnOK.Visible = false;
            cmbBoLoc.SelectedIndex = 0;
            cmbTenNV.SelectedIndex = 0;
            dtpMonth.ResetText();
            dtgvHoaDon.Enabled = false;
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
                //MessageBox.Show("Lần sau nhớ suy nghĩ kỹ trước khi thoát nha!!!");
            }
        }

        private void cmbBoLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoLoc.SelectedIndex == 1)
            {
                cmbTenNV.Enabled = true;
                dtpMonth.Enabled = false;
            }
            else if(cmbBoLoc.SelectedIndex == 2)
            {
                cmbTenNV.Enabled = false;
                dtpMonth.Enabled = true;
            }
            else
            {
                cmbTenNV.Enabled = true;
                dtpMonth.Enabled = true;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(cmbBoLoc.SelectedIndex==0)
            {
                Load_HD(cmbTenNV.SelectedValue.ToString(), dtpMonth.Value.Month.ToString(), dtpMonth.Value.Year.ToString());
            }
            else if(cmbBoLoc.SelectedIndex==1)
            {
                Load_HD_TenNV(cmbTenNV.SelectedValue.ToString());
            }
            else if(cmbBoLoc.SelectedIndex==2)
            {
                Load_HD_Thang(dtpMonth.Value.Month.ToString(), dtpMonth.Value.Year.ToString());
            }
        }

        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvHoaDon.CurrentCell.RowIndex;
            ma = dtgvHoaDon.Rows[r].Cells[0].Value.ToString();
            cmbTenNV.SelectedValue = dtgvHoaDon.Rows[r].Cells[2].Value.ToString();
            dtpMonth.Text = dtgvHoaDon.Rows[r].Cells[6].Value.ToString();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if(ma == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!");
            }
            else
            {
                try
                {
                    btnTim.Enabled = false;
                    btnChiTiet.Enabled = false;
                    dtgvHoaDon.Visible = false;
                    dtCT = new DataTable();
                    dtCT.Clear();
                    dtCT = nv.BaoCaoCTHD(ma);
                    dtgvCTHD.DataSource = dtCT;
                    dtgvCTHD.Visible = true;
                    btnOK.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dtgvCTHD.Visible = false;
            dtgvHoaDon.Visible = true;
            btnTim.Enabled = true;
            btnChiTiet.Enabled = true;
            btnOK.Visible = false;
        }

    }
}
