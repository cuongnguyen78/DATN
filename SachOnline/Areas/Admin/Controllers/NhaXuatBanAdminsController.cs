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
    public class NhaXuatBanAdminsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Admin/NhaXuatBanAdmins
        public ActionResult Index(string searchString, int? page)
        {
            var ac = db.NhaXuatBans.Select(p => p);
            if (searchString != null)
            {
                ac = ac.Where(p => p.TenNhaXuatBan.Contains(searchString));
            }
            ac = ac.OrderBy(s => s.MaNXB);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(ac.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/NhaXuatBanAdmins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }
            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBanAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaXuatBanAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNXB,TenNhaXuatBan")] NhaXuatBan nhaXuatBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NhaXuatBans.Add(nhaXuatBan);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                ViewBag.Error = "Lỗi nhập dữ liệu !";
                return View(nhaXuatBan);
            }
        }

        // GET: Admin/NhaXuatBanAdmins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: Admin/NhaXuatBanAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNXB,TenNhaXuatBan")] NhaXuatBan nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaXuatBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBanAdmins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: Admin/NhaXuatBanAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);

            try
            {

                db.NhaXuatBans.Remove(nhaXuatBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Hiện tại không thế xóa nhà xuất bản này !";
                return View("Delete", nhaXuatBan);
            }
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
