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
    public partial class F_PhieuNhapKho : Form
    {
        //bool CheckQuyen;
        //string MaNhanVien;
        public F_PhieuNhapKho()
        {
            InitializeComponent();
            //CheckQuyen = Quyen;
            //MaNhanVien = MaNV;
        }
        BUSNV nv = new BUSNV();
        DataTable dtPN = null;
        DataTable dtMPN = null;
        DataTable dtTen = null;

        DateTime date;
        void Load_PhieuNhap()
        {
            try
            {
                dtPN = new DataTable();
                dtPN.Clear();
                dtPN = nv.LayDSPhieuNhap();
                dtgvPhieuNhap.DataSource = dtPN;

                if(dtPN.Rows.Count == 0)
                {
                    dtgvPhieuNhap.Enabled = false;
                }
                else
                {
                    dtgvPhieuNhap.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Load_MaPNK()
        {
            try
            {
                dtMPN = new DataTable();
                dtMPN.Clear();
                dtMPN = nv.LayDSPhieuNhap();

                cmbMaPNK.DataSource = dtMPN;
                cmbMaPNK.DisplayMember = dtMPN.Columns["MaPNK"].ToString();
                cmbMaPNK.ValueMember = dtMPN.Columns["MaPNK"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Load_TenNV()
        {
            try
            {
                dtTen = new DataTable();
                dtTen.Clear();
                dtTen = nv.LayBangNhanVien();

                cmbTenNV.DataSource = dtTen;
                cmbTenNV.DisplayMember = dtTen.Columns["TenNV"].ToString();
                cmbTenNV.ValueMember = dtTen.Columns["TenNV"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void F_PhieuNhapKho_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            cmbTim.SelectedIndex = 0;
            Load_PhieuNhap();
            Load_MaPNK();
            Load_TenNV();
            //cmbMaPNK.SelectedIndex = 0;
            cmbTenNV.SelectedIndex = 0;
        }
        void Load_DSPN_Ma(string mapnk)
        {
            dtPN = new DataTable();
            dtPN.Clear();
            dtPN = nv.LayDSPN_Ma(mapnk);
            dtgvPhieuNhap.DataSource = dtPN;
            if(dtPN.Rows.Count == 0)
            {
                dtgvPhieuNhap.Enabled = false;
            }
            else
            {
                dtgvPhieuNhap.Enabled = true;
            }
        }
        void Load_DSPN_TenNV(string tenNV)
        {
            dtPN = new DataTable();
            dtPN.Clear();
            dtPN = nv.LayDSPN_NV(tenNV);
            dtgvPhieuNhap.DataSource = dtPN;
            if (dtPN.Rows.Count == 0)
            {
                dtgvPhieuNhap.Enabled = false;
            }
            else
            {
                dtgvPhieuNhap.Enabled = true;
            }
        }
        void Load_DSPN_Thang(string thang, string nam)
        {
            dtPN = new DataTable();
            dtPN.Clear();
            dtPN = nv.LayDSPN_Thang(thang, nam);
            dtgvPhieuNhap.DataSource = dtPN;
            if (dtPN.Rows.Count == 0)
            {
                dtgvPhieuNhap.Enabled = false;
            }
            else
            {
                dtgvPhieuNhap.Enabled = true;
            }
        }
        private void btnLietKe_Click(object sender, EventArgs e)
        {
            if(cmbTim.SelectedIndex == 1)
            {
                try
                {
                    Load_DSPN_Ma(cmbMaPNK.SelectedValue.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(cmbTim.SelectedIndex == 2)
            {
                try
                {
                    Load_DSPN_TenNV(cmbTenNV.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(cmbTim.SelectedIndex == 3)
            {
                try
                {
                    Load_DSPN_Thang(dtpDate1.Value.Month.ToString(), dtpDate1.Value.Year.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTim.SelectedIndex == 1)
            {
                cmbMaPNK.Enabled = true;
                cmbTenNV.Enabled = false;
                dtpDate1.Enabled = false;
            }
            if (cmbTim.SelectedIndex == 2)
            {
                cmbMaPNK.Enabled = false;
                cmbTenNV.Enabled = true;
                dtpDate1.Enabled = false;
            }
            if (cmbTim.SelectedIndex == 3)
            {
                cmbMaPNK.Enabled = false;
                cmbTenNV.Enabled = false;
                dtpDate1.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = "";
            date = DateTime.Today;
            try
            {
                bool f = nv.ThemPhieuNhap(ref err, cmbTenNV.SelectedValue.ToString(), date);
                if(f)
                {
                    MessageBox.Show("Thêm mới phiếu nhập kho");
                    string maPNK;
                    DataTable dtma = new DataTable();
                    dtma.Clear();
                    dtma = nv.LayMaPNK();
                    maPNK = dtma.Rows[0][0].ToString();
                    F_ChiTietPhieuNhap ct = new F_ChiTietPhieuNhap(maPNK, cmbTenNV.SelectedValue.ToString(), date);
                    this.Hide();
                    ct.Show();
                }
                else
                {
                    MessageBox.Show("Không thêm được!\n\r Lỗi! " + err);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                //MessageBox.Show("Lần sau nhớ suy nghĩ kỹ trước khi thoát nha!!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            F_ChiTietPhieuNhap f = new F_ChiTietPhieuNhap(cmbMaPNK.SelectedValue.ToString(), cmbTenNV.SelectedValue.ToString(), dtpDate1.Value);
            this.Close();
            f.Show();
        }

        private void dtgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvPhieuNhap.CurrentCell.RowIndex;
            cmbMaPNK.Text = dtgvPhieuNhap.Rows[r].Cells[0].Value.ToString();
            cmbTenNV.Text = dtgvPhieuNhap.Rows[r].Cells[1].Value.ToString();
            dtpDate1.Text = dtgvPhieuNhap.Rows[r].Cells[3].Value.ToString();
        }
        
    }
}
