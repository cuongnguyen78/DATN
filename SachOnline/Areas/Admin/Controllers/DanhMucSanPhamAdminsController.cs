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
    public class DanhMucSanPhamAdminsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Admin/DanhMucSanPhamAdmins
        public ActionResult Index(string searchString, int? page)
        {
            var ac = db.DanhMucSanPhams.Select(p => p);
            if (searchString != null)
            {
                ac = ac.Where(p => p.TenDanhMuc.Contains(searchString));
            }
            ac = ac.OrderBy(s => s.MaDanhMuc);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(ac.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DanhMucSanPhamAdmins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        // GET: Admin/DanhMucSanPhamAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucSanPhamAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMuc,TenDanhMuc")] DanhMucSanPham danhMucSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DanhMucSanPhams.Add(danhMucSanPham);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu !";
                return View(danhMucSanPham);
            }
        }

        // GET: Admin/DanhMucSanPhamAdmins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        // POST: Admin/DanhMucSanPhamAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMuc,TenDanhMuc")] DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucSanPham);
        }

        // GET: Admin/DanhMucSanPhamAdmins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        // POST: Admin/DanhMucSanPhamAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            try
            {
                
                db.DanhMucSanPhams.Remove(danhMucSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Hiện tại không thế xóa danh mục này !";
                return View("Delete", danhMucSanPham);
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
