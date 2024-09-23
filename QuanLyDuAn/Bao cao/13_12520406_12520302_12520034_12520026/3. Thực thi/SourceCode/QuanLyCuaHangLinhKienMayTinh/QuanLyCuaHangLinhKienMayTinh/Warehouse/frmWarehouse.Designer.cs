namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    partial class frmWarehouse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgWarehouse = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            this.clmWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWarehouse
            // 
            this.dgWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWarehouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmWarehouseID,
            this.clmWarehouseName,
            this.clmNote,
            this.clmEdit});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWarehouse.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgWarehouse.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgWarehouse.Location = new System.Drawing.Point(15, 170);
            this.dgWarehouse.Name = "dgWarehouse";
            this.dgWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgWarehouse.Size = new System.Drawing.Size(658, 293);
            this.dgWarehouse.TabIndex = 4;
            this.dgWarehouse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWarehouse_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(321, 113);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 113);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Tìm Kiếm";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(595, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(103, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(518, 87);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "Danh Sách Kho";
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(83, 114);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefresh.Location = new System.Drawing.Point(15, 142);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(51, 23);
            this.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm tươi";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // clmWarehouseID
            // 
            this.clmWarehouseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmWarehouseID.HeaderText = "Mã Kho";
            this.clmWarehouseID.MaxInputLength = 10;
            this.clmWarehouseID.Name = "clmWarehouseID";
            this.clmWarehouseID.ReadOnly = true;
            this.clmWarehouseID.Width = 69;
            // 
            // clmWarehouseName
            // 
            this.clmWarehouseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmWarehouseName.HeaderText = "Tên Kho";
            this.clmWarehouseName.Name = "clmWarehouseName";
            this.clmWarehouseName.ReadOnly = true;
            // 
            // clmNote
            // 
            this.clmNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmNote.HeaderText = "Ghi Chú";
            this.clmNote.Name = "clmNote";
            this.clmNote.ReadOnly = true;
            // 
            // clmEdit
            // 
            this.clmEdit.HeaderText = "";
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.Text = "Sửa";
            this.clmEdit.UseColumnTextForButtonValue = true;
            this.clmEdit.Width = 50;
            // 
            // frmWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 475);
            this.ControlBox = false;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgWarehouse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmWarehouse";
            this.Load += new System.EventHandler(this.frmWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgWarehouse;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn clmEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWarehouseID;
    }
}