' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
        
Imports DevExpress.Web.Mvc
Imports Mvc_DbStorage_Sample_VB.Services

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions
        DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.Default
        DevExpress.XtraReports.Web.QueryBuilder.Native.QueryBuilderBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.Default
        DevExpress.XtraReports.Web.ReportDesigner.Native.ReportDesignerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.Default
        DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(New CustomReportStorageWebExtension())
        System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocol Or System.Net.SecurityProtocolType.Tls12
        MVCxReportDesigner.StaticInitialize()
        DevExpress.XtraReports.Web.ClientControls.LoggerService.Initialize(Sub(ex, message)
                                                                               System.Diagnostics.Debug.WriteLine("[{0}]: Exception occurred. Message: '{1}'. Exception Details:\r\n{2}", DateTime.Now, message, ex)
                                                                           End Sub)
        AreaRegistration.RegisterAllAreas()
   
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        
        ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder()

        AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error
    End Sub

    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim exception As Exception = System.Web.HttpContext.Current.Server.GetLastError()
        'TODO: Handle Exception
    End Sub
End Class
