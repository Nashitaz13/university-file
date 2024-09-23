namespace QuanLyNhaThuoc
{
    partial class FrmThuoc
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.btKhongLuu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvcMaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSeriThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaNhomThuoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcMaDonViTinh = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHienThi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcDonGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btLuu);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Controls.Add(this.btKhongLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 373);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 65);
            this.panel2.TabIndex = 4;
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.Enabled = false;
            this.btSua.Location = new System.Drawing.Point(464, 22);
            this.btSua.Margin = new System.Windows.Forms.Padding(4);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(100, 28);
            this.btSua.TabIndex = 3;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btLuu
            // 
            this.btLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLuu.Enabled = false;
            this.btLuu.Location = new System.Drawing.Point(572, 22);
            this.btLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(100, 28);
            this.btLuu.TabIndex = 2;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(788, 22);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(100, 28);
            this.btThoat.TabIndex = 1;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btKhongLuu
            // 
            this.btKhongLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btKhongLuu.Enabled = false;
            this.btKhongLuu.Location = new System.Drawing.Point(680, 22);
            this.btKhongLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btKhongLuu.Name = "btKhongLuu";
            this.btKhongLuu.Size = new System.Drawing.Size(100, 28);
            this.btKhongLuu.TabIndex = 0;
            this.btKhongLuu.Text = "Không Lưu";
            this.btKhongLuu.UseVisualStyleBackColor = true;
            this.btKhongLuu.Click += new System.EventHandler(this.btKhongLuu_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(904, 438);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvThuoc);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(904, 371);
            this.panel4.TabIndex = 2;
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaThuoc,
            this.dgvcSeriThuoc,
            this.dgvcTenThuoc,
            this.dgvcMaNhomThuoc,
            this.dgvcMaDonViTinh,
            this.dgvcMoTa,
            this.dgvcHienThi,
            this.dgvcDonGiaBan,
            this.dgvcVAT,
            this.dgvcSoLuongTon});
            this.dgvThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThuoc.Location = new System.Drawing.Point(0, 0);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.Size = new System.Drawing.Size(904, 371);
            this.dgvThuoc.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 67);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(904, 67);
            this.label1.TabIndex = 1;
            this.label1.Text = "THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvcMaThuoc
            // 
            this.dgvcMaThuoc.DataPropertyName = "MaThuoc";
            this.dgvcMaThuoc.HeaderText = "MaThuoc";
            this.dgvcMaThuoc.Name = "dgvcMaThuoc";
            this.dgvcMaThuoc.Visible = false;
            // 
            // dgvcSeriThuoc
            // 
            this.dgvcSeriThuoc.DataPropertyName = "SeriThuoc";
            this.dgvcSeriThuoc.HeaderText = "Mã thuốc";
            this.dgvcSeriThuoc.Name = "dgvcSeriThuoc";
            // 
            // dgvcTenThuoc
            // 
            this.dgvcTenThuoc.DataPropertyName = "TenThuoc";
            this.dgvcTenThuoc.HeaderText = "Tên thuốc";
            this.dgvcTenThuoc.Name = "dgvcTenThuoc";
            this.dgvcTenThuoc.Width = 150;
            // 
            // dgvcMaNhomThuoc
            // 
            this.dgvcMaNhomThuoc.HeaderText = "Nhóm thuốc";
            this.dgvcMaNhomThuoc.Name = "dgvcMaNhomThuoc";
            this.dgvcMaNhomThuoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcMaNhomThuoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcMaNhomThuoc.Width = 150;
            // 
            // dgvcMaDonViTinh
            // 
            this.dgvcMaDonViTinh.HeaderText = "Đơn vị tính";
            this.dgvcMaDonViTinh.Name = "dgvcMaDonViTinh";
            this.dgvcMaDonViTinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcMaDonViTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcMoTa
            // 
            this.dgvcMoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcMoTa.DataPropertyName = "MoTa";
            this.dgvcMoTa.HeaderText = "Mô tả";
            this.dgvcMoTa.Name = "dgvcMoTa";
            // 
            // dgvcHienThi
            // 
            this.dgvcHienThi.DataPropertyName = "HienThi";
            this.dgvcHienThi.HeaderText = "Được phép sử dụng";
            this.dgvcHienThi.Name = "dgvcHienThi";
            this.dgvcHienThi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcHienThi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcDonGiaBan
            // 
            this.dgvcDonGiaBan.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvcDonGiaBan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcDonGiaBan.HeaderText = "Đơn giá bán hiện tại";
            this.dgvcDonGiaBan.Name = "dgvcDonGiaBan";
            this.dgvcDonGiaBan.ReadOnly = true;
            this.dgvcDonGiaBan.Visible = false;
            // 
            // dgvcVAT
            // 
            this.dgvcVAT.DataPropertyName = "VAT";
            this.dgvcVAT.HeaderText = "VAT";
            this.dgvcVAT.Name = "dgvcVAT";
            this.dgvcVAT.Visible = false;
            // 
            // dgvcSoLuongTon
            // 
            this.dgvcSoLuongTon.DataPropertyName = "SoLuongTon";
            this.dgvcSoLuongTon.HeaderText = "Số lương tồn";
            this.dgvcSoLuongTon.Name = "dgvcSoLuongTon";
            this.dgvcSoLuongTon.Visible = false;
            // 
            // FrmThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 438);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục thuốc";
            this.Load += new System.EventHandler(this.FrmThuoc_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btKhongLuu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvThuoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSeriThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenThuoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcMaNhomThuoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcMaDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMoTa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcHienThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDonGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSoLuongTon;
    }
}