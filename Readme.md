<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T190370)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[DesignerController.cs](./CS/DXWebApplication_ReportDesigner/Controllers/DesignerController.cs) (VB: [DesignerController.vb](./VB/DXWebApplication_ReportDesigner/Controllers/DesignerController.vb))**
* [ReportEntity.cs](./CS/DXWebApplication_ReportDesigner/DAL/ReportEntity.cs) (VB: [ReportEntity.vb](./VB/DXWebApplication_ReportDesigner/DAL/ReportEntity.vb))
* [SessionFactory.cs](./CS/DXWebApplication_ReportDesigner/DAL/SessionFactory.cs) (VB: [SessionFactory.vb](./VB/DXWebApplication_ReportDesigner/DAL/SessionFactory.vb))
* [DesignModel.cs](./CS/DXWebApplication_ReportDesigner/Models/DesignModel.cs) (VB: [DesignModel.vb](./VB/DXWebApplication_ReportDesigner/Models/DesignModel.vb))
* [IndexModel.cs](./CS/DXWebApplication_ReportDesigner/Models/IndexModel.cs) (VB: [IndexModel.vb](./VB/DXWebApplication_ReportDesigner/Models/IndexModel.vb))
* [ReportModel.cs](./CS/DXWebApplication_ReportDesigner/Models/ReportModel.cs) (VB: [ReportModel.vb](./VB/DXWebApplication_ReportDesigner/Models/ReportModel.vb))
* [Design.cshtml](./CS/DXWebApplication_ReportDesigner/Views/Designer/Design.cshtml)
* [Index.cshtml](./CS/DXWebApplication_ReportDesigner/Views/Designer/Index.cshtml)
<!-- default file list end -->
# How to integrate the Web Report Designer into an MVC web application


This example demonstrates how you can integrate the <strong>Web Report Designer</strong> into your web application. The application contains a simple report catalog, allowing you to add, delete, and edit reports whose layout data is stored in a custom data storage (i.e., an MS SQL database).
<p> </p>
<p>Additionally, this example demonstrates how you can add custom commands to the report designer menu at runtime to provide better integration with your application. In the example, the custom <strong>Save&Close</strong> menu command is introduced, which redirects you to the catalog page after saving the report.</p>
<p> <br><strong>Important note:</strong> Starting with version <strong>15.2,</strong> the <a href="https://documentation.devexpress.com/XtraReports/clsDevExpressXtraReportsWebExtensionsReportStorageWebExtensiontopic.aspx">ReportStorageWebExtension</a> is used to manage the reports storage for the Web Report Designer instead of the controller actions. </p>

<br/>


