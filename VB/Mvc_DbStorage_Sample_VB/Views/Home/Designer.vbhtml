@ModelType Mvc_DbStorage_Sample_VB.DesignModel

@Code
    ViewBag.Title = "Designer"
End Code

<link rel="stylesheet" type="text/css" href="~/Content/Designer.css" />
<script type="text/javascript">
    function reportDesigner_ExitDesigner(s, e) {
        window.location = '@Url.Action("Index")';
    }
</script>

@Code
    Dim designer = Html.DevExpress().ReportDesigner(Sub(settings)
                                                        settings.Name = "reportDesigner"

                                                        If Not IsNothing(Model.DataSource) Then
                                                            settings.DataSources.Add("Categories", Model.DataSource)
                                                        End If

                                                        settings.ClientSideEvents.ExitDesigner = "reportDesigner_ExitDesigner"
                                                    End Sub)

    If Model.Url IsNot Nothing Then
        designer.BindToUrl(Model.Url).Render()
    Else
        designer.Bind(New XtraReport()).Render()
    End If
End Code
