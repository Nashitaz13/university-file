using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars.Alerter;

namespace EasyPOS.Utils
{
    public static class Util
    {        
        // Convert IEnumerable to DataTable
        public static DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType.Name.Contains("Nullable") ? typeof(String) : p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }

        // Convert Image to byte[]
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        // Convert byte[] to Image
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public static void ExportXls(IPrintable Printer, string printCaption, Control.ControlCollection Controls)
        {
            if (Printer == null) return;
            OnBestFitColumns(Controls);
            PrintCaption = printCaption;
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            link.Component = Printer;
            link.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(printableComponentLink_CreateReportHeaderArea);

            link.PaperKind = System.Drawing.Printing.PaperKind.A4;

            link.Margins.Bottom = link.Margins.Left = link.Margins.Right = link.Margins.Top = 50;

            link.CreateDocument();
            string fileName = string.Empty;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Exel 2013 (*.xls)|*.xls";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fileName = save.FileName;

            if (string.IsNullOrEmpty(fileName)) return;
            link.ExportToXls(fileName);
        }
        public static void PreviewReport(IPrintable Printer, string printCaption, Control.ControlCollection Controls)
        {
            if (Printer == null) return;
            OnBestFitColumns(Controls);
            PrintCaption = printCaption;
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            link.Component = Printer;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(printableComponentLink_CreateReportHeaderArea);
            link.CreateReportFooterArea += new CreateAreaEventHandler(printableComponentLink_CreateReportFooterArea);



            link.Margins.Bottom = link.Margins.Left = link.Margins.Right = link.Margins.Top = 50;

            link.CreateDocument();
            link.ShowPreview();
        }

        #region "Print"  
        // Tiêu đề 
        private static string PrintCaption = string.Empty;
        private static WinControlContainer CopyGridControl(GridControl grid)
        {
            WinControlContainer winContainer = new WinControlContainer();

            winContainer.WinControl = grid;
            return winContainer;
        }
        // ghi tên doanh nghiệp, địa chỉ doanh nghiệp, tên báo cáo mặc định
        private static void printableComponentLink_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string companyName = "CỬA HÀNG BÁN LẺ";
            string address = "Thủ Đức, Hồ Chí Minh";
            RectangleF rec;
            string s = string.Empty;
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            s = string.Format("{0}", companyName);
            e.Graph.Font = new Font("SegoeUI", 12, FontStyle.Bold);
            rec = new RectangleF(5, 0, 400, 20);
            e.Graph.DrawString(s, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
            s = string.Format("{0}", address);
            e.Graph.Font = new Font("SegoeUI", 10, FontStyle.Regular);
            rec = new RectangleF(3, 20, 400, 20);
            e.Graph.DrawString(s, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);

            e.Graph.Font = new Font("SegoeUI", 10, FontStyle.Regular);
            rec = new RectangleF(7, 40, 400, 20);
            e.Graph.DrawString(thoiGian, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
            // ve tieu de

            e.Graph.Font = new Font("Tahoma", 16, FontStyle.Bold);
            rec = new RectangleF(200, 50, 450, 50);
            e.Graph.DrawString(PrintCaption.ToUpper(), Color.BlueViolet, rec, DevExpress.XtraPrinting.BorderSide.None);

        }
        private static void printableComponentLink_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {
            // TODO: sửa lại load từ tham số các thông tin cần thiết

            RectangleF rec;
            string s = string.Empty;

            s = "Nhân viên";
            e.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
            rec = new RectangleF(520, 20, 200, 20);
            e.Graph.BackColor = Color.Transparent;
            e.Graph.DrawString(s, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);

            s = BienToanCuc.TenNguoiDung;
            e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
            rec = new RectangleF(525, 80, 200, 20);
            e.Graph.BackColor = Color.Transparent;
            e.Graph.DrawString(s, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
        }
        private static void OnBestFitColumns(Control.ControlCollection Controls)
        {
            // hú hồn thiệt
            foreach (Control c in Controls)
            {
                if (c is LayoutControl)
                {
                    LayoutControl lc = c as LayoutControl;
                    foreach (BaseLayoutItem bItem in lc.Items)
                    {
                        if (bItem is LayoutControlItem)
                        {
                            LayoutControlItem lItem = bItem as LayoutControlItem;
                            if (lItem.Control != null)
                            {
                                if (lItem.Control is GridControl)
                                {
                                    GridControl g = lItem.Control as GridControl;
                                    GridView w = g.MainView as GridView;
                                    w.OptionsPrint.AutoWidth = true;
                                    w.BestFitColumns();
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ShowAlert(string desc,string title, Form f)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new AlertControl();
            AlertInfo info = new AlertInfo(title, desc);
            alertControl1.AutoFormDelay = 300;
            alertControl1.FormShowingEffect = AlertFormShowingEffect.SlideHorizontal;      
            alertControl1.Show(f, info);
        }
    #endregion

}
}
