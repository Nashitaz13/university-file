namespace EasyPOS
{
    partial class Frm_DanhSachHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DanhSachHoaDon));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_LamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.grid_ChiTietHD = new DevExpress.XtraGrid.GridControl();
            this.gridView_ChiTietHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_HoaDon = new DevExpress.XtraGrid.GridControl();
            this.gridView_HoaDon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_InDanhSach = new DevExpress.XtraEditors.SimpleButton();
            this.check_HDChi = new DevExpress.XtraEditors.CheckEdit();
            this.check_HDThu = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ChiTietHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ChiTietHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_HDChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_HDThu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_LamMoi);
            this.layoutControl1.Controls.Add(this.grid_ChiTietHD);
            this.layoutControl1.Controls.Add(this.grid_HoaDon);
            this.layoutControl1.Controls.Add(this.btn_InDanhSach);
            this.layoutControl1.Controls.Add(this.check_HDChi);
            this.layoutControl1.Controls.Add(this.check_HDThu);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(806, 482);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.AutoWidthInLayoutControl = true;
            this.btn_LamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.Image")));
            this.btn_LamMoi.Location = new System.Drawing.Point(605, 12);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(73, 22);
            this.btn_LamMoi.StyleController = this.layoutControl1;
            this.btn_LamMoi.TabIndex = 9;
            this.btn_LamMoi.Text = "LÀM MỚI";
            // 
            // grid_ChiTietHD
            // 
            this.grid_ChiTietHD.Location = new System.Drawing.Point(36, 287);
            this.grid_ChiTietHD.MainView = this.gridView_ChiTietHD;
            this.grid_ChiTietHD.Name = "grid_ChiTietHD";
            this.grid_ChiTietHD.Size = new System.Drawing.Size(734, 159);
            this.grid_ChiTietHD.TabIndex = 8;
            this.grid_ChiTietHD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ChiTietHD,
            this.gridView1});
            // 
            // gridView_ChiTietHD
            // 
            this.gridView_ChiTietHD.GridControl = this.grid_ChiTietHD;
            this.gridView_ChiTietHD.Name = "gridView_ChiTietHD";
            this.gridView_ChiTietHD.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grid_ChiTietHD;
            this.gridView1.Name = "gridView1";
            // 
            // grid_HoaDon
            // 
            this.grid_HoaDon.Location = new System.Drawing.Point(24, 68);
            this.grid_HoaDon.MainView = this.gridView_HoaDon;
            this.grid_HoaDon.Name = "grid_HoaDon";
            this.grid_HoaDon.Size = new System.Drawing.Size(758, 185);
            this.grid_HoaDon.TabIndex = 7;
            this.grid_HoaDon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_HoaDon});
            // 
            // gridView_HoaDon
            // 
            this.gridView_HoaDon.GridControl = this.grid_HoaDon;
            this.gridView_HoaDon.Name = "gridView_HoaDon";
            this.gridView_HoaDon.OptionsBehavior.ReadOnly = true;
            this.gridView_HoaDon.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView_HoaDon.OptionsView.ShowAutoFilterRow = true;
            this.gridView_HoaDon.OptionsView.ShowGroupPanel = false;
            // 
            // btn_InDanhSach
            // 
            this.btn_InDanhSach.AutoWidthInLayoutControl = true;
            this.btn_InDanhSach.Image = ((System.Drawing.Image)(resources.GetObject("btn_InDanhSach.Image")));
            this.btn_InDanhSach.Location = new System.Drawing.Point(692, 12);
            this.btn_InDanhSach.Name = "btn_InDanhSach";
            this.btn_InDanhSach.Size = new System.Drawing.Size(102, 22);
            this.btn_InDanhSach.StyleController = this.layoutControl1;
            this.btn_InDanhSach.TabIndex = 6;
            this.btn_InDanhSach.Text = "IN DANH SÁCH";
            // 
            // check_HDChi
            // 
            this.check_HDChi.Location = new System.Drawing.Point(109, 12);
            this.check_HDChi.Name = "check_HDChi";
            this.check_HDChi.Properties.Caption = "HÓA ĐƠN CHI";
            this.check_HDChi.Size = new System.Drawing.Size(492, 19);
            this.check_HDChi.StyleController = this.layoutControl1;
            this.check_HDChi.TabIndex = 5;
            // 
            // check_HDThu
            // 
            this.check_HDThu.EditValue = true;
            this.check_HDThu.Location = new System.Drawing.Point(12, 12);
            this.check_HDThu.Name = "check_HDThu";
            this.check_HDThu.Properties.Caption = "HÓA ĐƠN THU";
            this.check_HDThu.Size = new System.Drawing.Size(93, 19);
            this.check_HDThu.StyleController = this.layoutControl1;
            this.check_HDThu.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlGroup2,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(806, 482);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.check_HDThu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(97, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.check_HDChi;
            this.layoutControlItem2.Location = new System.Drawing.Point(97, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(496, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_InDanhSach;
            this.layoutControlItem3.Location = new System.Drawing.Point(680, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(106, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(786, 436);
            this.layoutControlGroup2.Text = "Danh sách hóa đơn đã thanh toán";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grid_HoaDon;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(762, 189);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 189);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(762, 205);
            this.layoutControlGroup3.Text = "Thông tin chi tiết hóa đơn";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grid_ChiTietHD;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(738, 163);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_LamMoi;
            this.layoutControlItem6.Location = new System.Drawing.Point(593, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(77, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(670, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Frm_DanhSachHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 482);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm_DanhSachHoaDon";
            this.Text = "QUẢN LÝ HÓA ĐƠN";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ChiTietHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ChiTietHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_HDChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_HDThu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grid_HoaDon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_HoaDon;
        private DevExpress.XtraEditors.SimpleButton btn_InDanhSach;
        private DevExpress.XtraEditors.CheckEdit check_HDChi;
        private DevExpress.XtraEditors.CheckEdit check_HDThu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grid_ChiTietHD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ChiTietHD;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_LamMoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}