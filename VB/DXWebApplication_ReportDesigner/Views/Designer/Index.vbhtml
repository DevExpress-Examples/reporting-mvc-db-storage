@ModelType DXWebApplication_ReportDesigner.Models.IndexModel

@Code
    ViewBag.Title = "Index"
End Code

<link rel="stylesheet" type="text/css" href="~/Content/Index.css" />

<h2>Report Catalog</h2>

@Using Html.BeginForm()
    ViewContext.Writer.Write("<span>Use the form below to manage reports in the catalog.</span>")
    @Html.DevExpress().ListBoxFor(Function(x) x.SelectedReportId, Sub(settings)
                                                                      settings.Name = "Id"
        
                                                                      settings.Properties.TextField = "Name"
                                                                      settings.Properties.ValueField = "Id"
                                                                      settings.Properties.ValueType = GetType(Integer)
            
                                                                      settings.ControlStyle.CssClass = "reports"
                                                                      settings.Width = 600
                                                                  End Sub).BindList(Model.Reports).GetHtml()

    @Html.DevExpress().Button(Sub(settings)
                                  settings.Name = "EditReportButton"
                                  settings.RouteValues = New With {.Controller = "Designer", .Action = "Edit"}
                                  settings.UseSubmitBehavior = True

                                  settings.Text = "Edit"
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
    

<hr />

@Using Html.BeginForm()
    @Html.DevExpress().Button(Sub(settings)
                                  settings.Name = "AddReportButton"
                                  settings.RouteValues = New With {.Controller = "Designer", .Action = "Add"}
                                  settings.UseSubmitBehavior = True

                                  settings.Text = "New Report"
                                  settings.Width = 100
                                  settings.ControlStyle.CssClass = "left buttonSeparator"
                              End Sub).GetHtml()

    @Html.DevExpress().TextBox(Sub(settings)
                                   settings.Name = "Name"
    
                                   settings.Properties.Caption = "New Report ID"
                                   settings.ControlStyle.CssClass = "left"
                                   settings.Width = 404
                                   settings.Height = 25
                               End Sub).GetHtml()
End Using
    