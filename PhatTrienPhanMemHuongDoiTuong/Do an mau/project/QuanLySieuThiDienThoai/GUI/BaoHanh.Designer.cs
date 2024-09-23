namespace QuanLySieuThiDienThoai.GUI
{
    partial class BaoHanh
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PBH_Ma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_PBH_MaPX1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PBH_imei = new System.Windows.Forms.TextBox();
            this.backstageViewTabItem_baohanh = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.btn_them = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_luu = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_huy = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_xoa = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_sua = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewControl1.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem_baohanh);
            this.backstageViewControl1.Items.Add(this.btn_them);
            this.backstageViewControl1.Items.Add(this.btn_luu);
            this.backstageViewControl1.Items.Add(this.btn_huy);
            this.backstageViewControl1.Items.Add(this.btn_xoa);
            this.backstageViewControl1.Items.Add(this.btn_sua);
            this.backstageViewControl1.Location = new System.Drawing.Point(0, 0);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.SelectedTab = this.backstageViewTabItem_baohanh;
            this.backstageViewControl1.SelectedTabIndex = 0;
            this.backstageViewControl1.Size = new System.Drawing.Size(984, 614);
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.panel1);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(852, 614);
            this.backstageViewClientControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuanLySieuThiDienThoai.Properties.Resources.business_banking_background_large_hero;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_PBH_Ma);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmb_PBH_MaPX1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_PBH_imei);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 160);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Mã Phiếu  Bảo Hành";
            // 
            // txt_PBH_Ma
            // 
            this.txt_PBH_Ma.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PBH_Ma.Location = new System.Drawing.Point(238, 32);
            this.txt_PBH_Ma.Name = "txt_PBH_Ma";
            this.txt_PBH_Ma.Size = new System.Drawing.Size(188, 26);
            this.txt_PBH_Ma.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 37;
            this.label6.Text = "Mã IMEI";
            // 
            // cmb_PBH_MaPX1
            // 
            this.cmb_PBH_MaPX1.DisplayMember = "MaPX";
            this.cmb_PBH_MaPX1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_PBH_MaPX1.FormattingEnabled = true;
            this.cmb_PBH_MaPX1.Location = new System.Drawing.Point(238, 112);
            this.cmb_PBH_MaPX1.Name = "cmb_PBH_MaPX1";
            this.cmb_PBH_MaPX1.Size = new System.Drawing.Size(188, 26);
            this.cmb_PBH_MaPX1.TabIndex = 36;
            this.cmb_PBH_MaPX1.ValueMember = "MaPX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Mã Phiếu Xuất";
            // 
            // txt_PBH_imei
            // 
            this.txt_PBH_imei.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PBH_imei.Location = new System.Drawing.Point(238, 72);
            this.txt_PBH_imei.Name = "txt_PBH_imei";
            this.txt_PBH_imei.Size = new System.Drawing.Size(188, 26);
            this.txt_PBH_imei.TabIndex = 34;
            // 
            // backstageViewTabItem_baohanh
            // 
            this.backstageViewTabItem_baohanh.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem_baohanh.Name = "backstageViewTabItem_baohanh";
            this.backstageViewTabItem_baohanh.Selected = true;
            // 
            // btn_them
            // 
            this.btn_them.Caption = "Thêm";
            this.btn_them.Name = "btn_them";
            this.btn_them.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_them_ItemClick);
            // 
            // btn_luu
            // 
            this.btn_luu.Caption = "Lưu";
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_luu_ItemClick);
            // 
            // btn_huy
            // 
            this.btn_huy.Caption = "Hủy";
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_huy_ItemClick);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Caption = "Xóa";
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_xoa_ItemClick);
            // 
            // btn_sua
            // 
            this.btn_sua.Caption = "Sửa";
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_sua_ItemClick);
            // 
            // BaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backstageViewControl1);
            this.Name = "BaoHanh";
            this.Size = new System.Drawing.Size(984, 614);
            this.Load += new System.EventHandler(this.BaoHanh_Load);
            this.backstageViewControl1.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem_baohanh;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_them;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_luu;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_huy;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_xoa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PBH_Ma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_PBH_MaPX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PBH_imei;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_sua;
    }
}
