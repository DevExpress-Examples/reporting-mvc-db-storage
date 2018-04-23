# How to integrate the Web Report Designer into an MVC web application


This example demonstrates how you can integrate the <strong>Web Report Designer</strong> into your web application. The application contains a simple report catalog, allowing you to add, delete, and edit reports whose layout data is stored in a custom data storage (i.e., an MS SQL database).
<p> </p>
<p>Additionally, this example demonstrates how you can add custom commands to the report designer menu at runtime to provide better integration with your application. In the example, the custom <strong>Save&Close</strong> menu command is introduced, which redirects you to the catalog page after saving the report.</p>
<p> <br><strong>Important note:</strong> Starting with version <strong>15.2,</strong> the <a href="https://documentation.devexpress.com/XtraReports/clsDevExpressXtraReportsWebExtensionsReportStorageWebExtensiontopic.aspx">ReportStorageWebExtension</a> is used to manage the reports storage for the Web Report Designer instead of the controller actions. </p>

<br/>


