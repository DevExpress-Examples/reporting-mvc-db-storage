<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>DevExpress ASP.NET project</title>

@Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors },
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report }
)
@Html.DevExpress().GetScripts(
        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        New Script With {.ExtensionSuite = ExtensionSuite.Editors },
        New Script With {.ExtensionSuite = ExtensionSuite.Report }
)
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
</head>

<body>
    <div class="content-wrapper">
        <div class="header">
            <h1>DevExpress ASP.NET project</h1>
        </div>

        <div class="content">
            @RenderBody()
        </div>

        <div class="footer">
            <p>&copy; @DateTime.Now.Year - DevExpress ASP.NET project copyright</p>
        </div>
    </div>
</body>
</html>
