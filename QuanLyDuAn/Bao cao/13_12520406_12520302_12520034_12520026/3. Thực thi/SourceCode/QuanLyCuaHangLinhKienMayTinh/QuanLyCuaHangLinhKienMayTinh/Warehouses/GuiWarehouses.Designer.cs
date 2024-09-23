namespace QuanLyCuaHangLinhKienMayTinh.Warehouses
{
    partial class GuiWarehouses
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
            this.dgList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.drMaKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drTenKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drTrangThai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.drNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgList
            // 
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.drMaKho,
            this.drTenKho,
            this.drTrangThai,
            this.drNgayTao,
            this.drGhiChu});
            this.dgList.Location = new System.Drawing.Point(28, 95);
            this.dgList.Name = "dgList";
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgList.Size = new System.Drawing.Size(578, 372);
            this.dgList.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(80, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(245, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(48, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(517, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Tạo mới kho";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // drMaKho
            // 
            this.drMaKho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.drMaKho.HeaderText = "Mã Kho";
            this.drMaKho.Name = "drMaKho";
            this.drMaKho.ReadOnly = true;
            this.drMaKho.Width = 69;
            // 
            // drTenKho
            // 
            this.drTenKho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.drTenKho.HeaderText = "Tên Kho";
            this.drTenKho.Name = "drTenKho";
            this.drTenKho.ReadOnly = true;
            // 
            // drTrangThai
            // 
            this.drTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.drTrangThai.HeaderText = "Trạng Thái";
            this.drTrangThai.Name = "drTrangThai";
            this.drTrangThai.ReadOnly = true;
            this.drTrangThai.Width = 65;
            // 
            // drNgayTao
            // 
            this.drNgayTao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.drNgayTao.HeaderText = "Ngày Tạo";
            this.drNgayTao.Name = "drNgayTao";
            this.drNgayTao.ReadOnly = true;
            this.drNgayTao.Width = 79;
            // 
            // drGhiChu
            // 
            this.drGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.drGhiChu.HeaderText = "Ghi Chú";
            this.drGhiChu.Name = "drGhiChu";
            this.drGhiChu.ReadOnly = true;
            // 
            // GuiWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(618, 479);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgList);
            this.DoubleBuffered = true;
            this.Name = "GuiWarehouses";
            this.Load += new System.EventHandler(this.Warehouses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn drGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn drNgayTao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn drTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn drTenKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn drMaKho;
    }
}