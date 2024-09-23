namespace QuanLyNhaThuoc
{
    partial class FrmSoPhieuTraThuoc
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
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSoPhieuTraThuoc = new System.Windows.Forms.DataGridView();
            this.dgvcMaPhieuTraThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSeriHoaDonTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNgayTraThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSeriHoaDonXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNguoiGhiPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongTienPhaiTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoPhieuTraThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 53);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1026, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "SỔ PHIẾU TRẢ THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btThem);
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 59);
            this.panel2.TabIndex = 3;
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.Location = new System.Drawing.Point(697, 18);
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
            this.btSua.Location = new System.Drawing.Point(805, 18);
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
            this.btThoat.Location = new System.Drawing.Point(913, 18);
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
            this.panel3.Controls.Add(this.dgvSoPhieuTraThuoc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 327);
            this.panel3.TabIndex = 4;
            // 
            // dgvSoPhieuTraThuoc
            // 
            this.dgvSoPhieuTraThuoc.AllowUserToAddRows = false;
            this.dgvSoPhieuTraThuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoPhieuTraThuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoPhieuTraThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoPhieuTraThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaPhieuTraThuoc,
            this.dgvcSeriHoaDonTra,
            this.dgvcNgayTraThuoc,
            this.dgvcSeriHoaDonXuat,
            this.dgvcNguoiGhiPhieu,
            this.dgvcLyDo,
            this.dgvcTongTienPhaiTra});
            this.dgvSoPhieuTraThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSoPhieuTraThuoc.Location = new System.Drawing.Point(0, 0);
            this.dgvSoPhieuTraThuoc.MultiSelect = false;
            this.dgvSoPhieuTraThuoc.Name = "dgvSoPhieuTraThuoc";
            this.dgvSoPhieuTraThuoc.ReadOnly = true;
            this.dgvSoPhieuTraThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoPhieuTraThuoc.Size = new System.Drawing.Size(1026, 327);
            this.dgvSoPhieuTraThuoc.TabIndex = 0;
            // 
            // dgvcMaPhieuTraThuoc
            // 
            this.dgvcMaPhieuTraThuoc.DataPropertyName = "MaPhieuTraThuoc";
            this.dgvcMaPhieuTraThuoc.HeaderText = "MaPhieuTraThuoc";
            this.dgvcMaPhieuTraThuoc.Name = "dgvcMaPhieuTraThuoc";
            this.dgvcMaPhieuTraThuoc.ReadOnly = true;
            this.dgvcMaPhieuTraThuoc.Visible = false;
            this.dgvcMaPhieuTraThuoc.Width = 10;
            // 
            // dgvcSeriHoaDonTra
            // 
            this.dgvcSeriHoaDonTra.DataPropertyName = "SeriHoaDonTra";
            this.dgvcSeriHoaDonTra.HeaderText = "Số hóa đơn trả";
            this.dgvcSeriHoaDonTra.Name = "dgvcSeriHoaDonTra";
            this.dgvcSeriHoaDonTra.ReadOnly = true;
            this.dgvcSeriHoaDonTra.Width = 120;
            // 
            // dgvcNgayTraThuoc
            // 
            this.dgvcNgayTraThuoc.DataPropertyName = "NgayTraThuoc";
            this.dgvcNgayTraThuoc.HeaderText = "Ngày trả thuốc";
            this.dgvcNgayTraThuoc.Name = "dgvcNgayTraThuoc";
            this.dgvcNgayTraThuoc.ReadOnly = true;
            this.dgvcNgayTraThuoc.Width = 120;
            // 
            // dgvcSeriHoaDonXuat
            // 
            this.dgvcSeriHoaDonXuat.DataPropertyName = "SeriHoaDonXuat";
            this.dgvcSeriHoaDonXuat.HeaderText = "Số hóa đơn xuất";
            this.dgvcSeriHoaDonXuat.Name = "dgvcSeriHoaDonXuat";
            this.dgvcSeriHoaDonXuat.ReadOnly = true;
            this.dgvcSeriHoaDonXuat.Width = 130;
            // 
            // dgvcNguoiGhiPhieu
            // 
            this.dgvcNguoiGhiPhieu.DataPropertyName = "NguoiGhiPhieu";
            this.dgvcNguoiGhiPhieu.HeaderText = "Người ghi phiếu";
            this.dgvcNguoiGhiPhieu.Name = "dgvcNguoiGhiPhieu";
            this.dgvcNguoiGhiPhieu.ReadOnly = true;
            this.dgvcNguoiGhiPhieu.Width = 150;
            // 
            // dgvcLyDo
            // 
            this.dgvcLyDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcLyDo.DataPropertyName = "LyDo";
            this.dgvcLyDo.HeaderText = "Lý do";
            this.dgvcLyDo.Name = "dgvcLyDo";
            this.dgvcLyDo.ReadOnly = true;
            // 
            // dgvcTongTienPhaiTra
            // 
            this.dgvcTongTienPhaiTra.DataPropertyName = "TongTienPhaiTra";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvcTongTienPhaiTra.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcTongTienPhaiTra.HeaderText = "Tổng thành tiền";
            this.dgvcTongTienPhaiTra.Name = "dgvcTongTienPhaiTra";
            this.dgvcTongTienPhaiTra.ReadOnly = true;
            this.dgvcTongTienPhaiTra.Width = 150;
            // 
            // FrmSoPhieuTraThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 439);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSoPhieuTraThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ phiếu trả thuốc";
            this.Load += new System.EventHandler(this.FrmSoPhieuTraThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoPhieuTraThuoc)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSoPhieuTraThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaPhieuTraThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSeriHoaDonTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNgayTraThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSeriHoaDonXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNguoiGhiPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongTienPhaiTra;
    }
}