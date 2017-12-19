namespace QuanLyNhaHangQuanAn
{
    partial class F_BaoCaoPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.MaPNK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvCTPN = new System.Windows.Forms.DataGridView();
            this.MaCTPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNguyenLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTongHD = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.cmbTenNV = new System.Windows.Forms.ComboBox();
            this.cmbBoLoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTongChi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCTPN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvPhieuNhap
            // 
            this.dtgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPNK,
            this.TenNV,
            this.TongGiaNhap,
            this.NgayNhap});
            this.dtgvPhieuNhap.Location = new System.Drawing.Point(12, 208);
            this.dtgvPhieuNhap.Name = "dtgvPhieuNhap";
            this.dtgvPhieuNhap.Size = new System.Drawing.Size(920, 318);
            this.dtgvPhieuNhap.TabIndex = 0;
            this.dtgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhieuNhap_CellClick);
            // 
            // MaPNK
            // 
            this.MaPNK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaPNK.DataPropertyName = "MaPNK";
            this.MaPNK.HeaderText = "Mã phiếu nhập";
            this.MaPNK.Name = "MaPNK";
            this.MaPNK.ReadOnly = true;
            // 
            // TenNV
            // 
            this.TenNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenNV.DataPropertyName = "TenNV";
            this.TenNV.HeaderText = "Tên nhân viên";
            this.TenNV.Name = "TenNV";
            this.TenNV.ReadOnly = true;
            // 
            // TongGiaNhap
            // 
            this.TongGiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TongGiaNhap.DataPropertyName = "TongGiaNhap";
            this.TongGiaNhap.HeaderText = "Tổng giá nhập";
            this.TongGiaNhap.Name = "TongGiaNhap";
            this.TongGiaNhap.ReadOnly = true;
            // 
            // NgayNhap
            // 
            this.NgayNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayNhap.DataPropertyName = "NgayNhap";
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.ReadOnly = true;
            // 
            // dtgvCTPN
            // 
            this.dtgvCTPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCTPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTPN,
            this.TenNguyenLieu,
            this.DonGiaNhap,
            this.SoLuongNhap});
            this.dtgvCTPN.Location = new System.Drawing.Point(12, 209);
            this.dtgvCTPN.Name = "dtgvCTPN";
            this.dtgvCTPN.Size = new System.Drawing.Size(622, 317);
            this.dtgvCTPN.TabIndex = 1;
            // 
            // MaCTPN
            // 
            this.MaCTPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaCTPN.DataPropertyName = "MaCTPN";
            this.MaCTPN.HeaderText = "Mã chi tiết";
            this.MaCTPN.Name = "MaCTPN";
            this.MaCTPN.ReadOnly = true;
            this.MaCTPN.Visible = false;
            // 
            // TenNguyenLieu
            // 
            this.TenNguyenLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenNguyenLieu.DataPropertyName = "TenNguyenLieu";
            this.TenNguyenLieu.HeaderText = "Nguyên liệu";
            this.TenNguyenLieu.Name = "TenNguyenLieu";
            this.TenNguyenLieu.ReadOnly = true;
            // 
            // DonGiaNhap
            // 
            this.DonGiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonGiaNhap.DataPropertyName = "DonGiaNhap";
            this.DonGiaNhap.HeaderText = "Đơn giá nhập";
            this.DonGiaNhap.Name = "DonGiaNhap";
            this.DonGiaNhap.ReadOnly = true;
            // 
            // SoLuongNhap
            // 
            this.SoLuongNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuongNhap.DataPropertyName = "SoLuongNhap";
            this.SoLuongNhap.HeaderText = "Số lượng nhập";
            this.SoLuongNhap.Name = "SoLuongNhap";
            this.SoLuongNhap.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTongChi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbTongHD);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 189);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // lbTongHD
            // 
            this.lbTongHD.AutoSize = true;
            this.lbTongHD.Location = new System.Drawing.Point(165, 154);
            this.lbTongHD.Name = "lbTongHD";
            this.lbTongHD.Size = new System.Drawing.Size(11, 16);
            this.lbTongHD.TabIndex = 20;
            this.lbTongHD.Text = " ";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(518, 26);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(85, 30);
            this.btnTim.TabIndex = 19;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lọc theo:";
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Location = new System.Drawing.Point(531, 119);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(85, 30);
            this.btnChiTiet.TabIndex = 20;
            this.btnChiTiet.Text = "Chi tiết...";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // dtpMonth
            // 
            this.dtpMonth.Location = new System.Drawing.Point(181, 122);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(238, 21);
            this.dtpMonth.TabIndex = 18;
            // 
            // cmbTenNV
            // 
            this.cmbTenNV.FormattingEnabled = true;
            this.cmbTenNV.Location = new System.Drawing.Point(181, 84);
            this.cmbTenNV.Name = "cmbTenNV";
            this.cmbTenNV.Size = new System.Drawing.Size(238, 23);
            this.cmbTenNV.TabIndex = 17;
            // 
            // cmbBoLoc
            // 
            this.cmbBoLoc.FormattingEnabled = true;
            this.cmbBoLoc.Items.AddRange(new object[] {
            "Tất cả",
            "Tên nhân viên",
            "Tháng"});
            this.cmbBoLoc.Location = new System.Drawing.Point(181, 44);
            this.cmbBoLoc.Name = "cmbBoLoc";
            this.cmbBoLoc.Size = new System.Drawing.Size(238, 23);
            this.cmbBoLoc.TabIndex = 15;
            this.cmbBoLoc.SelectedIndexChanged += new System.EventHandler(this.cmbBoLoc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tổng số hóa đơn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tháng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên nhân viên:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(761, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 40);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(761, 127);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 40);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tổng chi:";
            // 
            // lbTongChi
            // 
            this.lbTongChi.AutoSize = true;
            this.lbTongChi.Location = new System.Drawing.Point(423, 154);
            this.lbTongChi.Name = "lbTongChi";
            this.lbTongChi.Size = new System.Drawing.Size(14, 16);
            this.lbTongChi.TabIndex = 22;
            this.lbTongChi.Text = "  ";
            // 
            // F_BaoCaoPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 538);
            this.Controls.Add(this.btnChiTiet);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.cmbTenNV);
            this.Controls.Add(this.cmbBoLoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgvCTPN);
            this.Controls.Add(this.dtgvPhieuNhap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "F_BaoCaoPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_BaoCaoPhieuNhap";
            this.Load += new System.EventHandler(this.BaoCaoPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCTPN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPNK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridView dtgvCTPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNguyenLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.ComboBox cmbTenNV;
        private System.Windows.Forms.ComboBox cmbBoLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lbTongHD;
        private System.Windows.Forms.Label lbTongChi;
        private System.Windows.Forms.Label label5;
    }
}