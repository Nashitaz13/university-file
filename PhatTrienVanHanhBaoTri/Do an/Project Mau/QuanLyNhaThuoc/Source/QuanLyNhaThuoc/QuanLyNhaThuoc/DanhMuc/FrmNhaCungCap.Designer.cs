namespace QuanLyNhaThuoc
{
    partial class FrmNhaCungCap
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
            this.dgvNhaCungCap = new System.Windows.Forms.DataGridView();
            this.dgvcMaNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaSoThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNguoiLienHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 70);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(967, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHÀ CUNG CẤP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSua);
            this.panel2.Controls.Add(this.btLuu);
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Controls.Add(this.btKhongLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 428);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 80);
            this.panel2.TabIndex = 2;
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.Enabled = false;
            this.btSua.Location = new System.Drawing.Point(380, 27);
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
            this.btLuu.Location = new System.Drawing.Point(524, 27);
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
            this.btThoat.Location = new System.Drawing.Point(812, 27);
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
            this.btKhongLuu.Location = new System.Drawing.Point(668, 27);
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
            this.panel3.Controls.Add(this.dgvNhaCungCap);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(967, 358);
            this.panel3.TabIndex = 3;
            // 
            // dgvNhaCungCap
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhaCungCap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaNhaCungCap,
            this.dgvcTenNhaCungCap,
            this.dgvcMaSoThue,
            this.dgvcNguoiLienHe,
            this.dgvcDienThoai,
            this.dgvcFax,
            this.dgvcDiaChi,
            this.dgvcGhiChu});
            this.dgvNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.dgvNhaCungCap.Margin = new System.Windows.Forms.Padding(5);
            this.dgvNhaCungCap.Name = "dgvNhaCungCap";
            this.dgvNhaCungCap.Size = new System.Drawing.Size(967, 358);
            this.dgvNhaCungCap.TabIndex = 0;
            this.dgvNhaCungCap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhaCungCap_CellContentClick);
            // 
            // dgvcMaNhaCungCap
            // 
            this.dgvcMaNhaCungCap.DataPropertyName = "MaNhaCungCap";
            this.dgvcMaNhaCungCap.HeaderText = "MaNhaCungCap";
            this.dgvcMaNhaCungCap.Name = "dgvcMaNhaCungCap";
            this.dgvcMaNhaCungCap.Visible = false;
            // 
            // dgvcTenNhaCungCap
            // 
            this.dgvcTenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.dgvcTenNhaCungCap.HeaderText = "Tên nhà cung cấp";
            this.dgvcTenNhaCungCap.Name = "dgvcTenNhaCungCap";
            this.dgvcTenNhaCungCap.Width = 250;
            // 
            // dgvcMaSoThue
            // 
            this.dgvcMaSoThue.DataPropertyName = "MaSoThue";
            this.dgvcMaSoThue.HeaderText = "Mã số thuế";
            this.dgvcMaSoThue.Name = "dgvcMaSoThue";
            // 
            // dgvcNguoiLienHe
            // 
            this.dgvcNguoiLienHe.DataPropertyName = "NguoiLienHe";
            this.dgvcNguoiLienHe.HeaderText = "Người liên hệ";
            this.dgvcNguoiLienHe.Name = "dgvcNguoiLienHe";
            this.dgvcNguoiLienHe.Width = 150;
            // 
            // dgvcDienThoai
            // 
            this.dgvcDienThoai.DataPropertyName = "DienThoai";
            this.dgvcDienThoai.HeaderText = "Điện thoại";
            this.dgvcDienThoai.Name = "dgvcDienThoai";
            // 
            // dgvcFax
            // 
            this.dgvcFax.DataPropertyName = "Fax";
            this.dgvcFax.HeaderText = "Fax";
            this.dgvcFax.Name = "dgvcFax";
            // 
            // dgvcDiaChi
            // 
            this.dgvcDiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcDiaChi.DataPropertyName = "DiaChi";
            this.dgvcDiaChi.HeaderText = "Địa chỉ";
            this.dgvcDiaChi.Name = "dgvcDiaChi";
            // 
            // dgvcGhiChu
            // 
            this.dgvcGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcGhiChu.DataPropertyName = "GhiChu";
            this.dgvcGhiChu.HeaderText = "Ghi chú";
            this.dgvcGhiChu.Name = "dgvcGhiChu";
            this.dgvcGhiChu.Visible = false;
            // 
            // FrmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 508);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmNhaCungCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhà cung cấp";
            this.Load += new System.EventHandler(this.FrmNhaCungCap_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaSoThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNguoiLienHe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcGhiChu;
    }
}