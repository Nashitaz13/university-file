namespace EasyPOS
{
    partial class Frm_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DangNhap));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.txt_MatKhau = new DevExpress.XtraEditors.TextEdit();
            this.btn_DangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tài khoản :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mật khẩu :";
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.EditValue = "admin";
            this.txt_TaiKhoan.Location = new System.Drawing.Point(91, 22);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(227, 20);
            this.txt_TaiKhoan.TabIndex = 0;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.EditValue = "phuong1994";
            this.txt_MatKhau.Location = new System.Drawing.Point(91, 61);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Properties.PasswordChar = '*';
            this.txt_MatKhau.Properties.UseSystemPasswordChar = true;
            this.txt_MatKhau.Size = new System.Drawing.Size(227, 20);
            this.txt_MatKhau.TabIndex = 1;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Image = ((System.Drawing.Image)(resources.GetObject("btn_DangNhap.Image")));
            this.btn_DangNhap.Location = new System.Drawing.Point(91, 99);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(96, 23);
            this.btn_DangNhap.TabIndex = 2;
            this.btn_DangNhap.Text = "ĐĂNG NHẬP";
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.Image")));
            this.btn_Thoat.Location = new System.Drawing.Point(222, 99);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(96, 23);
            this.btn_Thoat.TabIndex = 3;
            this.btn_Thoat.Text = "THOÁT";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // Frm_DangNhap
            // 
            this.AcceptButton = this.btn_DangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 136);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.txt_TaiKhoan);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(369, 175);
            this.Name = "Frm_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP HỆ THỐNG";
            ((System.ComponentModel.ISupportInitialize)(this.txt_TaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MatKhau.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_TaiKhoan;
        private DevExpress.XtraEditors.TextEdit txt_MatKhau;
        private DevExpress.XtraEditors.SimpleButton btn_DangNhap;
        private DevExpress.XtraEditors.SimpleButton btn_Thoat;
    }
}