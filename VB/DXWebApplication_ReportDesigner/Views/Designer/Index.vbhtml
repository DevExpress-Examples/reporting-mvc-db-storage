@ModelType DXWebApplication_ReportDesigner.Models.IndexModel

@Code
    ViewBag.Title = "Index"
End Code

<link rel="stylesheet" type="text/css" href="~/Content/Index.css" />

<h2>Report Catalog</h2>

@Using Html.BeginForm()
    ViewContext.Writer.Write("<span>Use the form below to manage reports in the catalog.</span>")
    @Html.DevExpress().ListBoxFor(Function(x) x.SelectedReportUrl, Sub(settings)
                                                                       settings.Name = "Url"

                                                                       settings.Properties.TextField = "Url"
                                                                       settings.Properties.ValueField = "Url"
                                                                       settings.Properties.ValueType = GetType(String)
            
                                                                       settings.ControlStyle.CssClass = "reports"
                                                                       settings.Width = 600
                                                                   End Sub).BindList(Model.Reports).GetHtml()

    @Html.DevExpress().Button(Sub(settings)
                                  settings.Name = "EditReportButton"
                                  settings.RouteValues = New With {.Controller = "Designer", .Action = "Design"}
                                  settings.UseSubmitBehavior = True

                                  settings.Text = "Run Designer"
                                  settings.ControlStyle.CssClass = "buttonSeparator"
                                  settings.Width = 100
                              End Sub).GetHtml()

    @Html.DevExpress().Button(Sub(settings)
                                  settings.Name = "DeleteReportButton"
                                  settings.RouteValues = New With {.Controller = "Designer", .Action = "Delete"}
                                  settings.UseSubmitBehavior = True

                                  settings.Text = "Delete"
                                  settings.Width = 100
                              End Sub).GetHtml()
End Using