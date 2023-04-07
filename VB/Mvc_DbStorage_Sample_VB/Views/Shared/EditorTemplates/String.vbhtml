@ModelType Object
@Code
    Dim tModel As Type = ViewData.ModelMetadata.ContainerType.GetProperty(ViewData.ModelMetadata.PropertyName).PropertyType
    
    If GetType(System.String).IsAssignableFrom(tModel) Then
    @Html.DevExpress().TextBoxFor(Function(m) m).GetHtml()
    ElseIf GetType(System.Enum).IsAssignableFrom(tModel) Then
    @Html.DevExpress().ComboBoxFor(Function(m) m, Sub(s)
                                    s.Properties.Items.AddRange(System.Enum.GetValues(tModel))
                                    s.SelectedIndex = 0
                                    s.Properties.DropDownStyle = DropDownStyle.DropDownList
                                End Sub).GetHtml()
End If
End Code
