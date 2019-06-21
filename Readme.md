# GridView - How to restore detail rows' state if a user leaves a page and returns back
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4840)**
<!-- run online end -->


<p>This example demonstrates how to restore state of grid detail rows if the user leaves a page and then returns back.</p>
<p>To accomplish this task, perform the following:</p>
<p>1) Disable the page's cache as it is described in the <a href="https://www.devexpress.com/Support/Center/p/KA18692">Why controls do not work properly when clicking browser Back / Forward buttons</a> article.</p>
<p>2) Handle the grid's <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_DetailRowExpandedChangedtopic">DetailRowExpandedChanged</a> event to save the expanded state. The session is used in this example.</p>


```cs
settings.DetailRowExpandedChanged = (s, e) => {
	if (e.Expanded)
		rows.Add(e.VisibleIndex);
	else
		rows.Remove(e.VisibleIndex);
};
```


<p>3) Handle the grid's client-side Init event to send a get request to the server to see if it is necessary to expand rows.</p>


```js
function OnInit(s, e) {    
	$.ajax({        
		type: "GET",        
		dataType: "text",        
		url: '@Url.Action("ShouldSendCallback", "Home")',        
		success: function (sendCallback) {            
			if (sendCallback)                
				GridView.PerformCallback();        }    
		});
}
```


<p>4) Handle the grid's BeforeGetCallbackResult event to expand detail rows during the callback if necessary.</p>


```cs
settings.BeforeGetCallbackResult = (s, e) => {     
	var grid = s as MVCxGridView;    
	if (rows.Count != grid.DetailRows.VisibleCount) {        
		foreach (int item in rows) {            
			grid.DetailRows.ExpandRow(item);                        
		}        
		grid.PageIndex = Convert.ToInt32(Session["curPage"]);    
	}    
	Session["curPage"] = grid.PageIndex;
};
```



<br/>


