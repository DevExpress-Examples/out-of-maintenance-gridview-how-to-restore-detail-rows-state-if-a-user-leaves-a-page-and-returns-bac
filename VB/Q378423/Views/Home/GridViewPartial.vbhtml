@Functions
    Public Property rows() As List(Of Integer)
        Get
            If Session("detailRows") Is Nothing Then
                Session("detailRows") = New List(Of Integer)()
            End If
            Return TryCast(Session("detailRows"), List(Of Integer))
        End Get
        Set(ByVal value As List(Of Integer))
            Session("detailRows") = value
        End Set
    End Property
End Functions


@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "GridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.KeyFieldName = "ID"
            settings.SettingsDetail.ShowDetailRow = True

            settings.Columns.Add("ID")

            settings.SetDetailRowTemplateContent(
                Sub(c)
                        Html.RenderAction("DetailGridPartial", New With {Key .key = c.KeyValue})
                End Sub)

            settings.BeforeGetCallbackResult =
                Sub(s, e)
                        Dim grid As MVCxGridView = TryCast(s, MVCxGridView)
                        If rows.Count <> grid.DetailRows.VisibleCount Then
                            For Each item As Integer In rows
                                grid.DetailRows.ExpandRow(item)
                            Next item
                            grid.PageIndex = Convert.ToInt32(Session("curPage"))
                        End If
                        Session("curPage") = grid.PageIndex
                End Sub

            settings.DetailRowExpandedChanged =
                Sub(s, e)
                        If (e.Expanded) Then
                            rows.Add(e.VisibleIndex)
                        Else
                            rows.Remove(e.VisibleIndex)
                        End If
                End Sub

            settings.ClientSideEvents.Init = "OnInit"
    
    End Sub).Bind(Model).GetHtml()