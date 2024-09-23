using RoutingURL.Models;
using RoutingURL.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingURL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ExportProductReport()
        {
            ProductsReport rpt = new ProductsReport();
            rpt.Load();
            Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        public ActionResult ShowOrderList()
        {
            OrderSubreport rpt = new OrderSubreport();
            rpt.Load();
            Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
    }
}