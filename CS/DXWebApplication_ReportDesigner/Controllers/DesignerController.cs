using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Xpo;
using DevExpress.Web.Mvc;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;
using DXWebApplication_ReportDesigner.DAL;
using DXWebApplication_ReportDesigner.Models;
using DevExpress.DataAccess.Sql;

namespace DXWebApplication_ReportDesigner.Controllers {
    public class DesignerController : Controller {
        [HttpGet]
        public ActionResult Index() {
            using (var session = SessionFactory.Create()) {
                var reports = session.Query<ReportEntity>()
                    .Select(x => new ReportModel {
                        Url = x.Url
                    })
                    .ToArray();
                var firstReport = reports.FirstOrDefault();
                var model = new IndexModel {
                    SelectedReportUrl = firstReport != null ? firstReport.Url : String.Empty,
                    Reports = reports
                };
                return View("Index", model);
            }
        }

        [HttpPost]
        public ActionResult Delete(string url) {
            using (var session = SessionFactory.Create()) {
                var report = session.GetObjectByKey<ReportEntity>(url);
                session.Delete(report);

                session.CommitChanges();
            }
            return Index();
        }       

        [HttpPost]
        public ActionResult Design(string url) {            
            return View("Design", new DesignModel { Url = url, DataSource = CreateSqlDataSource() });
        }

        SqlDataSource CreateSqlDataSource() {
            SqlDataSource ds = new SqlDataSource("nwindConnectionString");
            ds.Name = "NWind";
            ds.Queries.Add(new CustomSqlQuery("Categories", "SELECT * FROM [Categories]"));
            ds.RebuildResultSchema();
            return ds;
        }

    }
}
