namespace QuanLyNhaThuoc
{
    partial class FrmPhieuNhapThuoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSoPhieuNhap = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.btKhongLuu = new System.Windows.Forms.Button();
            this.txtTongTienThuoc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTienVAT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTongThanhTien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboHinhThucThanhToan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNguoiGhiPhieu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.dgvcMaHoaDonNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcThuoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcSoLo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNgaySanXuat = new QLNT.CommonLayer.DataGridViewDateTimePickerColumn();
            this.dgvcNgayHetHan = new QLNT.CommonLayer.DataGridViewDateTimePickerColumn();
            this.dgvcSoLuong = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgvcDonGia = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgvcTienThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSoLuongBanDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDateTimePickerColumn1 = new QLNT.CommonLayer.DataGridViewDateTimePickerColumn();
            this.dataGridViewDateTimePickerColumn2 = new QLNT.CommonLayer.DataGridViewDateTimePickerColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 53);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHIẾU NHẬP MUA THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btXoa);
            this.panel2.Controls.Add(this.btSoPhieuNhap);
            this.panel2.Controls.Add(this.btThem);
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btLuu);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Controls.Add(this.btKhongLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 59);
            this.panel2.TabIndex = 1;
            // 
            // btXoa
            // 
            this.btXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btXoa.Location = new System.Drawing.Point(663, 18);
            this.btXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(100, 28);
            this.btXoa.TabIndex = 10;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // btSoPhieuNhap
            // 
            this.btSoPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSoPhieuNhap.Location = new System.Drawing.Point(115, 18);
            this.btSoPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btSoPhieuNhap.Name = "btSoPhieuNhap";
            this.btSoPhieuNhap.Size = new System.Drawing.Size(113, 28);
            this.btSoPhieuNhap.TabIndex = 9;
            this.btSoPhieuNhap.Text = "Sổ phiếu nhập";
            this.btSoPhieuNhap.UseVisualStyleBackColor = true;
            this.btSoPhieuNhap.Click += new System.EventHandler(this.btSoPhieuNhap_Click);
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.Location = new System.Drawing.Point(235, 18);
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
            this.btSua.Location = new System.Drawing.Point(342, 18);
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
            this.btLuu.Location = new System.Drawing.Point(449, 18);
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
            this.btThoat.Location = new System.Drawing.Point(770, 18);
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
            this.btKhongLuu.Location = new System.Drawing.Point(556, 18);
            this.btKhongLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btKhongLuu.Name = "btKhongLuu";
            this.btKhongLuu.Size = new System.Drawing.Size(100, 28);
            this.btKhongLuu.TabIndex = 4;
            this.btKhongLuu.Text = "Không Lưu";
            this.btKhongLuu.UseVisualStyleBackColor = true;
            this.btKhongLuu.Click += new System.EventHandler(this.btKhongLuu_Click);
            // 
            // txtTongTienThuoc
            // 
            this.txtTongTienThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTienThuoc.Location = new System.Drawing.Point(712, 86);
            this.txtTongTienThuoc.Name = "txtTongTienThuoc";
            this.txtTongTienThuoc.ReadOnly = true;
            this.txtTongTienThuoc.Size = new System.Drawing.Size(234, 22);
            this.txtTongTienThuoc.TabIndex = 9;
            this.txtTongTienThuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(583, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "Tổng tiền thuốc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTienVAT);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtTongThanhTien);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtTongTienThuoc);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboNhaCungCap);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboHinhThucThanhToan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpNgayNhap);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboNguoiGhiPhieu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // txtTienVAT
            // 
            this.txtTienVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienVAT.Location = new System.Drawing.Point(712, 115);
            this.txtTienVAT.Name = "txtTienVAT";
            this.txtTienVAT.ReadOnly = true;
            this.txtTienVAT.Size = new System.Drawing.Size(234, 22);
            this.txtTienVAT.TabIndex = 21;
            this.txtTienVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(583, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Tiền VAT (5%)";
            // 
            // txtTongThanhTien
            // 
            this.txtTongThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThanhTien.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTongThanhTien.Location = new System.Drawing.Point(712, 145);
            this.txtTongThanhTien.Name = "txtTongThanhTien";
            this.txtTongThanhTien.ReadOnly = true;
            this.txtTongThanhTien.Size = new System.Drawing.Size(234, 22);
            this.txtTongThanhTien.TabIndex = 18;
            this.txtTongThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(583, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "Tổng thành tiền";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(712, 26);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(234, 24);
            this.cboNhaCungCap.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(583, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Nhà cung cấp";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(135, 88);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(330, 76);
            this.txtGhiChu.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Ghi chú";
            // 
            // cboHinhThucThanhToan
            // 
            this.cboHinhThucThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHinhThucThanhToan.FormattingEnabled = true;
            this.cboHinhThucThanhToan.Location = new System.Drawing.Point(712, 55);
            this.cboHinhThucThanhToan.Name = "cboHinhThucThanhToan";
            this.cboHinhThucThanhToan.Size = new System.Drawing.Size(234, 24);
            this.cboHinhThucThanhToan.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Hình thức thanh toán";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(361, 26);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(104, 22);
            this.dtpNgayNhap.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày nhập";
            // 
            // cboNguoiGhiPhieu
            // 
            this.cboNguoiGhiPhieu.FormattingEnabled = true;
            this.cboNguoiGhiPhieu.Location = new System.Drawing.Point(135, 56);
            this.cboNguoiGhiPhieu.Name = "cboNguoiGhiPhieu";
            this.cboNguoiGhiPhieu.Size = new System.Drawing.Size(330, 24);
            this.cboNguoiGhiPhieu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Người ghi phiếu";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(135, 27);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(123, 22);
            this.txtSoPhieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số phiếu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChiTietPhieuNhap);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 218);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phiếu nhập";
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaHoaDonNhap,
            this.dgvcThuoc,
            this.dgvcSoLo,
            this.dgvcNgaySanXuat,
            this.dgvcNgayHetHan,
            this.dgvcSoLuong,
            this.dgvcDonGia,
            this.dgvcTienThuoc,
            this.dgvcSoLuongBanDau});
            this.dgvChiTietPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhieuNhap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(3, 18);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(978, 197);
            this.dgvChiTietPhieuNhap.TabIndex = 0;
            this.dgvChiTietPhieuNhap.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuNhap_CellEndEdit);
            this.dgvChiTietPhieuNhap.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuNhap_CellValueChanged);
            this.dgvChiTietPhieuNhap.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvChiTietPhieuNhap_DataError);
            // 
            // dgvcMaHoaDonNhap
            // 
            this.dgvcMaHoaDonNhap.HeaderText = "MaHoaDonNhap";
            this.dgvcMaHoaDonNhap.Name = "dgvcMaHoaDonNhap";
            this.dgvcMaHoaDonNhap.Visible = false;
            this.dgvcMaHoaDonNhap.Width = 30;
            // 
            // dgvcThuoc
            // 
            this.dgvcThuoc.HeaderText = "Tên Thuốc";
            this.dgvcThuoc.Name = "dgvcThuoc";
            this.dgvcThuoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcThuoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcThuoc.Width = 220;
            // 
            // dgvcSoLo
            // 
            this.dgvcSoLo.HeaderText = "Số Lô";
            this.dgvcSoLo.Name = "dgvcSoLo";
            // 
            // dgvcNgaySanXuat
            // 
            this.dgvcNgaySanXuat.HeaderText = "Ngày Sản Xuất";
            this.dgvcNgaySanXuat.Name = "dgvcNgaySanXuat";
            this.dgvcNgaySanXuat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcNgaySanXuat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcNgaySanXuat.Width = 120;
            // 
            // dgvcNgayHetHan
            // 
            this.dgvcNgayHetHan.HeaderText = "Ngày Hết Hạn";
            this.dgvcNgayHetHan.Name = "dgvcNgayHetHan";
            this.dgvcNgayHetHan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcNgayHetHan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcNgayHetHan.Width = 120;
            // 
            // dgvcSoLuong
            // 
            this.dgvcSoLuong.HeaderText = "Số Lượng";
            this.dgvcSoLuong.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.dgvcSoLuong.Name = "dgvcSoLuong";
            this.dgvcSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcSoLuong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcDonGia
            // 
            this.dgvcDonGia.HeaderText = "Đơn Giá";
            this.dgvcDonGia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.dgvcDonGia.Name = "dgvcDonGia";
            this.dgvcDonGia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcDonGia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcTienThuoc
            // 
            this.dgvcTienThuoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvcTienThuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcTienThuoc.HeaderText = "Tiền Thuốc";
            this.dgvcTienThuoc.Name = "dgvcTienThuoc";
            this.dgvcTienThuoc.ReadOnly = true;
            this.dgvcTienThuoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvcSoLuongBanDau
            // 
            this.dgvcSoLuongBanDau.HeaderText = "SoLuongBanDau";
            this.dgvcSoLuongBanDau.Name = "dgvcSoLuongBanDau";
            this.dgvcSoLuongBanDau.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaHoaDonNhap";
            this.dataGridViewTextBoxColumn1.HeaderText = "MaHoaDonNhap";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SoLo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Số Lô";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewDateTimePickerColumn1
            // 
            this.dataGridViewDateTimePickerColumn1.HeaderText = "Ngày Sản Xuất";
            this.dataGridViewDateTimePickerColumn1.Name = "dataGridViewDateTimePickerColumn1";
            this.dataGridViewDateTimePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDateTimePickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewDateTimePickerColumn1.Width = 120;
            // 
            // dataGridViewDateTimePickerColumn2
            // 
            this.dataGridViewDateTimePickerColumn2.HeaderText = "Ngày Hết Hạn";
            this.dataGridViewDateTimePickerColumn2.Name = "dataGridViewDateTimePickerColumn2";
            this.dataGridViewDateTimePickerColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDateTimePickerColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewDateTimePickerColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NgaySanXuat";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày Sản Xuất";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NgayHetHan";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày Hết Hạn";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số Lượng";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn6.HeaderText = "Đơn Giá";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ThanhTien";
            this.dataGridViewTextBoxColumn7.HeaderText = "Thành Tiền";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // FrmPhieuNhapThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 512);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPhieuNhapThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập mua thuốc";
            this.Load += new System.EventHandler(this.FrmPhieuNhapThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btKhongLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNguoiGhiPhieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboHinhThucThanhToan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTongTienThuoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.TextBox txtTongThanhTien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox txtTienVAT;
        private System.Windows.Forms.Label label13;
        private QLNT.CommonLayer.DataGridViewDateTimePickerColumn dataGridViewDateTimePickerColumn1;
        private QLNT.CommonLayer.DataGridViewDateTimePickerColumn dataGridViewDateTimePickerColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaHoaDonNhap;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSoLo;
        private QLNT.CommonLayer.DataGridViewDateTimePickerColumn dgvcNgaySanXuat;
        private QLNT.CommonLayer.DataGridViewDateTimePickerColumn dgvcNgayHetHan;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvcSoLuong;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvcDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTienThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSoLuongBanDau;
        private System.Windows.Forms.Button btSoPhieuNhap;
        private System.Windows.Forms.Button btXoa;
    }
}