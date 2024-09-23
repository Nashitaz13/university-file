
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CommonLayer
{
    public class CommonFunction
    {
        public struct BillProduct
        {
            public string proId;
            public int num;
        }
        public static bool IntToBool(int n)
        {
            return n == 0 ? false : true;
        }

        public static int BoolToInt(bool b)
        {
            return b == false ? 0 : 1;
        }

        #region search
        /// <summary>
        /// seach 
        /// </summary>
        /// <param name="data"> dgv</param>
        /// <param name="key"> key search</param>
        /// <param name="index"> index start search</param>
        /// <returns> index defind key in dgv</returns>
        public static int Search(DataGridView data, string key, int index)
        {
            int check = 0;
            for (int i = index+1; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Rows[i].Cells.Count; j++)
                {
                    if (data.Columns[j].Displayed == true)
                    {
                        string cells =NonUnicode( data.Rows[i].Cells[j].Value.ToString().ToUpper());
                        string newKey = NonUnicode(key.ToUpper());
                        if (cells.Contains(newKey))
                        {
                            data.Rows[i].Selected = true;
                            data.FirstDisplayedScrollingRowIndex = i;
                            return i;
                        }

                    }

                }
            }
            if(check==0)
            {
                index = 0;
                check = 1;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    for (int j = 0; j < data.Rows[i].Cells.Count; j++)
                    {
                        if (data.Columns[j].Displayed == true)
                        {
                            string cells = NonUnicode(data.Rows[i].Cells[j].Value.ToString().ToUpper());
                            string newKey = NonUnicode(key.ToUpper());
                            if (cells.Contains(newKey))
                            {
                                data.Rows[i].Selected = true;
                                data.FirstDisplayedScrollingRowIndex = i;
                                return i;
                            }

                        }

                    }
                }
            }
            MessageBox.Show("Không tìm thấy giá trị tương ứng!");
            return 0;
        }

        public static string NonUnicode( string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        public static DataTable SortByColumn(DataTable data, int indexcolumn, string valuecolumn)
        {
            for ( int i=0;i< data.Rows.Count;i++)
            {
                DataRow row = data.Rows[i];
                if (row.ItemArray[indexcolumn].ToString()!=valuecolumn)
                {
                    data.Rows.Remove(row);
                    i--;
                }
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="indexcolumn"></param>
        /// <param name="valuecolumn"></param>
        /// <param name="type">1-before//2-after</param>
        /// <returns></returns>
        public static DataTable SortByColumnDate(DataTable data, int indexcolumn, string valuecolumn, int type)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                try
                {
                    DateTime daterow = DateTime.Parse(row.ItemArray[indexcolumn].ToString());
                    DateTime compare = DateTime.Parse(valuecolumn);

                    if ( daterow.Year==compare.Year && daterow.Day == compare.Day && daterow.Month == compare.Month)
                    {
                        
                    }
                    else
                    {
                        data.Rows.Remove(row);
                        i--;
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
                
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="indexcolumn"></param>
        /// <param name="valuecolumnstart">from</param>
        /// <param name="valuecolumnend">end</param>
        /// <returns></returns>
        public static DataTable SortByColumnDate(DataTable data, int indexcolumn, string valuecolumnstart , string valuecolumnend)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                try
                {
                    DateTime daterow = DateTime.Parse(row.ItemArray[indexcolumn].ToString());
                    DateTime start = DateTime.Parse(valuecolumnstart);
                    DateTime end = DateTime.Parse(valuecolumnend);
                    if (daterow <= end && daterow >= start)
                    {

                    }
                    else
                    {
                        data.Rows.Remove(row);
                        i--;
                    }
                    return data;
                }
                catch (Exception e)
                {
                    throw e;
                }
                
            }
            return data;
        }
        #endregion
    }

}
