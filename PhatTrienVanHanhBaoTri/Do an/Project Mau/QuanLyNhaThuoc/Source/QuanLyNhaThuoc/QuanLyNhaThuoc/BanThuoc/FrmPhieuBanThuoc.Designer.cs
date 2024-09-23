namespace QuanLyNhaThuoc
{
    partial class FrmPhieuBanThuoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.btKhongLuu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPhieuXuat = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNguoiPhatThuoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienVAT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTongThanhTien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTongTienThuoc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThongTinBenhNhan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNguoiGhiPhieu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvcMaHoaDonXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaThuoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcSoLuong = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgvcDonGiaXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSoLuongBanDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuXuat)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 53);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(847, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHIẾU XUẤT BÁN THUỐC";
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
            this.panel2.Location = new System.Drawing.Point(0, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 59);
            this.panel2.TabIndex = 2;
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.Location = new System.Drawing.Point(302, 18);
            this.btThem.Margin = new System.Windows.Forms.Padding(4);
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
            this.btSua.Location = new System.Drawing.Point(410, 18);
            this.btSua.Margin = new System.Windows.Forms.Padding(4);
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
            this.btLuu.Location = new System.Drawing.Point(518, 18);
            this.btLuu.Margin = new System.Windows.Forms.Padding(4);
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
            this.btThoat.Location = new System.Drawing.Point(734, 18);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4);
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
            this.btKhongLuu.Location = new System.Drawing.Point(626, 18);
            this.btKhongLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btKhongLuu.Name = "btKhongLuu";
            this.btKhongLuu.Size = new System.Drawing.Size(100, 28);
            this.btKhongLuu.TabIndex = 4;
            this.btKhongLuu.Text = "Không Lưu";
            this.btKhongLuu.UseVisualStyleBackColor = true;
            this.btKhongLuu.Click += new System.EventHandler(this.btKhongLuu_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(847, 400);
            this.panel3.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChiTietPhieuXuat);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phiếu xuất";
            // 
            // dgvChiTietPhieuXuat
            // 
            this.dgvChiTietPhieuXuat.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPhieuXuat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietPhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaHoaDonXuat,
            this.dgvcMaThuoc,
            this.dgvcSoLuong,
            this.dgvcDonGiaXuat,
            this.dgvcThanhTien,
            this.dgvcSoLuongBanDau});
            this.dgvChiTietPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhieuXuat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvChiTietPhieuXuat.Location = new System.Drawing.Point(3, 18);
            this.dgvChiTietPhieuXuat.Name = "dgvChiTietPhieuXuat";
            this.dgvChiTietPhieuXuat.Size = new System.Drawing.Size(841, 199);
            this.dgvChiTietPhieuXuat.TabIndex = 0;
            this.dgvChiTietPhieuXuat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuXuat_CellEndEdit);
            this.dgvChiTietPhieuXuat.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuXuat_CellValueChanged);
            this.dgvChiTietPhieuXuat.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvChiTietPhieuXuat_DataError);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboNguoiPhatThuoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTienVAT);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtTongThanhTien);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtTongTienThuoc);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtThongTinBenhNhan);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpNgayXuat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboNguoiGhiPhieu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu xuất";
            // 
            // cboNguoiPhatThuoc
            // 
            this.cboNguoiPhatThuoc.FormattingEnabled = true;
            this.cboNguoiPhatThuoc.Location = new System.Drawing.Point(144, 89);
            this.cboNguoiPhatThuoc.Name = "cboNguoiPhatThuoc";
            this.cboNguoiPhatThuoc.Size = new System.Drawing.Size(309, 24);
            this.cboNguoiPhatThuoc.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Người phát thuốc";
            // 
            // txtTienVAT
            // 
            this.txtTienVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienVAT.Location = new System.Drawing.Point(657, 60);
            this.txtTienVAT.Name = "txtTienVAT";
            this.txtTienVAT.ReadOnly = true;
            this.txtTienVAT.Size = new System.Drawing.Size(177, 22);
            this.txtTienVAT.TabIndex = 27;
            this.txtTienVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(532, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Tiền VAT 5%";
            // 
            // txtTongThanhTien
            // 
            this.txtTongThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThanhTien.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTongThanhTien.Location = new System.Drawing.Point(657, 90);
            this.txtTongThanhTien.Name = "txtTongThanhTien";
            this.txtTongThanhTien.ReadOnly = true;
            this.txtTongThanhTien.Size = new System.Drawing.Size(177, 22);
            this.txtTongThanhTien.TabIndex = 25;
            this.txtTongThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(532, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Tổng thành tiền";
            // 
            // txtTongTienThuoc
            // 
            this.txtTongTienThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTienThuoc.Location = new System.Drawing.Point(657, 30);
            this.txtTongTienThuoc.Name = "txtTongTienThuoc";
            this.txtTongTienThuoc.ReadOnly = true;
            this.txtTongTienThuoc.Size = new System.Drawing.Size(177, 22);
            this.txtTongTienThuoc.TabIndex = 23;
            this.txtTongTienThuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(532, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tổng tiền thuốc";
            // 
            // txtThongTinBenhNhan
            // 
            this.txtThongTinBenhNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThongTinBenhNhan.Location = new System.Drawing.Point(144, 119);
            this.txtThongTinBenhNhan.Multiline = true;
            this.txtThongTinBenhNhan.Name = "txtThongTinBenhNhan";
            this.txtThongTinBenhNhan.Size = new System.Drawing.Size(690, 50);
            this.txtThongTinBenhNhan.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Thông tin bệnh nhân";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayXuat.Location = new System.Drawing.Point(349, 30);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(104, 22);
            this.dtpNgayXuat.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ngày xuất";
            // 
            // cboNguoiGhiPhieu
            // 
            this.cboNguoiGhiPhieu.FormattingEnabled = true;
            this.cboNguoiGhiPhieu.Location = new System.Drawing.Point(144, 59);
            this.cboNguoiGhiPhieu.Name = "cboNguoiGhiPhieu";
            this.cboNguoiGhiPhieu.Size = new System.Drawing.Size(309, 24);
            this.cboNguoiGhiPhieu.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Người ghi phiếu";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(144, 30);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(105, 22);
            this.txtSoPhieu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số phiếu";
            // 
            // dgvcMaHoaDonXuat
            // 
            this.dgvcMaHoaDonXuat.HeaderText = "MaHoaDonXuat";
            this.dgvcMaHoaDonXuat.Name = "dgvcMaHoaDonXuat";
            this.dgvcMaHoaDonXuat.Visible = false;
            // 
            // dgvcMaThuoc
            // 
            this.dgvcMaThuoc.HeaderText = "Tên thuốc";
            this.dgvcMaThuoc.Name = "dgvcMaThuoc";
            this.dgvcMaThuoc.Width = 200;
            // 
            // dgvcSoLuong
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvcSoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcSoLuong.HeaderText = "Số lượng";
            this.dgvcSoLuong.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.dgvcSoLuong.Name = "dgvcSoLuong";
            // 
            // dgvcDonGiaXuat
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvcDonGiaXuat.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcDonGiaXuat.HeaderText = "Đơn giá xuất";
            this.dgvcDonGiaXuat.Name = "dgvcDonGiaXuat";
            this.dgvcDonGiaXuat.ReadOnly = true;
            this.dgvcDonGiaXuat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcDonGiaXuat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.dgvcSoLuongBanDau.HeaderText = "SoLuongBanDau";
            this.dgvcSoLuongBanDau.Name = "dgvcSoLuongBanDau";
            this.dgvcSoLuongBanDau.Visible = false;
            // 
            // FrmPhieuBanThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 512);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPhieuBanThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu bán thuốc";
            this.Load += new System.EventHandler(this.FrmPhieuBanThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuXuat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuXuat;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNguoiGhiPhieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThongTinBenhNhan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTienVAT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTongThanhTien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTongTienThuoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboNguoiPhatThuoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaHoaDonXuat;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcMaThuoc;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvcSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDonGiaXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSoLuongBanDau;
    }
}