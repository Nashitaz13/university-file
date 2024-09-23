namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    partial class frmAddWarehouse
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
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtWarehouseID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtWarehouseName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            // 
            // 
            // 
            this.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(59, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(301, 128);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm Kho";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelX2.Location = new System.Drawing.Point(13, 137);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Mã Kho";
            // 
            // txtWarehouseID
            // 
            // 
            // 
            // 
            this.txtWarehouseID.Border.Class = "TextBoxBorder";
            this.txtWarehouseID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWarehouseID.Location = new System.Drawing.Point(114, 137);
            this.txtWarehouseID.MaxLength = 10;
            this.txtWarehouseID.Name = "txtWarehouseID";
            this.txtWarehouseID.Size = new System.Drawing.Size(246, 20);
            this.txtWarehouseID.TabIndex = 0;
            this.txtWarehouseID.Click += new System.EventHandler(this.txt_Click);
            this.txtWarehouseID.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtWarehouseName
            // 
            // 
            // 
            // 
            this.txtWarehouseName.Border.Class = "TextBoxBorder";
            this.txtWarehouseName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWarehouseName.Location = new System.Drawing.Point(114, 174);
            this.txtWarehouseName.MaxLength = 50;
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(246, 20);
            this.txtWarehouseName.TabIndex = 1;
            this.txtWarehouseName.Click += new System.EventHandler(this.txt_Click);
            this.txtWarehouseName.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelX1.Location = new System.Drawing.Point(13, 174);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Tên Kho";
            // 
            // txtNote
            // 
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.Location = new System.Drawing.Point(114, 213);
            this.txtNote.MaxLength = 100;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(246, 20);
            this.txtNote.TabIndex = 2;
            this.txtNote.Click += new System.EventHandler(this.txt_Click);
            this.txtNote.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelX3.Location = new System.Drawing.Point(13, 213);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "Ghi Chú";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(114, 251);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(215, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 290);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtWarehouseName);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtWarehouseID);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "frmAddWarehouse";
            this.Text = "Thêm Kho";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWarehouseID;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWarehouseName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}