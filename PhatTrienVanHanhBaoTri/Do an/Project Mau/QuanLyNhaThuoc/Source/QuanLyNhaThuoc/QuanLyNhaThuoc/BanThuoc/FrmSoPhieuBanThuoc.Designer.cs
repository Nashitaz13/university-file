namespace QuanLyNhaThuoc
{
    partial class FrmSoPhieuBanThuoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSoPhieuXuatThuoc = new System.Windows.Forms.DataGridView();
            this.dgvcMaHoaDonXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSeriHoaDonNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNguoiGhiPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNgayXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongTienThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTienVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongTienThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoPhieuXuatThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 65);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1051, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "SỔ PHIẾU XUẤT BÁN THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btThem);
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 486);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 73);
            this.panel2.TabIndex = 3;
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.Location = new System.Drawing.Point(612, 22);
            this.btThem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(133, 34);
            this.btThem.TabIndex = 8;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.Location = new System.Drawing.Point(756, 22);
            this.btSua.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(133, 34);
            this.btSua.TabIndex = 7;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(900, 22);
            this.btThoat.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(133, 34);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSoPhieuXuatThuoc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1051, 421);
            this.panel3.TabIndex = 4;
            // 
            // dgvSoPhieuXuatThuoc
            // 
            this.dgvSoPhieuXuatThuoc.AllowUserToAddRows = false;
            this.dgvSoPhieuXuatThuoc.AllowUserToDeleteRows = false;
            this.dgvSoPhieuXuatThuoc.AllowUserToOrderColumns = true;
            this.dgvSoPhieuXuatThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoPhieuXuatThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaHoaDonXuat,
            this.dgvcSeriHoaDonNhap,
            this.dgvcNguoiGhiPhieu,
            this.dgvcNgayXuat,
            this.dgvcTongTienThuoc,
            this.dgvcTienVAT,
            this.dgvcTongTienThanhToan});
            this.dgvSoPhieuXuatThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSoPhieuXuatThuoc.Location = new System.Drawing.Point(0, 0);
            this.dgvSoPhieuXuatThuoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSoPhieuXuatThuoc.MultiSelect = false;
            this.dgvSoPhieuXuatThuoc.Name = "dgvSoPhieuXuatThuoc";
            this.dgvSoPhieuXuatThuoc.ReadOnly = true;
            this.dgvSoPhieuXuatThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoPhieuXuatThuoc.Size = new System.Drawing.Size(1051, 421);
            this.dgvSoPhieuXuatThuoc.TabIndex = 0;
            // 
            // dgvcMaHoaDonXuat
            // 
            this.dgvcMaHoaDonXuat.DataPropertyName = "MaHoaDonXuat";
            this.dgvcMaHoaDonXuat.HeaderText = "MaHoaDonXuat";
            this.dgvcMaHoaDonXuat.Name = "dgvcMaHoaDonXuat";
            this.dgvcMaHoaDonXuat.ReadOnly = true;
            this.dgvcMaHoaDonXuat.Visible = false;
            // 
            // dgvcSeriHoaDonNhap
            // 
            this.dgvcSeriHoaDonNhap.DataPropertyName = "SeriHoaDonXuat";
            this.dgvcSeriHoaDonNhap.HeaderText = "Mã số";
            this.dgvcSeriHoaDonNhap.Name = "dgvcSeriHoaDonNhap";
            this.dgvcSeriHoaDonNhap.ReadOnly = true;
            // 
            // dgvcNguoiGhiPhieu
            // 
            this.dgvcNguoiGhiPhieu.DataPropertyName = "NguoiGhiPhieu";
            this.dgvcNguoiGhiPhieu.HeaderText = "Người ghi phiếu";
            this.dgvcNguoiGhiPhieu.Name = "dgvcNguoiGhiPhieu";
            this.dgvcNguoiGhiPhieu.ReadOnly = true;
            this.dgvcNguoiGhiPhieu.Width = 150;
            // 
            // dgvcNgayXuat
            // 
            this.dgvcNgayXuat.DataPropertyName = "NgayXuat";
            this.dgvcNgayXuat.HeaderText = "Ngày xuất";
            this.dgvcNgayXuat.Name = "dgvcNgayXuat";
            this.dgvcNgayXuat.ReadOnly = true;
            this.dgvcNgayXuat.Width = 120;
            // 
            // dgvcTongTienThuoc
            // 
            this.dgvcTongTienThuoc.DataPropertyName = "TongTienThuoc";
            this.dgvcTongTienThuoc.HeaderText = "Tổng tiền thuốc";
            this.dgvcTongTienThuoc.Name = "dgvcTongTienThuoc";
            this.dgvcTongTienThuoc.ReadOnly = true;
            this.dgvcTongTienThuoc.Width = 130;
            // 
            // dgvcTienVAT
            // 
            this.dgvcTienVAT.DataPropertyName = "TongTienVAT";
            this.dgvcTienVAT.HeaderText = "Tiền VAT";
            this.dgvcTienVAT.Name = "dgvcTienVAT";
            this.dgvcTienVAT.ReadOnly = true;
            // 
            // dgvcTongTienThanhToan
            // 
            this.dgvcTongTienThanhToan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcTongTienThanhToan.DataPropertyName = "TongTienThanhToan";
            this.dgvcTongTienThanhToan.HeaderText = "Tổng thành tiền";
            this.dgvcTongTienThanhToan.Name = "dgvcTongTienThanhToan";
            this.dgvcTongTienThanhToan.ReadOnly = true;
            // 
            // FrmSoPhieuBanThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 559);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmSoPhieuBanThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ phiếu bán thuốc";
            this.Load += new System.EventHandler(this.FrmSoPhieuBanThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoPhieuXuatThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSoPhieuXuatThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaHoaDonXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSeriHoaDonNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNguoiGhiPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNgayXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongTienThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTienVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongTienThanhToan;
    }
}