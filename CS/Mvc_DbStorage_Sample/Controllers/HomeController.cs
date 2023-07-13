using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.DataAccess.Sql;
using Mvc_DbStorage_Sample.Services.DAL;
using System.Web.Mvc;
using DevExpress.Xpo;

namespace Mvc_DbStorage_Sample.Controllers {
    public class HomeController : Controller {
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
            return View("Designer", new DesignModel { Url = url, DataSource = CreateSqlDataSource() });
        }

        SqlDataSource CreateSqlDataSource() {
            SqlDataSource ds = new SqlDataSource("NWindConnectionString");
            ds.Name = "NWind";
            SelectQuery categoriesQuery = SelectQueryFluentBuilder.AddTable("Categories").SelectAllColumns().Build("Categories");
            ds.Queries.Add(categoriesQuery);
            ds.RebuildResultSchema();
            return ds;
        }

    }
}
