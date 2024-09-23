namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    partial class frmProduct
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
            this.dgvListProduct = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAccede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantilies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnLamTuoi = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnTim = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblMaSanPham = new DevComponents.DotNetBar.LabelX();
            this.lblGhiChu = new DevComponents.DotNetBar.LabelX();
            this.txtMaSanPham = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDonViTinh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblTenSanPham = new DevComponents.DotNetBar.LabelX();
            this.lblDonGiaNhap = new DevComponents.DotNetBar.LabelX();
            this.lblDonViTinh = new DevComponents.DotNetBar.LabelX();
            this.txtThoiGianBaoHanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenSanPham = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDonGiaNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSoLuong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblThoiGianBaoHanh = new DevComponents.DotNetBar.LabelX();
            this.lblDonGiaBan = new DevComponents.DotNetBar.LabelX();
            this.lblSoLuong = new DevComponents.DotNetBar.LabelX();
            this.txtLoaiSanPham = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLoaiSanPham = new DevComponents.DotNetBar.LabelX();
            this.txtDonGiaBan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.btnCloseFind = new DevComponents.DotNetBar.ButtonX();
            this.btnFindnext = new DevComponents.DotNetBar.ButtonX();
            this.txtFindText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFind.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListProduct
            // 
            this.dgvListProduct.AllowUserToAddRows = false;
            this.dgvListProduct.AllowUserToDeleteRows = false;
            this.dgvListProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmProductID,
            this.clmProductName,
            this.clmProductType,
            this.clmWarranty,
            this.clmAccede,
            this.clmPrice,
            this.clmQuantilies,
            this.clmUnit,
            this.clmNote});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvListProduct.Location = new System.Drawing.Point(12, 6);
            this.dgvListProduct.MultiSelect = false;
            this.dgvListProduct.Name = "dgvListProduct";
            this.dgvListProduct.ReadOnly = true;
            this.dgvListProduct.RowHeadersVisible = false;
            this.dgvListProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListProduct.Size = new System.Drawing.Size(910, 289);
            this.dgvListProduct.TabIndex = 4;
            this.dgvListProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListProduct_CellClick);
            // 
            // clmProductID
            // 
            this.clmProductID.DataPropertyName = "MaSanPham";
            this.clmProductID.HeaderText = "Mã Sản Phẩm";
            this.clmProductID.Name = "clmProductID";
            this.clmProductID.ReadOnly = true;
            // 
            // clmProductName
            // 
            this.clmProductName.DataPropertyName = "TenSanPham";
            this.clmProductName.HeaderText = "Tên Sản Phẩm";
            this.clmProductName.Name = "clmProductName";
            this.clmProductName.ReadOnly = true;
            // 
            // clmProductType
            // 
            this.clmProductType.DataPropertyName = "LoaiSanPham";
            this.clmProductType.HeaderText = "Loại Sản Phẩm";
            this.clmProductType.Name = "clmProductType";
            this.clmProductType.ReadOnly = true;
            // 
            // clmWarranty
            // 
            this.clmWarranty.DataPropertyName = "ThoiGianBaoHanh";
            this.clmWarranty.HeaderText = "Thời Gian Bảo Hành";
            this.clmWarranty.Name = "clmWarranty";
            this.clmWarranty.ReadOnly = true;
            // 
            // clmAccede
            // 
            this.clmAccede.DataPropertyName = "DonGiaNhap";
            this.clmAccede.HeaderText = "Giá Nhập";
            this.clmAccede.Name = "clmAccede";
            this.clmAccede.ReadOnly = true;
            // 
            // clmPrice
            // 
            this.clmPrice.DataPropertyName = "DonGiaBan";
            this.clmPrice.HeaderText = "Giá Bán";
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.ReadOnly = true;
            // 
            // clmQuantilies
            // 
            this.clmQuantilies.DataPropertyName = "SoLuong";
            this.clmQuantilies.HeaderText = "Số Lượng";
            this.clmQuantilies.Name = "clmQuantilies";
            this.clmQuantilies.ReadOnly = true;
            // 
            // clmUnit
            // 
            this.clmUnit.DataPropertyName = "DonViTinh";
            this.clmUnit.HeaderText = "Đơn Vị Tính";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            // 
            // clmNote
            // 
            this.clmNote.DataPropertyName = "GhiChu";
            this.clmNote.HeaderText = "Ghi Chú";
            this.clmNote.Name = "clmNote";
            this.clmNote.ReadOnly = true;
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Location = new System.Drawing.Point(928, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 28);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 601);
            this.panel1.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 295);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1011, 306);
            this.panel5.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pnlFind);
            this.panel7.Controls.Add(this.dgvListProduct);
            this.panel7.Controls.Add(this.btnLamTuoi);
            this.panel7.Controls.Add(this.btnThoat);
            this.panel7.Controls.Add(this.btnLuu);
            this.panel7.Controls.Add(this.btnTim);
            this.panel7.Controls.Add(this.btnSua);
            this.panel7.Controls.Add(this.btnXoa);
            this.panel7.Controls.Add(this.btnThem);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1011, 306);
            this.panel7.TabIndex = 5;
            // 
            // btnLamTuoi
            // 
            this.btnLamTuoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLamTuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamTuoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLamTuoi.Location = new System.Drawing.Point(928, 226);
            this.btnLamTuoi.Name = "btnLamTuoi";
            this.btnLamTuoi.Size = new System.Drawing.Size(80, 28);
            this.btnLamTuoi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLamTuoi.TabIndex = 2;
            this.btnLamTuoi.Text = "Làm Tươi";
            this.btnLamTuoi.Click += new System.EventHandler(this.btnLamTuoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(928, 266);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 28);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Enabled = false;
            this.btnLuu.Location = new System.Drawing.Point(928, 182);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 28);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTim
            // 
            this.btnTim.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTim.Location = new System.Drawing.Point(928, 138);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(80, 28);
            this.btnTim.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Location = new System.Drawing.Point(928, 94);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 28);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Location = new System.Drawing.Point(928, 50);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 28);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::QuanLyCuaHangLinhKienMayTinh.Properties.Resources.TieuDeChung;
            this.panel3.Controls.Add(this.labelX2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1011, 36);
            this.panel3.TabIndex = 5;
            // 
            // labelX2
            // 
            this.labelX2.BackgroundImage = global::QuanLyCuaHangLinhKienMayTinh.Properties.Resources.TieuDeChung;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(206, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Danh Sách Sản Phẩm";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblMaSanPham);
            this.panel6.Controls.Add(this.lblGhiChu);
            this.panel6.Controls.Add(this.txtMaSanPham);
            this.panel6.Controls.Add(this.txtDonViTinh);
            this.panel6.Controls.Add(this.txtGhiChu);
            this.panel6.Controls.Add(this.lblTenSanPham);
            this.panel6.Controls.Add(this.lblDonGiaNhap);
            this.panel6.Controls.Add(this.lblDonViTinh);
            this.panel6.Controls.Add(this.txtThoiGianBaoHanh);
            this.panel6.Controls.Add(this.txtTenSanPham);
            this.panel6.Controls.Add(this.txtDonGiaNhap);
            this.panel6.Controls.Add(this.txtSoLuong);
            this.panel6.Controls.Add(this.lblThoiGianBaoHanh);
            this.panel6.Controls.Add(this.lblDonGiaBan);
            this.panel6.Controls.Add(this.lblSoLuong);
            this.panel6.Controls.Add(this.txtLoaiSanPham);
            this.panel6.Controls.Add(this.lblLoaiSanPham);
            this.panel6.Controls.Add(this.txtDonGiaBan);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 36);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1011, 223);
            this.panel6.TabIndex = 5;
            // 
            // lblMaSanPham
            // 
            this.lblMaSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblMaSanPham.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMaSanPham.Location = new System.Drawing.Point(184, 5);
            this.lblMaSanPham.Name = "lblMaSanPham";
            this.lblMaSanPham.Size = new System.Drawing.Size(107, 23);
            this.lblMaSanPham.TabIndex = 0;
            this.lblMaSanPham.Text = "Mã Sản Phẩm";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblGhiChu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGhiChu.Location = new System.Drawing.Point(557, 135);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(67, 23);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtMaSanPham.Border.Class = "TextBoxBorder";
            this.txtMaSanPham.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaSanPham.Enabled = false;
            this.txtMaSanPham.FocusHighlightEnabled = true;
            this.txtMaSanPham.Location = new System.Drawing.Point(305, 6);
            this.txtMaSanPham.MaxLength = 10;
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(179, 20);
            this.txtMaSanPham.TabIndex = 1;
            this.txtMaSanPham.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtDonViTinh.Border.Class = "TextBoxBorder";
            this.txtDonViTinh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDonViTinh.Location = new System.Drawing.Point(638, 90);
            this.txtDonViTinh.MaxLength = 10;
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(179, 20);
            this.txtDonViTinh.TabIndex = 1;
            this.txtDonViTinh.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGhiChu.Location = new System.Drawing.Point(638, 142);
            this.txtGhiChu.MaxLength = 100;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(179, 20);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblTenSanPham.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTenSanPham.Location = new System.Drawing.Point(184, 46);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(107, 23);
            this.lblTenSanPham.TabIndex = 0;
            this.lblTenSanPham.Text = "Tên Sản Phẩm";
            // 
            // lblDonGiaNhap
            // 
            this.lblDonGiaNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblDonGiaNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDonGiaNhap.Location = new System.Drawing.Point(184, 181);
            this.lblDonGiaNhap.Name = "lblDonGiaNhap";
            this.lblDonGiaNhap.Size = new System.Drawing.Size(75, 23);
            this.lblDonGiaNhap.TabIndex = 0;
            this.lblDonGiaNhap.Text = "Đơn Giá Nhập";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblDonViTinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDonViTinh.Location = new System.Drawing.Point(557, 89);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(75, 23);
            this.lblDonViTinh.TabIndex = 0;
            this.lblDonViTinh.Text = "Đơn Vị Tính";
            // 
            // txtThoiGianBaoHanh
            // 
            this.txtThoiGianBaoHanh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtThoiGianBaoHanh.Border.Class = "TextBoxBorder";
            this.txtThoiGianBaoHanh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtThoiGianBaoHanh.Location = new System.Drawing.Point(305, 136);
            this.txtThoiGianBaoHanh.MaxLength = 9;
            this.txtThoiGianBaoHanh.Name = "txtThoiGianBaoHanh";
            this.txtThoiGianBaoHanh.Size = new System.Drawing.Size(179, 20);
            this.txtThoiGianBaoHanh.TabIndex = 1;
            this.txtThoiGianBaoHanh.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtThoiGianBaoHanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberic_KeyPress);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtTenSanPham.Border.Class = "TextBoxBorder";
            this.txtTenSanPham.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenSanPham.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTenSanPham.Location = new System.Drawing.Point(305, 47);
            this.txtTenSanPham.MaxLength = 50;
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(179, 20);
            this.txtTenSanPham.TabIndex = 1;
            this.txtTenSanPham.WatermarkColor = System.Drawing.SystemColors.WindowText;
            this.txtTenSanPham.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtDonGiaNhap.Border.Class = "TextBoxBorder";
            this.txtDonGiaNhap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDonGiaNhap.Location = new System.Drawing.Point(305, 184);
            this.txtDonGiaNhap.MaxLength = 12;
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(179, 20);
            this.txtDonGiaNhap.TabIndex = 1;
            this.txtDonGiaNhap.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtDonGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDouble_KeyPress);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtSoLuong.Border.Class = "TextBoxBorder";
            this.txtSoLuong.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSoLuong.Location = new System.Drawing.Point(638, 47);
            this.txtSoLuong.MaxLength = 9;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(179, 20);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberic_KeyPress);
            // 
            // lblThoiGianBaoHanh
            // 
            this.lblThoiGianBaoHanh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblThoiGianBaoHanh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblThoiGianBaoHanh.Location = new System.Drawing.Point(184, 135);
            this.lblThoiGianBaoHanh.Name = "lblThoiGianBaoHanh";
            this.lblThoiGianBaoHanh.Size = new System.Drawing.Size(107, 23);
            this.lblThoiGianBaoHanh.TabIndex = 0;
            this.lblThoiGianBaoHanh.Text = "Thời Gian Bảo Hành";
            // 
            // lblDonGiaBan
            // 
            this.lblDonGiaBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblDonGiaBan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDonGiaBan.Location = new System.Drawing.Point(557, 5);
            this.lblDonGiaBan.Name = "lblDonGiaBan";
            this.lblDonGiaBan.Size = new System.Drawing.Size(75, 23);
            this.lblDonGiaBan.TabIndex = 0;
            this.lblDonGiaBan.Text = "Đơn Giá Bán";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblSoLuong.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSoLuong.Location = new System.Drawing.Point(557, 46);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(75, 23);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.Text = "Số Lượng";
            // 
            // txtLoaiSanPham
            // 
            this.txtLoaiSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtLoaiSanPham.Border.Class = "TextBoxBorder";
            this.txtLoaiSanPham.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLoaiSanPham.Location = new System.Drawing.Point(305, 90);
            this.txtLoaiSanPham.MaxLength = 50;
            this.txtLoaiSanPham.Name = "txtLoaiSanPham";
            this.txtLoaiSanPham.Size = new System.Drawing.Size(179, 20);
            this.txtLoaiSanPham.TabIndex = 1;
            this.txtLoaiSanPham.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblLoaiSanPham
            // 
            this.lblLoaiSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.lblLoaiSanPham.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLoaiSanPham.Location = new System.Drawing.Point(184, 89);
            this.lblLoaiSanPham.Name = "lblLoaiSanPham";
            this.lblLoaiSanPham.Size = new System.Drawing.Size(107, 23);
            this.lblLoaiSanPham.TabIndex = 0;
            this.lblLoaiSanPham.Text = "Loại Sản Phẩm";
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtDonGiaBan.Border.Class = "TextBoxBorder";
            this.txtDonGiaBan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDonGiaBan.Location = new System.Drawing.Point(638, 6);
            this.txtDonGiaBan.MaxLength = 12;
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(179, 20);
            this.txtDonGiaBan.TabIndex = 1;
            this.txtDonGiaBan.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtDonGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDouble_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::QuanLyCuaHangLinhKienMayTinh.Properties.Resources.TieuDeChung;
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1011, 36);
            this.panel2.TabIndex = 5;
            // 
            // labelX1
            // 
            this.labelX1.BackgroundImage = global::QuanLyCuaHangLinhKienMayTinh.Properties.Resources.TieuDeChung;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(206, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Thông Tin Sản Phẩm";
            // 
            // pnlFind
            // 
            this.pnlFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFind.BackColor = System.Drawing.Color.Transparent;
            this.pnlFind.Controls.Add(this.btnCloseFind);
            this.pnlFind.Controls.Add(this.btnFindnext);
            this.pnlFind.Controls.Add(this.txtFindText);
            this.pnlFind.Location = new System.Drawing.Point(679, 213);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(243, 81);
            this.pnlFind.TabIndex = 38;
            this.pnlFind.Visible = false;
            // 
            // btnCloseFind
            // 
            this.btnCloseFind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCloseFind.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCloseFind.Location = new System.Drawing.Point(0, 0);
            this.btnCloseFind.Name = "btnCloseFind";
            this.btnCloseFind.Size = new System.Drawing.Size(20, 23);
            this.btnCloseFind.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCloseFind.TabIndex = 2;
            this.btnCloseFind.Text = "X";
            // 
            // btnFindnext
            // 
            this.btnFindnext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFindnext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFindnext.Location = new System.Drawing.Point(79, 49);
            this.btnFindnext.Name = "btnFindnext";
            this.btnFindnext.Size = new System.Drawing.Size(89, 23);
            this.btnFindnext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFindnext.TabIndex = 1;
            this.btnFindnext.Text = "Tìm kế tiếp";
            this.btnFindnext.Click += new System.EventHandler(this.btnFindnext_Click);
            // 
            // txtFindText
            // 
            this.txtFindText.Location = new System.Drawing.Point(22, 19);
            this.txtFindText.Name = "txtFindText";
            this.txtFindText.Size = new System.Drawing.Size(202, 20);
            this.txtFindText.TabIndex = 0;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 601);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvListProduct;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnTim;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblMaSanPham;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaSanPham;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenSanPham;
        private DevComponents.DotNetBar.LabelX lblTenSanPham;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtThoiGianBaoHanh;
        private DevComponents.DotNetBar.LabelX lblThoiGianBaoHanh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLoaiSanPham;
        private DevComponents.DotNetBar.LabelX lblLoaiSanPham;
        private DevComponents.DotNetBar.LabelX lblGhiChu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDonViTinh;
        private DevComponents.DotNetBar.LabelX lblDonViTinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoLuong;
        private DevComponents.DotNetBar.LabelX lblSoLuong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDonGiaBan;
        private DevComponents.DotNetBar.LabelX lblDonGiaBan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDonGiaNhap;
        private DevComponents.DotNetBar.LabelX lblDonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantilies;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAccede;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductID;
        private DevComponents.DotNetBar.ButtonX btnLamTuoi;
        private System.Windows.Forms.Panel pnlFind;
        private DevComponents.DotNetBar.ButtonX btnCloseFind;
        private DevComponents.DotNetBar.ButtonX btnFindnext;
        private System.Windows.Forms.TextBox txtFindText;
    }
}