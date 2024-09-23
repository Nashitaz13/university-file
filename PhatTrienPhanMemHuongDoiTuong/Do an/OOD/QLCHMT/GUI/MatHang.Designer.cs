namespace QLCHMT.GUI
{
    partial class MatHang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatHang));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.btn_xoa = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sua = new DevExpress.XtraEditors.SimpleButton();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_mathang = new DevExpress.XtraGrid.GridControl();
            this.mATHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.gridView_mathang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaMatHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenMatHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianBaoHanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_loaihang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lOAIHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colNhaSanXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_nhasanxuat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.nHASANXUATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colThongTin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mATHANGTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.MATHANGTableAdapter();
            this.nHASANXUATTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.NHASANXUATTableAdapter();
            this.lOAIHANGTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.LOAIHANGTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_mathang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_mathang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_loaihang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAIHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_nhasanxuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHASANXUATBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Controls.Add(this.btn_sua);
            this.panel1.Controls.Add(this.btn_luu);
            this.panel1.Controls.Add(this.btn_huy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "QUẢN LÝ MẶT HÀNG";
            // 
            // btn_them
            // 
            this.btn_them.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_them.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.Location = new System.Drawing.Point(722, 0);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(81, 50);
            this.btn_them.TabIndex = 4;
            this.btn_them.Text = "Thêm";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_xoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_xoa.Image")));
            this.btn_xoa.Location = new System.Drawing.Point(803, 0);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(81, 50);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_sua.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_sua.Image")));
            this.btn_sua.Location = new System.Drawing.Point(884, 0);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(81, 50);
            this.btn_sua.TabIndex = 2;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_luu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.Location = new System.Drawing.Point(965, 0);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(81, 50);
            this.btn_luu.TabIndex = 1;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_huy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_huy.Image")));
            this.btn_huy.Location = new System.Drawing.Point(1046, 0);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 50);
            this.btn_huy.TabIndex = 0;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl_mathang);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 50);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1127, 552);
            this.panelControl1.TabIndex = 2;
            // 
            // gridControl_mathang
            // 
            this.gridControl_mathang.DataSource = this.mATHANGBindingSource;
            this.gridControl_mathang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_mathang.Location = new System.Drawing.Point(2, 2);
            this.gridControl_mathang.MainView = this.gridView_mathang;
            this.gridControl_mathang.Name = "gridControl_mathang";
            this.gridControl_mathang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_nhasanxuat,
            this.repositoryItemLookUpEdit_loaihang});
            this.gridControl_mathang.Size = new System.Drawing.Size(1123, 548);
            this.gridControl_mathang.TabIndex = 0;
            this.gridControl_mathang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_mathang});
            // 
            // mATHANGBindingSource
            // 
            this.mATHANGBindingSource.DataMember = "MATHANG";
            this.mATHANGBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView_mathang
            // 
            this.gridView_mathang.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_mathang.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_mathang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.gridView_mathang.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_mathang.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView_mathang.Appearance.Row.Options.UseFont = true;
            this.gridView_mathang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaMatHang,
            this.colTenMatHang,
            this.colThoiGianBaoHanh,
            this.colGia,
            this.colLoaiHang,
            this.colNhaSanXuat,
            this.colThongTin,
            this.colSoLuong});
            this.gridView_mathang.GridControl = this.gridControl_mathang;
            this.gridView_mathang.Name = "gridView_mathang";
            this.gridView_mathang.OptionsFind.AlwaysVisible = true;
            this.gridView_mathang.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_mathang.OptionsView.ShowGroupPanel = false;
            this.gridView_mathang.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_mathang_InitNewRow);
            this.gridView_mathang.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_mathang_CellValueChanging);
            this.gridView_mathang.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_mathang_BeforeLeaveRow);
            this.gridView_mathang.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_mathang_ValidatingEditor);
            // 
            // colMaMatHang
            // 
            this.colMaMatHang.Caption = "Mã Mặt Hàng";
            this.colMaMatHang.FieldName = "MaMatHang";
            this.colMaMatHang.Name = "colMaMatHang";
            this.colMaMatHang.OptionsColumn.AllowEdit = false;
            this.colMaMatHang.Visible = true;
            this.colMaMatHang.VisibleIndex = 0;
            // 
            // colTenMatHang
            // 
            this.colTenMatHang.Caption = "Tên Mặt Hàng";
            this.colTenMatHang.FieldName = "TenMatHang";
            this.colTenMatHang.Name = "colTenMatHang";
            this.colTenMatHang.Visible = true;
            this.colTenMatHang.VisibleIndex = 1;
            // 
            // colThoiGianBaoHanh
            // 
            this.colThoiGianBaoHanh.Caption = "Thời Gian Bảo Hành";
            this.colThoiGianBaoHanh.FieldName = "ThoiGianBaoHanh";
            this.colThoiGianBaoHanh.Name = "colThoiGianBaoHanh";
            this.colThoiGianBaoHanh.Visible = true;
            this.colThoiGianBaoHanh.VisibleIndex = 2;
            // 
            // colGia
            // 
            this.colGia.Caption = "Giá";
            this.colGia.DisplayFormat.FormatString = "#,#";
            this.colGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGia.FieldName = "Gia";
            this.colGia.Name = "colGia";
            this.colGia.Visible = true;
            this.colGia.VisibleIndex = 3;
            // 
            // colLoaiHang
            // 
            this.colLoaiHang.Caption = "Loại Hàng";
            this.colLoaiHang.ColumnEdit = this.repositoryItemLookUpEdit_loaihang;
            this.colLoaiHang.FieldName = "LoaiHang";
            this.colLoaiHang.Name = "colLoaiHang";
            this.colLoaiHang.Visible = true;
            this.colLoaiHang.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit_loaihang
            // 
            this.repositoryItemLookUpEdit_loaihang.AutoHeight = false;
            this.repositoryItemLookUpEdit_loaihang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_loaihang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLoai", "Mã Loại"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoai", "Tên Loại")});
            this.repositoryItemLookUpEdit_loaihang.DataSource = this.lOAIHANGBindingSource;
            this.repositoryItemLookUpEdit_loaihang.DisplayMember = "TenLoai";
            this.repositoryItemLookUpEdit_loaihang.Name = "repositoryItemLookUpEdit_loaihang";
            this.repositoryItemLookUpEdit_loaihang.ValueMember = "MaLoai";
            // 
            // lOAIHANGBindingSource
            // 
            this.lOAIHANGBindingSource.DataMember = "LOAIHANG";
            this.lOAIHANGBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // colNhaSanXuat
            // 
            this.colNhaSanXuat.Caption = "Nhà Sản Xuất";
            this.colNhaSanXuat.ColumnEdit = this.repositoryItemLookUpEdit_nhasanxuat;
            this.colNhaSanXuat.FieldName = "NhaSanXuat";
            this.colNhaSanXuat.Name = "colNhaSanXuat";
            this.colNhaSanXuat.Visible = true;
            this.colNhaSanXuat.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit_nhasanxuat
            // 
            this.repositoryItemLookUpEdit_nhasanxuat.AutoHeight = false;
            this.repositoryItemLookUpEdit_nhasanxuat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_nhasanxuat.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNhaSanXuat", "Mã Nhà Sản Xuất"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhaSanXuat", "Tên Nhà Sản Xuất")});
            this.repositoryItemLookUpEdit_nhasanxuat.DataSource = this.nHASANXUATBindingSource;
            this.repositoryItemLookUpEdit_nhasanxuat.DisplayMember = "TenNhaSanXuat";
            this.repositoryItemLookUpEdit_nhasanxuat.Name = "repositoryItemLookUpEdit_nhasanxuat";
            this.repositoryItemLookUpEdit_nhasanxuat.ValueMember = "MaNhaSanXuat";
            // 
            // nHASANXUATBindingSource
            // 
            this.nHASANXUATBindingSource.DataMember = "NHASANXUAT";
            this.nHASANXUATBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // colThongTin
            // 
            this.colThongTin.Caption = "Thông Tin";
            this.colThongTin.FieldName = "ThongTin";
            this.colThongTin.Name = "colThongTin";
            this.colThongTin.Visible = true;
            this.colThongTin.VisibleIndex = 6;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số Lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 7;
            // 
            // mATHANGTableAdapter
            // 
            this.mATHANGTableAdapter.ClearBeforeFill = true;
            // 
            // nHASANXUATTableAdapter
            // 
            this.nHASANXUATTableAdapter.ClearBeforeFill = true;
            // 
            // lOAIHANGTableAdapter
            // 
            this.lOAIHANGTableAdapter.ClearBeforeFill = true;
            // 
            // MatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Name = "MatHang";
            this.Size = new System.Drawing.Size(1127, 602);
            this.Load += new System.EventHandler(this.MatHang_Load);
            this.Leave += new System.EventHandler(this.MatHang_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_mathang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_mathang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_loaihang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAIHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_nhasanxuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHASANXUATBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private DevExpress.XtraEditors.SimpleButton btn_sua;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_xoa;
        private DevExpress.XtraEditors.SimpleButton btn_them;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl_mathang;
        private System.Windows.Forms.BindingSource mATHANGBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_mathang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaMatHang;
        private DevExpress.XtraGrid.Columns.GridColumn colTenMatHang;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianBaoHanh;
        private DevExpress.XtraGrid.Columns.GridColumn colGia;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_loaihang;
        private System.Windows.Forms.BindingSource lOAIHANGBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaSanXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_nhasanxuat;
        private System.Windows.Forms.BindingSource nHASANXUATBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colThongTin;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DATA.QLCHDTdatasetTableAdapters.MATHANGTableAdapter mATHANGTableAdapter;
        private DATA.QLCHDTdatasetTableAdapters.NHASANXUATTableAdapter nHASANXUATTableAdapter;
        private DATA.QLCHDTdatasetTableAdapters.LOAIHANGTableAdapter lOAIHANGTableAdapter;
    }
}
