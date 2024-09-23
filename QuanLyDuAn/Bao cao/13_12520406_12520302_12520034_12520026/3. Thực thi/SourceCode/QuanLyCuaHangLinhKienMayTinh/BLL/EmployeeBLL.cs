using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.IO;

namespace BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL EmployeeDAL = new EmployeeDAL();
        public string CreateEmployeeID()
        {
            try
            {

                string Soluong = EmployeeDAL.GetEmployeeCount().Rows[0].ItemArray[0].ToString();
                Soluong =( int.Parse(Soluong) + 1).ToString();
                // length <7  thi them so 0 truoc
                string sub = "";
                if (Soluong.Length < 4)
                {
                    int def = 4 - Soluong.Length;

                    // tao chuoi phu
                    for (int i = 0; i < def; i++)
                    {
                        sub = sub + "0";
                    }
                }
                return ("MNV" + sub + Soluong);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void SaveEmployee(string manv, string ten, string gioitinh, string cmnd, string sdt, 
                        string ngaysinh, string diachi, string noisinh, string tuoi, string chucvu,
                        string luong, string ngayVaoLam, MemoryStream anhThe,string pass, string trangthai)
        {
            try
            {
                EmployeeDAL.Save(manv,ten,gioitinh,cmnd,sdt,ngaysinh,diachi,noisinh,tuoi,chucvu,luong,ngayVaoLam,anhThe,pass,trangthai);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void UpdateEmployee(string manv, string ten, string gioitinh, string cmnd, string sdt,
                       string ngaysinh, string diachi, string noisinh, string tuoi, string chucvu,
                       string luong, string ngayVaoLam, MemoryStream anhThe, string pass, string trangthai)
        {
            try
            {
                EmployeeDAL.UpdateEmployee(manv, ten, gioitinh, cmnd, sdt, ngaysinh, diachi, noisinh, tuoi, chucvu, luong, ngayVaoLam, anhThe, pass, trangthai);
                //update control
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteEmployee(string manv, string ten, string gioitinh, string cmnd, string sdt,
                       string ngaysinh, string diachi, string noisinh, string tuoi, string chucvu,
                       string luong, string ngayVaoLam, MemoryStream anhThe, string pass, string trangthai)
        {
            try
            {
                EmployeeDAL.DeleteEmployee(manv, "Đã nghĩ làm");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<position> GetListPosition()
        {
            List<position> cv = new List<position>();
            try
            {
                DataTable d = EmployeeDAL.GetListPosition();
                foreach (DataRow  r in d.Rows)
                {
                    position c = new position();
                    c.PositionNumber = r.ItemArray[0].ToString();
                    c.PositionName = r.ItemArray[1].ToString();
                    c.Salary = r.ItemArray[2].ToString();
                    c.ControlID = r.ItemArray[3].ToString();
                    cv.Add(c);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return cv;
        }

         
        public List<Employee> GetAllEmployee()
        {
            List<Employee> cv = new List<Employee>();
            try
            {
                DataTable d = EmployeeDAL.GetAllEmployee();
                foreach (DataRow r in d.Rows)
                {
                    Employee c = new Employee();
                    c.EmployeeID = r.ItemArray[0].ToString();
                    c.EmployeeName = r.ItemArray[1].ToString();
                    c.Sex = r.ItemArray[2].ToString();
                    c.NumberID = r.ItemArray[3].ToString();
                    c.Phone = r.ItemArray[4].ToString();
                    c.BirthDay = r.ItemArray[5].ToString();
                    c.Address = r.ItemArray[6].ToString();
                    c.PlaceBirth = r.ItemArray[7].ToString();
                    c.Age = r.ItemArray[8].ToString();
                    c.PositionID = r.ItemArray[9].ToString();
                    c.PositionName = GetPositionName(r.ItemArray[9].ToString());
                    c.Salary = r.ItemArray[10].ToString();
                    c.DayWorking = r.ItemArray[11].ToString();
                    c.StatusName = r.ItemArray[13].ToString();
                    //c.ImageLink =new MemoryStream(Encoding.UTF8.GetBytes( r.ItemArray[12].ToString()));
                    c.PassWord = r.ItemArray[14].ToString();
                    c.ControlID = r.ItemArray[15].ToString();
                    cv.Add(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return cv;
        }

        public string GetPositionName(string positionID)
        {
            DataTable d = (EmployeeDAL.GetPositionName(positionID));
            string pos="";
            try
            {
                if(d.Rows.Count>0)
                    pos = d.Rows[0].ItemArray[0].ToString();
                return pos;
            }
            catch(Exception e)
            {
                throw e;
            }
            return pos;
        }
   

        public position GetOnePosition(string PositionID)
        {
            position pos = new position();
            try
            {
                DataTable d = EmployeeDAL.GetPosition(PositionID);
                if (d.Rows.Count > 0)
                {
                    
                    pos.PositionName = d.Rows[0].ItemArray[1].ToString();
                    pos.PositionNumber = d.Rows[0].ItemArray[0].ToString();
                    pos.Salary = d.Rows[0].ItemArray[2].ToString();
                    pos.ControlID= d.Rows[0].ItemArray[3].ToString();
                }
                return pos;

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public byte[] GetImage(string EmployeeID)
        {
            //byte[] b;
            try
            {
                DataTable d = new DataTable();
                d= EmployeeDAL.GetImage(EmployeeID);
                byte[] b = (byte[])(d.Rows[0][0]);
                return b;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
       
    }
}
