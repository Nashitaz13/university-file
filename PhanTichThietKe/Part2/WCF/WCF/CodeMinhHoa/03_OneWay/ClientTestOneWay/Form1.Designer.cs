namespace ClientTestOneWay
{
    partial class MainForm
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
            this.btnCallOneWayOperation = new System.Windows.Forms.Button();
            this.btnCallNonOneWay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallOneWayOperation
            // 
            this.btnCallOneWayOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallOneWayOperation.Location = new System.Drawing.Point(114, 80);
            this.btnCallOneWayOperation.Name = "btnCallOneWayOperation";
            this.btnCallOneWayOperation.Size = new System.Drawing.Size(373, 90);
            this.btnCallOneWayOperation.TabIndex = 0;
            this.btnCallOneWayOperation.Text = "Call OneWay operation";
            this.btnCallOneWayOperation.UseVisualStyleBackColor = true;
            this.btnCallOneWayOperation.Click += new System.EventHandler(this.btnCallOneWayOperation_Click);
            // 
            // btnCallNonOneWay
            // 
            this.btnCallNonOneWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallNonOneWay.Location = new System.Drawing.Point(114, 223);
            this.btnCallNonOneWay.Name = "btnCallNonOneWay";
            this.btnCallNonOneWay.Size = new System.Drawing.Size(373, 90);
            this.btnCallNonOneWay.TabIndex = 1;
            this.btnCallNonOneWay.Text = "Call Non OneWay operation";
            this.btnCallNonOneWay.UseVisualStyleBackColor = true;
            this.btnCallNonOneWay.Click += new System.EventHandler(this.btnCallNonOneWay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 407);
            this.Controls.Add(this.btnCallNonOneWay);
            this.Controls.Add(this.btnCallOneWayOperation);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallOneWayOperation;
        private System.Windows.Forms.Button btnCallNonOneWay;
    }
}

