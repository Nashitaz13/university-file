namespace QLCHMT.GUI
{
    partial class CapNhatSuaChuaBaoHanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapNhatSuaChuaBaoHanh));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pHIEUTIEPNHANBAOHANHTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.PHIEUTIEPNHANBAOHANHTableAdapter();
            this.iNPHIEUBAOHANHTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.INPHIEUBAOHANHTableAdapter();
            this.iNPHIEUBAOHANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.pHIEUTIEPNHANBAOHANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl_tiepnhanbh = new DevExpress.XtraGrid.GridControl();
            this.gridView_tiepnhanbh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaPhieuBaoHanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinhTrangSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHongHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiTraHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaPhieuTiepNhanBaoHanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiSuaChua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_trangthai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tRANGTHAISUACHUABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tRANGTHAISUACHUATableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.TRANGTHAISUACHUATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNPHIEUBAOHANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUTIEPNHANBAOHANHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_tiepnhanbh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_tiepnhanbh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_trangthai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRANGTHAISUACHUABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // pHIEUTIEPNHANBAOHANHTableAdapter
            // 
            this.pHIEUTIEPNHANBAOHANHTableAdapter.ClearBeforeFill = true;
            // 
            // iNPHIEUBAOHANHTableAdapter
            // 
            this.iNPHIEUBAOHANHTableAdapter.ClearBeforeFill = true;
            // 
            // iNPHIEUBAOHANHBindingSource
            // 
            this.iNPHIEUBAOHANHBindingSource.DataMember = "INPHIEUBAOHANH";
            this.iNPHIEUBAOHANHBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pHIEUTIEPNHANBAOHANHBindingSource
            // 
            this.pHIEUTIEPNHANBAOHANHBindingSource.DataMember = "PHIEUTIEPNHANBAOHANH";
            this.pHIEUTIEPNHANBAOHANHBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "CẬP NHẬT BẢO HÀNH";
            // 
            // btn_luu
            // 
            this.btn_luu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_luu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.Location = new System.Drawing.Point(882, 0);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(96, 50);
            this.btn_luu.TabIndex = 1;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_huy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_huy.Image")));
            this.btn_huy.Location = new System.Drawing.Point(978, 0);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 50);
            this.btn_huy.TabIndex = 0;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_luu);
            this.panel1.Controls.Add(this.btn_huy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 50);
            this.panel1.TabIndex = 9;
            // 
            // gridControl_tiepnhanbh
            // 
            this.gridControl_tiepnhanbh.DataSource = this.pHIEUTIEPNHANBAOHANHBindingSource;
            this.gridControl_tiepnhanbh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_tiepnhanbh.Location = new System.Drawing.Point(0, 50);
            this.gridControl_tiepnhanbh.MainView = this.gridView_tiepnhanbh;
            this.gridControl_tiepnhanbh.Name = "gridControl_tiepnhanbh";
            this.gridControl_tiepnhanbh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_trangthai});
            this.gridControl_tiepnhanbh.Size = new System.Drawing.Size(1059, 537);
            this.gridControl_tiepnhanbh.TabIndex = 11;
            this.gridControl_tiepnhanbh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_tiepnhanbh});
            // 
            // gridView_tiepnhanbh
            // 
            this.gridView_tiepnhanbh.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_tiepnhanbh.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_tiepnhanbh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.gridView_tiepnhanbh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_tiepnhanbh.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView_tiepnhanbh.Appearance.Row.Options.UseFont = true;
            this.gridView_tiepnhanbh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaPhieuBaoHanh,
            this.colTinhTrangSanPham,
            this.colHongHoc,
            this.colTrangThaiTraHang,
            this.colKhachHang,
            this.colSDT,
            this.colMaPhieuTiepNhanBaoHanh,
            this.colTrangThaiSuaChua});
            this.gridView_tiepnhanbh.GridControl = this.gridControl_tiepnhanbh;
            this.gridView_tiepnhanbh.Name = "gridView_tiepnhanbh";
            this.gridView_tiepnhanbh.OptionsFind.AlwaysVisible = true;
            this.gridView_tiepnhanbh.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_tiepnhanbh.OptionsView.ShowGroupPanel = false;
            this.gridView_tiepnhanbh.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_tiepnhanbh_CellValueChanging);
            // 
            // colMaPhieuBaoHanh
            // 
            this.colMaPhieuBaoHanh.Caption = "Mã phiếu bảo hành";
            this.colMaPhieuBaoHanh.FieldName = "MaPhieuBaoHanh";
            this.colMaPhieuBaoHanh.Name = "colMaPhieuBaoHanh";
            this.colMaPhieuBaoHanh.OptionsColumn.AllowEdit = false;
            this.colMaPhieuBaoHanh.Visible = true;
            this.colMaPhieuBaoHanh.VisibleIndex = 1;
            this.colMaPhieuBaoHanh.Width = 159;
            // 
            // colTinhTrangSanPham
            // 
            this.colTinhTrangSanPham.Caption = "Tình trạng sản phẩm";
            this.colTinhTrangSanPham.FieldName = "TinhTrangSanPham";
            this.colTinhTrangSanPham.Name = "colTinhTrangSanPham";
            this.colTinhTrangSanPham.OptionsColumn.AllowEdit = false;
            this.colTinhTrangSanPham.Visible = true;
            this.colTinhTrangSanPham.VisibleIndex = 2;
            this.colTinhTrangSanPham.Width = 148;
            // 
            // colHongHoc
            // 
            this.colHongHoc.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colHongHoc.AppearanceCell.Options.UseBackColor = true;
            this.colHongHoc.Caption = "Hỏng hóc";
            this.colHongHoc.FieldName = "HongHoc";
            this.colHongHoc.Name = "colHongHoc";
            this.colHongHoc.Visible = true;
            this.colHongHoc.VisibleIndex = 3;
            this.colHongHoc.Width = 120;
            // 
            // colTrangThaiTraHang
            // 
            this.colTrangThaiTraHang.FieldName = "TrangThaiTraHang";
            this.colTrangThaiTraHang.Name = "colTrangThaiTraHang";
            // 
            // colKhachHang
            // 
            this.colKhachHang.Caption = "Tên khách hàng";
            this.colKhachHang.FieldName = "KhachHang";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.OptionsColumn.AllowEdit = false;
            this.colKhachHang.Visible = true;
            this.colKhachHang.VisibleIndex = 4;
            this.colKhachHang.Width = 122;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "Số điện thoại";
            this.colSDT.FieldName = "SDT";
            this.colSDT.Name = "colSDT";
            this.colSDT.OptionsColumn.AllowEdit = false;
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 5;
            this.colSDT.Width = 127;
            // 
            // colMaPhieuTiepNhanBaoHanh
            // 
            this.colMaPhieuTiepNhanBaoHanh.Caption = "Mã phiếu tiếp nhận bảo hành";
            this.colMaPhieuTiepNhanBaoHanh.FieldName = "MaPhieuTiepNhanBaoHanh";
            this.colMaPhieuTiepNhanBaoHanh.Name = "colMaPhieuTiepNhanBaoHanh";
            this.colMaPhieuTiepNhanBaoHanh.OptionsColumn.AllowEdit = false;
            this.colMaPhieuTiepNhanBaoHanh.Visible = true;
            this.colMaPhieuTiepNhanBaoHanh.VisibleIndex = 0;
            this.colMaPhieuTiepNhanBaoHanh.Width = 209;
            // 
            // colTrangThaiSuaChua
            // 
            this.colTrangThaiSuaChua.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colTrangThaiSuaChua.AppearanceCell.Options.UseBackColor = true;
            this.colTrangThaiSuaChua.Caption = "Trạng thái sửa chữa";
            this.colTrangThaiSuaChua.ColumnEdit = this.repositoryItemLookUpEdit_trangthai;
            this.colTrangThaiSuaChua.FieldName = "TrangThaiSuaChua";
            this.colTrangThaiSuaChua.Name = "colTrangThaiSuaChua";
            this.colTrangThaiSuaChua.Visible = true;
            this.colTrangThaiSuaChua.VisibleIndex = 6;
            this.colTrangThaiSuaChua.Width = 156;
            // 
            // repositoryItemLookUpEdit_trangthai
            // 
            this.repositoryItemLookUpEdit_trangthai.AutoHeight = false;
            this.repositoryItemLookUpEdit_trangthai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_trangthai.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTrangThai", "Mã trạng thái", 91, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTrangThai", "Tên trạng thái", 82, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_trangthai.DataSource = this.tRANGTHAISUACHUABindingSource;
            this.repositoryItemLookUpEdit_trangthai.DisplayMember = "TenTrangThai";
            this.repositoryItemLookUpEdit_trangthai.Name = "repositoryItemLookUpEdit_trangthai";
            this.repositoryItemLookUpEdit_trangthai.ValueMember = "MaTrangThai";
            // 
            // tRANGTHAISUACHUABindingSource
            // 
            this.tRANGTHAISUACHUABindingSource.DataMember = "TRANGTHAISUACHUA";
            this.tRANGTHAISUACHUABindingSource.DataSource = this.qLCHDTdataset;
            // 
            // tRANGTHAISUACHUATableAdapter
            // 
            this.tRANGTHAISUACHUATableAdapter.ClearBeforeFill = true;
            // 
            // CapNhatSuaChuaBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_tiepnhanbh);
            this.Controls.Add(this.panel1);
            this.Name = "CapNhatSuaChuaBaoHanh";
            this.Size = new System.Drawing.Size(1059, 587);
            this.Load += new System.EventHandler(this.CapNhatSuaChuaBaoHanh_Load);
            this.Leave += new System.EventHandler(this.CapNhatSuaChuaBaoHanh_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNPHIEUBAOHANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUTIEPNHANBAOHANHBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_tiepnhanbh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_tiepnhanbh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_trangthai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRANGTHAISUACHUABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DATA.QLCHDTdatasetTableAdapters.PHIEUTIEPNHANBAOHANHTableAdapter pHIEUTIEPNHANBAOHANHTableAdapter;
        private DATA.QLCHDTdatasetTableAdapters.INPHIEUBAOHANHTableAdapter iNPHIEUBAOHANHTableAdapter;
        private System.Windows.Forms.BindingSource iNPHIEUBAOHANHBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private System.Windows.Forms.BindingSource pHIEUTIEPNHANBAOHANHBindingSource;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl_tiepnhanbh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_tiepnhanbh;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhieuBaoHanh;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhTrangSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colHongHoc;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiTraHang;
        private DevExpress.XtraGrid.Columns.GridColumn colKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhieuTiepNhanBaoHanh;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiSuaChua;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_trangthai;
        private System.Windows.Forms.BindingSource tRANGTHAISUACHUABindingSource;
        private DATA.QLCHDTdatasetTableAdapters.TRANGTHAISUACHUATableAdapter tRANGTHAISUACHUATableAdapter;
    }
}
