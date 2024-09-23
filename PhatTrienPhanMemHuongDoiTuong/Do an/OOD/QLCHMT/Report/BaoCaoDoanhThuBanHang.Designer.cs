namespace QLCHMT.Report
{
    partial class BaoCaoDoanhThuBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCaoDoanhThuBanHang));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_nam = new System.Windows.Forms.ComboBox();
            this.nAMXUATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.comboBox_thang = new System.Windows.Forms.ComboBox();
            this.tHANGXUATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton_chonthang = new System.Windows.Forms.RadioButton();
            this.radioButton_tungaydenngay = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEdit_denngay = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_tungay = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_xem = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tHANG_XUATTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.THANG_XUATTableAdapter();
            this.nAM_XUATTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.NAM_XUATTableAdapter();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAMXUATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHANGXUATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_tungay.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(375, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 487);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.btn_xem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(375, 487);
            this.panel4.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_nam);
            this.groupBox1.Controls.Add(this.comboBox_thang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioButton_chonthang);
            this.groupBox1.Controls.Add(this.radioButton_tungaydenngay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateEdit_denngay);
            this.groupBox1.Controls.Add(this.dateEdit_tungay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 309);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn điều kiện";
            // 
            // comboBox_nam
            // 
            this.comboBox_nam.DataSource = this.nAMXUATBindingSource;
            this.comboBox_nam.DisplayMember = "Nam";
            this.comboBox_nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_nam.FormattingEnabled = true;
            this.comboBox_nam.Location = new System.Drawing.Point(170, 216);
            this.comboBox_nam.Name = "comboBox_nam";
            this.comboBox_nam.Size = new System.Drawing.Size(137, 28);
            this.comboBox_nam.TabIndex = 25;
            this.comboBox_nam.ValueMember = "Nam";
            // 
            // nAMXUATBindingSource
            // 
            this.nAMXUATBindingSource.DataMember = "NAM_XUAT";
            this.nAMXUATBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox_thang
            // 
            this.comboBox_thang.DataSource = this.tHANGXUATBindingSource;
            this.comboBox_thang.DisplayMember = "Thang";
            this.comboBox_thang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_thang.FormattingEnabled = true;
            this.comboBox_thang.Location = new System.Drawing.Point(171, 168);
            this.comboBox_thang.Name = "comboBox_thang";
            this.comboBox_thang.Size = new System.Drawing.Size(136, 28);
            this.comboBox_thang.TabIndex = 24;
            this.comboBox_thang.ValueMember = "Thang";
            // 
            // tHANGXUATBindingSource
            // 
            this.tHANGXUATBindingSource.DataMember = "THANG_XUAT";
            this.tHANGXUATBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Chọn tháng";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Chọn năm";
            // 
            // radioButton_chonthang
            // 
            this.radioButton_chonthang.AutoSize = true;
            this.radioButton_chonthang.Location = new System.Drawing.Point(29, 176);
            this.radioButton_chonthang.Name = "radioButton_chonthang";
            this.radioButton_chonthang.Size = new System.Drawing.Size(14, 13);
            this.radioButton_chonthang.TabIndex = 19;
            this.radioButton_chonthang.TabStop = true;
            this.radioButton_chonthang.UseVisualStyleBackColor = true;
            this.radioButton_chonthang.CheckedChanged += new System.EventHandler(this.radioButton_chonthang_CheckedChanged);
            // 
            // radioButton_tungaydenngay
            // 
            this.radioButton_tungaydenngay.AutoSize = true;
            this.radioButton_tungaydenngay.Location = new System.Drawing.Point(27, 33);
            this.radioButton_tungaydenngay.Name = "radioButton_tungaydenngay";
            this.radioButton_tungaydenngay.Size = new System.Drawing.Size(14, 13);
            this.radioButton_tungaydenngay.TabIndex = 18;
            this.radioButton_tungaydenngay.TabStop = true;
            this.radioButton_tungaydenngay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Từ ngày";
            // 
            // dateEdit_denngay
            // 
            this.dateEdit_denngay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateEdit_denngay.EditValue = null;
            this.dateEdit_denngay.Location = new System.Drawing.Point(169, 79);
            this.dateEdit_denngay.Name = "dateEdit_denngay";
            this.dateEdit_denngay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit_denngay.Properties.Appearance.Options.UseFont = true;
            this.dateEdit_denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_denngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_denngay.Size = new System.Drawing.Size(136, 26);
            this.dateEdit_denngay.TabIndex = 16;
            // 
            // dateEdit_tungay
            // 
            this.dateEdit_tungay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateEdit_tungay.EditValue = null;
            this.dateEdit_tungay.Location = new System.Drawing.Point(169, 31);
            this.dateEdit_tungay.Name = "dateEdit_tungay";
            this.dateEdit_tungay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit_tungay.Properties.Appearance.Options.UseFont = true;
            this.dateEdit_tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_tungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_tungay.Size = new System.Drawing.Size(136, 26);
            this.dateEdit_tungay.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Đến ngày";
            // 
            // btn_xem
            // 
            this.btn_xem.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xem.Appearance.Options.UseFont = true;
            this.btn_xem.Image = ((System.Drawing.Image)(resources.GetObject("btn_xem.Image")));
            this.btn_xem.Location = new System.Drawing.Point(137, 361);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(87, 45);
            this.btn_xem.TabIndex = 18;
            this.btn_xem.Text = "Xem";
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 65);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "BÁO CÁO DOANH THU BÁN HÀNG";
            // 
            // tHANG_XUATTableAdapter
            // 
            this.tHANG_XUATTableAdapter.ClearBeforeFill = true;
            // 
            // nAM_XUATTableAdapter
            // 
            this.nAM_XUATTableAdapter.ClearBeforeFill = true;
            // 
            // BaoCaoDoanhThuBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "BaoCaoDoanhThuBanHang";
            this.Size = new System.Drawing.Size(1014, 552);
            this.Load += new System.EventHandler(this.BaoCaoDoanhThuBanHang_Load);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAMXUATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHANGXUATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_tungay.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_nam;
        private System.Windows.Forms.ComboBox comboBox_thang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton_chonthang;
        private System.Windows.Forms.RadioButton radioButton_tungaydenngay;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dateEdit_denngay;
        private DevExpress.XtraEditors.DateEdit dateEdit_tungay;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btn_xem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource nAMXUATBindingSource;
        private DATA.QLCHDTdataset qLCHDTdataset;
        private System.Windows.Forms.BindingSource tHANGXUATBindingSource;
        private DATA.QLCHDTdatasetTableAdapters.THANG_XUATTableAdapter tHANG_XUATTableAdapter;
        private DATA.QLCHDTdatasetTableAdapters.NAM_XUATTableAdapter nAM_XUATTableAdapter;
    }
}
