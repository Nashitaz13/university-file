namespace QLCHMT.Report
{
    partial class BaoCaoBanHang
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
            this.qLCHDTdataset = new QLCHMT.DATA.QLCHDTdataset();
            this.bAOCAOBANHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bAOCAOBANHANGTableAdapter = new QLCHMT.DATA.QLCHDTdatasetTableAdapters.BAOCAOBANHANGTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAOCAOBANHANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // qLCHDTdataset
            // 
            this.qLCHDTdataset.DataSetName = "QLCHDTdataset";
            this.qLCHDTdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bAOCAOBANHANGBindingSource
            // 
            this.bAOCAOBANHANGBindingSource.DataMember = "BAOCAOBANHANG";
            this.bAOCAOBANHANGBindingSource.DataSource = this.qLCHDTdataset;
            // 
            // bAOCAOBANHANGTableAdapter
            // 
            this.bAOCAOBANHANGTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BaoCaoBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Name = "BaoCaoBanHang";
            this.Size = new System.Drawing.Size(1082, 561);
            ((System.ComponentModel.ISupportInitialize)(this.qLCHDTdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAOCAOBANHANGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DATA.QLCHDTdataset qLCHDTdataset;
        private System.Windows.Forms.BindingSource bAOCAOBANHANGBindingSource;
        private DATA.QLCHDTdatasetTableAdapters.BAOCAOBANHANGTableAdapter bAOCAOBANHANGTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}
