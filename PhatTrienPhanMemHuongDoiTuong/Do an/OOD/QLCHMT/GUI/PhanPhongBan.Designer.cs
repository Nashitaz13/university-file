namespace QLCHMT.GUI
{
    partial class PhanPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhanPhongBan));
            this.gridControl_nhanvien = new DevExpress.XtraGrid.GridControl();
            this.nHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.gridView_nhanvien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl_phongban = new DevExpress.XtraGrid.GridControl();
            this.pHONGBANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_phongban = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.nHANVIENTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.NHANVIENTableAdapter();
            this.pHONGBANTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.PHONGBANTableAdapter();
            this.cHITIETPHONGBANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cHITIETPHONGBANTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.CHITIETPHONGBANTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_phongban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHONGBANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_phongban)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIETPHONGBANBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_nhanvien
            // 
            this.gridControl_nhanvien.DataSource = this.nHANVIENBindingSource;
            this.gridControl_nhanvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_nhanvien.Location = new System.Drawing.Point(0, 50);
            this.gridControl_nhanvien.MainView = this.gridView_nhanvien;
            this.gridControl_nhanvien.Name = "gridControl_nhanvien";
            this.gridControl_nhanvien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControl_nhanvien.Size = new System.Drawing.Size(571, 588);
            this.gridControl_nhanvien.TabIndex = 5;
            this.gridControl_nhanvien.UseEmbeddedNavigator = true;
            this.gridControl_nhanvien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_nhanvien});
            // 
            // nHANVIENBindingSource
            // 
            this.nHANVIENBindingSource.DataMember = "NHANVIEN";
            this.nHANVIENBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView_nhanvien
            // 
            this.gridView_nhanvien.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_nhanvien.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_nhanvien.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.gridView_nhanvien.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_nhanvien.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView_nhanvien.Appearance.Row.Options.UseFont = true;
            this.gridView_nhanvien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNhanVien,
            this.colTenNhanVien,
            this.colCMND,
            this.colNgaySinh});
            this.gridView_nhanvien.GridControl = this.gridControl_nhanvien;
            this.gridView_nhanvien.Name = "gridView_nhanvien";
            this.gridView_nhanvien.OptionsFind.AlwaysVisible = true;
            this.gridView_nhanvien.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_nhanvien.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_nhanvien.OptionsView.ShowGroupPanel = false;
            this.gridView_nhanvien.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_nhanvien_RowClick);
            this.gridView_nhanvien.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_nhanvien_RowCellClick);
            this.gridView_nhanvien.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_nhanvien_BeforeLeaveRow);
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.Caption = "Mã Nhân Viên";
            this.colMaNhanVien.FieldName = "MaNhanVien";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.OptionsColumn.AllowEdit = false;
            this.colMaNhanVien.Visible = true;
            this.colMaNhanVien.VisibleIndex = 0;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.Caption = "Tên Nhân Viên";
            this.colTenNhanVien.FieldName = "TenNhanVien";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.OptionsColumn.AllowEdit = false;
            this.colTenNhanVien.Visible = true;
            this.colTenNhanVien.VisibleIndex = 1;
            // 
            // colCMND
            // 
            this.colCMND.FieldName = "CMND";
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsColumn.AllowEdit = false;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 2;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày Sinh";
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.OptionsColumn.AllowEdit = false;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // gridControl_phongban
            // 
            this.gridControl_phongban.DataSource = this.pHONGBANBindingSource;
            this.gridControl_phongban.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridControl_phongban.Location = new System.Drawing.Point(571, 50);
            this.gridControl_phongban.MainView = this.gridView_phongban;
            this.gridControl_phongban.Name = "gridControl_phongban";
            this.gridControl_phongban.Size = new System.Drawing.Size(520, 588);
            this.gridControl_phongban.TabIndex = 4;
            this.gridControl_phongban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_phongban});
            // 
            // pHONGBANBindingSource
            // 
            this.pHONGBANBindingSource.DataMember = "PHONGBAN";
            this.pHONGBANBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // gridView_phongban
            // 
            this.gridView_phongban.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_phongban.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_phongban.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.gridView_phongban.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_phongban.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView_phongban.Appearance.Row.Options.UseFont = true;
            this.gridView_phongban.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaPhongBan,
            this.colTenPhongBan});
            this.gridView_phongban.GridControl = this.gridControl_phongban;
            this.gridView_phongban.Name = "gridView_phongban";
            this.gridView_phongban.OptionsFind.AlwaysVisible = true;
            this.gridView_phongban.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_phongban.OptionsSelection.MultiSelect = true;
            this.gridView_phongban.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView_phongban.OptionsView.ShowGroupPanel = false;
            this.gridView_phongban.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_phongban_SelectionChanged);
            // 
            // colMaPhongBan
            // 
            this.colMaPhongBan.Caption = "Mã Phòng Ban";
            this.colMaPhongBan.FieldName = "MaPhongBan";
            this.colMaPhongBan.Name = "colMaPhongBan";
            this.colMaPhongBan.OptionsColumn.AllowEdit = false;
            this.colMaPhongBan.Visible = true;
            this.colMaPhongBan.VisibleIndex = 1;
            // 
            // colTenPhongBan
            // 
            this.colTenPhongBan.Caption = "Tên Phòng Ban";
            this.colTenPhongBan.FieldName = "TenPhongBan";
            this.colTenPhongBan.Name = "colTenPhongBan";
            this.colTenPhongBan.OptionsColumn.AllowEdit = false;
            this.colTenPhongBan.Visible = true;
            this.colTenPhongBan.VisibleIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_luu);
            this.panel1.Controls.Add(this.btn_huy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 50);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "PHÂN PHÒNG BAN";
            // 
            // btn_luu
            // 
            this.btn_luu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_luu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.Location = new System.Drawing.Point(929, 0);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(81, 50);
            this.btn_luu.TabIndex = 6;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_huy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_huy.Image")));
            this.btn_huy.Location = new System.Drawing.Point(1010, 0);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 50);
            this.btn_huy.TabIndex = 5;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // nHANVIENTableAdapter
            // 
            this.nHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // pHONGBANTableAdapter
            // 
            this.pHONGBANTableAdapter.ClearBeforeFill = true;
            // 
            // cHITIETPHONGBANBindingSource
            // 
            this.cHITIETPHONGBANBindingSource.DataMember = "CHITIETPHONGBAN";
            this.cHITIETPHONGBANBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // cHITIETPHONGBANTableAdapter
            // 
            this.cHITIETPHONGBANTableAdapter.ClearBeforeFill = true;
            // 
            // PhanPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_nhanvien);
            this.Controls.Add(this.gridControl_phongban);
            this.Controls.Add(this.panel1);
            this.Name = "PhanPhongBan";
            this.Size = new System.Drawing.Size(1091, 638);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_phongban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHONGBANBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_phongban)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIETPHONGBANBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_nhanvien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_nhanvien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl gridControl_phongban;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_phongban;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colTenPhongBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private System.Windows.Forms.BindingSource nHANVIENBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private System.Windows.Forms.BindingSource pHONGBANBindingSource;
        private DATA.QLCHDTdatasetTableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private DATA.QLCHDTdatasetTableAdapters.PHONGBANTableAdapter pHONGBANTableAdapter;
        private System.Windows.Forms.BindingSource cHITIETPHONGBANBindingSource;
        private DATA.QLCHDTdatasetTableAdapters.CHITIETPHONGBANTableAdapter cHITIETPHONGBANTableAdapter;
    }
}
