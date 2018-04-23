Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Q378423.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"

			Return View()
		End Function

		Public Function GridViewPartial() As ActionResult
			Dim model = Enumerable.Range(0, 100).Select(Function(i) New With {Key .ID = i})
			Return PartialView(model)
		End Function

		Public Function DetailGridPartial(ByVal key As String) As ActionResult
			ViewData("key") = key
			Dim model = Enumerable.Range(0, 10).Select(Function(i) New With {Key .SubID = i, Key .link = "http://devexpress.com"})
			Return PartialView(model)
		End Function

		Public Function ShouldSendCallback() As ActionResult
			Dim list = TryCast(Session("detailRows"), List(Of Integer))
			If list Is Nothing Then
				Return Content("false")
			End If
			Return Content((list.Count > 0).ToString())
		End Function
	End Class
End Namespace