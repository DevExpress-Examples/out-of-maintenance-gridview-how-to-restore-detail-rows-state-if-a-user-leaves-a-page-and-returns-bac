using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q378423.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View();
        }

        public ActionResult GridViewPartial() {
            var model = Enumerable.Range(0, 100).Select(i => new { ID = i});
            return PartialView(model);
        }

        public ActionResult DetailGridPartial(string key) {
            ViewData["key"] = key;
            var model = Enumerable.Range(0, 10).Select(i => new { SubID = i, link = "http://devexpress.com"});
            return PartialView(model);
        }

        public ActionResult ShouldSendCallback() {
            var list = Session["detailRows"] as List<int>;
            if (list == null)
                return Content("false");
            return Content((list.Count > 0).ToString());
        }
    }
}