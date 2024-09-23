using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BB.Bao_Bieu;
using System.Configuration;
using System.Data.SqlClient;

namespace BB
{
    public partial class MH_In_NguonKhac : Form
    {
        public MH_In_NguonKhac()
        {
            InitializeComponent();
        }
        private void XML_Click(object sender, EventArgs e)
        {
            BB_Nguon_XML BC = new BB_Nguon_XML();
            CrystalDecisions.Shared.TableLogOnInfo thongtin;
            thongtin = BC.Database.Tables[0].LogOnInfo;
            thongtin.ConnectionInfo.ServerName = Application.StartupPath + "C:\\..\\..\\..\\..\\..\\..\\..\\Du_Lieu\\QLCuonSach.xml";
            BC.Database.Tables[0].ApplyLogOnInfo(thongtin);
            BC.RecordSelectionFormula = "{CUONSACH.TinhTrang}= 'Chưa được mượn'";
            MH_Xem_BaoBieu mh = new MH_Xem_BaoBieu();
            mh.CRV.ReportSource = BC;
            mh.ShowDialog();
        }

        private void EXCEL_Click(object sender, EventArgs e)
        {
            BB_Nguon_Excel BC = new BB_Nguon_Excel();
            CrystalDecisions.Shared.TableLogOnInfo thongtin;
            thongtin = BC.Database.Tables[0].LogOnInfo;
            thongtin.ConnectionInfo.ServerName = Application.StartupPath + @"C:\..\..\..\..\..\..\..\Du_Lieu\QLSach.xls";
            BC.Database.Tables[0].ApplyLogOnInfo(thongtin);
            MH_Xem_BaoBieu mh = new MH_Xem_BaoBieu();
            mh.CRV.ReportSource = BC;
            mh.ShowDialog();
        }

        private void ACCESS_Click(object sender, EventArgs e)
        {
            BB_Nguon_Access BC = new BB_Nguon_Access();
            CrystalDecisions.Shared.TableLogOnInfo thongtin;
            thongtin = BC.Database.Tables[0].LogOnInfo;
            thongtin.ConnectionInfo.ServerName = Application.StartupPath + @"C:\..\..\..\..\..\..\..\Du_Lieu\QLSach.mdb";
            BC.Database.Tables[0].ApplyLogOnInfo(thongtin);
            MH_Xem_BaoBieu mh = new MH_Xem_BaoBieu();
            mh.CRV.ReportSource = BC;
            mh.ShowDialog();
        }

        private void Typed_dataset_Click(object sender, EventArgs e)
        {
            //Xử lý độc dữ liệu và gán nguồn lại cho báo biểu 
            
            // Lấy thông tin kết nối
            string chuoi_ket_noi = ConfigurationManager.ConnectionStrings["chuoiketnoi"].ConnectionString;
            string chuoilenh = "Select * From SACH;Select * From CUONSACH";
            SqlDataAdapter bo_doc_ghi = new SqlDataAdapter(chuoilenh,chuoi_ket_noi);
            bo_doc_ghi.TableMappings.Add("Table", "SACH");
            bo_doc_ghi.TableMappings.Add("Table1", "CUONSACH");
            DataSet du_lieu = new DataSet("QUANLYTHUVIEN");
            bo_doc_ghi.Fill(du_lieu);

            //DataSet ket_noi = new DataSet();
            //ket_noi.ReadXml(Application.StartupPath +  @"C:\..\..\..\..\..\..\..\ket_noi.xml");

            // Xứ lý in báo biếu nguồn
            BB_Nguon_Typed_Dataset BC = new BB_Nguon_Typed_Dataset();
            BC.SetDataSource(du_lieu);
            //CrystalDecisions.Shared.TableLogOnInfo thongtin;
            //thongtin = BC.Database.Tables[0].LogOnInfo;
            //thongtin.ConnectionInfo.ServerName = Application.StartupPath + @"C:\..\..\..\..\..\..\..\Typed_Dataset\csdl_qlsach.xsd";
            //BC.Database.Tables[0].ApplyLogOnInfo(thongtin);
            MH_Xem_BaoBieu mh = new MH_Xem_BaoBieu();
            mh.CRV.ReportSource = BC;
            mh.ShowDialog();
        }
    }
}
