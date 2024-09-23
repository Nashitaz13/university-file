using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.IO;
using System.Drawing.Imaging;

namespace QuanLyCuaHangLinhKienMayTinh
{
    public partial class frmInfoEmployee : Form
    {
        public BLL.InfoEmployeeBLL infoEmployeeBLL = new InfoEmployeeBLL();
        static string EmployeeID= "MNV0001";



        public frmInfoEmployee()
        {
            InitializeComponent();
        }

        private void frmInfoEmployee_Load(object sender, EventArgs e)
        {
           
            // combobox
            cboPosition.DataSource = infoEmployeeBLL.GetListPosition();
            cboPosition.SelectedIndex = -1;
            cboPosition.DisplayMember = "PositionName";
            //
            ReadInfoEmployeeFromData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSave() == true)
            {
                //get position number
                DTO.position c = (DTO.position)cboPosition.SelectedItem;
                string macv = c.PositionNumber.ToString();
                MemoryStream mem = new MemoryStream();
                try
                {
                   
                    Image ima = picImage.BackgroundImage;
                    ima.Save(mem, ImageFormat.Jpeg);
                }
                catch { };
                try
                {
                    
                    infoEmployeeBLL.UpdateEmployee(txtEmployeeID.Text, txtEmployeeName.Text, cboSex.Text, txtNumberID.Text, txtPhone.Text, dtmBirthDay.Value.ToString(), txtAddress.Text,
                                txtPlaceBrith.Text, txtAge.Text, macv, txtSalary.Text, dtmDayWorking.Value.ToString(), txtPassword.Text, cboStatus.Text, mem);
                    DisplayNotify("Cập nhật thành công", 1);


                }
                catch
                {
                    DisplayNotify("Lỗi ghi dữ liệu xuống CSDL", -1);
                }
            }
            else
            {
                DisplayNotify("Lỗi nhập dữ liệu, có thể bạn đã nhập sai hoặc thiếu các trường được đánh dấu đỏ", -1);


            }

        }

        private void dtmBirthDay_ValueChanged(object sender, EventArgs e)
        {
            // ngay vao lam
            if (dtmDayWorking.Value < dtmBirthDay.Value)
            {
                lblDayWorking.ForeColor = Color.Red;
            }
            else
                lblDayWorking.ForeColor = Color.Black;
            //  ngay sinh
            if (dtmBirthDay.Value >= DateTime.Now)
            {
                lblBirthDay.ForeColor = Color.Red;
            }
            else
            {
                lblBirthDay.ForeColor = Color.Black;
                txtAge.Text = (DateTime.Now.Year - dtmBirthDay.Value.Year).ToString();
            }
        }

        private void ControlTexxtbox_change(object sender, EventArgs e)
        {
            // all field
            if (((Control)(sender)).Text.Trim().Length == 0)
            {
                this.Controls.Find(((Control)(sender)).Tag.ToString(), true)[0].ForeColor = Color.Red;
            }
            else
            {
                this.Controls.Find(((Control)(sender)).Tag.ToString(), true)[0].ForeColor = Color.Green;
            }
            // field number
            CheckFieldNumber((Control)sender);

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
        public bool CheckBeforeSave()
        {
            bool check = true;
            List<Control> textbox = new List<Control>();
            // textbox
            textbox.Add(txtEmployeeID);
            textbox.Add(txtEmployeeName);
            textbox.Add(cboSex);
            textbox.Add(txtNumberID);
            textbox.Add(txtPhone);
            textbox.Add(txtAddress);
            textbox.Add(txtPlaceBrith);
            textbox.Add(txtSalary);
            textbox.Add(txtPassword);
            textbox.Add(cboPosition);
            textbox.Add(cboStatus);
            foreach (Control c in textbox)
            {
                if (c.Text.Trim().Length == 0)
                {
                    this.Controls.Find(c.Tag.ToString(), true)[0].ForeColor = Color.Red;
                    check = false;
                }
                else
                {
                    this.Controls.Find(c.Tag.ToString(), true)[0].ForeColor = Color.Green;
                    // field nuimber
                    bool checkflag = CheckFieldNumber(c);
                    if (checkflag == false)
                        check = false;
                }

            }
            //  ngay sinh
            if (dtmBirthDay.Value >= DateTime.Now)
            {
                check = false;
                lblBirthDay.ForeColor = Color.Red;
            }
            else
            {
                lblBirthDay.ForeColor = Color.Green;
            }
            // ngay vao lam
            if (dtmDayWorking.Value < dtmBirthDay.Value)
            {
                check = false;
                lblDayWorking.ForeColor = Color.Red;
            }
            else
            {
                lblDayWorking.ForeColor = Color.Green;
            }

            return check;
        }
        public bool CheckFieldNumber(Control control)
        {
            bool check = true;
            // field number
            if (control.Name == "txtPhone" || control.Name == "txtNumberID" || control.Name == "txtSalary")
            {
                rule r = new rule();
                if (control.Name == "txtPhone")
                {
                    if (r.CheckPhone(control.Text) == false)
                    {
                        check = false;
                        this.Controls.Find(control.Tag.ToString(), true)[0].ForeColor = Color.Red;
                    }
                    else
                        this.Controls.Find(control.Tag.ToString(), true)[0].ForeColor = Color.Green;
                }
                else
                {
                    if (control.Name == "txtNumberID")
                    {
                        if (r.CheckNumberID(control.Text) == false)
                        {
                            check = false;
                            this.Controls.Find(control.Tag.ToString(), true)[0].ForeColor = Color.Red;
                        }
                        else
                            this.Controls.Find(control.Tag.ToString(), true)[0].ForeColor = Color.Green;
                    }
                    else
                    {
                        if (r.CheckNumber(control.Text) == false)
                        {
                            check = false;
                            this.Controls.Find(control.Tag.ToString(), true)[0].ForeColor = Color.Red;
                        }
                        else
                            this.Controls.Find(control.Tag.ToString(), true)[0].ForeColor = Color.Green;
                    }
                }
            }
            return check;
        }
        public void SetSelectItemComboboxPosition(string ID)
                {
                    for (int i = 0; i < cboPosition.Items.Count; i++)
                    {
                        DTO.position a = (DTO.position)(cboPosition.Items[i]);
                        if (a.PositionNumber == ID)
                        {
                            cboPosition.SelectedIndex = i;
                            break;
                        }
                    }
                }
        public void ReadInfoEmployeeFromData()
        {
            try {
                DTO.Employee EmployeeSelected = infoEmployeeBLL.GetEmployee(EmployeeID);

                txtEmployeeID.Text = EmployeeSelected.EmployeeID;
                txtEmployeeName.Text = EmployeeSelected.EmployeeName;
                cboSex.SelectedItem = EmployeeSelected.Sex;
                txtNumberID.Text = EmployeeSelected.NumberID;
                txtPhone.Text = EmployeeSelected.Phone;
                dtmBirthDay.Value = DateTime.Parse(EmployeeSelected.BirthDay);
                txtAddress.Text = EmployeeSelected.Address;
                txtPlaceBrith.Text = EmployeeSelected.PlaceBirth;
                txtAge.Text = EmployeeSelected.Age;
                txtSalary.Text = EmployeeSelected.Salary;
                byte[] b = infoEmployeeBLL.GetImage(EmployeeSelected.EmployeeID);
                MemoryStream mem = new MemoryStream(b);
                Image ima = Image.FromStream(mem, true);
                picImage.BackgroundImage = ima;
                txtPassword.Text = EmployeeSelected.PassWord;
                cboStatus.SelectedItem = EmployeeSelected.StatusName;
                SetSelectItemComboboxPosition(EmployeeSelected.PositionID);

                // read control with controlID = EmployeeSelected.ControlID;
            }
            catch
            {
                DisplayNotify("Lỗi không đọc được chi tiết nhân viên từ csdl", -1);
            }
        }



        
    }
}
