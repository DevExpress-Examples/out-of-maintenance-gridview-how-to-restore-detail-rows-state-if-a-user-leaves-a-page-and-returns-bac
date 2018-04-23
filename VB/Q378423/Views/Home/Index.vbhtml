@Code
    ViewBag.Title = "Home Page"
End Code

<script type="text/javascript">
    function OnInit(s, e) {
        $.ajax({
            type: "GET",
            dataType: "text",
            url: '@Url.Action("ShouldSendCallback", "Home")',
            success: function (sendCallback) {
                if (sendCallback)
                    GridView.PerformCallback();
            }
        });
        }
</script>

@Html.Action("GridViewPartial")