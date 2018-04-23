@ModelType DXWebApplication_ReportDesigner.Models.DesignModel

@Code
    ViewBag.Title = "Design"
End Code

<link rel="stylesheet" type="text/css" href="~/Content/Designer.css" />
<script type="text/javascript">
    function reportDesigner_CustomizeMenuActions(s, e) {
        var saveItem = e.Actions.filter(function (x) { return x.text === 'Save' })[0];
        saveItem.text = 'Save&Close';
        saveItem.imageClassName = 'saveCloseAction';
    }

    function reportDesigner_SaveCommandExecuted(s, e) {
        if (e.Result) {
            window.location = '@Url.Action("Index")';
        }        
    };
</script>

@Html.DevExpress().ReportDesigner(Sub(settings)
                                      settings.Name = "reportDesigner"
    
                                      Dim newReportUrl = New With {.Controller = "Designer", .Action = "AddNewReport", .name = Model.NewName}
                                      Dim existReportUrl = New With {.Controller = "Designer", .Action = "UpdateReport", .id = Model.Id}
                                      settings.SaveCallbackRouteValues = If(Model.Id <> 0, existReportUrl, newReportUrl)
    
                                      settings.Height = Unit.Percentage(100)
                                      settings.ControlStyle.CssClass = "fullscreen"
     
                                      settings.ClientSideEvents.CustomizeMenuActions = "reportDesigner_CustomizeMenuActions"
                                      settings.ClientSideEvents.SaveCommandExecuted = "reportDesigner_SaveCommandExecuted"

                                      If Not IsNothing(Model.DataSource) Then
                                          settings.DataSources.Add("Categories", Model.DataSource)
                                      End If
                                           
                                  End Sub).Bind(Model.Report).GetHtml()