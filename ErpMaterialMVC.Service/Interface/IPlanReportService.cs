using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterialMVC.Models;
using ErpMaterialMVC.Service.ViewModel;

namespace ErpMaterialMVC.Service.Interface
{
    public interface IPlanReportService
    {
        PageLayUI<PlanReport> list();
        PageLayUI<PlanReport> listPage(int page, int limit);
    }
}
