@ModelType object
@Html.DevExpress().TextBoxFor(Function(m) m, Sub(s)
                              s.Properties.Password = True
                          End Sub).GetHtml()
