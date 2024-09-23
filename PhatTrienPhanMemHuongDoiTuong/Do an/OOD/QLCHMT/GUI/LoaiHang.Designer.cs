namespace QLCHMT.GUI
{
    partial class LoaiHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaiHang));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.btn_xoa = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sua = new DevExpress.XtraEditors.SimpleButton();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl_loaihang = new DevExpress.XtraGrid.GridControl();
            this.lOAIHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.gridView_loaihang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lOAIHANGTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.LOAIHANGTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_loaihang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAIHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_loaihang)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(926, 50);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "QUẢN LÝ LOẠI HÀNG";
            // 
            // btn_them
            // 
            this.btn_them.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_them.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.Location = new System.Drawing.Point(521, 0);
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
            this.btn_xoa.Location = new System.Drawing.Point(602, 0);
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
            this.btn_sua.Location = new System.Drawing.Point(683, 0);
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
            this.btn_luu.Location = new System.Drawing.Point(764, 0);
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
            this.btn_huy.Location = new System.Drawing.Point(845, 0);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 50);
            this.btn_huy.TabIndex = 0;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl_loaihang);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(926, 540);
            this.panel2.TabIndex = 3;
            // 
            // gridControl_loaihang
            // 
            this.gridControl_loaihang.DataSource = this.lOAIHANGBindingSource;
            this.gridControl_loaihang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_loaihang.Location = new System.Drawing.Point(0, 0);
            this.gridControl_loaihang.MainView = this.gridView_loaihang;
            this.gridControl_loaihang.Name = "gridControl_loaihang";
            this.gridControl_loaihang.Size = new System.Drawing.Size(926, 540);
            this.gridControl_loaihang.TabIndex = 0;
            this.gridControl_loaihang.UseEmbeddedNavigator = true;
            this.gridControl_loaihang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_loaihang});
            // 
            // lOAIHANGBindingSource
            // 
            this.lOAIHANGBindingSource.DataMember = "LOAIHANG";
            this.lOAIHANGBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView_loaihang
            // 
            this.gridView_loaihang.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_loaihang.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_loaihang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.gridView_loaihang.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_loaihang.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView_loaihang.Appearance.Row.Options.UseFont = true;
            this.gridView_loaihang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaLoai,
            this.colTenLoai});
            this.gridView_loaihang.GridControl = this.gridControl_loaihang;
            this.gridView_loaihang.Name = "gridView_loaihang";
            this.gridView_loaihang.OptionsFind.AlwaysVisible = true;
            this.gridView_loaihang.OptionsFind.FindNullPrompt = "Nhập từ tìm kiếm...";
            this.gridView_loaihang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_loaihang.OptionsView.ShowGroupPanel = false;
            this.gridView_loaihang.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_loaihang_InitNewRow);
            this.gridView_loaihang.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_loaihang_CellValueChanging);
            this.gridView_loaihang.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_loaihang_BeforeLeaveRow);
            this.gridView_loaihang.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_loaihang_ValidatingEditor);
            // 
            // colMaLoai
            // 
            this.colMaLoai.Caption = "Mã Loại";
            this.colMaLoai.FieldName = "MaLoai";
            this.colMaLoai.Name = "colMaLoai";
            this.colMaLoai.OptionsColumn.AllowEdit = false;
            this.colMaLoai.Visible = true;
            this.colMaLoai.VisibleIndex = 0;
            // 
            // colTenLoai
            // 
            this.colTenLoai.Caption = "Tên Loại";
            this.colTenLoai.FieldName = "TenLoai";
            this.colTenLoai.Name = "colTenLoai";
            this.colTenLoai.Visible = true;
            this.colTenLoai.VisibleIndex = 1;
            // 
            // lOAIHANGTableAdapter
            // 
            this.lOAIHANGTableAdapter.ClearBeforeFill = true;
            // 
            // LoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LoaiHang";
            this.Size = new System.Drawing.Size(926, 590);
            this.Load += new System.EventHandler(this.LoaiHang_Load);
            this.Leave += new System.EventHandler(this.LoaiHang_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_loaihang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAIHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_loaihang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_them;
        private DevExpress.XtraEditors.SimpleButton btn_xoa;
        private DevExpress.XtraEditors.SimpleButton btn_sua;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl_loaihang;
        private System.Windows.Forms.BindingSource lOAIHANGBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_loaihang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoai;
        private DATA.QLCHDTdatasetTableAdapters.LOAIHANGTableAdapter lOAIHANGTableAdapter;
    }
}
