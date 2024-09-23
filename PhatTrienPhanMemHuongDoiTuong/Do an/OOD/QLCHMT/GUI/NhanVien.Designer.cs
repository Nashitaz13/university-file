namespace QLCHMT.GUI
{
    partial class NhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.btn_xoa = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sua = new DevExpress.XtraEditors.SimpleButton();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl_nhanvien = new DevExpress.XtraGrid.GridControl();
            this.nHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.gridView_nhanvien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pHONGBANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.NHANVIENTableAdapter();
            this.pHONGBANTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.PHONGBANTableAdapter();
            this.cHITIETPHONGBANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cHITIETPHONGBANTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.CHITIETPHONGBANTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHONGBANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIETPHONGBANBindingSource)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1063, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // btn_them
            // 
            this.btn_them.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_them.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.Location = new System.Drawing.Point(658, 0);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(81, 50);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_xoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_xoa.Image")));
            this.btn_xoa.Location = new System.Drawing.Point(739, 0);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(81, 50);
            this.btn_xoa.TabIndex = 8;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_sua.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_sua.Image")));
            this.btn_sua.Location = new System.Drawing.Point(820, 0);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(81, 50);
            this.btn_sua.TabIndex = 7;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_luu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.Location = new System.Drawing.Point(901, 0);
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
            this.btn_huy.Location = new System.Drawing.Point(982, 0);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 50);
            this.btn_huy.TabIndex = 5;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl_nhanvien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1063, 522);
            this.panel2.TabIndex = 1;
            // 
            // gridControl_nhanvien
            // 
            this.gridControl_nhanvien.DataSource = this.nHANVIENBindingSource;
            this.gridControl_nhanvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_nhanvien.Location = new System.Drawing.Point(0, 0);
            this.gridControl_nhanvien.MainView = this.gridView_nhanvien;
            this.gridControl_nhanvien.Name = "gridControl_nhanvien";
            this.gridControl_nhanvien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControl_nhanvien.Size = new System.Drawing.Size(1063, 522);
            this.gridControl_nhanvien.TabIndex = 2;
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
            this.colNgaySinh,
            this.colTenDangNhap,
            this.colMatKhau});
            this.gridView_nhanvien.GridControl = this.gridControl_nhanvien;
            this.gridView_nhanvien.Name = "gridView_nhanvien";
            this.gridView_nhanvien.OptionsFind.AlwaysVisible = true;
            this.gridView_nhanvien.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_nhanvien.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_nhanvien.OptionsView.ShowGroupPanel = false;
            this.gridView_nhanvien.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_nhanvien_RowClick);
            this.gridView_nhanvien.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_nhanvien_InitNewRow);
            this.gridView_nhanvien.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_nhanvien_CellValueChanged);
            this.gridView_nhanvien.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_nhanvien_CellValueChanging);
            this.gridView_nhanvien.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_nhanvien_BeforeLeaveRow);
            this.gridView_nhanvien.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView_nhanvien_RowDeleting);
            this.gridView_nhanvien.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_nhanvien_ValidatingEditor);
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
            this.colTenNhanVien.Visible = true;
            this.colTenNhanVien.VisibleIndex = 1;
            // 
            // colCMND
            // 
            this.colCMND.FieldName = "CMND";
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 2;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày Sinh";
            this.colNgaySinh.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgaySinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.Caption = "Tên Đăng Nhập";
            this.colTenDangNhap.FieldName = "TenDangNhap";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.Visible = true;
            this.colTenDangNhap.VisibleIndex = 4;
            // 
            // colMatKhau
            // 
            this.colMatKhau.Caption = "Mật Khẩu";
            this.colMatKhau.ColumnEdit = this.repositoryItemTextEdit1;
            this.colMatKhau.FieldName = "MatKhau";
            this.colMatKhau.Name = "colMatKhau";
            this.colMatKhau.Visible = true;
            this.colMatKhau.VisibleIndex = 5;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // pHONGBANBindingSource
            // 
            this.pHONGBANBindingSource.DataMember = "PHONGBAN";
            this.pHONGBANBindingSource.DataSource = this.qLCHDTdataset;
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
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NhanVien";
            this.Size = new System.Drawing.Size(1063, 572);
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.Leave += new System.EventHandler(this.NhanVien_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHONGBANBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIETPHONGBANBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource nHANVIENBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private DATA.QLCHDTdatasetTableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private DevExpress.XtraEditors.SimpleButton btn_them;
        private DevExpress.XtraEditors.SimpleButton btn_xoa;
        private DevExpress.XtraEditors.SimpleButton btn_sua;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource pHONGBANBindingSource;
        private DATA.QLCHDTdatasetTableAdapters.PHONGBANTableAdapter pHONGBANTableAdapter;
        private System.Windows.Forms.BindingSource cHITIETPHONGBANBindingSource;
        private DATA.QLCHDTdatasetTableAdapters.CHITIETPHONGBANTableAdapter cHITIETPHONGBANTableAdapter;
        private DevExpress.XtraGrid.GridControl gridControl_nhanvien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_nhanvien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDangNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colMatKhau;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;



    }
}
