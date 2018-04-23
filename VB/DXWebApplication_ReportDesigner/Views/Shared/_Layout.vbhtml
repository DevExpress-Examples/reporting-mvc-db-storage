<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>

    @Html.DevExpress().GetStyleSheets(
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report}
)
    @Html.DevExpress().GetScripts(
    New Script With {.ExtensionSuite = ExtensionSuite.Editors},
    New Script With {.ExtensionSuite = ExtensionSuite.Report}
)
</head>

<body>
    @RenderBody()
</body>
</html>
