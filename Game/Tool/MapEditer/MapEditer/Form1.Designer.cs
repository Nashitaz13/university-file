namespace MapEditer
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Y = new System.Windows.Forms.TextBox();
            this.txt_X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_grid = new System.Windows.Forms.Button();
            this.btn_loadOb = new System.Windows.Forms.Button();
            this.btn_loadBG = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cmb_level = new System.Windows.Forms.ComboBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.btn_grid);
            this.panel2.Controls.Add(this.btn_loadOb);
            this.panel2.Controls.Add(this.btn_loadBG);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.cmb_level);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 459);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1279, 187);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Y);
            this.groupBox1.Controls.Add(this.txt_X);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1197, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(70, 160);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // txt_Y
            // 
            this.txt_Y.Location = new System.Drawing.Point(29, 56);
            this.txt_Y.Name = "txt_Y";
            this.txt_Y.Size = new System.Drawing.Size(35, 20);
            this.txt_Y.TabIndex = 9;
            // 
            // txt_X
            // 
            this.txt_X.Location = new System.Drawing.Point(29, 30);
            this.txt_X.Name = "txt_X";
            this.txt_X.Size = new System.Drawing.Size(35, 20);
            this.txt_X.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(151, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1040, 177);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1032, 151);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enemy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1026, 145);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_grid
            // 
            this.btn_grid.Location = new System.Drawing.Point(12, 121);
            this.btn_grid.Name = "btn_grid";
            this.btn_grid.Size = new System.Drawing.Size(121, 30);
            this.btn_grid.TabIndex = 5;
            this.btn_grid.Text = "Grid";
            this.btn_grid.UseVisualStyleBackColor = true;
            this.btn_grid.Click += new System.EventHandler(this.btn_grid_Click);
            // 
            // btn_loadOb
            // 
            this.btn_loadOb.Location = new System.Drawing.Point(12, 85);
            this.btn_loadOb.Name = "btn_loadOb";
            this.btn_loadOb.Size = new System.Drawing.Size(121, 30);
            this.btn_loadOb.TabIndex = 4;
            this.btn_loadOb.Text = "Load Ob";
            this.btn_loadOb.UseVisualStyleBackColor = true;
            this.btn_loadOb.Click += new System.EventHandler(this.btn_loadOb_Click);
            // 
            // btn_loadBG
            // 
            this.btn_loadBG.Location = new System.Drawing.Point(12, 49);
            this.btn_loadBG.Name = "btn_loadBG";
            this.btn_loadBG.Size = new System.Drawing.Size(121, 30);
            this.btn_loadBG.TabIndex = 3;
            this.btn_loadBG.Text = "Load BG";
            this.btn_loadBG.UseVisualStyleBackColor = true;
            this.btn_loadBG.Click += new System.EventHandler(this.btn_loadBG_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 13);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(121, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cmb_level
            // 
            this.cmb_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_level.FormattingEnabled = true;
            this.cmb_level.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5"});
            this.cmb_level.Location = new System.Drawing.Point(12, 159);
            this.cmb_level.Name = "cmb_level";
            this.cmb_level.Size = new System.Drawing.Size(121, 21);
            this.cmb_level.TabIndex = 0;
            this.cmb_level.SelectedIndexChanged += new System.EventHandler(this.cmb_level_SelectedIndexChanged);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Location = new System.Drawing.Point(0, 442);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(1279, 17);
            this.hScrollBar.TabIndex = 3;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_ValueChanged);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(1262, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 442);
            this.vScrollBar.TabIndex = 4;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 432);
            this.panel1.TabIndex = 5;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_grid;
        private System.Windows.Forms.Button btn_loadOb;
        private System.Windows.Forms.Button btn_loadBG;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmb_level;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Y;
        private System.Windows.Forms.TextBox txt_X;
    }
}

