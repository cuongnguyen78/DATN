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

namespace SachOnline.Areas.Admin.Controllers
{
    public class AccountAdminsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Admin/AccountAdmins
        public ActionResult Index(string searchString, int? page)
        {
            var ac = db.AccountAdmins.Select(p => p);
            if (searchString != null)
            {
                ac = ac.Where(p => p.MaTK.Contains(searchString));
            }
            ac = ac.OrderBy(s => s.MaTK);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(ac.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/AccountAdmins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            if (accountAdmin == null)
            {
                return HttpNotFound();
            }
            return View(accountAdmin);
        }

        // GET: Admin/AccountAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTK,MatKhau,Ten,SDT,Quyen")] AccountAdmin accountAdmin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AccountAdmins.Add(accountAdmin);
                    db.SaveChanges();
                    
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu !";
                return View(accountAdmin);

            }
        }

        // GET: Admin/AccountAdmins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            if (accountAdmin == null)
            {
                return HttpNotFound();
            }
            return View(accountAdmin);
        }

        // POST: Admin/AccountAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTK,MatKhau,Ten,SDT,Quyen")] AccountAdmin accountAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountAdmin);
        }

        // GET: Admin/AccountAdmins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            if (accountAdmin == null)
            {
                return HttpNotFound();
            }
            return View(accountAdmin);
        }

        // POST: Admin/AccountAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            db.AccountAdmins.Remove(accountAdmin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
