using BUS;
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

namespace QuanLyNhaHangQuanAn
{
    public partial class fManager : Form
    {
        //string ConnStr = @"Data Source=DESKTOP-B1PMH13\SQLEXPRESS;Initial Catalog=NhaHangQuanAn;Integrated Security=True";
        //SqlConnection con;
        //SqlDataAdapter da;
        //DataTable dt;
        BUSNV nv = new BUSNV();
        //bool Them;

        SqlDataAdapter daNV = null;

        DataTable dtNV = null;
        DataTable dtMaOrder1 = null;
        DataTable dtMonGoi1 = null;

        //string MaNhanVien;
        //bool CheckQuyen;

        public fManager()
        {
            InitializeComponent();
        }

        //private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FormNhanVien f = new FormNhanVien();
        //    f.ShowDialog();
        //}
        bool CheckQuyen;
        string MaNV;

        public fManager(bool quyen, string manv) : this()
        {
            CheckQuyen = quyen;
            MaNV = manv;
        }
        public void LoadData()
        {
            dtNV = new DataTable();
            dtNV.Clear();
            dtNV = nv.LayDuLieuTable_Ban();
            dgvBan.DataSource = dtNV;

            Button[] bt = new Button[30];
            bt[0] = SV01;
            bt[1] = SV02;
            bt[2] = SV03;
            bt[3] = SV04;
            bt[4] = SV05;
            bt[5] = SV06;
            bt[6] = SV07;
            bt[7] = SV08;
            bt[8] = SV09;
            bt[9] = TN01;
            bt[10] = TN02;
            bt[11] = TN03;
            bt[12] = TN04;
            bt[13] = TN05;
            bt[14] = TN06;
            bt[15] = TN07;
            bt[16] = TN08;
            bt[17] = TN09;
            bt[18] = L101;
            bt[19] = L102;
            bt[20] = L103;
            bt[21] = L104;
            bt[22] = L105;
            bt[23] = L106;
            bt[24] = L107;
            bt[25] = L108;
            bt[26] = L109;

            for (int i = 0; i <= dgvBan.Rows.Count - 1; i++)
            {
                if (dgvBan.Rows[i].Cells[2].Value.ToString() == "Đang gọi món")
                {
                    //a[i] = dgvTestBan.Rows[i].Cells[3].Value.ToString();
                    bt[i].BackColor = Color.Red;
                    //bt[i].BackColor = Color.Red;
                }
                else if (dgvBan.Rows[i].Cells[2].Value.ToString() == "Trống")
                {
                    bt[i].BackColor = Color.White;
                }
                else if (dgvBan.Rows[i].Cells[2].Value.ToString() == "Mở bàn")
                {
                    bt[i].BackColor = Color.LightGray;
                }
                else if (dgvBan.Rows[i].Cells[2].Value.ToString() == "Đang làm")
                {
                    bt[i].BackColor = Color.LightSeaGreen;
                }
                else
                {
                    bt[i].BackColor = Color.DarkRed;
                }

            }
            //for (int i = 0; i < dgvBan.Rows.Count - 1; i++)
            //{
            //    if (dgvBan.Rows[i].Cells[2].Value.ToString() == "Trống")
            //    {
            //        //a[i] = dgvTestBan.Rows[i].Cells[3].Value.ToString();
            //        bt[i].BackColor = Color.Red;
            //        //bt[i].BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        //todo
            //    }
            //}
        }

        void LoadData_MaPhieuOrder_1()
        {
            int r = dgvBan.CurrentCell.RowIndex;
            string strMaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
            string strTrangThaiBan = dgvBan.Rows[r].Cells[2].Value.ToString();
            if (strTrangThaiBan == "Trống" || strTrangThaiBan == "Mở bàn")
            {
                MessageBox.Show("Chưa có khách Order cho bàn này ");
            }
            else
            {
                try
                {
                    //dtMaOrder1 = new DataTable();
                    dtMaOrder1 = new DataTable();
                    dtMaOrder1.Clear();
                    dtMaOrder1 = nv.LayDuLieu_MaPhieuOrder_TheoMaBan(strMaBan);

                    DataRow dr = dtMaOrder1.Rows[0];
                    txtMaPhieuO.Text = dr["MaPhieuOrder"].ToString();


                }
                catch (SqlException)
                {
                    MessageBox.Show("Không lấy được nội dung trong table PhieuOrder. Lỗi rồi!!!");
                }
            }
        }
        void LoadData_DanhSachMonGoi()
        {
            try
            {
                dtMonGoi1 = new DataTable();
                dtMonGoi1.Clear();
                dtMonGoi1 = nv.LayDuLieuDanhSachMonGoi(txtMaPhieuO.Text);
                // Đưa dữ liệu lên DataGridView  

                dgvChiTietO.DataSource = dtMonGoi1;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table ChiTietHoaDon. Lỗi rồi!!!");
            }
        }

        public void LoadData_Order()
        {
            int r = dgvBan.CurrentCell.RowIndex;
            string strMaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
            string strTrangThaiBan = dgvBan.Rows[r].Cells[2].Value.ToString();
            if (strTrangThaiBan != "Trống" || strTrangThaiBan != "Mở bàn")
            {
                LoadData_MaPhieuOrder_1();
            }

        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fManager_Load(object sender, EventArgs e)
        {
            //if(Global.GlobalVar == -1)
            //{
            //    LoadData();
            //}
            lbMaNV.Text = MaNV;
            gbchuyenban.Visible = false;
            //gbGoiMon.Visible = false;
            LoadData();
            dgvBan.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvBan.ReadOnly = true;
            dgvBan.ClearSelection();
            //dgvBan.RowHeadersVisible = false;


            //dgvBan.Rows[1].Selected = true;
            PictureBox pb = new PictureBox();
            //pb.Image = Image.FromFile(@"C:\121.png");

            //pb.SizeMode = PictureBoxSizeMode.AutoSize;
            //this.Controls.Add(pb);
            //this.Size = pb.Size;

            if (CheckQuyen == false)
            {

                menuTaiKhoan.Enabled = false;
                menuNhanVien.Enabled = false;

                //Phuc vu dang nhap
                //quảnLýToolStripMenuItem.Visible = false;
                //thốngKêToolStripMenuItem.Visible = false;


            }
            if (CheckQuyen == true)
            {
                //mnsQuanLyBan.Enabled = false;
                btnGoiMon.Visible = false;
                btnXuatHoaDon.Visible = false;
                gbGhepban.Visible = false;
                gbThaotacban.Visible = false;
                gbPhieuOrder.Visible = false;
                btnXuatHoaDon.Visible = false;
                gbSanVuon.Visible = false;
                gbTrongNha.Visible = false;
                gbLau1.Visible = false;
                dgvBan.Visible = false;
            }



        }

        //CHUYEN BAN FORM
        DataTable dtCb = null;
        void LoadData_Ban()
        {
            try
            {
                dtCb = new DataTable();
                dtCb.Clear();
                dtCb = nv.LayDuLieuBan();



                cmbBan.DataSource = dtCb;
                cmbMaBan.DataSource = dtCb;



                cmbMaBan.DisplayMember = dtCb.Columns["KhuVuc"].ToString();
                cmbBan.DisplayMember = dtCb.Columns["MaBan"].ToString();

                cmbMaBan.ValueMember = dtCb.Columns["KhuVuc"].ToString();
                cmbBan.ValueMember = dtCb.Columns["MaBan"].ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung lên combobox. Lỗi rồi!!!");
            }
        }
        void CapNhatTrangThaiBan_Trong()
        {
            int r = dgvBan.CurrentCell.RowIndex;
            string strMaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
            //string strKhuVuc = dgvBan.Rows[r].Cells[1].Value.ToString();
            //string strTrangThaiBan = dgvBan.Rows[r].Cells[2].Value.ToString();
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                bool f = nv.CapNhatTrangThaiBan(ref err, strMaBan, "Trống");


                if (f)
                {
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                }

            }

            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }
        void CapNhatTrangThaiBan_CoKhach()
        {
            string err = "";
            bool kt = true;
            try
            {


                // Lệnh Insert InTo 
                bool f = nv.CapNhatTrangThaiBan(ref err, cmbBan.SelectedValue.ToString(), "Mở bàn");


                if (f)
                {
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                }

            }

            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }
        //CHUYEN BAN FORM





        public void closeForm()
        {
            this.LoadData();
        }
        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_PhieuNhapKho f = new F_PhieuNhapKho();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormNhanVien f = new FormNhanVien();
            f.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTaiKhoan f = new FormTaiKhoan();
            f.ShowDialog();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nguyênLiêuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNguyenLieu f = new FormNguyenLieu();
            f.ShowDialog();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnMoBan_Click(object sender, EventArgs e)
        {
            Button[] bt = new Button[30];
            bt[0] = SV01;
            bt[1] = SV02;
            bt[2] = SV03;
            bt[3] = SV04;
            bt[4] = SV05;
            bt[5] = SV06;
            bt[6] = SV07;
            bt[7] = SV08;
            bt[8] = SV09;
            bt[9] = TN01;
            bt[10] = TN02;
            bt[11] = TN03;
            bt[12] = TN04;
            bt[13] = TN05;
            bt[14] = TN06;
            bt[15] = TN07;
            bt[16] = TN08;
            bt[17] = TN09;
            bt[18] = L101;
            bt[19] = L102;
            bt[20] = L103;
            bt[21] = L104;
            bt[22] = L105;
            bt[23] = L106;
            bt[24] = L107;
            bt[25] = L108;
            bt[26] = L109;
            int r = dgvBan.CurrentCell.RowIndex;
            if (dgvBan.Rows[r].Cells[2].Value.ToString() == "Trống")
            {
                bt[r].BackColor = Color.LightGray;
                string err = "";
                string MaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
                bool f = nv.CapNhatMoBan(ref err, MaBan);
                LoadData();
                //dgvBan.Row[r].Cell[2].Value.ToString() == "Đang gọi món";
            }
            else
            {
                //
            }
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            Button[] bt = new Button[30];
            bt[0] = SV01;
            bt[1] = SV02;
            bt[2] = SV03;
            bt[3] = SV04;
            bt[4] = SV05;
            bt[5] = SV06;
            bt[6] = SV07;
            bt[7] = SV08;
            bt[8] = SV09;
            bt[9] = TN01;
            bt[10] = TN02;
            bt[11] = TN03;
            bt[12] = TN04;
            bt[13] = TN05;
            bt[14] = TN06;
            bt[15] = TN07;
            bt[16] = TN08;
            bt[17] = TN09;
            bt[18] = L101;
            bt[19] = L102;
            bt[20] = L103;
            bt[21] = L104;
            bt[22] = L105;
            bt[23] = L106;
            bt[24] = L107;
            bt[25] = L108;
            bt[26] = L109;
            int r = dgvBan.CurrentCell.RowIndex;
            if (dgvBan.Rows[r].Cells[2].Value.ToString() == "Mở bàn" || dgvBan.Rows[r].Cells[2].Value.ToString() == "Đang gọi món")
            {
                bt[r].BackColor = Color.White;
                string err = "";
                string MaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
                bool f = nv.CapNhatHuyBan(ref err, MaBan);
                LoadData();
                //dgvBan.Row[r].Cell[2].Value.ToString() == "Đang gọi món";
            }
            else
            {
                //
            }
            //gbThaotacban.Visible = !gbThaotacban.Visible;
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {

            int r = dgvBan.CurrentCell.RowIndex;
            //string strMaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
            //string strKhuVuc = dgvBan.Rows[r].Cells[1].Value.ToString();
            string strTrangThaiBan = dgvBan.Rows[r].Cells[2].Value.ToString();

            if (strTrangThaiBan != "Mở bàn")
            {
                MessageBox.Show("Chỉ được chuyển bàn khi có khách và chưa gọi món!", "Thông báo");
            }
            else
            {
                LoadData_Ban();
                gbchuyenban.Visible = !gbchuyenban.Visible;
            }
        }

        private void btnGoiMon_Click(object sender, EventArgs e)
        {
            int r = dgvBan.CurrentCell.RowIndex;

            string strMaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
            //string strTenBan = dgvBan.Rows[r].Cells[1].Value.ToString();
            string strTrangThaiBan = dgvBan.Rows[r].Cells[2].Value.ToString();


            if (strTrangThaiBan == "Trống")
            {
                MessageBox.Show("Chỉ được gọi món khi có khách !", "Thông báo");
            }
            else if (strTrangThaiBan == "Mở bàn" || strTrangThaiBan == "Đang gọi món" || strTrangThaiBan == "Đang làm" || strTrangThaiBan == "Phục vụ")
            {
                FormGoiMon frmGM = new FormGoiMon(strMaBan, strTrangThaiBan, MaNV);
                frmGM.FormClosing += new FormClosingEventHandler(this.FormGoiMon_FormClosing);
                frmGM.ShowDialog();
            }

        }

        private void FormGoiMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadData();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //groupBox8.Visible = !groupBox8.Visible;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string err = "";
            gbchuyenban.Visible = !gbchuyenban.Visible;
            //bool kt = true;
            try
            {
                // Lệnh Insert InTo 
                //bool f = nv.ChuyenBan(ref err, mahd, cmbBan.SelectedValue.ToString());
                bool f;
                if (cmbBan.SelectedValue.ToString() == "Trống")
                    f = false;
                else
                    f = true;
                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 
                    // Thông báo 
                    //LoadData_MaChiTietPhieuNhap();
                    CapNhatTrangThaiBan_Trong();
                    CapNhatTrangThaiBan_CoKhach();

                    MessageBox.Show("Đã chuyển bàn thành công xong!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }

        private void SV01_Click(object sender, EventArgs e)
        {
            //gbThaotacban.Visible = !gbThaotacban.Visible;
            dgvBan.CurrentCell = dgvBan.Rows[0].Cells[0];
            dgvBan.Rows[0].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV02_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgvBan.Rows)
            //    if (this.dgvBan.SelectedRows.Count == 0)
            //        dgvBan.Rows[1].Selected = true;
            dgvBan.CurrentCell = dgvBan.Rows[1].Cells[0];
            dgvBan.Rows[1].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void dgvBan_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dgvBan_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void SV03_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[2].Cells[0];
            dgvBan.Rows[2].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV04_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[3].Cells[0];
            dgvBan.Rows[3].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV05_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[4].Cells[0];
            dgvBan.Rows[4].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV06_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[5].Cells[0];
            dgvBan.Rows[5].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV07_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[6].Cells[0];
            dgvBan.Rows[6].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV08_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[7].Cells[0];
            dgvBan.Rows[7].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void SV09_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[8].Cells[0];
            dgvBan.Rows[8].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN01_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[9].Cells[0];
            dgvBan.Rows[9].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN02_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[10].Cells[0];
            dgvBan.Rows[10].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN03_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[11].Cells[0];
            dgvBan.Rows[11].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN04_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[12].Cells[0];
            dgvBan.Rows[12].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN05_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[13].Cells[0];
            dgvBan.Rows[13].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN06_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[14].Cells[0];
            dgvBan.Rows[14].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN07_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[15].Cells[0];
            dgvBan.Rows[15].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN08_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[16].Cells[0];
            dgvBan.Rows[16].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void TN09_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[17].Cells[0];
            dgvBan.Rows[17].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L101_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[18].Cells[0];
            dgvBan.Rows[18].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L102_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[19].Cells[0];
            dgvBan.Rows[19].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L103_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[20].Cells[0];
            dgvBan.Rows[20].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L104_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[21].Cells[0];
            dgvBan.Rows[21].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L105_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[22].Cells[0];
            dgvBan.Rows[22].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L106_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[23].Cells[0];
            dgvBan.Rows[23].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L107_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[24].Cells[0];
            dgvBan.Rows[24].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L108_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[25].Cells[0];
            dgvBan.Rows[25].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void L109_Click(object sender, EventArgs e)
        {
            dgvBan.CurrentCell = dgvBan.Rows[26].Cells[0];
            dgvBan.Rows[26].Selected = true;
            LoadData_Order();
            LoadData_DanhSachMonGoi();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Chon_Click(object sender, EventArgs e)
        {
            //int r = dgvMonAn.CurrentCell.RowIndex;
            //string strMaMon = dgvMonAn.Rows[r].Cells[0].Value.ToString();

            MessageBox.Show(MaNV);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //LoadData_MonAn();
        }


        private void cmbLoaiMonAn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //LoadData_MonAn();
        }

        private void cmbLoaiMonAn_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(" Loai mon an!!!");
            //LoadData_MonAn();
        }

        private void cmbLoaiMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(" Loai mon an!!!");
            //LoadData_MonAn();
        }

        private void cmbLoaiMonAn_TextUpdate(object sender, EventArgs e)
        {
            //LoadData_MonAn();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            int r = dgvBan.CurrentCell.RowIndex;

            string strMaBan = dgvBan.Rows[r].Cells[0].Value.ToString();
            //string strTenBan = dgvBan.Rows[r].Cells[1].Value.ToString();
            string strTrangThaiBan = dgvBan.Rows[r].Cells[2].Value.ToString();

            if (strTrangThaiBan == "Trống" || strTrangThaiBan == "Mở bàn")
            {
                MessageBox.Show("Chỉ được xuất hóa đơn khi có khách đặt món !", "Thông báo");
            }
            else if (strTrangThaiBan == "Đang gọi món" || strTrangThaiBan == "Đang làm" || strTrangThaiBan == "Phục vụ")
            {
                int count = dgvChiTietO.RowCount;
                
                FormXuatHoaDon frmHoaDon = new FormXuatHoaDon(strMaBan, strTrangThaiBan, MaNV, txtMaPhieuO.Text);
                frmHoaDon.FormClosing += new FormClosingEventHandler(this.FormHoaDon_FormClosing);
                frmHoaDon.ShowDialog();
            }
        }
        private void FormHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadData();
            //dgvChiTietO.DataSource = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button[] bt = new Button[30];
            bt[0] = SV01;
            bt[1] = SV02;
            bt[2] = SV03;
            bt[3] = SV04;
            bt[4] = SV05;
            bt[5] = SV06;
            bt[6] = SV07;
            bt[7] = SV08;
            bt[8] = SV09;
            bt[9] = TN01;
            bt[10] = TN02;
            bt[11] = TN03;
            bt[12] = TN04;
            bt[13] = TN05;
            bt[14] = TN06;
            bt[15] = TN07;
            bt[16] = TN08;
            bt[17] = TN09;
            bt[18] = L101;
            bt[19] = L102;
            bt[20] = L103;
            bt[21] = L104;
            bt[22] = L105;
            bt[23] = L106;
            bt[24] = L107;
            bt[25] = L108;
            bt[26] = L109;
            int r = dgvBan.CurrentCell.RowIndex;
            MessageBox.Show("" + Global.GlobalVar);
            //if (dgvBan.Rows[r].Cells[2].Value.ToString() == "Trống" )
            //{
            //    if (bt[r].Enabled == true)
            //    {
            //        //bt[r].Focus();
            //        //((Button)sender).Enabled = false;
            //        bt[r].Enabled = false;
            //        //bt[r].Cursor;
            //    }

            //    else
            //        bt[r].Enabled = true;
            //}
            
        }

        private void mónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonAn f = new FormMonAn();
            f.ShowDialog();
        }

        private void loạiMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoaiMonAn f = new FormLoaiMonAn();
            f.ShowDialog();
        }

        private void hìnhThứcThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHTTT f = new FormHTTT();
            f.ShowDialog();
        }

        private void nhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_PhieuNhapKho f = new F_PhieuNhapKho();
            f.ShowDialog();
        }

        private void btnGhepBan_Click(object sender, EventArgs e)
        {

        }
    }
}
