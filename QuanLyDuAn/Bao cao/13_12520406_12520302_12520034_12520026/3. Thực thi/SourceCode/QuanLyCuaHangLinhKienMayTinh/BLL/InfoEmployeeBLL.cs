using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;
using System.IO;

namespace BLL
{
    public class InfoEmployeeBLL
    {
        DAL.InfoEmployeeDAL infoEmployeDAL = new DAL.InfoEmployeeDAL();




        public Employee GetEmployee(string EmployeeID)
        {

            DataTable data = infoEmployeDAL.GetEmployee(EmployeeID);
            try
            {
                Employee c = new Employee();
                if (data.Rows.Count > 0)
                 {
                    DataRow r = data.Rows[0];
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
                    //c.ImageLink = new MemoryStream(Encoding.UTF8.GetBytes(r.ItemArray[12].ToString()));
                    c.PassWord = r.ItemArray[14].ToString();
                    c.ControlID = r.ItemArray[15].ToString();
                    return c;
                }
                else
                    return c;

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
        public string GetPositionName(string positionID)
        {
            DataTable d = (infoEmployeDAL.GetPositionName(positionID));
            string pos = "";
            try
            {
                if (d.Rows.Count > 0)
                    pos = d.Rows[0].ItemArray[0].ToString();
                return pos;
            }
            catch (Exception e)
            {
                throw e;
            }
            return pos;
        }

        public List<position> GetListPosition()
        {
            List<position> cv = new List<position>();
            try
            {
                DataTable d = infoEmployeDAL.GetListPosition();
                foreach (DataRow r in d.Rows)
                {
                    position c = new position();
                    c.PositionNumber = r.ItemArray[0].ToString();
                    c.PositionName = r.ItemArray[1].ToString();
                    c.Salary = r.ItemArray[2].ToString();
                    c.ControlID = r.ItemArray[3].ToString();
                    cv.Add(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return cv;
        }

        public void UpdateEmployee(string manv, string ten, string gioitinh, string cmnd, string sdt,
                      string ngaysinh, string diachi, string noisinh, string tuoi, string chucvu,
                      string luong, string ngayVaoLam, string pass, string trangthai, MemoryStream anhthe)
        {
            try
            {
                infoEmployeDAL.UpdateEmployee(manv, ten, gioitinh, cmnd, sdt, ngaysinh, diachi, noisinh, tuoi, chucvu, luong, ngayVaoLam, pass, trangthai,anhthe);
                //update control
            }
            catch (Exception e)
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
                d = infoEmployeDAL.GetImage(EmployeeID);
                byte[] b = (byte[])(d.Rows[0][0]);
                return b;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}