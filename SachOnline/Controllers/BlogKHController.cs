using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SachOnline.Models;
namespace SachOnline.Controllers
{
    
    public class BlogKHController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            DataBase mydb = new DataBase();
            var blog = mydb.BLOGs.Select(p => p);
            return View(blog);
        }
    }
}