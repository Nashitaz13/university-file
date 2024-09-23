namespace DoAnThucHanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.HinhChuNhat = new System.Windows.Forms.Button();
            this.Elip = new System.Windows.Forms.Button();
            this.DuongThang = new System.Windows.Forms.Button();
            this.Paste = new System.Windows.Forms.Button();
            this.Cut = new System.Windows.Forms.Button();
            this.ChonHinh = new System.Windows.Forms.Button();
            this.Fill = new System.Windows.Forms.Button();
            this.Del = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Foreground = new System.Windows.Forms.Button();
            this.Background = new System.Windows.Forms.Button();
            this.Border = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Sort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HinhChuNhat
            // 
            this.HinhChuNhat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HinhChuNhat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HinhChuNhat.BackgroundImage")));
            this.HinhChuNhat.Location = new System.Drawing.Point(5, 5);
            this.HinhChuNhat.Name = "HinhChuNhat";
            this.HinhChuNhat.Size = new System.Drawing.Size(40, 40);
            this.HinhChuNhat.TabIndex = 0;
            this.HinhChuNhat.UseVisualStyleBackColor = false;
            this.HinhChuNhat.Click += new System.EventHandler(this.HinhChuNhat_Click);
            // 
            // Elip
            // 
            this.Elip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Elip.BackgroundImage")));
            this.Elip.Location = new System.Drawing.Point(45, 5);
            this.Elip.Name = "Elip";
            this.Elip.Size = new System.Drawing.Size(40, 40);
            this.Elip.TabIndex = 3;
            this.Elip.UseVisualStyleBackColor = true;
            this.Elip.Click += new System.EventHandler(this.Elip_Click);
            // 
            // DuongThang
            // 
            this.DuongThang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DuongThang.BackgroundImage")));
            this.DuongThang.Location = new System.Drawing.Point(85, 5);
            this.DuongThang.Name = "DuongThang";
            this.DuongThang.Size = new System.Drawing.Size(40, 40);
            this.DuongThang.TabIndex = 4;
            this.DuongThang.UseVisualStyleBackColor = true;
            this.DuongThang.Click += new System.EventHandler(this.DuongThang_Click);
            // 
            // Paste
            // 
            this.Paste.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paste.Location = new System.Drawing.Point(215, 5);
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(40, 40);
            this.Paste.TabIndex = 7;
            this.Paste.Text = "V";
            this.Paste.UseVisualStyleBackColor = true;
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Cut
            // 
            this.Cut.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cut.Location = new System.Drawing.Point(175, 5);
            this.Cut.Name = "Cut";
            this.Cut.Size = new System.Drawing.Size(40, 40);
            this.Cut.TabIndex = 6;
            this.Cut.Text = "X";
            this.Cut.UseVisualStyleBackColor = true;
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // ChonHinh
            // 
            this.ChonHinh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChonHinh.BackgroundImage")));
            this.ChonHinh.Location = new System.Drawing.Point(135, 5);
            this.ChonHinh.Name = "ChonHinh";
            this.ChonHinh.Size = new System.Drawing.Size(40, 40);
            this.ChonHinh.TabIndex = 5;
            this.ChonHinh.UseVisualStyleBackColor = true;
            this.ChonHinh.Click += new System.EventHandler(this.ChonHinh_Click);
            // 
            // Fill
            // 
            this.Fill.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fill.Location = new System.Drawing.Point(345, 5);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(40, 40);
            this.Fill.TabIndex = 10;
            this.Fill.Text = "Fill";
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // Del
            // 
            this.Del.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Del.Location = new System.Drawing.Point(295, 5);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(40, 40);
            this.Del.TabIndex = 9;
            this.Del.Text = "Del";
            this.Del.UseVisualStyleBackColor = true;
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // Copy
            // 
            this.Copy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copy.Location = new System.Drawing.Point(255, 5);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(40, 40);
            this.Copy.TabIndex = 8;
            this.Copy.Text = "C";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Foreground
            // 
            this.Foreground.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Foreground.Location = new System.Drawing.Point(465, 5);
            this.Foreground.Name = "Foreground";
            this.Foreground.Size = new System.Drawing.Size(40, 40);
            this.Foreground.TabIndex = 13;
            this.Foreground.Text = "FG";
            this.Foreground.UseVisualStyleBackColor = true;
            // 
            // Background
            // 
            this.Background.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Background.Location = new System.Drawing.Point(425, 5);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(40, 40);
            this.Background.TabIndex = 12;
            this.Background.Text = "BG";
            this.Background.UseVisualStyleBackColor = true;
            this.Background.Click += new System.EventHandler(this.Background_Click);
            // 
            // Border
            // 
            this.Border.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Border.Location = new System.Drawing.Point(385, 5);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(40, 40);
            this.Border.TabIndex = 11;
            this.Border.Text = "Border";
            this.Border.UseVisualStyleBackColor = true;
            this.Border.Click += new System.EventHandler(this.Border_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(555, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(40, 40);
            this.Save.TabIndex = 15;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Sort
            // 
            this.Sort.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sort.Location = new System.Drawing.Point(515, 5);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(40, 40);
            this.Sort.TabIndex = 14;
            this.Sort.Text = "Sort";
            this.Sort.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 461);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.Foreground);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.Del);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Paste);
            this.Controls.Add(this.Cut);
            this.Controls.Add(this.ChonHinh);
            this.Controls.Add(this.DuongThang);
            this.Controls.Add(this.Elip);
            this.Controls.Add(this.HinhChuNhat);
            this.Name = "Form1";
            this.Text = "Đồ án cá nhân - 12520026 - Phan Y Biển";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HinhChuNhat;
        private System.Windows.Forms.Button Elip;
        private System.Windows.Forms.Button DuongThang;
        private System.Windows.Forms.Button Paste;
        private System.Windows.Forms.Button Cut;
        private System.Windows.Forms.Button ChonHinh;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.Button Del;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button Foreground;
        private System.Windows.Forms.Button Background;
        private System.Windows.Forms.Button Border;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Sort;
    }
}

