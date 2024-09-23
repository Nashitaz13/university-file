namespace QLCHMT.GUI
{
    partial class TraHangBaoHanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraHangBaoHanh));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl_trabaohanh = new DevExpress.XtraGrid.GridControl();
            this.pHIEUTIEPNHANBAOHANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.gridView_trabaohanh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaPhieuBaoHanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinhTrangSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHongHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiTraHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_tt = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tRANGTHAITRAHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaPhieuTiepNhanBaoHanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiSuaChua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pHIEUTIEPNHANBAOHANHTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.PHIEUTIEPNHANBAOHANHTableAdapter();
            this.tRANGTHAITRAHANGTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.TRANGTHAITRAHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_trabaohanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUTIEPNHANBAOHANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_trabaohanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_tt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRANGTHAITRAHANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "TRẢ BẢO HÀNH";
            // 
            // btn_luu
            // 
            this.btn_luu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_luu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.Location = new System.Drawing.Point(850, 0);
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
            this.btn_huy.Location = new System.Drawing.Point(946, 0);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 50);
            this.btn_huy.TabIndex = 0;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_luu);
            this.panel1.Controls.Add(this.btn_huy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 50);
            this.panel1.TabIndex = 12;
            // 
            // gridControl_trabaohanh
            // 
            this.gridControl_trabaohanh.DataSource = this.pHIEUTIEPNHANBAOHANHBindingSource;
            this.gridControl_trabaohanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_trabaohanh.Location = new System.Drawing.Point(0, 50);
            this.gridControl_trabaohanh.MainView = this.gridView_trabaohanh;
            this.gridControl_trabaohanh.Name = "gridControl_trabaohanh";
            this.gridControl_trabaohanh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_tt});
            this.gridControl_trabaohanh.Size = new System.Drawing.Size(1027, 503);
            this.gridControl_trabaohanh.TabIndex = 13;
            this.gridControl_trabaohanh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_trabaohanh});
            // 
            // pHIEUTIEPNHANBAOHANHBindingSource
            // 
            this.pHIEUTIEPNHANBAOHANHBindingSource.DataMember = "PHIEUTIEPNHANBAOHANH";
            this.pHIEUTIEPNHANBAOHANHBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView_trabaohanh
            // 
            this.gridView_trabaohanh.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_trabaohanh.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_trabaohanh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.gridView_trabaohanh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_trabaohanh.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView_trabaohanh.Appearance.Row.Options.UseFont = true;
            this.gridView_trabaohanh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaPhieuBaoHanh,
            this.colTinhTrangSanPham,
            this.colHongHoc,
            this.colTrangThaiTraHang,
            this.colKhachHang,
            this.colSDT,
            this.colMaPhieuTiepNhanBaoHanh,
            this.colTrangThaiSuaChua});
            this.gridView_trabaohanh.GridControl = this.gridControl_trabaohanh;
            this.gridView_trabaohanh.Name = "gridView_trabaohanh";
            this.gridView_trabaohanh.OptionsFind.AlwaysVisible = true;
            this.gridView_trabaohanh.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_trabaohanh.OptionsView.ShowGroupPanel = false;
            // 
            // colMaPhieuBaoHanh
            // 
            this.colMaPhieuBaoHanh.FieldName = "MaPhieuBaoHanh";
            this.colMaPhieuBaoHanh.Name = "colMaPhieuBaoHanh";
            this.colMaPhieuBaoHanh.OptionsColumn.AllowEdit = false;
            // 
            // colTinhTrangSanPham
            // 
            this.colTinhTrangSanPham.Caption = "Tình trạng sản phẩm";
            this.colTinhTrangSanPham.FieldName = "TinhTrangSanPham";
            this.colTinhTrangSanPham.Name = "colTinhTrangSanPham";
            this.colTinhTrangSanPham.OptionsColumn.AllowEdit = false;
            this.colTinhTrangSanPham.Visible = true;
            this.colTinhTrangSanPham.VisibleIndex = 1;
            // 
            // colHongHoc
            // 
            this.colHongHoc.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colHongHoc.AppearanceCell.Options.UseBackColor = true;
            this.colHongHoc.Caption = "Hỏng hóc";
            this.colHongHoc.FieldName = "HongHoc";
            this.colHongHoc.Name = "colHongHoc";
            this.colHongHoc.OptionsColumn.AllowEdit = false;
            this.colHongHoc.Visible = true;
            this.colHongHoc.VisibleIndex = 2;
            // 
            // colTrangThaiTraHang
            // 
            this.colTrangThaiTraHang.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colTrangThaiTraHang.AppearanceCell.Options.UseBackColor = true;
            this.colTrangThaiTraHang.Caption = "Trạng thái trả hàng";
            this.colTrangThaiTraHang.ColumnEdit = this.repositoryItemLookUpEdit_tt;
            this.colTrangThaiTraHang.FieldName = "TrangThaiTraHang";
            this.colTrangThaiTraHang.Name = "colTrangThaiTraHang";
            this.colTrangThaiTraHang.Visible = true;
            this.colTrangThaiTraHang.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit_tt
            // 
            this.repositoryItemLookUpEdit_tt.AutoHeight = false;
            this.repositoryItemLookUpEdit_tt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_tt.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTrangThai", "Mã trạng thái", 91, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTrangThai", "Tên trạng thái", 82, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_tt.DataSource = this.tRANGTHAITRAHANGBindingSource;
            this.repositoryItemLookUpEdit_tt.DisplayMember = "TenTrangThai";
            this.repositoryItemLookUpEdit_tt.Name = "repositoryItemLookUpEdit_tt";
            this.repositoryItemLookUpEdit_tt.ValueMember = "MaTrangThai";
            // 
            // tRANGTHAITRAHANGBindingSource
            // 
            this.tRANGTHAITRAHANGBindingSource.DataMember = "TRANGTHAITRAHANG";
            this.tRANGTHAITRAHANGBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // colKhachHang
            // 
            this.colKhachHang.Caption = "Tên khách hàng";
            this.colKhachHang.FieldName = "KhachHang";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.OptionsColumn.AllowEdit = false;
            this.colKhachHang.Visible = true;
            this.colKhachHang.VisibleIndex = 3;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "Số điện thoại";
            this.colSDT.FieldName = "SDT";
            this.colSDT.Name = "colSDT";
            this.colSDT.OptionsColumn.AllowEdit = false;
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 4;
            // 
            // colMaPhieuTiepNhanBaoHanh
            // 
            this.colMaPhieuTiepNhanBaoHanh.Caption = "Mã phiếu tiếp nhận bảo hành";
            this.colMaPhieuTiepNhanBaoHanh.FieldName = "MaPhieuTiepNhanBaoHanh";
            this.colMaPhieuTiepNhanBaoHanh.Name = "colMaPhieuTiepNhanBaoHanh";
            this.colMaPhieuTiepNhanBaoHanh.OptionsColumn.AllowEdit = false;
            this.colMaPhieuTiepNhanBaoHanh.Visible = true;
            this.colMaPhieuTiepNhanBaoHanh.VisibleIndex = 0;
            // 
            // colTrangThaiSuaChua
            // 
            this.colTrangThaiSuaChua.FieldName = "TrangThaiSuaChua";
            this.colTrangThaiSuaChua.Name = "colTrangThaiSuaChua";
            this.colTrangThaiSuaChua.OptionsColumn.AllowEdit = false;
            // 
            // pHIEUTIEPNHANBAOHANHTableAdapter
            // 
            this.pHIEUTIEPNHANBAOHANHTableAdapter.ClearBeforeFill = true;
            // 
            // tRANGTHAITRAHANGTableAdapter
            // 
            this.tRANGTHAITRAHANGTableAdapter.ClearBeforeFill = true;
            // 
            // TraHangBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_trabaohanh);
            this.Controls.Add(this.panel1);
            this.Name = "TraHangBaoHanh";
            this.Size = new System.Drawing.Size(1027, 553);
            this.Load += new System.EventHandler(this.TraHangBaoHanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_trabaohanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUTIEPNHANBAOHANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_trabaohanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_tt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRANGTHAITRAHANGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl_trabaohanh;
        private System.Windows.Forms.BindingSource pHIEUTIEPNHANBAOHANHBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_trabaohanh;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhieuBaoHanh;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhTrangSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colHongHoc;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiTraHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_tt;
        private System.Windows.Forms.BindingSource tRANGTHAITRAHANGBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhieuTiepNhanBaoHanh;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiSuaChua;
        private DATA.QLCHDTdatasetTableAdapters.PHIEUTIEPNHANBAOHANHTableAdapter pHIEUTIEPNHANBAOHANHTableAdapter;
        private DATA.QLCHDTdatasetTableAdapters.TRANGTHAITRAHANGTableAdapter tRANGTHAITRAHANGTableAdapter;
    }
}
