namespace QuanLyNhaThuoc
{
    partial class FrmSoPhieuNhapThuoc
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
            this.dgvSoPhieuNhapThuoc = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaHoaDonNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSeriHoaDonNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongTienThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTienVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongTienThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoPhieuNhapThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 53);
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
            this.label1.Size = new System.Drawing.Size(984, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "SỔ PHIẾU NHẬP MUA THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btThem);
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 59);
            this.panel2.TabIndex = 2;
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.Location = new System.Drawing.Point(655, 18);
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
            this.btSua.Location = new System.Drawing.Point(763, 18);
            this.btSua.Margin = new System.Windows.Forms.Padding(4);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(100, 28);
            this.btSua.TabIndex = 7;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(871, 18);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(100, 28);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSoPhieuNhapThuoc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 400);
            this.panel3.TabIndex = 3;
            // 
            // dgvSoPhieuNhapThuoc
            // 
            this.dgvSoPhieuNhapThuoc.AllowUserToAddRows = false;
            this.dgvSoPhieuNhapThuoc.AllowUserToDeleteRows = false;
            this.dgvSoPhieuNhapThuoc.AllowUserToOrderColumns = true;
            this.dgvSoPhieuNhapThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoPhieuNhapThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaHoaDonNhap,
            this.dgvcSeriHoaDonNhap,
            this.dgvcTenNhanVien,
            this.dgvcNgayNhap,
            this.dgvcTenNhaCungCap,
            this.dgvcVAT,
            this.dgvcTongTienThuoc,
            this.dgvcTienVAT,
            this.dgvcTongTienThanhToan});
            this.dgvSoPhieuNhapThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSoPhieuNhapThuoc.Location = new System.Drawing.Point(0, 0);
            this.dgvSoPhieuNhapThuoc.MultiSelect = false;
            this.dgvSoPhieuNhapThuoc.Name = "dgvSoPhieuNhapThuoc";
            this.dgvSoPhieuNhapThuoc.ReadOnly = true;
            this.dgvSoPhieuNhapThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoPhieuNhapThuoc.Size = new System.Drawing.Size(984, 400);
            this.dgvSoPhieuNhapThuoc.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaHoaDonNhap";
            this.dataGridViewTextBoxColumn1.HeaderText = "MaHoaDonNhap";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SeriHoaDonNhap";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã số";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KyHieuHoaDonNhap";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ký hiệu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TenNhanVien";
            this.dataGridViewTextBoxColumn4.HeaderText = "Nhân viên";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NgayNhap";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ngày nhập";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TenNhaCungCap";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nhà cung cấp";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "VAT";
            this.dataGridViewTextBoxColumn7.HeaderText = "VAT";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TongTienThuoc";
            this.dataGridViewTextBoxColumn8.HeaderText = "Tổng tiền thuốc";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TienVAT";
            this.dataGridViewTextBoxColumn9.HeaderText = "Tiền VAT";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TongTienThanhToan";
            this.dataGridViewTextBoxColumn10.HeaderText = "Tổng thành tiền";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dgvcMaHoaDonNhap
            // 
            this.dgvcMaHoaDonNhap.DataPropertyName = "MaHoaDonNhap";
            this.dgvcMaHoaDonNhap.HeaderText = "MaHoaDonNhap";
            this.dgvcMaHoaDonNhap.Name = "dgvcMaHoaDonNhap";
            this.dgvcMaHoaDonNhap.ReadOnly = true;
            this.dgvcMaHoaDonNhap.Visible = false;
            // 
            // dgvcSeriHoaDonNhap
            // 
            this.dgvcSeriHoaDonNhap.DataPropertyName = "SeriHoaDonNhap";
            this.dgvcSeriHoaDonNhap.HeaderText = "Mã số";
            this.dgvcSeriHoaDonNhap.Name = "dgvcSeriHoaDonNhap";
            this.dgvcSeriHoaDonNhap.ReadOnly = true;
            this.dgvcSeriHoaDonNhap.Width = 80;
            // 
            // dgvcTenNhanVien
            // 
            this.dgvcTenNhanVien.DataPropertyName = "TenNhanVien";
            this.dgvcTenNhanVien.HeaderText = "Nhân viên";
            this.dgvcTenNhanVien.Name = "dgvcTenNhanVien";
            this.dgvcTenNhanVien.ReadOnly = true;
            this.dgvcTenNhanVien.Width = 150;
            // 
            // dgvcNgayNhap
            // 
            this.dgvcNgayNhap.DataPropertyName = "NgayNhap";
            this.dgvcNgayNhap.HeaderText = "Ngày nhập";
            this.dgvcNgayNhap.Name = "dgvcNgayNhap";
            this.dgvcNgayNhap.ReadOnly = true;
            // 
            // dgvcTenNhaCungCap
            // 
            this.dgvcTenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.dgvcTenNhaCungCap.HeaderText = "Nhà cung cấp";
            this.dgvcTenNhaCungCap.Name = "dgvcTenNhaCungCap";
            this.dgvcTenNhaCungCap.ReadOnly = true;
            this.dgvcTenNhaCungCap.Width = 170;
            // 
            // dgvcVAT
            // 
            this.dgvcVAT.DataPropertyName = "VAT";
            this.dgvcVAT.HeaderText = "VAT (%)";
            this.dgvcVAT.Name = "dgvcVAT";
            this.dgvcVAT.ReadOnly = true;
            this.dgvcVAT.Width = 80;
            // 
            // dgvcTongTienThuoc
            // 
            this.dgvcTongTienThuoc.DataPropertyName = "TongTienThuoc";
            this.dgvcTongTienThuoc.HeaderText = "Tổng tiền thuốc (đ)";
            this.dgvcTongTienThuoc.Name = "dgvcTongTienThuoc";
            this.dgvcTongTienThuoc.ReadOnly = true;
            this.dgvcTongTienThuoc.Width = 120;
            // 
            // dgvcTienVAT
            // 
            this.dgvcTienVAT.DataPropertyName = "TienVAT";
            this.dgvcTienVAT.HeaderText = "Tiền VAT (đ)";
            this.dgvcTienVAT.Name = "dgvcTienVAT";
            this.dgvcTienVAT.ReadOnly = true;
            this.dgvcTienVAT.Width = 120;
            // 
            // dgvcTongTienThanhToan
            // 
            this.dgvcTongTienThanhToan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcTongTienThanhToan.DataPropertyName = "TongTienThanhToan";
            this.dgvcTongTienThanhToan.HeaderText = "Tổng thành tiền (đ)";
            this.dgvcTongTienThanhToan.Name = "dgvcTongTienThanhToan";
            this.dgvcTongTienThanhToan.ReadOnly = true;
            // 
            // FrmSoPhieuNhapThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 512);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSoPhieuNhapThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ phiếu nhập thuốc";
            this.Load += new System.EventHandler(this.FrmSoPhieuNhapThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoPhieuNhapThuoc)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSoPhieuNhapThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaHoaDonNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSeriHoaDonNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongTienThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTienVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongTienThanhToan;
    }
}