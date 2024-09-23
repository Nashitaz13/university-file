namespace BB
{
    partial class MH_In_NguonKhac
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
            this.Typed_dataset = new System.Windows.Forms.Button();
            this.XML = new System.Windows.Forms.Button();
            this.ACCESS = new System.Windows.Forms.Button();
            this.EXCEL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Typed_dataset
            // 
            this.Typed_dataset.Location = new System.Drawing.Point(131, 36);
            this.Typed_dataset.Name = "Typed_dataset";
            this.Typed_dataset.Size = new System.Drawing.Size(338, 38);
            this.Typed_dataset.TabIndex = 0;
            this.Typed_dataset.Text = "In báo biểu lấy nguồn từ Typed Dataset";
            this.Typed_dataset.UseVisualStyleBackColor = true;
            this.Typed_dataset.Click += new System.EventHandler(this.Typed_dataset_Click);
            // 
            // XML
            // 
            this.XML.Location = new System.Drawing.Point(131, 91);
            this.XML.Name = "XML";
            this.XML.Size = new System.Drawing.Size(338, 38);
            this.XML.TabIndex = 0;
            this.XML.Text = "In báo biểu lấy nguồn từ XML";
            this.XML.UseVisualStyleBackColor = true;
            this.XML.Click += new System.EventHandler(this.XML_Click);
            // 
            // ACCESS
            // 
            this.ACCESS.Location = new System.Drawing.Point(131, 210);
            this.ACCESS.Name = "ACCESS";
            this.ACCESS.Size = new System.Drawing.Size(338, 38);
            this.ACCESS.TabIndex = 0;
            this.ACCESS.Text = "In báo biểu lấy nguồn từ ACCESS";
            this.ACCESS.UseVisualStyleBackColor = true;
            this.ACCESS.Click += new System.EventHandler(this.ACCESS_Click);
            // 
            // EXCEL
            // 
            this.EXCEL.Location = new System.Drawing.Point(131, 151);
            this.EXCEL.Name = "EXCEL";
            this.EXCEL.Size = new System.Drawing.Size(338, 38);
            this.EXCEL.TabIndex = 0;
            this.EXCEL.Text = "In báo biểu lấy nguồn từ EXCEL";
            this.EXCEL.UseVisualStyleBackColor = true;
            this.EXCEL.Click += new System.EventHandler(this.EXCEL_Click);
            // 
            // MH_In_NguonKhac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 280);
            this.Controls.Add(this.EXCEL);
            this.Controls.Add(this.ACCESS);
            this.Controls.Add(this.XML);
            this.Controls.Add(this.Typed_dataset);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MH_In_NguonKhac";
            this.Text = "In báo biểu từ các nguồn khác";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Typed_dataset;
        private System.Windows.Forms.Button XML;
        private System.Windows.Forms.Button ACCESS;
        private System.Windows.Forms.Button EXCEL;
    }
}