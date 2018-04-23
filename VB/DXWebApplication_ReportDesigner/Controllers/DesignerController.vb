Imports System.IO
Imports System.Linq
Imports System.Web.Mvc
Imports DevExpress.Xpo
Imports DevExpress.Web.Mvc
Imports DevExpress.XtraReports.Native
Imports DevExpress.XtraReports.UI
Imports DXWebApplication_ReportDesigner.DAL
Imports DXWebApplication_ReportDesigner.Models
Imports DevExpress.DataAccess.Sql

Namespace DXWebApplication_ReportDesigner.Controllers
	Public Class DesignerController
		Inherits Controller

		<HttpGet>
		Public Function Index() As ActionResult
			Using session = SessionFactory.Create()
				Dim reports = session.Query(Of ReportEntity)().Select(Function(x) New ReportModel With {.Id = x.Oid, .Name = x.Name}).ToArray()
				Dim firstReport = reports.FirstOrDefault()
				Dim model = New IndexModel With {.SelectedReportId = If(firstReport IsNot Nothing, firstReport.Id, 0), .Reports = reports}
				Return View(model)
			End Using
		End Function

		<HttpPost>
		Public Function Delete(ByVal id As Integer) As ActionResult
			Using session = SessionFactory.Create()
				Dim report = session.GetObjectByKey(Of ReportEntity)(id)
				session.Delete(report)

				session.CommitChanges()

				session.CommitChanges()
			End Using
			Return RedirectToAction("Index")
		End Function

		<HttpPost>
		Public Function Add(ByVal name As String) As ActionResult
			Return View("Design", New DesignModel With {.NewName = name, .Report = GetNewReport(), .DataSource = CreateSqlDataSource()})
		End Function

		<HttpPost>
		Public Function Edit(ByVal id As Integer) As ActionResult
			Using session = SessionFactory.Create()
				Dim reportEntity = session.GetObjectByKey(Of ReportEntity)(id)
				Using stream = New MemoryStream(reportEntity.Layout)
					Dim report = XtraReport.FromStream(stream, True)
					Return View("Design", New DesignModel With {.Id = id, .Report = report})
				End Using
			End Using
		End Function

		<HttpPost>
		Public Function AddNewReport(ByVal name As String) As JsonResult
			Dim layout = ReportDesignerExtension.GetReportXml("reportDesigner")
			Using session = SessionFactory.Create()
				Dim reportEntity = New ReportEntity(session) With {.Name = name, .Layout = layout}

				session.CommitChanges()

				Return Json(reportEntity.Oid)
			End Using
		End Function

		<HttpPost>
		Public Function UpdateReport(ByVal id As Integer) As JsonResult
			Dim layout = ReportDesignerExtension.GetReportXml("reportDesigner")
			Using session = SessionFactory.Create()
				Dim reportEntity = session.GetObjectByKey(Of ReportEntity)(id)
				reportEntity.Layout = layout

				session.CommitChanges()

				Return Json(reportEntity.Oid)
			End Using
		End Function

		Private Function GetNewReport() As XtraReport
			Return New XtraReport()
		End Function

		Private Function CreateSqlDataSource() As SqlDataSource
			Dim ds As New SqlDataSource("nwindConnectionString")
			ds.Name = "NWind"
			ds.Queries.Add(New CustomSqlQuery("Categories", "SELECT * FROM [Categories]"))
			ds.RebuildResultSchema()
			Return ds
		End Function

	End Class
End Namespace
