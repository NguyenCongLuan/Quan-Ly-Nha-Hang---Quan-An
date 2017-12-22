using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace QuanLyNhaHangQuanAn
{
    public partial class FormInHoaDon : Form
    {
        BUSNV nv = new BUSNV();
        DataTable dtMonGoi1 = null;
        public FormInHoaDon()
        {
            InitializeComponent();
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
        }
        string MaOrder;
        string MaNhanVien;
        string Ban;
        string TongTien;
        public FormInHoaDon(string MaPhieuOrder, string MaNV, string MaBan, string TongThanhToan)
            : this()
        {
            MaOrder = MaPhieuOrder;
            MaNhanVien = MaNV;
            Ban = MaBan;
            TongTien = TongThanhToan;
        }
        string ConnStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=NhaHangQuanAn;Integrated Security=True";
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=NhaHangQuanAn;Integrated Security=True");

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        void LoadData_DanhSachMonGoi()
        {
            try
            {
                //int MaPhieuOrder;
                dtMonGoi1 = new DataTable();
                dtMonGoi1.Clear();
                dtMonGoi1 = nv.LayDuLieuDanhSachMonGoi(MaOrder);
                // Đưa dữ liệu lên DataGridView  
                RptHoaDon hd = new RptHoaDon();
                hd.SetDataSource(dtMonGoi1);
                hd.SetParameterValue("MaPhieuOrder", MaOrder);
                hd.SetParameterValue("Ban", Ban);
                hd.SetParameterValue("MaNV", MaNhanVien);
                hd.SetParameterValue("TongThanhToan", TongTien);
                crystalReportViewer1.ReportSource = hd;

                //dgvChiTietO.DataSource = dtMonGoi1;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table ChiTietHoaDon. Lỗi rồi!!!");
            }
        }
        private void FormInHoaDon_Load(object sender, EventArgs e)
        {
            LoadData_DanhSachMonGoi();
            //SqlCommand comd = new SqlCommand("LayDuLieuDanhSachMonGoi",con);
            //comd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(comd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //con.Close();
            //RptHoaDon hd = new RptHoaDon();
            //hd.SetDataSource(dt);
            //hd.SetParameterValue("MaPhieuNhap", "1");
            //crystalReportViewer1.ReportSource = hd;
        }
    }
}
