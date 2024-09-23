namespace EasyPOS
{
    partial class Frm_HangHoa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HangHoa));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_Them_Moi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Xoa = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Luu_Lai = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Lam_Moi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_In = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaHangHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenHangHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkup_LoaiHangHoa = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_SoLuongTon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkup_DonVi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_DonGiaNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkup_LoaiHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkup_DonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Them_Moi,
            this.btn_Xoa,
            this.btn_Luu_Lai,
            this.btn_In,
            this.btn_Lam_Moi});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Them_Moi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Xoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Luu_Lai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Lam_Moi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_In, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btn_Them_Moi
            // 
            this.btn_Them_Moi.Caption = "THÊM MỚI";
            this.btn_Them_Moi.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Them_Moi.Glyph")));
            this.btn_Them_Moi.Id = 0;
            this.btn_Them_Moi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Them_Moi.LargeGlyph")));
            this.btn_Them_Moi.Name = "btn_Them_Moi";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Caption = "XÓA";
            this.btn_Xoa.Enabled = false;
            this.btn_Xoa.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Glyph")));
            this.btn_Xoa.Id = 1;
            this.btn_Xoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.LargeGlyph")));
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Xoa_ItemClick);
            // 
            // btn_Luu_Lai
            // 
            this.btn_Luu_Lai.Caption = "LƯU LẠI";
            this.btn_Luu_Lai.Enabled = false;
            this.btn_Luu_Lai.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Luu_Lai.Glyph")));
            this.btn_Luu_Lai.Id = 2;
            this.btn_Luu_Lai.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Luu_Lai.LargeGlyph")));
            this.btn_Luu_Lai.Name = "btn_Luu_Lai";
            this.btn_Luu_Lai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Luu_Lai_ItemClick);
            // 
            // btn_Lam_Moi
            // 
            this.btn_Lam_Moi.Caption = "LÀM MỚI";
            this.btn_Lam_Moi.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Lam_Moi.Glyph")));
            this.btn_Lam_Moi.Id = 4;
            this.btn_Lam_Moi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Lam_Moi.LargeGlyph")));
            this.btn_Lam_Moi.Name = "btn_Lam_Moi";
            this.btn_Lam_Moi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Lam_Moi_ItemClick);
            // 
            // btn_In
            // 
            this.btn_In.Caption = "IN ";
            this.btn_In.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_In.Glyph")));
            this.btn_In.Id = 3;
            this.btn_In.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_In.LargeGlyph")));
            this.btn_In.Name = "btn_In";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(744, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 451);
            this.barDockControlBottom.Size = new System.Drawing.Size(744, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 427);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(744, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 427);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(622, 253, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(744, 427);
            this.layoutControl1.TabIndex = 11;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Padding = new System.Windows.Forms.Padding(5);
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkup_LoaiHangHoa,
            this.lkup_DonVi});
            this.gridControl1.Size = new System.Drawing.Size(720, 374);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaHangHoa,
            this.col_TenHangHoa,
            this.col_SoLuongTon,
            this.col_DonVi,
            this.col_DonGiaNhap});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm dòng mới tại đây...";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // col_MaHangHoa
            // 
            this.col_MaHangHoa.AppearanceHeader.Options.UseTextOptions = true;
            this.col_MaHangHoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_MaHangHoa.Caption = "MÃ HÀNG HÓA";
            this.col_MaHangHoa.FieldName = "MaHangHoa";
            this.col_MaHangHoa.Name = "col_MaHangHoa";
            this.col_MaHangHoa.Visible = true;
            this.col_MaHangHoa.VisibleIndex = 1;
            this.col_MaHangHoa.Width = 56;
            // 
            // col_TenHangHoa
            // 
            this.col_TenHangHoa.AppearanceCell.Options.UseTextOptions = true;
            this.col_TenHangHoa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenHangHoa.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenHangHoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenHangHoa.Caption = "TÊN HÀNG HÓA";
            this.col_TenHangHoa.FieldName = "TenHangHoa";
            this.col_TenHangHoa.Name = "col_TenHangHoa";
            this.col_TenHangHoa.Visible = true;
            this.col_TenHangHoa.VisibleIndex = 2;
            this.col_TenHangHoa.Width = 132;
            // 
            // lkup_LoaiHangHoa
            // 
            this.lkup_LoaiHangHoa.AutoHeight = false;
            this.lkup_LoaiHangHoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkup_LoaiHangHoa.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Khu_Vuc", "KHU VỰC")});
            this.lkup_LoaiHangHoa.Name = "lkup_LoaiHangHoa";
            this.lkup_LoaiHangHoa.NullText = "[Chọn loại hàng hóa]";
            // 
            // col_SoLuongTon
            // 
            this.col_SoLuongTon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SoLuongTon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuongTon.Caption = "SỐ LƯỢNG TỒN";
            this.col_SoLuongTon.FieldName = "SoLuongTon";
            this.col_SoLuongTon.Name = "col_SoLuongTon";
            this.col_SoLuongTon.Visible = true;
            this.col_SoLuongTon.VisibleIndex = 3;
            this.col_SoLuongTon.Width = 55;
            // 
            // col_DonVi
            // 
            this.col_DonVi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonVi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonVi.Caption = "ĐƠN VỊ";
            this.col_DonVi.ColumnEdit = this.lkup_DonVi;
            this.col_DonVi.FieldName = "MaDonVi";
            this.col_DonVi.Name = "col_DonVi";
            this.col_DonVi.Visible = true;
            this.col_DonVi.VisibleIndex = 4;
            this.col_DonVi.Width = 55;
            // 
            // lkup_DonVi
            // 
            this.lkup_DonVi.AutoHeight = false;
            this.lkup_DonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkup_DonVi.Name = "lkup_DonVi";
            this.lkup_DonVi.NullText = "[Chọn Đơn Vị]";
            // 
            // col_DonGiaNhap
            // 
            this.col_DonGiaNhap.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonGiaNhap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonGiaNhap.Caption = "ĐƠN GIÁ NHẬP";
            this.col_DonGiaNhap.FieldName = "DonGiaNhap";
            this.col_DonGiaNhap.Name = "col_DonGiaNhap";
            this.col_DonGiaNhap.Visible = true;
            this.col_DonGiaNhap.VisibleIndex = 5;
            this.col_DonGiaNhap.Width = 55;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.simpleLabelItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(744, 427);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(724, 378);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleLabelItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem1.CustomizationFormText = "DANH SÁCH HÀNG HÓA";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(724, 29);
            this.simpleLabelItem1.Text = "DANH SÁCH HÀNG HÓA";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(50, 25);
            // 
            // Frm_HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 451);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_HangHoa";
            this.Text = "QUẢN LÝ HÀNG HÓA";
            this.Load += new System.EventHandler(this.Frm_HangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkup_LoaiHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkup_DonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btn_Them_Moi;
        private DevExpress.XtraBars.BarButtonItem btn_Xoa;
        private DevExpress.XtraBars.BarButtonItem btn_Luu_Lai;
        private DevExpress.XtraBars.BarButtonItem btn_Lam_Moi;
        private DevExpress.XtraBars.BarButtonItem btn_In;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaHangHoa;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenHangHoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkup_LoaiHangHoa;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuongTon;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonVi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkup_DonVi;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonGiaNhap;
    }
}