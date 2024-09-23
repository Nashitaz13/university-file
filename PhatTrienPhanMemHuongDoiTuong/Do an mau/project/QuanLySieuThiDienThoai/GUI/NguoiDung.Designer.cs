namespace QuanLySieuThiDienThoai.GUI
{
    partial class NguoiDung
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
            this.backstageViewControl_nguoidung = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.gridControl_PQ = new DevExpress.XtraGrid.GridControl();
            this.gridView_PQ = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Q = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_NV = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmb_PQ_MaNV = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_PQ_Quyen = new System.Windows.Forms.ComboBox();
            this.txt_PQ_mk = new System.Windows.Forms.TextBox();
            this.txt_PQ_TenNV = new System.Windows.Forms.TextBox();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.gridControl_loaiquyen = new DevExpress.XtraGrid.GridControl();
            this.gridView_loaiquyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenQuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_LQ_Ten = new System.Windows.Forms.TextBox();
            this.txt_LQ_Ma = new System.Windows.Forms.TextBox();
            this.backstageViewTabItem_phnquyen = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewTabItem_loaiquyen = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator2 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.btn_them = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_sua = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_luu = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_huy = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btn_xoa = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewControl_nguoidung.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_PQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_NV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.backstageViewClientControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_loaiquyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_loaiquyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backstageViewControl_nguoidung
            // 
            this.backstageViewControl_nguoidung.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl_nguoidung.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl_nguoidung.Controls.Add(this.backstageViewClientControl2);
            this.backstageViewControl_nguoidung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backstageViewControl_nguoidung.Items.Add(this.backstageViewTabItem_phnquyen);
            this.backstageViewControl_nguoidung.Items.Add(this.backstageViewTabItem_loaiquyen);
            this.backstageViewControl_nguoidung.Items.Add(this.backstageViewItemSeparator2);
            this.backstageViewControl_nguoidung.Items.Add(this.btn_them);
            this.backstageViewControl_nguoidung.Items.Add(this.btn_sua);
            this.backstageViewControl_nguoidung.Items.Add(this.btn_luu);
            this.backstageViewControl_nguoidung.Items.Add(this.btn_huy);
            this.backstageViewControl_nguoidung.Items.Add(this.btn_xoa);
            this.backstageViewControl_nguoidung.Location = new System.Drawing.Point(0, 0);
            this.backstageViewControl_nguoidung.Name = "backstageViewControl_nguoidung";
            this.backstageViewControl_nguoidung.SelectedTab = null;
            this.backstageViewControl_nguoidung.Size = new System.Drawing.Size(948, 617);
            this.backstageViewControl_nguoidung.TabIndex = 0;
            this.backstageViewControl_nguoidung.Text = "backstageViewControl1";
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.gridControl_PQ);
            this.backstageViewClientControl1.Controls.Add(this.panelControl2);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(146, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(802, 617);
            this.backstageViewClientControl1.TabIndex = 0;
            // 
            // gridControl_PQ
            // 
            this.gridControl_PQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_PQ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_PQ.Location = new System.Drawing.Point(0, 163);
            this.gridControl_PQ.MainView = this.gridView_PQ;
            this.gridControl_PQ.Name = "gridControl_PQ";
            this.gridControl_PQ.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_NV,
            this.repositoryItemLookUpEdit_Q});
            this.gridControl_PQ.Size = new System.Drawing.Size(802, 454);
            this.gridControl_PQ.TabIndex = 1;
            this.gridControl_PQ.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_PQ});
            this.gridControl_PQ.Click += new System.EventHandler(this.gridControl_PQ_Click);
            // 
            // gridView_PQ
            // 
            this.gridView_PQ.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuyen,
            this.colMaNV,
            this.colTenNV,
            this.colMK});
            this.gridView_PQ.GridControl = this.gridControl_PQ;
            this.gridView_PQ.Name = "gridView_PQ";
            this.gridView_PQ.OptionsFind.AlwaysVisible = true;
            this.gridView_PQ.OptionsView.ShowGroupPanel = false;
            // 
            // colQuyen
            // 
            this.colQuyen.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colQuyen.AppearanceCell.Options.UseFont = true;
            this.colQuyen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colQuyen.AppearanceHeader.Options.UseFont = true;
            this.colQuyen.Caption = "Quyền";
            this.colQuyen.ColumnEdit = this.repositoryItemLookUpEdit_Q;
            this.colQuyen.FieldName = "Quyen";
            this.colQuyen.Name = "colQuyen";
            this.colQuyen.Visible = true;
            this.colQuyen.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit_Q
            // 
            this.repositoryItemLookUpEdit_Q.AutoHeight = false;
            this.repositoryItemLookUpEdit_Q.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Q.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaQuyen", "Mã Quyen", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenQuyen", "Tên Quyen", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_Q.DisplayMember = "TenQuyen";
            this.repositoryItemLookUpEdit_Q.Name = "repositoryItemLookUpEdit_Q";
            this.repositoryItemLookUpEdit_Q.ValueMember = "MaQuyen";
            // 
            // colMaNV
            // 
            this.colMaNV.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colMaNV.AppearanceCell.Options.UseFont = true;
            this.colMaNV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colMaNV.AppearanceHeader.Options.UseFont = true;
            this.colMaNV.Caption = "Mã Nhân Viên";
            this.colMaNV.ColumnEdit = this.repositoryItemLookUpEdit_NV;
            this.colMaNV.FieldName = "MaNV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Visible = true;
            this.colMaNV.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit_NV
            // 
            this.repositoryItemLookUpEdit_NV.AutoHeight = false;
            this.repositoryItemLookUpEdit_NV.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_NV.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNV", "Mã NV", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNV", "Tên NV", 44, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_NV.DisplayMember = "MaNV";
            this.repositoryItemLookUpEdit_NV.Name = "repositoryItemLookUpEdit_NV";
            this.repositoryItemLookUpEdit_NV.ValueMember = "MaNV";
            // 
            // colTenNV
            // 
            this.colTenNV.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colTenNV.AppearanceCell.Options.UseFont = true;
            this.colTenNV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colTenNV.AppearanceHeader.Options.UseFont = true;
            this.colTenNV.Caption = "Tên Nhân Viên";
            this.colTenNV.FieldName = "TenNV";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.Visible = true;
            this.colTenNV.VisibleIndex = 0;
            // 
            // colMK
            // 
            this.colMK.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colMK.AppearanceCell.Options.UseFont = true;
            this.colMK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colMK.AppearanceHeader.Options.UseFont = true;
            this.colMK.Caption = "Mật Khẩu";
            this.colMK.FieldName = "MK";
            this.colMK.Name = "colMK";
            this.colMK.Visible = true;
            this.colMK.VisibleIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.ContentImage = global::QuanLySieuThiDienThoai.Properties.Resources.business_banking_background_large_hero;
            this.panelControl2.Controls.Add(this.cmb_PQ_MaNV);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label7);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.cmb_PQ_Quyen);
            this.panelControl2.Controls.Add(this.txt_PQ_mk);
            this.panelControl2.Controls.Add(this.txt_PQ_TenNV);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(802, 163);
            this.panelControl2.TabIndex = 0;
            // 
            // cmb_PQ_MaNV
            // 
            this.cmb_PQ_MaNV.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_PQ_MaNV.FormattingEnabled = true;
            this.cmb_PQ_MaNV.Location = new System.Drawing.Point(158, 84);
            this.cmb_PQ_MaNV.Name = "cmb_PQ_MaNV";
            this.cmb_PQ_MaNV.Size = new System.Drawing.Size(256, 26);
            this.cmb_PQ_MaNV.TabIndex = 17;
            this.cmb_PQ_MaNV.ValueMember = "MaNV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(463, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mật Khẩu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Quyền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mã Nhân Viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tên Đăng Nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên Đăng Nhập";
            // 
            // cmb_PQ_Quyen
            // 
            this.cmb_PQ_Quyen.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_PQ_Quyen.FormattingEnabled = true;
            this.cmb_PQ_Quyen.Location = new System.Drawing.Point(545, 38);
            this.cmb_PQ_Quyen.Name = "cmb_PQ_Quyen";
            this.cmb_PQ_Quyen.Size = new System.Drawing.Size(182, 26);
            this.cmb_PQ_Quyen.TabIndex = 12;
            this.cmb_PQ_Quyen.ValueMember = "MaQuyen";
            // 
            // txt_PQ_mk
            // 
            this.txt_PQ_mk.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PQ_mk.Location = new System.Drawing.Point(545, 88);
            this.txt_PQ_mk.Name = "txt_PQ_mk";
            this.txt_PQ_mk.Size = new System.Drawing.Size(182, 26);
            this.txt_PQ_mk.TabIndex = 11;
            // 
            // txt_PQ_TenNV
            // 
            this.txt_PQ_TenNV.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PQ_TenNV.Location = new System.Drawing.Point(158, 35);
            this.txt_PQ_TenNV.Name = "txt_PQ_TenNV";
            this.txt_PQ_TenNV.Size = new System.Drawing.Size(256, 26);
            this.txt_PQ_TenNV.TabIndex = 10;
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Controls.Add(this.gridControl_loaiquyen);
            this.backstageViewClientControl2.Controls.Add(this.panelControl1);
            this.backstageViewClientControl2.Location = new System.Drawing.Point(146, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new System.Drawing.Size(802, 617);
            this.backstageViewClientControl2.TabIndex = 1;
            // 
            // gridControl_loaiquyen
            // 
            this.gridControl_loaiquyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_loaiquyen.Location = new System.Drawing.Point(0, 153);
            this.gridControl_loaiquyen.MainView = this.gridView_loaiquyen;
            this.gridControl_loaiquyen.Name = "gridControl_loaiquyen";
            this.gridControl_loaiquyen.Size = new System.Drawing.Size(802, 464);
            this.gridControl_loaiquyen.TabIndex = 4;
            this.gridControl_loaiquyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_loaiquyen});
            this.gridControl_loaiquyen.Click += new System.EventHandler(this.gridControl_loaiquyen_Click);
            // 
            // gridView_loaiquyen
            // 
            this.gridView_loaiquyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQuyen,
            this.colTenQuyen});
            this.gridView_loaiquyen.GridControl = this.gridControl_loaiquyen;
            this.gridView_loaiquyen.Name = "gridView_loaiquyen";
            this.gridView_loaiquyen.OptionsFind.AlwaysVisible = true;
            this.gridView_loaiquyen.OptionsView.ShowGroupPanel = false;
            // 
            // colMaQuyen
            // 
            this.colMaQuyen.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaQuyen.AppearanceCell.Options.UseFont = true;
            this.colMaQuyen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colMaQuyen.AppearanceHeader.Options.UseFont = true;
            this.colMaQuyen.Caption = "Mã Quyền";
            this.colMaQuyen.FieldName = "MaQuyen";
            this.colMaQuyen.Name = "colMaQuyen";
            this.colMaQuyen.Visible = true;
            this.colMaQuyen.VisibleIndex = 0;
            // 
            // colTenQuyen
            // 
            this.colTenQuyen.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTenQuyen.AppearanceCell.Options.UseFont = true;
            this.colTenQuyen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colTenQuyen.AppearanceHeader.Options.UseFont = true;
            this.colTenQuyen.Caption = "Tên Quyền";
            this.colTenQuyen.FieldName = "TenQuyen";
            this.colTenQuyen.Name = "colTenQuyen";
            this.colTenQuyen.Visible = true;
            this.colTenQuyen.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.ContentImage = global::QuanLySieuThiDienThoai.Properties.Resources.business_banking_background_large_hero;
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txt_LQ_Ten);
            this.panelControl1.Controls.Add(this.txt_LQ_Ma);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(802, 153);
            this.panelControl1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên Quyền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã Quyền";
            // 
            // txt_LQ_Ten
            // 
            this.txt_LQ_Ten.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LQ_Ten.Location = new System.Drawing.Point(134, 82);
            this.txt_LQ_Ten.Name = "txt_LQ_Ten";
            this.txt_LQ_Ten.Size = new System.Drawing.Size(379, 26);
            this.txt_LQ_Ten.TabIndex = 5;
            // 
            // txt_LQ_Ma
            // 
            this.txt_LQ_Ma.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LQ_Ma.Location = new System.Drawing.Point(134, 35);
            this.txt_LQ_Ma.Name = "txt_LQ_Ma";
            this.txt_LQ_Ma.Size = new System.Drawing.Size(379, 26);
            this.txt_LQ_Ma.TabIndex = 4;
            // 
            // backstageViewTabItem_phnquyen
            // 
            this.backstageViewTabItem_phnquyen.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewTabItem_phnquyen.Appearance.Options.UseFont = true;
            this.backstageViewTabItem_phnquyen.AppearanceHover.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewTabItem_phnquyen.AppearanceHover.Options.UseFont = true;
            this.backstageViewTabItem_phnquyen.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewTabItem_phnquyen.AppearanceSelected.Options.UseFont = true;
            this.backstageViewTabItem_phnquyen.Caption = "Phân Quyền";
            this.backstageViewTabItem_phnquyen.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem_phnquyen.Name = "backstageViewTabItem_phnquyen";
            this.backstageViewTabItem_phnquyen.Selected = false;
            this.backstageViewTabItem_phnquyen.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItem_phnquyen_SelectedChanged);
            // 
            // backstageViewTabItem_loaiquyen
            // 
            this.backstageViewTabItem_loaiquyen.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewTabItem_loaiquyen.Appearance.Options.UseFont = true;
            this.backstageViewTabItem_loaiquyen.AppearanceHover.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewTabItem_loaiquyen.AppearanceHover.Options.UseFont = true;
            this.backstageViewTabItem_loaiquyen.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewTabItem_loaiquyen.AppearanceSelected.Options.UseFont = true;
            this.backstageViewTabItem_loaiquyen.Caption = "Loại Quyền";
            this.backstageViewTabItem_loaiquyen.ContentControl = this.backstageViewClientControl2;
            this.backstageViewTabItem_loaiquyen.Name = "backstageViewTabItem_loaiquyen";
            this.backstageViewTabItem_loaiquyen.Selected = false;
            this.backstageViewTabItem_loaiquyen.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItem_loaiquyen_SelectedChanged);
            // 
            // backstageViewItemSeparator2
            // 
            this.backstageViewItemSeparator2.Name = "backstageViewItemSeparator2";
            // 
            // btn_them
            // 
            this.btn_them.Caption = "Thêm";
            this.btn_them.Name = "btn_them";
            this.btn_them.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_them_ItemClick);
            // 
            // btn_sua
            // 
            this.btn_sua.Caption = "Sửa";
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btn_sua_ItemClick);
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
            // NguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backstageViewControl_nguoidung);
            this.Name = "NguoiDung";
            this.Size = new System.Drawing.Size(948, 617);
            this.Load += new System.EventHandler(this.NguoiDung_Load);
            this.backstageViewControl_nguoidung.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_PQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_NV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.backstageViewClientControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_loaiquyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_loaiquyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl_nguoidung;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem_phnquyen;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem_loaiquyen;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_them;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_xoa;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_luu;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator2;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_huy;
        private DevExpress.XtraGrid.GridControl gridControl_loaiquyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_loaiquyen;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colTenQuyen;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_PQ;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_PQ;
        private DevExpress.XtraGrid.Columns.GridColumn colQuyen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Q;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNV;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_NV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNV;
        private DevExpress.XtraGrid.Columns.GridColumn colMK;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ComboBox cmb_PQ_MaNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_PQ_Quyen;
        private System.Windows.Forms.TextBox txt_PQ_mk;
        private System.Windows.Forms.TextBox txt_PQ_TenNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_LQ_Ten;
        private System.Windows.Forms.TextBox txt_LQ_Ma;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btn_sua;
        private System.Windows.Forms.Label label7;
    }
}
