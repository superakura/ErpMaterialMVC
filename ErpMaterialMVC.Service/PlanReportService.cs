using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpMaterialMVC.Models;
using ErpMaterialMVC.Repository;
using ErpMaterialMVC.Service.ViewModel;

namespace ErpMaterialMVC.Service
{
    public class PlanReportService : Interface.IPlanReportService
    {
        private IGenericRepository<PlanReport> _repo;
        public PlanReportService(IGenericRepository<PlanReport> repo)
        {
            this._repo = repo;
        }

        public PageLayUI<PlanReport> list()
        {
            var planReport = _repo.GetList();
            PageLayUI<PlanReport> pageLayUI = new PageLayUI<PlanReport>();
            pageLayUI.count = planReport.Count();
            pageLayUI.data = planReport.ToList();
            return pageLayUI;
        }

        public PageLayUI<PlanReport> listPage(int page, int limit)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            var planReport = _repo.GetList();
            PageLayUI<PlanReport> pageLayUI = new PageLayUI<PlanReport>();
            pageLayUI.count = planReport.Count();
            pageLayUI.data = planReport.OrderBy(o=>o.PlanReportID).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}
