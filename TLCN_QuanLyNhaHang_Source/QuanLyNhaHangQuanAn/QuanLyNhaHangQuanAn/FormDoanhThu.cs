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
    public partial class FormDoanhThu : Form
    {
        BUSNV nv = new BUSNV();
        DataTable dtPN = null;
        DataTable dtHD = null;
        DataTable dtNV = null;
      
        int doanhthu;

        public FormDoanhThu()
        {
            InitializeComponent();
        }

        void Load_DSPN(string thang, string nam)
        {
            try
            {
                dtPN = new DataTable();
                dtPN.Clear();
                dtPN = nv.LayDSPN_Thang(thang, nam);
                dtgvDSPN.DataSource = dtPN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Load_DSHD(string thang, string nam)
        {
            try
            {
                dtHD = new DataTable();
                dtHD.Clear();
                dtHD = nv.LayDSHD_Thang(thang, nam);
                dtgvDSHD.DataSource = dtHD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Load_DSNV()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                dtNV = nv.LayDSNV_DoanhThu();
                dtgvDSNV.DataSource = dtNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            dtgvDSPN.Enabled = false;
            dtgvDSHD.Enabled = false;
            dtgvDSNV.Enabled = false;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Load_DSHD(dtpDate.Value.Month.ToString(), dtpDate.Value.Year.ToString());
            Load_DSPN(dtpDate.Value.Month.ToString(), dtpDate.Value.Year.ToString());
            Load_DSNV();
            lbTongChi.Text = (from DataGridViewRow row in dtgvDSPN.Rows
                              where row.Cells[2].FormattedValue.ToString() != string.Empty
                              select Convert.ToInt32(row.Cells[2].FormattedValue)).Sum().ToString();
            lbTongThu.Text = (from DataGridViewRow row in dtgvDSHD.Rows
                              where row.Cells[2].FormattedValue.ToString() != string.Empty
                              select Convert.ToInt32(row.Cells[2].FormattedValue)).Sum().ToString();
            lbLuong.Text = (from DataGridViewRow row in dtgvDSNV.Rows
                            where row.Cells[2].FormattedValue.ToString() != string.Empty
                            select Convert.ToInt32(row.Cells[2].FormattedValue)).Sum().ToString();
            doanhthu = int.Parse(lbTongThu.Text) - int.Parse(lbTongChi.Text) - int.Parse(lbLuong.Text);
            lbDoanhThu.Text = doanhthu.ToString();
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

        

        
    }
}
