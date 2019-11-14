using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErpMaterialMVC.Web.Controllers
{
    public class PlanReportController : Controller
    {
        // GET: PlanReport
        public ActionResult List()
        {
            return View();
        }

        public JsonResult ListPage()
        {
            try
            {
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}