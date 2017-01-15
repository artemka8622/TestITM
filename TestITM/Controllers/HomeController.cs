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
            return View();
        }

        public ActionResult Report2()
        {
            return View();
        }
        public ActionResult Report3()
        {
            return View();
        }

        public ActionResult GetSwitch(string term = "")
        {
            var objCustomerlist = repo.GetItemByName(term).Distinct().ToList();
            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }
    }
}