namespace QuanLyNhaThuoc
{
    partial class FrmThuocTonKho
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btTraCuu = new System.Windows.Forms.Button();
            this.ckbTatCaThuoc = new System.Windows.Forms.CheckBox();
            this.txtThuocCanTim = new System.Windows.Forms.TextBox();
            this.cboNhomThuoc = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.dgvcMaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTenNhomThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongSoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongSoLuongXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTongSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 53);
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
            this.label1.Size = new System.Drawing.Size(995, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "TRA CỨU THUỐC TỒN KHO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 62);
            this.panel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btTraCuu);
            this.groupBox1.Controls.Add(this.ckbTatCaThuoc);
            this.groupBox1.Controls.Add(this.txtThuocCanTim);
            this.groupBox1.Controls.Add(this.cboNhomThuoc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cần tra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên thuốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhóm thuốc";
            // 
            // btTraCuu
            // 
            this.btTraCuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTraCuu.Location = new System.Drawing.Point(894, 28);
            this.btTraCuu.Name = "btTraCuu";
            this.btTraCuu.Size = new System.Drawing.Size(75, 23);
            this.btTraCuu.TabIndex = 3;
            this.btTraCuu.Text = "Tra cứu";
            this.btTraCuu.UseVisualStyleBackColor = true;
            this.btTraCuu.Click += new System.EventHandler(this.btTraCuu_Click);
            // 
            // ckbTatCaThuoc
            // 
            this.ckbTatCaThuoc.AutoSize = true;
            this.ckbTatCaThuoc.Location = new System.Drawing.Point(29, 29);
            this.ckbTatCaThuoc.Name = "ckbTatCaThuoc";
            this.ckbTatCaThuoc.Size = new System.Drawing.Size(100, 20);
            this.ckbTatCaThuoc.TabIndex = 0;
            this.ckbTatCaThuoc.Text = "Tất cả thuốc";
            this.ckbTatCaThuoc.UseVisualStyleBackColor = true;
            this.ckbTatCaThuoc.CheckedChanged += new System.EventHandler(this.ckbTatCaThuoc_CheckedChanged);
            // 
            // txtThuocCanTim
            // 
            this.txtThuocCanTim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThuocCanTim.Location = new System.Drawing.Point(578, 28);
            this.txtThuocCanTim.Name = "txtThuocCanTim";
            this.txtThuocCanTim.Size = new System.Drawing.Size(266, 22);
            this.txtThuocCanTim.TabIndex = 2;
            // 
            // cboNhomThuoc
            // 
            this.cboNhomThuoc.FormattingEnabled = true;
            this.cboNhomThuoc.Location = new System.Drawing.Point(253, 27);
            this.cboNhomThuoc.Name = "cboNhomThuoc";
            this.cboNhomThuoc.Size = new System.Drawing.Size(210, 24);
            this.cboNhomThuoc.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKetQua);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(995, 351);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả";
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcMaThuoc,
            this.dgvcTenNhomThuoc,
            this.dgvcTenThuoc,
            this.dgvcTongSoLuongNhap,
            this.dgvcTongSoLuongXuat,
            this.dgvcTongSoLuongTon});
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(3, 18);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(989, 330);
            this.dgvKetQua.TabIndex = 0;
            // 
            // dgvcMaThuoc
            // 
            this.dgvcMaThuoc.HeaderText = "MaThuoc";
            this.dgvcMaThuoc.Name = "dgvcMaThuoc";
            this.dgvcMaThuoc.ReadOnly = true;
            this.dgvcMaThuoc.Visible = false;
            // 
            // dgvcTenNhomThuoc
            // 
            this.dgvcTenNhomThuoc.HeaderText = "Nhóm thuốc";
            this.dgvcTenNhomThuoc.Name = "dgvcTenNhomThuoc";
            this.dgvcTenNhomThuoc.ReadOnly = true;
            this.dgvcTenNhomThuoc.Width = 200;
            // 
            // dgvcTenThuoc
            // 
            this.dgvcTenThuoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcTenThuoc.HeaderText = "Tên thuốc";
            this.dgvcTenThuoc.Name = "dgvcTenThuoc";
            this.dgvcTenThuoc.ReadOnly = true;
            // 
            // dgvcTongSoLuongNhap
            // 
            this.dgvcTongSoLuongNhap.HeaderText = "Tổng số lượng nhập";
            this.dgvcTongSoLuongNhap.Name = "dgvcTongSoLuongNhap";
            this.dgvcTongSoLuongNhap.ReadOnly = true;
            this.dgvcTongSoLuongNhap.Width = 200;
            // 
            // dgvcTongSoLuongXuat
            // 
            this.dgvcTongSoLuongXuat.HeaderText = "Tổng số lượng xuất";
            this.dgvcTongSoLuongXuat.Name = "dgvcTongSoLuongXuat";
            this.dgvcTongSoLuongXuat.ReadOnly = true;
            this.dgvcTongSoLuongXuat.Width = 200;
            // 
            // dgvcTongSoLuongTon
            // 
            this.dgvcTongSoLuongTon.HeaderText = "Tổng số lượng tồn kho";
            this.dgvcTongSoLuongTon.Name = "dgvcTongSoLuongTon";
            this.dgvcTongSoLuongTon.ReadOnly = true;
            this.dgvcTongSoLuongTon.Width = 200;
            // 
            // FrmThuocTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 466);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmThuocTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu thuốc tồn kho";
            this.Load += new System.EventHandler(this.FrmThuocTonKho_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btTraCuu;
        private System.Windows.Forms.CheckBox ckbTatCaThuoc;
        private System.Windows.Forms.TextBox txtThuocCanTim;
        private System.Windows.Forms.ComboBox cboNhomThuoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenNhomThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongSoLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongSoLuongXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTongSoLuongTon;
    }
}