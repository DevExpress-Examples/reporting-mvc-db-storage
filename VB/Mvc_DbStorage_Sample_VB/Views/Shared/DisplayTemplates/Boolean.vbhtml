@ModelType Boolean?
@Html.DevExpress().CheckBoxFor(Function(m) m, Sub(s)
                                  s.ReadOnly = True
                              End Sub).GetHtml()
