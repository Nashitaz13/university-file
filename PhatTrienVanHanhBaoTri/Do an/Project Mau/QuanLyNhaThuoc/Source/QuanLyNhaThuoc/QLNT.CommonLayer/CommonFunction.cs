using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNT.CommonLayer
{
    public class CommonFunction
    {
        public static void DinhDangThaoTacLuoi(DataGridView dgv, bool duocPhepSua)
        {
            dgv.AllowUserToAddRows = duocPhepSua;
            dgv.AllowUserToDeleteRows = duocPhepSua;            
            dgv.ReadOnly = !duocPhepSua;
        }

        public static void DinhDangHienThiLuoi(DataGridView dgv)
        {
            for (int iRow = 0; iRow < dgv.Rows.Count; iRow++)
            {
                for (int iCell = 0; iCell < dgv.Columns.Count; iCell++)
                {                    
                    if (dgv.Rows[iRow].Cells[iCell].ReadOnly)
                    {
                        dgv.Rows[iRow].Cells[iCell].Style.BackColor = Color.WhiteSmoke;                        
                    }
                    else
                    {
                        dgv.Rows[iRow].Cells[iCell].Style.BackColor = dgv.Rows[iRow].Cells[iCell].OwningColumn.DefaultCellStyle.BackColor;                       
                    }
                }
                
            }
        }
    }
}
