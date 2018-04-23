@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "GridView" + ViewData("key")
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "DetailGridPartial", .key = ViewData("key")}

            settings.SettingsDetail.MasterGridName = "GridView"

            settings.KeyFieldName = "SubID"

            settings.Columns.Add("SubID")
            settings.Columns.Add(Sub(c)
                                         c.FieldName = "link"
                                         c.ColumnType = MVCxGridViewColumnType.HyperLink
                                 End Sub)
    End Sub).Bind(Model).GetHtml()