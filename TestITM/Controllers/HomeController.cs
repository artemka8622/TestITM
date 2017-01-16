using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Repository;
using Store.Model;
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

        public ActionResult Report2()
        {
            var model = new ReportViewModel();
            return View(model);
        }
        public ActionResult Report3()
        {
            var model = new ReportViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Report3(ReportViewModel vm)
        {
            var model = new ReportViewModel();
            return View(model);
        }

        public ActionResult GetSwitch(string term = "")
        {
            var objCustomerlist = repo.GetItemByName(term).Distinct().ToList();
            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }
    }
}