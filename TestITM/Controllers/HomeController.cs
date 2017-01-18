using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Repository;
using Store.Model;
using TestITM.Helper;
using TestITM.Models;

namespace TestITM.Controllers
{
    public class HomeController : BaseController
    {
        SwitchRepository repo { get; set; } = new SwitchRepository();
        public ActionResult Index()
        {
            var model =  new SwitchViewModel();
            return View(model);
        }

        public ActionResult Report1()
        {
            var model = new ReportViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Report1(ReportViewModel vm)
        {
            vm.StausViewModels = repo.GetReport1(vm.SearchViewModel.From, vm.SearchViewModel.To).Select(t => new StausViewModel()
            { SwitchName = t.Switch.Name, DateTime = t.DateTime, ActionSwitch = t.ActionSwitch }).ToList();
            return View(vm);
        }

        public ActionResult Report2()
        {
            var model = new ReportViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Report2(ReportViewModel vm)
        {
            vm.StausViewModels = repo.GetReport2(vm.SearchViewModel.From, vm.SearchViewModel.To).Where(t => t.SwitchId == vm.SearchViewModel.SwitchId
                                                                                || vm.SearchViewModel.SwitchId == Guid.Empty)
                                .Select(t => new StausViewModel()
                                { SwitchName = t.Switch.Name, DateTime = t.DateTime, ActionSwitch = t.ActionSwitch, WorkTime = t.WorkTime })
                                .ToList();
            return View(vm);
        }

        public ActionResult Report3()
        {
            var model = new ReportViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Report3(ReportViewModel vm)
        {
            vm.StausViewModels = repo.GetReport3(vm.SearchViewModel.From,vm.SearchViewModel.To).Select(t => new StausViewModel()
            { SwitchName = t.Switch.Name, WorkTime = t.WorkTime, ActionSwitch = t.ActionSwitch}).ToList();
            return View(vm);
        }

        public ActionResult GetSwitch(string term = "")
        {
            var objCustomerlist = repo.GetItemByName(term).Distinct().ToList();
            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Switch(Guid id)
        {
            var res = repo.Switch(id);
            return new JsonResult() { Data = new { result = "Коммутатор - " + res.GetDescription()}};
        }
    }
}