using ErpMaterialMVC.Models;
using ErpMaterialMVC.Service.Interface;
using ErpMaterialMVC.Service.ViewModel;
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

        private IPlanReportService _servicePlanReport;
        public PlanReportController(IPlanReportService servicePlanReport)
        {
            _servicePlanReport = servicePlanReport;
        }

        public JsonResult GetList()
        {
            var skip = Request.QueryString["page"] == "1" ? 0 : (Convert.ToInt32(Request.QueryString["page"]) - 1) * Convert.ToInt32(Request.QueryString["limit"]);
            var take = Convert.ToInt32(Request.QueryString["limit"]);

            List<PlanReport> planReport = new List<PlanReport>();
            for (int i = 1; i <= 100; i++)
            {
                planReport.Add(new PlanReport
                {
                    MaterialCode = ("编码" + i)
                    ,
                    MaterialDesc = "描述" + i
                    ,
                    MaterialCount = i
                    ,
                    PlanReportDept = "部门 " + i
                    ,
                    PlanReportPerson = "人员 " + i
                    ,
                    MaterialAge = "账龄" + i
                });
            }
            PageLayUI<PlanReport> pageLayUI = new PageLayUI<PlanReport>();
            pageLayUI.count = planReport.Count;
            pageLayUI.data = planReport.Skip(skip).Take(take).ToList();

            return Json(pageLayUI);
        }

        public JsonResult ListPage()
        {
            var page = 0;
            int.TryParse(Request.QueryString["page"], out page);
            var limit = 0;
            int.TryParse(Request.QueryString["limit"], out limit);

            return Json(_servicePlanReport.listPage(page, limit), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAll()
        {
            return Json(_servicePlanReport.list(),JsonRequestBehavior.AllowGet);
        }
    }
}