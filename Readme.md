<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128596503/23.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T190370)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Reporting for ASP.NET MVC - End-User Report Designer and Report Database Storage

This example includes [Web End-User Report Designer](https://docs.devexpress.com/XtraReports/400216/web-reporting/asp-net-mvc-reporting/end-user-report-designer) that uses an SQLite database to store reports. 

The Web Report Designer uses the [ReportStorageWebExtension](https://documentation.devexpress.com/XtraReports/clsDevExpressXtraReportsWebExtensionsReportStorageWebExtensiontopic.aspx) to manage reports.

After you run the application, select a report in the list box. The list box displays the names of the reports stored in the database:

![](Images/report-catalog.png)

Click **Run Designer** to invoke the End-User Report Designer for the selected report. You can edit a report, save it to a database, and exit Designer to return to the report catalog.

![](Images/report-designer.png)

## Files to Review

 - [HomeController.cs](CS/Mvc_DbStorage_Sample/Controllers/HomeController.cs)
 - [CustomReportStorageWebExtension.cs](CS/Mvc_DbStorage_Sample/Services/CustomReportStorageWebExtension.cs) 
 - [ReportEntity.cs](CS/Mvc_DbStorage_Sample/DAL/ReportEntity.cs)
 - [SessionFactory.cs](CS/Mvc_DbStorage_Sample/DAL/SessionFactory.cs)
 - [Global.asax.cs](CS/Mvc_DbStorage_Sample/Global.asax.cs)
 - [DesignModel.cs](CS/Mvc_DbStorage_Sample/Models/DesignModel.cs) 
 - [IndexModel.cs](CS/Mvc_DbStorage_Sample/Models/IndexModel.cs) 
 - [ReportModel.cs](CS/Mvc_DbStorage_Sample/Models/ReportModel.cs) 
 - [Design.cshtml](CS/Mvc_DbStorage_Sample/Views/Home/Designer.cshtml) 
 - [Index.cshtml](CS/Mvc_DbStorage_Sample/Views/Home/Index.cshtml)

 ## Documentation

- [End-User Report Designer in ASP.NET MVC Applications](https://docs.devexpress.com/XtraReports/400216/web-reporting/asp-net-mvc-reporting/end-user-report-designer-in-asp-net-mvc-applications)
- [DevExpress Data Library](https://docs.devexpress.com/CoreLibraries/17541/devexpress-data-library)
- [Add a Report Storage](https://docs.devexpress.com/XtraReports/400204/web-reporting/asp-net-mvc-reporting/end-user-report-designer/add-a-report-storage)

 ## More Examples

 - [How to Implement a Custom Report Storage](https://github.com/DevExpress-Examples/reporting-winforms-custom-report-storage)
 - [Reporting for Web Forms - Report Designer with Report Storage and Custom Command](https://github.com/DevExpress-Examples/reporting-web-forms-designer-storage)
 - [Reporting for WPF - How to Implement a Report Storage](https://github.com/DevExpress-Examples/Reporting_wpf-end-user-report-designer-how-to-implement-a-report-storage-t292945)
<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-mvc-db-storage&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-mvc-db-storage&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

