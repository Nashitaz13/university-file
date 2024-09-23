using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLayer;
using BLL;

namespace QuanLyCuaHangLinhKienMayTinh
{
    
    public partial class frmPosition : Form
    {
        PositionBLL positionBLL = new PositionBLL();
        static int SearchIndex = 0;
        public frmPosition()
        {
            InitializeComponent();
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            //
            try
            {
                dgvData.DataSource = positionBLL.GetAllPosition();
                dgvData.ClearSelection();
            }
            catch(Exception ex)
            {
                DisplayNotify("Lỗi đọc danh sách chức vụ từ csdl", -1);
            }
            //
            try
            {
                ResetTextbox();
                txtPositionID.Text = positionBLL.CreatPositionID();
            }
            catch(Exception ex)
            {
                DisplayNotify("Lỗi Tạo mới mã chức vụ", -1);
            }
            //button
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ResetTextbox();
                txtPositionID.Text = positionBLL.CreatPositionID();

            }
            catch(Exception ex)
            {
                DisplayNotify("Lỗi tạo mã nhân viên mới! ",-1);
            }
            //button
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void ResetTextbox()
        {
            txtPositionID.Text = txtPositionName.Text = txtSalary.Text = null;
            // radiobutton
             
            
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DTO.position p = (DTO.position)(dgvData.SelectedRows[0].DataBoundItem);
                txtPositionID.Text = p.PositionNumber;
                txtPositionName.Text = p.PositionName;
                txtSalary.Text = p.Salary;
                //btn
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                // control
                try
                {

                }
                catch(Exception ex)
                {
                    DisplayNotify("Lỗi không đọc được chức năng của Chức vụ này !",-1);
                }


            }
        }
        public void ResetNotify()
        {
            lblNotify.Text = "";
            lblNotify.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(45)))));
        }
        public void DisplayNotify(string error, int codeError)
        {
            if (codeError == 1)
            {
                lblNotify.Text = error;
                lblNotify.BackColor = Color.Green;
            }
            else
            {
                if (codeError == -1)
                {
                    lblNotify.Text = error;
                    lblNotify.BackColor = Color.Red;
                }
            }
            // timer
            int TimeInterval = error.Length * 30;
            if (TimeInterval < 800)
                TimeInterval = 800;
            timerNotify.Interval = TimeInterval;
            timerNotify.Start();
        }
        private void timerNotify_Tick(object sender, EventArgs e)
        {
            ResetNotify();
            timerNotify.Stop();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            rule r = new rule();
            if (txtPositionID.Text.Trim().Length > 0 && txtPositionName.Text.Trim().Length > 0 && r.CheckNumber(txtSalary.Text.Trim()) == true)
            {
                try {
                    positionBLL.Update(txtPositionID.Text, txtPositionName.Text, txtSalary.Text, txtPositionID.Text);
                    //update control 
                    string KeyToSelect = txtPositionID.Text;
                    DisplayNotify("cập nhật dữ liệu thành công",1);
                    dgvData.DataSource = positionBLL.GetAllPosition();
                    dgvData.DataSource = positionBLL.GetAllPosition();
                    SelectRow(dgvData, KeyToSelect);
                }
                catch(Exception ex)
                {
                    DisplayNotify("Lỗi cập nhật dữ liệu không thành công",-1);
                }

            }
            else
                DisplayNotify("Lỗi nhập sai các ô nhập liệu hoặc nhập thiếu",-1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            rule r = new rule();
            if (txtPositionID.Text.Trim().Length > 0 && txtPositionName.Text.Trim().Length > 0 && r.CheckNumber(txtSalary.Text.Trim()) == true)
            {
                try
                {
                    positionBLL.Save(txtPositionID.Text, txtPositionName.Text, txtSalary.Text, txtPositionID.Text);
                    //update control 

                    //
                    string KeyToSelect = txtPositionID.Text;
                    btnSave.Enabled = false;
                    DisplayNotify("Lưu dữ liệu thành công", 1);
                    dgvData.DataSource = positionBLL.GetAllPosition();
                    SelectRow(dgvData, KeyToSelect);

                }
                catch (Exception ex)
                {
                    DisplayNotify("Lỗi Lưu  dữ liệu không thành công", -1);
                }

            }
            else
                DisplayNotify("Lỗi nhập sai các ô nhập liệu hoặc nhập thiếu", -1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                String error = "0";
                positionBLL.Delete(txtPositionID.Text, out error);

                if (error == "0")
                {// update control
                    
                    DisplayNotify("Xóa dữ liệu thành công", 1);
                    dgvData.DataSource = positionBLL.GetAllPosition();
                }
                else
                {
                    DisplayNotify(error, -1);
                }
            }
            catch (Exception ex)
            {
                DisplayNotify("Lỗi Xóa dữ liệu không thành công", -1);
            }

            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = true;
            
        }
        private void btnFindnext_Click_1(object sender, EventArgs e)
        {
             
            SearchIndex = CommonFunction.Search(dgvData, txtFindText.Text, SearchIndex);
        }

        private void btnCloseFind_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = false;
        }
        public void SelectRow(DataGridView dgv, string key)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null && dgv.Rows[i].Cells[j].Value != "")
                    {
                        if (dgv.Rows[i].Cells[j].Value.ToString() == key)
                        {
                            dgv.Rows[i].Selected = true;
                            dgvData.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                    }
                }
            }
        }




    }
}
