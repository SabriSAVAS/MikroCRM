using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.Controllers
{
    public class CalendarController : BaseController
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult GetEvent()
        {
            var data = _cleanderservice.GetList().AsEnumerable().Select(x => new
            {
                title = x.Title,
                start = x.Start.ToString("yyyy/MM/dd"),
                end = x.End.ToString("yyyy/MM/dd"),
                backgroundColor = "#f56954",
            }).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}