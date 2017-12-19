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
    public partial class F_BaoCaoPhieuNhap : Form
    {
        public F_BaoCaoPhieuNhap()
        {
            InitializeComponent();
        }

        BUSNV nv = new BUSNV();
        DataTable dtPN = null;
        DataTable dtNV = null;
        DataTable dtCT = null;
        string ma = "";
        int dem;
        int tongchi;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Load_PN(string tennv, string thang, string nam)
        {
            try
            {
                dtPN = new DataTable();
                dtPN.Clear();
                dtPN = nv.BaoCaoPN(tennv, thang, nam);
                dtgvPhieuNhap.DataSource = dtPN;
                dem = dtPN.Rows.Count;
                if(dem==0)
                {
                    dtgvPhieuNhap.Enabled = false;
                }
                else
                {
                    dtgvPhieuNhap.Enabled = true;
                }
                tongchi = (from DataGridViewRow row in dtgvPhieuNhap.Rows
                           where row.Cells[2].FormattedValue.ToString() != string.Empty
                           select Convert.ToInt32(row.Cells[2].FormattedValue)).Sum();
                lbTongChi.Text = tongchi.ToString();
                lbTongHD.Text = dem.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Load_PN_Ten(string tennv)
        {
            try
            {
                dtPN = new DataTable();
                dtPN.Clear();
                dtPN = nv.LayDSPN_NV(tennv);
                dtgvPhieuNhap.DataSource = dtPN;
                dem = dtPN.Rows.Count;
                if (dem == 0)
                {
                    dtgvPhieuNhap.Enabled = false;
                }
                else
                {
                    dtgvPhieuNhap.Enabled = true;
                }
                tongchi = (from DataGridViewRow row in dtgvPhieuNhap.Rows
                           where row.Cells[2].FormattedValue.ToString() != string.Empty
                           select Convert.ToInt32(row.Cells[2].FormattedValue)).Sum();
                lbTongChi.Text = tongchi.ToString();
                lbTongHD.Text = dem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Load_PN_Thang(string thang, string nam)
        {
            try
            {
                dtPN = new DataTable();
                dtPN.Clear();
                dtPN = nv.LayDSPN_Thang(thang, nam);
                dtgvPhieuNhap.DataSource = dtPN;
                dem = dtPN.Rows.Count;
                if (dem == 0)
                {
                    dtgvPhieuNhap.Enabled = false;
                }
                else
                {
                    dtgvPhieuNhap.Enabled = true;
                }
                tongchi = (from DataGridViewRow row in dtgvPhieuNhap.Rows
                           where row.Cells[2].FormattedValue.ToString() != string.Empty
                           select Convert.ToInt32(row.Cells[2].FormattedValue)).Sum();
                lbTongChi.Text = tongchi.ToString();
                lbTongHD.Text = dem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BaoCaoPhieuNhap_Load(object sender, EventArgs e)
        {
            Load_TenNV();
            dtgvCTPN.Visible = false;
            btnOK.Visible = false;
            cmbBoLoc.SelectedIndex = 0;
            cmbTenNV.SelectedIndex = 0;
            dtpMonth.ResetText();
            dtgvPhieuNhap.Enabled = false;
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
            if (cmbBoLoc.SelectedIndex == 1)
            {
                cmbTenNV.Enabled = true;
                dtpMonth.Enabled = false;
            }
            else if (cmbBoLoc.SelectedIndex == 2)
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

        private void dtgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvPhieuNhap.CurrentCell.RowIndex;
            ma = dtgvPhieuNhap.Rows[r].Cells[0].Value.ToString();
            cmbTenNV.SelectedValue = dtgvPhieuNhap.Rows[r].Cells[1].Value.ToString();
            dtpMonth.Text = dtgvPhieuNhap.Rows[r].Cells[3].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(cmbBoLoc.SelectedIndex==0)
            {
                Load_PN(cmbTenNV.SelectedValue.ToString(), dtpMonth.Value.Month.ToString(), dtpMonth.Value.Year.ToString());
            }
            else if(cmbBoLoc.SelectedIndex==1)
            {
                Load_PN_Ten(cmbTenNV.SelectedValue.ToString());
            }
            else if(cmbBoLoc.SelectedIndex==2)
            {
                Load_PN_Thang(dtpMonth.Value.Month.ToString(), dtpMonth.Value.Year.ToString());
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (ma=="")
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập");
            }
            else
            {
                try
                {
                    btnTim.Enabled = false;
                    btnChiTiet.Enabled = false;
                    dtgvPhieuNhap.Visible = false;
                    dtCT = new DataTable();
                    dtCT.Clear();
                    dtCT = nv.LayBangCTPN(ma);
                    dtgvCTPN.DataSource = dtCT;
                    dtgvCTPN.Visible = true;
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
            dtgvCTPN.Visible = false;
            dtgvPhieuNhap.Visible = true;
            btnTim.Enabled = true;
            btnChiTiet.Enabled = true;
            btnOK.Visible = false;
        }
    }
}
