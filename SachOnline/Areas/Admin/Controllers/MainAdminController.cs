using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class MainAdminController : Controller
    {
        // GET: Admin/MainAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}