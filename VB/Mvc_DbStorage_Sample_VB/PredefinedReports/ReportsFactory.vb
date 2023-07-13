Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports DevExpress.XtraReports.UI

Namespace PredefinedReports
    Public Module ReportsFactory
        Public Reports As New Dictionary(Of String, Func(Of XtraReport))() From {
            { "TestReport", Function() New TestReport() }
        }
    End Module
End Namespace
