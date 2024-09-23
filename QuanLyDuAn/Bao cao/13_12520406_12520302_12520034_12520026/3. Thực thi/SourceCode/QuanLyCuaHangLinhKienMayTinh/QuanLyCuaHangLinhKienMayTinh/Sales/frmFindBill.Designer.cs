namespace QuanLyCuaHangLinhKienMayTinh
{
    partial class frmFindBill
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
            this.pnlFind = new System.Windows.Forms.Panel();
            this.btnExpand = new DevComponents.DotNetBar.ButtonX();
            this.btnFindnext = new DevComponents.DotNetBar.ButtonX();
            this.txtFindText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlcontent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlAdvanced = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlcontent.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlAdvanced.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.BackColor = System.Drawing.Color.Transparent;
            this.pnlFind.Controls.Add(this.btnExpand);
            this.pnlFind.Controls.Add(this.btnFindnext);
            this.pnlFind.Controls.Add(this.txtFindText);
            this.pnlFind.Controls.Add(this.label3);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFind.Location = new System.Drawing.Point(3, 16);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(793, 81);
            this.pnlFind.TabIndex = 38;
            // 
            // btnExpand
            // 
            this.btnExpand.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.BackgroundImage = global::QuanLyCuaHangLinhKienMayTinh.Properties.Resources.Button_Upload_icon;
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpand.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnExpand.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExpand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExpand.Location = new System.Drawing.Point(757, 60);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(33, 18);
            this.btnExpand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExpand.TabIndex = 5;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnFindnext
            // 
            this.btnFindnext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFindnext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFindnext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFindnext.Location = new System.Drawing.Point(295, 46);
            this.btnFindnext.Name = "btnFindnext";
            this.btnFindnext.Size = new System.Drawing.Size(89, 23);
            this.btnFindnext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFindnext.TabIndex = 1;
            this.btnFindnext.Text = "Tìm kế tiếp";
            this.btnFindnext.Click += new System.EventHandler(this.btnFindnext_Click);
            // 
            // txtFindText
            // 
            this.txtFindText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFindText.Location = new System.Drawing.Point(268, 16);
            this.txtFindText.Name = "txtFindText";
            this.txtFindText.Size = new System.Drawing.Size(261, 20);
            this.txtFindText.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlFind);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(799, 100);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội dung tìm kiếm";
            // 
            // pnlcontent
            // 
            this.pnlcontent.Controls.Add(this.panel3);
            this.pnlcontent.Controls.Add(this.pnlAdvanced);
            this.pnlcontent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlcontent.Location = new System.Drawing.Point(0, 100);
            this.pnlcontent.Name = "pnlcontent";
            this.pnlcontent.Size = new System.Drawing.Size(799, 357);
            this.pnlcontent.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 257);
            this.panel3.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(799, 257);
            this.dgvData.TabIndex = 8;
            // 
            // pnlAdvanced
            // 
            this.pnlAdvanced.Controls.Add(this.groupBox1);
            this.pnlAdvanced.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdvanced.Location = new System.Drawing.Point(0, 0);
            this.pnlAdvanced.Name = "pnlAdvanced";
            this.pnlAdvanced.Size = new System.Drawing.Size(799, 100);
            this.pnlAdvanced.TabIndex = 0;
            this.pnlAdvanced.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker4);
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn tìm kiếm nâng cao";
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(284, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(73, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Sau ngày:";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(284, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Từ ngày:";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(284, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(82, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Trước ngày:";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khách hàng";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(95, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(568, 39);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker4.TabIndex = 5;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(375, 41);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker3.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(375, 65);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(375, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nội dung tìm kiếm";
            // 
            // frmFindBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 457);
            this.ControlBox = false;
            this.Controls.Add(this.pnlcontent);
            this.Controls.Add(this.groupBox2);
            this.MinimumSize = new System.Drawing.Size(815, 473);
            this.Name = "frmFindBill";
            this.Load += new System.EventHandler(this.frmFillBill_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlcontent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlAdvanced.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFind;
        private DevComponents.DotNetBar.ButtonX btnFindnext;
        private System.Windows.Forms.TextBox txtFindText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlcontent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pnlAdvanced;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevComponents.DotNetBar.ButtonX btnExpand;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
    }
}