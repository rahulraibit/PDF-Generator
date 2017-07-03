using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using pdfGenerator.Models;
using TemplateViewRenderExample.TemplateHandler;
using NReco.ImageGenerator;

namespace pdfGenerator.Controllers
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
        public ActionResult GetTemplate()
        {
            var chartimage = this.PieChart();
            CertificateTemplet certificate = new CertificateTemplet
            {
                Header = "Certificate",
                Name = "Caliberation",
                PieData = chartimage
            };
            return View(certificate);
        }

        public ActionResult GenerateHtmlToPdf()
        {
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfContentType = "application/pdf";
            var chartimage = this.PieChart();
            //htmlToPdf.CustomWkHtmlArgs = "  --print-media-type ";
            var x = TemplateGenerator.RenderPartialViewToString(this, "GetTemplate", new CertificateTemplet { Header = "Certificate", Name = "Caliberation", PieData = chartimage });
            return File(htmlToPdf.GeneratePdf(x, null), pdfContentType);
        }

        public string PieChart()
        {
            var myChart = new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Chart Title")
                .AddSeries(
                    name: "ChartTitle",
                    chartType: "Pie",
                    xValue: new[] { "Col1", "Col2", "Col3", "Col4", "Col5" },
                    yValues: new[] { "2", "6", "4", "5", "3" });
            var chrtpng = myChart.GetBytes(ImageFormat.Jpeg);
            return Convert.ToBase64String(chrtpng);
        }
    }
}