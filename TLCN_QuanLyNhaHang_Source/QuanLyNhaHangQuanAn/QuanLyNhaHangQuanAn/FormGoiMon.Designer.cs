namespace QuanLyNhaHangQuanAn
{
    partial class FormGoiMon
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
            this.gbGoiMon = new System.Windows.Forms.GroupBox();
            this.cmbLoaiMonAn = new System.Windows.Forms.ComboBox();
            this.Chon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaHienTai0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDonGiaHienTai = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaPhieuOrder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvChiTietOrder = new System.Windows.Forms.DataGridView();
            this.MaCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaHIenTai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lbMaNV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMaLoai = new System.Windows.Forms.ComboBox();
            this.txtBan = new System.Windows.Forms.TextBox();
            this.gbGoiMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGoiMon
            // 
            this.gbGoiMon.Controls.Add(this.cmbLoaiMonAn);
            this.gbGoiMon.Controls.Add(this.Chon);
            this.gbGoiMon.Controls.Add(this.label3);
            this.gbGoiMon.Controls.Add(this.dgvMonAn);
            this.gbGoiMon.Controls.Add(this.btnNext);
            this.gbGoiMon.Controls.Add(this.label4);
            this.gbGoiMon.Location = new System.Drawing.Point(12, 12);
            this.gbGoiMon.Name = "gbGoiMon";
            this.gbGoiMon.Size = new System.Drawing.Size(399, 363);
            this.gbGoiMon.TabIndex = 9;
            this.gbGoiMon.TabStop = false;
            this.gbGoiMon.Text = "Gọi món";
            // 
            // cmbLoaiMonAn
            // 
            this.cmbLoaiMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiMonAn.FormattingEnabled = true;
            this.cmbLoaiMonAn.Location = new System.Drawing.Point(5, 35);
            this.cmbLoaiMonAn.Name = "cmbLoaiMonAn";
            this.cmbLoaiMonAn.Size = new System.Drawing.Size(213, 26);
            this.cmbLoaiMonAn.TabIndex = 14;
            // 
            // Chon
            // 
            this.Chon.Location = new System.Drawing.Point(300, 90);
            this.Chon.Name = "Chon";
            this.Chon.Size = new System.Drawing.Size(93, 63);
            this.Chon.TabIndex = 13;
            this.Chon.Text = "Chọn";
            this.Chon.UseVisualStyleBackColor = true;
            this.Chon.Click += new System.EventHandler(this.Chon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Món ăn theo loại";
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.AllowUserToResizeColumns = false;
            this.dgvMonAn.AllowUserToResizeRows = false;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.DonGiaHienTai0});
            this.dgvMonAn.Location = new System.Drawing.Point(5, 90);
            this.dgvMonAn.MultiSelect = false;
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(289, 235);
            this.dgvMonAn.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaMon";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã Món";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenMon";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên Món";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DonViTinh";
            this.dataGridViewTextBoxColumn3.HeaderText = "Đơn vị tính";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // DonGiaHienTai0
            // 
            this.DonGiaHienTai0.DataPropertyName = "DonGiaHienTai";
            this.DonGiaHienTai0.HeaderText = "Đơn Giá Hiện Tại";
            this.DonGiaHienTai0.Name = "DonGiaHienTai0";
            this.DonGiaHienTai0.ReadOnly = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(224, 29);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(70, 41);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chọn Loại món ăn (thức uống)";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.btnDong);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtDonGiaHienTai);
            this.groupBox6.Controls.Add(this.btnThem);
            this.groupBox6.Controls.Add(this.txtMaBan);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txtMaPhieuOrder);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.dgvChiTietOrder);
            this.groupBox6.Controls.Add(this.txtSoLuong);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtDonViTinh);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtTenMon);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txtMaMon);
            this.groupBox6.Controls.Add(this.lbMaNV);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(436, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(566, 359);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Phiếu Order";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Sửa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(438, 327);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 17;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Đơn giá hiện tại";
            // 
            // txtDonGiaHienTai
            // 
            this.txtDonGiaHienTai.Location = new System.Drawing.Point(231, 101);
            this.txtDonGiaHienTai.Name = "txtDonGiaHienTai";
            this.txtDonGiaHienTai.ReadOnly = true;
            this.txtDonGiaHienTai.Size = new System.Drawing.Size(100, 20);
            this.txtDonGiaHienTai.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 327);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMaBan
            // 
            this.txtMaBan.Location = new System.Drawing.Point(94, 51);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.ReadOnly = true;
            this.txtMaBan.Size = new System.Drawing.Size(100, 20);
            this.txtMaBan.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Bàn";
            // 
            // txtMaPhieuOrder
            // 
            this.txtMaPhieuOrder.Location = new System.Drawing.Point(94, 25);
            this.txtMaPhieuOrder.Name = "txtMaPhieuOrder";
            this.txtMaPhieuOrder.ReadOnly = true;
            this.txtMaPhieuOrder.Size = new System.Drawing.Size(100, 20);
            this.txtMaPhieuOrder.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mã Phiếu Order";
            // 
            // dgvChiTietOrder
            // 
            this.dgvChiTietOrder.AllowUserToAddRows = false;
            this.dgvChiTietOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTO,
            this.TenMon,
            this.DonViTinh,
            this.DonGiaHIenTai,
            this.SoLuong,
            this.ThanhTien});
            this.dgvChiTietOrder.Location = new System.Drawing.Point(6, 172);
            this.dgvChiTietOrder.Name = "dgvChiTietOrder";
            this.dgvChiTietOrder.RowHeadersVisible = false;
            this.dgvChiTietOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietOrder.Size = new System.Drawing.Size(551, 149);
            this.dgvChiTietOrder.TabIndex = 10;
            // 
            // MaCTO
            // 
            this.MaCTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaCTO.DataPropertyName = "MaCTO";
            this.MaCTO.HeaderText = "Chi tiết Order ";
            this.MaCTO.Name = "MaCTO";
            // 
            // TenMon
            // 
            this.TenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenMon.DataPropertyName = "TenMon";
            this.TenMon.HeaderText = "Tên món";
            this.TenMon.Name = "TenMon";
            // 
            // DonViTinh
            // 
            this.DonViTinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.Name = "DonViTinh";
            // 
            // DonGiaHIenTai
            // 
            this.DonGiaHIenTai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonGiaHIenTai.DataPropertyName = "DonGiaHienTai";
            this.DonGiaHIenTai.HeaderText = "Đơn giá";
            this.DonGiaHIenTai.Name = "DonGiaHIenTai";
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // ThanhTien
            // 
            this.ThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(457, 133);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Số lượng";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(457, 101);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(100, 20);
            this.txtDonViTinh.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Đơn vị tính";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(94, 133);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.ReadOnly = true;
            this.txtTenMon.Size = new System.Drawing.Size(100, 20);
            this.txtTenMon.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên món";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã món";
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(94, 101);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.ReadOnly = true;
            this.txtMaMon.Size = new System.Drawing.Size(100, 20);
            this.txtMaMon.TabIndex = 2;
            // 
            // lbMaNV
            // 
            this.lbMaNV.AutoSize = true;
            this.lbMaNV.Location = new System.Drawing.Point(494, 25);
            this.lbMaNV.Name = "lbMaNV";
            this.lbMaNV.Size = new System.Drawing.Size(19, 13);
            this.lbMaNV.TabIndex = 1;
            this.lbMaNV.Text = "....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhân viên ghi order:";
            // 
            // cmbMaLoai
            // 
            this.cmbMaLoai.FormattingEnabled = true;
            this.cmbMaLoai.Location = new System.Drawing.Point(423, 487);
            this.cmbMaLoai.Name = "cmbMaLoai";
            this.cmbMaLoai.Size = new System.Drawing.Size(68, 21);
            this.cmbMaLoai.TabIndex = 16;
            // 
            // txtBan
            // 
            this.txtBan.Location = new System.Drawing.Point(423, 461);
            this.txtBan.Name = "txtBan";
            this.txtBan.Size = new System.Drawing.Size(100, 20);
            this.txtBan.TabIndex = 14;
            // 
            // FormGoiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 386);
            this.ControlBox = false;
            this.Controls.Add(this.txtBan);
            this.Controls.Add(this.cmbMaLoai);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.gbGoiMon);
            this.Name = "FormGoiMon";
            this.Text = "Gọi Món";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGoiMon_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGoiMon_FormClosed);
            this.Load += new System.EventHandler(this.FormGoiMon_Load);
            this.gbGoiMon.ResumeLayout(false);
            this.gbGoiMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGoiMon;
        private System.Windows.Forms.ComboBox cmbLoaiMonAn;
        private System.Windows.Forms.Button Chon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaBan;
        private System.Windows.Forms.ComboBox cmbMaLoai;
        private System.Windows.Forms.DataGridView dgvChiTietOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaHIenTai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.TextBox txtMaPhieuOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaHienTai0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDonGiaHienTai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}