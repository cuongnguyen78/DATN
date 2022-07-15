using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhapThanhCong()
        {
            return View();
        }

        // methed login
        [HttpPost]
        public ActionResult Authen(AccountAdmin tk)
        {
            DataBase mydb = new DataBase();
            var check = mydb.AccountAdmins.Where(p => p.MaTK.Equals(tk.MaTK) && p.MatKhau.Equals(tk.MatKhau)).FirstOrDefault();
            if (check == null)
            {
                ViewBag.Error = "Đăng nhập không thành công";
                return View("Index", tk);
            }
            else
            {
                Session["MATK"] = tk.MaTK;
                Session["Ten"] = check.Ten;
                Session["Quyen"] = check.Quyen;
                if(Session["Quyen"].ToString().Equals("ADMIN"))
                {
                    return RedirectToAction("Index", "AccountAdmins");
                }    
                else
                {
                    return RedirectToAction("Index", "BLOGs");
                }    
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginAdmin");
        }
    }
}