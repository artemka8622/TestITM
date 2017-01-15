using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store;

namespace TestITM.Controllers
{
    public class BaseController : Controller
    {
        public AutoConnector connector { get; set; } = ConnectionFactory.GetConnector();
    }
}