namespace QuanLySieuThiDienThoai.GUI
{
    partial class NhapHang
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
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItem_nhaphang = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.btn_them = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_luu = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_xoa = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_huy = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_sua = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewControl1.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem_nhaphang);
            this.backstageViewControl1.Items.Add(this.btn_them);
            this.backstageViewControl1.Items.Add(this.btn_luu);
            this.backstageViewControl1.Items.Add(this.btn_xoa);
            this.backstageViewControl1.Items.Add(this.btn_huy);
            this.backstageViewControl1.Items.Add(this.btn_sua);
            this.backstageViewControl1.Location = new System.Drawing.Point(0, 0);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.SelectedTab = this.backstageViewTabItem_nhaphang;
            this.backstageViewControl1.SelectedTabIndex = 1;
            this.backstageViewControl1.Size = new System.Drawing.Size(978, 609);
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.panel1);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(846, 609);
            this.backstageViewClientControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::QuanLySieuThiDienThoai.Properties.Resources.business_banking_background_large_hero;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 167);
            this.panel1.TabIndex = 0;
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // backstageViewTabItem_nhaphang
            // 
            this.backstageViewTabItem_nhaphang.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem_nhaphang.Name = "backstageViewTabItem_nhaphang";
            this.backstageViewTabItem_nhaphang.Selected = true;
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
            // btn_xoa
            // 
            this.btn_xoa.Caption = "Xóa";
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_xoa_ItemClick);
            // 
            // btn_huy
            // 
            this.btn_huy.Caption = "Hủy";
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_huy_ItemClick);
            // 
            // btn_sua
            // 
            this.btn_sua.Caption = "Sửa";
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_sua_ItemClick);
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backstageViewControl1);
            this.Name = "NhapHang";
            this.Size = new System.Drawing.Size(978, 609);
            this.Load += new System.EventHandler(this.NhapHang_Load);
            this.backstageViewControl1.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem_nhaphang;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_them;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_luu;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_xoa;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_huy;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_sua;
    }
}
