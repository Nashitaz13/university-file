namespace Client
{
    partial class Form1
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
            this.btnAddAsync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSync = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAsync
            // 
            this.btnAddAsync.Location = new System.Drawing.Point(336, 167);
            this.btnAddAsync.Name = "btnAddAsync";
            this.btnAddAsync.Size = new System.Drawing.Size(199, 51);
            this.btnAddAsync.TabIndex = 0;
            this.btnAddAsync.Text = "Add Async";
            this.btnAddAsync.UseVisualStyleBackColor = true;
            this.btnAddAsync.Click += new System.EventHandler(this.btnAddAsync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "A=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "B=";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(121, 38);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(201, 38);
            this.txtA.TabIndex = 3;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(121, 99);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(201, 38);
            this.txtB.TabIndex = 4;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(121, 261);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(201, 38);
            this.txtAdd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "A+B=";
            // 
            // btnAddSync
            // 
            this.btnAddSync.Location = new System.Drawing.Point(39, 167);
            this.btnAddSync.Name = "btnAddSync";
            this.btnAddSync.Size = new System.Drawing.Size(199, 51);
            this.btnAddSync.TabIndex = 7;
            this.btnAddSync.Text = "Add Sync";
            this.btnAddSync.UseVisualStyleBackColor = true;
            this.btnAddSync.Click += new System.EventHandler(this.btnAddSync_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(12, 319);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(612, 47);
            this.lblStatus.TabIndex = 8;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(42, 388);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(552, 53);
            this.trackBar1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 474);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddSync);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAsync);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAsync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddSync;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

