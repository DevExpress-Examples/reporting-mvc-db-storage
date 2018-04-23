Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports DevExpress.Xpo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Web.Extensions
Imports DXWebApplication_ReportDesigner.DAL
Imports System.IO


Namespace DXWebApplication_ReportDesigner
	Public Class CustomReportStorageWebExtension
		Inherits ReportStorageWebExtension

		Public Overrides Function CanSetData(ByVal url As String) As Boolean
			' Check if the URL is available in the report storage.
			Using session = SessionFactory.Create()
				Return session.GetObjectByKey(Of ReportEntity)(url) IsNot Nothing
			End Using
		End Function


		Public Overrides Function GetData(ByVal url As String) As Byte()
			' Get the report data from the storage.
			Using session = SessionFactory.Create()
				Dim report = session.GetObjectByKey(Of ReportEntity)(url)
				Return report.Layout
			End Using

		End Function


		Public Overrides Function GetUrls() As Dictionary(Of String, String)
			' Get URLs and display names for all reports available in the storage
			Using session = SessionFactory.Create()
				Return session.Query(Of ReportEntity)().ToDictionary(Function(report) report.Url, Function(report) report.Url)
			End Using
		End Function


		Public Overrides Function IsValidUrl(ByVal url As String) As Boolean
			' Check if the specified URL is valid for the current report storage.
			' In this example, a URL should be a string containing a numeric value that is used as a data row primary key.
			Return True
		End Function


		Public Overrides Sub SetData(ByVal report As XtraReport, ByVal url As String)
			' Write a report to the storage under the specified URL.
			Using session = SessionFactory.Create()
				Dim reportEntity = session.GetObjectByKey(Of ReportEntity)(url)

				Dim ms As New MemoryStream()
				report.SaveLayout(ms)
				reportEntity.Layout = ms.ToArray()

				session.CommitChanges()
			End Using
		End Sub


		Public Overrides Function SetNewData(ByVal report As XtraReport, ByVal defaultUrl As String) As String
			' Save a report to the storage under a new URL. 
			' The defaultUrl parameter contains the report display name specified by a user.
			If CanSetData(defaultUrl) Then
				SetData(report, defaultUrl)
			Else
				Using session = SessionFactory.Create()
					Dim ms As New MemoryStream()
					report.SaveLayout(ms)

					Dim reportEntity = New ReportEntity(session) With {.Url = defaultUrl, .Layout = ms.ToArray()}

					session.CommitChanges()
				End Using
			End If
			Return defaultUrl
		End Function
	End Class
End Namespace