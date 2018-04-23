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
                        Id = x.Oid,
                        Name = x.Name
                    })
                    .ToArray();
                var firstReport = reports.FirstOrDefault();
                var model = new IndexModel {
                    SelectedReportId = firstReport != null ? firstReport.Id : 0,
                    Reports = reports
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id) {
            using (var session = SessionFactory.Create()) {
                var report = session.GetObjectByKey<ReportEntity>(id);
                session.Delete(report);

                session.CommitChanges();

                session.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(string name) {
            return View("Design", new DesignModel {
                NewName = name,
                Report = GetNewReport(),
                DataSource = CreateSqlDataSource()
            });
        }

        [HttpPost]
        public ActionResult Edit(int id) {
            using (var session = SessionFactory.Create()) {
                var reportEntity = session.GetObjectByKey<ReportEntity>(id);
                using (var stream = new MemoryStream(reportEntity.Layout)) {
                    var report = XtraReport.FromStream(stream, true);
                    return View("Design", new DesignModel { Id = id, Report = report });
                }
            }
        }

        [HttpPost]
        public JsonResult AddNewReport(string name) {
            var layout = ReportDesignerExtension.GetReportXml("reportDesigner");
            using (var session = SessionFactory.Create()) {
                var reportEntity = new ReportEntity(session) {
                    Name = name,
                    Layout = layout
                };
                                
                session.CommitChanges();

                return Json(reportEntity.Oid);
            }
        }

        [HttpPost]
        public JsonResult UpdateReport(int id) {
            var layout = ReportDesignerExtension.GetReportXml("reportDesigner");
            using (var session = SessionFactory.Create()) {
                var reportEntity = session.GetObjectByKey<ReportEntity>(id);
                reportEntity.Layout = layout;

                session.CommitChanges();

                return Json(reportEntity.Oid);
            }
        }

        XtraReport GetNewReport() {
            return new XtraReport();
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
