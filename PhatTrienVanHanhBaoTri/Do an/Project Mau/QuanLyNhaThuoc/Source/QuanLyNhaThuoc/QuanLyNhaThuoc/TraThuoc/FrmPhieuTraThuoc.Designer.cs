namespace QuanLyNhaThuoc
{
    partial class FrmPhieuTraThuoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.btKhongLuu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPhieuHoaDonXuat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTongTienPhaiTra = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboNguoiNhanThuoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNguoiGhiPhieu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPhieuTra = new System.Windows.Forms.DataGridView();
            this.dgvcMaPhieuTraThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaThuoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcSoLuongXuatBanDau = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgvcSoLuongTra = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgvcDonGiaXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSoLuongBanDau = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuTra)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 65);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(906, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHIẾU TRẢ THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btThem);
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btLuu);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Controls.Add(this.btKhongLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 518);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 73);
            this.panel2.TabIndex = 2;
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.Location = new System.Drawing.Point(213, 22);
            this.btThem.Margin = new System.Windows.Forms.Padding(5);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(100, 28);
            this.btThem.TabIndex = 8;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.Location = new System.Drawing.Point(323, 22);
            this.btSua.Margin = new System.Windows.Forms.Padding(5);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(100, 28);
            this.btSua.TabIndex = 7;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btLuu
            // 
            this.btLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLuu.Location = new System.Drawing.Point(433, 22);
            this.btLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(100, 28);
            this.btLuu.TabIndex = 6;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(653, 22);
            this.btThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(100, 28);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btKhongLuu
            // 
            this.btKhongLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btKhongLuu.Location = new System.Drawing.Point(543, 22);
            this.btKhongLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btKhongLuu.Name = "btKhongLuu";
            this.btKhongLuu.Size = new System.Drawing.Size(100, 28);
            this.btKhongLuu.TabIndex = 4;
            this.btKhongLuu.Text = "Không Lưu";
            this.btKhongLuu.UseVisualStyleBackColor = true;
            this.btKhongLuu.Click += new System.EventHandler(this.btKhongLuu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPhieuHoaDonXuat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTongTienPhaiTra);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtLyDo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboNguoiNhanThuoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpNgayTra);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboNguoiGhiPhieu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(906, 156);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu trả thuốc";
            // 
            // cboPhieuHoaDonXuat
            // 
            this.cboPhieuHoaDonXuat.FormattingEnabled = true;
            this.cboPhieuHoaDonXuat.Location = new System.Drawing.Point(129, 114);
            this.cboPhieuHoaDonXuat.Name = "cboPhieuHoaDonXuat";
            this.cboPhieuHoaDonXuat.Size = new System.Drawing.Size(299, 24);
            this.cboPhieuHoaDonXuat.TabIndex = 23;
            this.cboPhieuHoaDonXuat.SelectedIndexChanged += new System.EventHandler(this.cboPhieuHoaDonXuat_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Hóa Đơn Xuất";
            // 
            // txtTongTienPhaiTra
            // 
            this.txtTongTienPhaiTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTienPhaiTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienPhaiTra.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTongTienPhaiTra.Location = new System.Drawing.Point(575, 114);
            this.txtTongTienPhaiTra.Name = "txtTongTienPhaiTra";
            this.txtTongTienPhaiTra.ReadOnly = true;
            this.txtTongTienPhaiTra.Size = new System.Drawing.Size(313, 22);
            this.txtTongTienPhaiTra.TabIndex = 21;
            this.txtTongTienPhaiTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(459, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Tổng thành tiền";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLyDo.Location = new System.Drawing.Point(575, 24);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(313, 84);
            this.txtLyDo.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(459, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Lý do";
            // 
            // cboNguoiNhanThuoc
            // 
            this.cboNguoiNhanThuoc.FormattingEnabled = true;
            this.cboNguoiNhanThuoc.Location = new System.Drawing.Point(129, 84);
            this.cboNguoiNhanThuoc.Margin = new System.Windows.Forms.Padding(4);
            this.cboNguoiNhanThuoc.Name = "cboNguoiNhanThuoc";
            this.cboNguoiNhanThuoc.Size = new System.Drawing.Size(299, 24);
            this.cboNguoiNhanThuoc.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Người nhận thuốc";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(325, 22);
            this.dtpNgayTra.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(103, 22);
            this.dtpNgayTra.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ngày trả";
            // 
            // cboNguoiGhiPhieu
            // 
            this.cboNguoiGhiPhieu.FormattingEnabled = true;
            this.cboNguoiGhiPhieu.Location = new System.Drawing.Point(129, 52);
            this.cboNguoiGhiPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.cboNguoiGhiPhieu.Name = "cboNguoiGhiPhieu";
            this.cboNguoiGhiPhieu.Size = new System.Drawing.Size(299, 24);
            this.cboNguoiGhiPhieu.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Người ghi phiếu";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(129, 22);
            this.txtSoPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(106, 22);
            this.txtSoPhieu.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Số phiếu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChiTietPhieuTra);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 221);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(906, 297);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phiếu trả thuốc";
            // 
            // dgvChiTietPhieuTra
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPhieuTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietPhieuTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaPhieuTraThuoc,
            this.dgvcMaThuoc,
            this.dgvcSoLuongXuatBanDau,
            this.dgvcSoLuongTra,
            this.dgvcDonGiaXuat,
            this.dgvcThanhTien,
            this.dgvcSoLuongBanDau});
            this.dgvChiTietPhieuTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhieuTra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvChiTietPhieuTra.Location = new System.Drawing.Point(4, 19);
            this.dgvChiTietPhieuTra.Name = "dgvChiTietPhieuTra";
            this.dgvChiTietPhieuTra.Size = new System.Drawing.Size(898, 274);
            this.dgvChiTietPhieuTra.TabIndex = 0;
            this.dgvChiTietPhieuTra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuTra_CellEndEdit);
            this.dgvChiTietPhieuTra.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuTra_CellValueChanged);
            this.dgvChiTietPhieuTra.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvChiTietPhieuTra_DataError);
            // 
            // dgvcMaPhieuTraThuoc
            // 
            this.dgvcMaPhieuTraThuoc.HeaderText = "MaPhieuTraThuoc";
            this.dgvcMaPhieuTraThuoc.Name = "dgvcMaPhieuTraThuoc";
            this.dgvcMaPhieuTraThuoc.Visible = false;
            // 
            // dgvcMaThuoc
            // 
            this.dgvcMaThuoc.HeaderText = "Tên thuốc";
            this.dgvcMaThuoc.Name = "dgvcMaThuoc";
            this.dgvcMaThuoc.Width = 200;
            // 
            // dgvcSoLuongXuatBanDau
            // 
            this.dgvcSoLuongXuatBanDau.HeaderText = "Số lượng thuốc xuất ban đầu";
            this.dgvcSoLuongXuatBanDau.Name = "dgvcSoLuongXuatBanDau";
            // 
            // dgvcSoLuongTra
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvcSoLuongTra.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcSoLuongTra.HeaderText = "Số lượng thuốc trả";
            this.dgvcSoLuongTra.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.dgvcSoLuongTra.Name = "dgvcSoLuongTra";
            this.dgvcSoLuongTra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvcDonGiaXuat
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvcDonGiaXuat.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcDonGiaXuat.HeaderText = "Đơn giá xuất";
            this.dgvcDonGiaXuat.Name = "dgvcDonGiaXuat";
            this.dgvcDonGiaXuat.ReadOnly = true;
            this.dgvcDonGiaXuat.Width = 150;
            // 
            // dgvcThanhTien
            // 
            this.dgvcThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvcThanhTien.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvcThanhTien.HeaderText = "Thành tiền";
            this.dgvcThanhTien.Name = "dgvcThanhTien";
            this.dgvcThanhTien.ReadOnly = true;
            // 
            // dgvcSoLuongBanDau
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvcSoLuongBanDau.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcSoLuongBanDau.HeaderText = "Số lượng thuốc ban đầu";
            this.dgvcSoLuongBanDau.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.dgvcSoLuongBanDau.Name = "dgvcSoLuongBanDau";
            this.dgvcSoLuongBanDau.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FrmPhieuTraThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 591);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPhieuTraThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu trả thuốc";
            this.Load += new System.EventHandler(this.FrmPhieuTraThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuTra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btKhongLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboNguoiNhanThuoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNguoiGhiPhieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTongTienPhaiTra;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuTra;
        private System.Windows.Forms.ComboBox cboPhieuHoaDonXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaPhieuTraThuoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcMaThuoc;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvcSoLuongXuatBanDau;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvcSoLuongTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDonGiaXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcThanhTien;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvcSoLuongBanDau;
    }
}