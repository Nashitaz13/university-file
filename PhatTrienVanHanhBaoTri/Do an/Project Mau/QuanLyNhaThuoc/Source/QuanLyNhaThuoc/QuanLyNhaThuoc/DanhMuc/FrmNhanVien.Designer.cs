namespace QuanLyNhaThuoc
{
    partial class FrmNhanVien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.btKhongLuu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.dgvcMaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaChucVu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcGioiTinhNam = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTrinhDoVanHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcChuyenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 70);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(845, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btLuu);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Controls.Add(this.btKhongLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 80);
            this.panel2.TabIndex = 2;
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.Enabled = false;
            this.btSua.Location = new System.Drawing.Point(258, 27);
            this.btSua.Margin = new System.Windows.Forms.Padding(5);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(133, 34);
            this.btSua.TabIndex = 3;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btLuu
            // 
            this.btLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLuu.Enabled = false;
            this.btLuu.Location = new System.Drawing.Point(402, 27);
            this.btLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(133, 34);
            this.btLuu.TabIndex = 2;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(690, 27);
            this.btThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(133, 34);
            this.btThoat.TabIndex = 1;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btKhongLuu
            // 
            this.btKhongLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btKhongLuu.Enabled = false;
            this.btKhongLuu.Location = new System.Drawing.Point(546, 27);
            this.btKhongLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btKhongLuu.Name = "btKhongLuu";
            this.btKhongLuu.Size = new System.Drawing.Size(133, 34);
            this.btKhongLuu.TabIndex = 0;
            this.btKhongLuu.Text = "Không Lưu";
            this.btKhongLuu.UseVisualStyleBackColor = true;
            this.btKhongLuu.Click += new System.EventHandler(this.btKhongLuu_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvNhanVien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(845, 401);
            this.panel3.TabIndex = 3;
            // 
            // dgvNhanVien
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaNhanVien,
            this.dgvcMaChucVu,
            this.dgvcTenNhanVien,
            this.dgvcNgaySinh,
            this.dgvcGioiTinhNam,
            this.dgvcTaiKhoan,
            this.dgvcMatKhau,
            this.dgvcTrinhDoVanHoa,
            this.dgvcCMND,
            this.dgvcChuyenMon,
            this.dgvcDiaChi});
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 0);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.Size = new System.Drawing.Size(845, 401);
            this.dgvNhanVien.TabIndex = 0;
            // 
            // dgvcMaNhanVien
            // 
            this.dgvcMaNhanVien.DataPropertyName = "MaNhanVien";
            this.dgvcMaNhanVien.HeaderText = "MaNhanVien";
            this.dgvcMaNhanVien.Name = "dgvcMaNhanVien";
            this.dgvcMaNhanVien.Visible = false;
            // 
            // dgvcMaChucVu
            // 
            this.dgvcMaChucVu.DataPropertyName = "MaChucVu";
            this.dgvcMaChucVu.HeaderText = "Chức vụ";
            this.dgvcMaChucVu.Name = "dgvcMaChucVu";
            this.dgvcMaChucVu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcMaChucVu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcMaChucVu.Width = 130;
            // 
            // dgvcTenNhanVien
            // 
            this.dgvcTenNhanVien.DataPropertyName = "TenNhanVien";
            this.dgvcTenNhanVien.HeaderText = "Tên nhân viên";
            this.dgvcTenNhanVien.Name = "dgvcTenNhanVien";
            this.dgvcTenNhanVien.Width = 200;
            // 
            // dgvcNgaySinh
            // 
            this.dgvcNgaySinh.DataPropertyName = "NgaySinh";
            this.dgvcNgaySinh.HeaderText = "Ngày sinh";
            this.dgvcNgaySinh.Name = "dgvcNgaySinh";
            this.dgvcNgaySinh.Visible = false;
            // 
            // dgvcGioiTinhNam
            // 
            this.dgvcGioiTinhNam.DataPropertyName = "GioiTinhNam";
            this.dgvcGioiTinhNam.HeaderText = "Giới tính (Nam)";
            this.dgvcGioiTinhNam.Name = "dgvcGioiTinhNam";
            this.dgvcGioiTinhNam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcGioiTinhNam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcGioiTinhNam.Width = 150;
            // 
            // dgvcTaiKhoan
            // 
            this.dgvcTaiKhoan.DataPropertyName = "TaiKhoan";
            this.dgvcTaiKhoan.HeaderText = "TaiKhoan";
            this.dgvcTaiKhoan.Name = "dgvcTaiKhoan";
            this.dgvcTaiKhoan.Visible = false;
            // 
            // dgvcMatKhau
            // 
            this.dgvcMatKhau.DataPropertyName = "MatKhau";
            this.dgvcMatKhau.HeaderText = "MatKhau";
            this.dgvcMatKhau.Name = "dgvcMatKhau";
            this.dgvcMatKhau.Visible = false;
            // 
            // dgvcTrinhDoVanHoa
            // 
            this.dgvcTrinhDoVanHoa.DataPropertyName = "TrinhDoVanHoa";
            this.dgvcTrinhDoVanHoa.HeaderText = "Trình độ văn hóa";
            this.dgvcTrinhDoVanHoa.Name = "dgvcTrinhDoVanHoa";
            this.dgvcTrinhDoVanHoa.Visible = false;
            // 
            // dgvcCMND
            // 
            this.dgvcCMND.DataPropertyName = "CMND";
            this.dgvcCMND.HeaderText = "CMND";
            this.dgvcCMND.Name = "dgvcCMND";
            this.dgvcCMND.Visible = false;
            // 
            // dgvcChuyenMon
            // 
            this.dgvcChuyenMon.DataPropertyName = "ChuyenMon";
            this.dgvcChuyenMon.HeaderText = "ChuyenMon";
            this.dgvcChuyenMon.Name = "dgvcChuyenMon";
            this.dgvcChuyenMon.Visible = false;
            // 
            // dgvcDiaChi
            // 
            this.dgvcDiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcDiaChi.DataPropertyName = "DiaChi";
            this.dgvcDiaChi.HeaderText = "Địa chỉ";
            this.dgvcDiaChi.Name = "dgvcDiaChi";
            // 
            // FrmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 551);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.FrmNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btKhongLuu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaNhanVien;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcMaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNgaySinh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcGioiTinhNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTrinhDoVanHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcChuyenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDiaChi;
    }
}