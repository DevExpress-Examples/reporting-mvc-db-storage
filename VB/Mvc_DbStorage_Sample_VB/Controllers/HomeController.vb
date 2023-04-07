Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.DataAccess.Sql
Imports System.Web.Mvc
Imports DevExpress.Xpo
Imports Mvc_DbStorage_Sample_VB.Services.DAL

Namespace Mvc_DbStorage_Sample.Controllers
	Public Class HomeController
		Inherits Controller

		<HttpGet>
		Public Function Index() As ActionResult
			Using session = SessionFactory.Create()
				Dim reports = session.Query(Of ReportEntity)().Select(Function(x) New ReportModel With {.Url = x.Url}).ToArray()
				Dim firstReport = reports.FirstOrDefault()
				Dim model = New IndexModel With {
					.SelectedReportUrl = If(firstReport IsNot Nothing, firstReport.Url, String.Empty),
					.Reports = reports
				}
				Return View("Index", model)
			End Using
		End Function

		<HttpPost>
		Public Function Delete(ByVal url As String) As ActionResult
			Using session = SessionFactory.Create()
				Dim report = session.GetObjectByKey(Of ReportEntity)(url)
				session.Delete(report)

				session.CommitChanges()
			End Using
			Return Index()
		End Function

		<HttpPost>
		Public Function Design(ByVal url As String) As ActionResult
			Return View("Designer", New DesignModel With {
				.Url = url,
				.DataSource = CreateSqlDataSource()
			})
		End Function

		Private Function CreateSqlDataSource() As SqlDataSource
			Dim ds As New SqlDataSource("NWindConnectionString")
			ds.Name = "NWind"
			Dim categoriesQuery As SelectQuery = SelectQueryFluentBuilder.AddTable("Categories").SelectAllColumns().Build("Categories")
			ds.Queries.Add(categoriesQuery)
			ds.RebuildResultSchema()
			Return ds
		End Function

	End Class
End Namespace
