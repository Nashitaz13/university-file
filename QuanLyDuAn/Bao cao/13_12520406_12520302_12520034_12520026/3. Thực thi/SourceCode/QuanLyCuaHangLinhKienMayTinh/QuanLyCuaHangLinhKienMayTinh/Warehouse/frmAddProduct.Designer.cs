namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    partial class frmAddProduct
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
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.warehouseComboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtPrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtQuanlity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtUnit = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUnitImport = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtProductName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtProductID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtProductType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.distributorComboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.Location = new System.Drawing.Point(127, 245);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(202, 20);
            this.txtNote.TabIndex = 9;
            this.txtNote.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // warehouseComboBox
            // 
            this.warehouseComboBox.DisplayMember = "TenKho";
            this.warehouseComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.warehouseComboBox.FormattingEnabled = true;
            this.warehouseComboBox.ItemHeight = 14;
            this.warehouseComboBox.Location = new System.Drawing.Point(800, 196);
            this.warehouseComboBox.Name = "warehouseComboBox";
            this.warehouseComboBox.Size = new System.Drawing.Size(202, 20);
            this.warehouseComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.warehouseComboBox.TabIndex = 8;
            this.warehouseComboBox.ValueMember = "MaKho";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.Border.Class = "TextBoxBorder";
            this.txtPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrice.Location = new System.Drawing.Point(127, 198);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(202, 20);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(28, 197);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(75, 23);
            this.labelX11.TabIndex = 57;
            this.labelX11.Text = "Đơn Giá Bán";
            // 
            // txtQuanlity
            // 
            // 
            // 
            // 
            this.txtQuanlity.Border.Class = "TextBoxBorder";
            this.txtQuanlity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuanlity.Location = new System.Drawing.Point(800, 148);
            this.txtQuanlity.Name = "txtQuanlity";
            this.txtQuanlity.Size = new System.Drawing.Size(202, 20);
            this.txtQuanlity.TabIndex = 5;
            this.txtQuanlity.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(719, 147);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(75, 23);
            this.labelX12.TabIndex = 56;
            this.labelX12.Text = "Số Lượng";
            // 
            // txtUnit
            // 
            // 
            // 
            // 
            this.txtUnit.Border.Class = "TextBoxBorder";
            this.txtUnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUnit.Location = new System.Drawing.Point(463, 198);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(202, 20);
            this.txtUnit.TabIndex = 7;
            this.txtUnit.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtUnitImport
            // 
            // 
            // 
            // 
            this.txtUnitImport.Border.Class = "TextBoxBorder";
            this.txtUnitImport.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUnitImport.Location = new System.Drawing.Point(463, 150);
            this.txtUnitImport.Name = "txtUnitImport";
            this.txtUnitImport.Size = new System.Drawing.Size(202, 20);
            this.txtUnitImport.TabIndex = 4;
            this.txtUnitImport.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(364, 149);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(75, 23);
            this.labelX13.TabIndex = 55;
            this.labelX13.Text = "Đơn Giá Nhập";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(127, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(31, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(719, 195);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 54;
            this.labelX8.Text = "Kho";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(28, 244);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(75, 23);
            this.labelX14.TabIndex = 48;
            this.labelX14.Text = "Ghi Chú";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(364, 197);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 50;
            this.labelX10.Text = "Đơn Vị Tính";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(719, 99);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 37;
            this.labelX4.Text = "Nhà Phân Phối";
            // 
            // txtProductName
            // 
            // 
            // 
            // 
            this.txtProductName.Border.Class = "TextBoxBorder";
            this.txtProductName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductName.Location = new System.Drawing.Point(463, 100);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(202, 20);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(364, 99);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 33;
            this.labelX3.Text = "Tên Sản Phẩm";
            // 
            // txtProductID
            // 
            // 
            // 
            // 
            this.txtProductID.Border.Class = "TextBoxBorder";
            this.txtProductID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductID.Location = new System.Drawing.Point(127, 102);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(202, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(31, 99);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 30;
            this.labelX2.Text = "Mã Sản Phẩm";
            // 
            // lblTitle
            // 
            // 
            // 
            // 
            this.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(238, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(486, 75);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Thêm Sản Phẩm";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 149);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(82, 23);
            this.labelX1.TabIndex = 37;
            this.labelX1.Text = "Loại Sản Phẩm";
            // 
            // txtProductType
            // 
            // 
            // 
            // 
            this.txtProductType.Border.Class = "TextBoxBorder";
            this.txtProductType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductType.Location = new System.Drawing.Point(127, 150);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(202, 20);
            this.txtProductType.TabIndex = 3;
            // 
            // distributorComboBox
            // 
            this.distributorComboBox.DisplayMember = "TenNhaPhanPhoi";
            this.distributorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.distributorComboBox.FormattingEnabled = true;
            this.distributorComboBox.ItemHeight = 14;
            this.distributorComboBox.Location = new System.Drawing.Point(800, 100);
            this.distributorComboBox.Name = "distributorComboBox";
            this.distributorComboBox.Size = new System.Drawing.Size(202, 20);
            this.distributorComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.distributorComboBox.TabIndex = 2;
            this.distributorComboBox.ValueMember = "NhaPhanPhoi";
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 326);
            this.Controls.Add(this.txtProductType);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.distributorComboBox);
            this.Controls.Add(this.warehouseComboBox);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.txtQuanlity);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtUnitImport);
            this.Controls.Add(this.labelX13);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX14);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddProduct";
            this.Text = "Thêm Sản Phẩm";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductID;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUnitImport;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUnit;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQuanlity;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrice;
        private DevComponents.DotNetBar.Controls.ComboBoxEx warehouseComboBox;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx distributorComboBox;
    }
}