namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    partial class frmWarehouseBill
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.txtTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgvDetailWarehouseBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaChiTietPhieuNhapKHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhieuNhapKho1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWarehouseBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaPhieuNhapKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLapPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiLapPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLamTuoi = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnTim = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailWarehouseBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseBill)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 42);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1077, 546);
            this.panel5.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnThem);
            this.panel7.Controls.Add(this.txtTotal);
            this.panel7.Controls.Add(this.labelX3);
            this.panel7.Controls.Add(this.dgvDetailWarehouseBill);
            this.panel7.Controls.Add(this.dgvWarehouseBill);
            this.panel7.Controls.Add(this.btnLamTuoi);
            this.panel7.Controls.Add(this.btnThoat);
            this.panel7.Controls.Add(this.btnTim);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1077, 546);
            this.panel7.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Location = new System.Drawing.Point(994, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 28);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotal.Border.Class = "TextBoxBorder";
            this.txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(848, 511);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(141, 20);
            this.txtTotal.TabIndex = 9;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(788, 511);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(54, 23);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "Tổng";
            // 
            // dgvDetailWarehouseBill
            // 
            this.dgvDetailWarehouseBill.AllowUserToAddRows = false;
            this.dgvDetailWarehouseBill.AllowUserToDeleteRows = false;
            this.dgvDetailWarehouseBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailWarehouseBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetailWarehouseBill.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetailWarehouseBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailWarehouseBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiTietPhieuNhapKHo,
            this.MaPhieuNhapKho1,
            this.MaSanPham,
            this.DonGiaNhap,
            this.SoLuong,
            this.GhiChu1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailWarehouseBill.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetailWarehouseBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDetailWarehouseBill.Location = new System.Drawing.Point(428, 6);
            this.dgvDetailWarehouseBill.Name = "dgvDetailWarehouseBill";
            this.dgvDetailWarehouseBill.ReadOnly = true;
            this.dgvDetailWarehouseBill.RowHeadersVisible = false;
            this.dgvDetailWarehouseBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDetailWarehouseBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailWarehouseBill.Size = new System.Drawing.Size(560, 479);
            this.dgvDetailWarehouseBill.TabIndex = 5;
            // 
            // MaChiTietPhieuNhapKHo
            // 
            this.MaChiTietPhieuNhapKHo.DataPropertyName = "MaChiTietPhieuNhapKho";
            this.MaChiTietPhieuNhapKHo.HeaderText = "Mã Chi Tiết Phiếu Nhập Kho";
            this.MaChiTietPhieuNhapKHo.Name = "MaChiTietPhieuNhapKHo";
            this.MaChiTietPhieuNhapKHo.ReadOnly = true;
            // 
            // MaPhieuNhapKho1
            // 
            this.MaPhieuNhapKho1.DataPropertyName = "MaPhieuNhapKho";
            this.MaPhieuNhapKho1.HeaderText = "Mã Phiếu Nhập Kho";
            this.MaPhieuNhapKho1.Name = "MaPhieuNhapKho1";
            this.MaPhieuNhapKho1.ReadOnly = true;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã Sản Phẩm";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.ReadOnly = true;
            this.MaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DonGiaNhap
            // 
            this.DonGiaNhap.DataPropertyName = "DonGiaNhap";
            this.DonGiaNhap.HeaderText = "Đơn Giá";
            this.DonGiaNhap.Name = "DonGiaNhap";
            this.DonGiaNhap.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GhiChu1
            // 
            this.GhiChu1.DataPropertyName = "GhiChu";
            this.GhiChu1.HeaderText = "Ghi Chú";
            this.GhiChu1.Name = "GhiChu1";
            this.GhiChu1.ReadOnly = true;
            // 
            // dgvWarehouseBill
            // 
            this.dgvWarehouseBill.AllowUserToAddRows = false;
            this.dgvWarehouseBill.AllowUserToDeleteRows = false;
            this.dgvWarehouseBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvWarehouseBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouseBill.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWarehouseBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouseBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuNhapKho,
            this.NgayLapPhieu,
            this.NguoiLapPhieu,
            this.GhiChu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWarehouseBill.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWarehouseBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvWarehouseBill.Location = new System.Drawing.Point(12, 6);
            this.dgvWarehouseBill.Name = "dgvWarehouseBill";
            this.dgvWarehouseBill.ReadOnly = true;
            this.dgvWarehouseBill.RowHeadersVisible = false;
            this.dgvWarehouseBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvWarehouseBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouseBill.Size = new System.Drawing.Size(404, 529);
            this.dgvWarehouseBill.TabIndex = 4;
            this.dgvWarehouseBill.SelectionChanged += new System.EventHandler(this.dgvWarehouseBill_SelectionChanged);
            // 
            // MaPhieuNhapKho
            // 
            this.MaPhieuNhapKho.DataPropertyName = "MaPhieuNhapKho";
            this.MaPhieuNhapKho.HeaderText = "Mã Phiếu Nhập Kho";
            this.MaPhieuNhapKho.Name = "MaPhieuNhapKho";
            this.MaPhieuNhapKho.ReadOnly = true;
            // 
            // NgayLapPhieu
            // 
            this.NgayLapPhieu.DataPropertyName = "NgayLapPhieu";
            this.NgayLapPhieu.HeaderText = "Ngày Lập Phiếu";
            this.NgayLapPhieu.Name = "NgayLapPhieu";
            this.NgayLapPhieu.ReadOnly = true;
            // 
            // NguoiLapPhieu
            // 
            this.NguoiLapPhieu.DataPropertyName = "MaNguoiLapPhieu";
            this.NguoiLapPhieu.HeaderText = "Người Lập Phiếu";
            this.NguoiLapPhieu.Name = "NguoiLapPhieu";
            this.NguoiLapPhieu.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // btnLamTuoi
            // 
            this.btnLamTuoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLamTuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamTuoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLamTuoi.Location = new System.Drawing.Point(994, 80);
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
            this.btnThoat.Location = new System.Drawing.Point(994, 120);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 28);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            // 
            // btnTim
            // 
            this.btnTim.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTim.Location = new System.Drawing.Point(994, 40);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(80, 28);
            this.btnTim.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 588);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::QuanLyCuaHangLinhKienMayTinh.Properties.Resources.TieuDeChung;
            this.panel3.Controls.Add(this.labelX2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1077, 42);
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
            this.labelX2.Text = "Danh Sách Phiếu Nhập Kho";
            // 
            // frmWarehouseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 588);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1093, 604);
            this.Name = "frmWarehouseBill";
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailWarehouseBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseBill)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDetailWarehouseBill;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvWarehouseBill;
        private DevComponents.DotNetBar.ButtonX btnLamTuoi;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnTim;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiLapPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuNhapKho;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTotal;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuNhapKho1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietPhieuNhapKHo;
    }
}