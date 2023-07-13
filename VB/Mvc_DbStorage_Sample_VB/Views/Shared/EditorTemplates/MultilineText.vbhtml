@ModelType object
@Html.DevExpress().MemoFor(Function(m) m, Sub(s)
    s.Width = 170
End Sub).GetHtml()
