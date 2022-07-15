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
    public class SanPhamAdminsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Admin/SanPhamAdmins
        public ActionResult Index(string searchString, int? page)
        {
            var ac = db.SanPhams.Select(p => p);
            if (searchString != null)
            {
                ac = ac.Where(p => p.TenSP.Contains(searchString));
            }
            ac = ac.OrderBy(s => s.MaSP);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(ac.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhamAdmins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhamAdmins/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan");
            return View();
        }

        // POST: Admin/SanPhamAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Gia,MoTa,HinhAnh,MaDanhMuc,MaNXB")] SanPham sanPham)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.HinhAnh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);

                        string UploadPath = Server.MapPath("~/Assets/images/DanhMucSach/" + FileName);

                        f.SaveAs(UploadPath);
                        sanPham.HinhAnh = FileName;
                    }
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu";
                ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
                ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan", sanPham.MaNXB);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhamAdmins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan", sanPham.MaNXB);
            return View(sanPham);
        }

        // POST: Admin/SanPhamAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Gia,MoTa,HinhAnh,MaDanhMuc,MaNXB")] SanPham sanPham)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.HinhAnh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Assets/images/DanhMucSach/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.HinhAnh = FileName;
                        
                    }
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception EX)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu";
                ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
                ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan", sanPham.MaNXB);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhamAdmins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhamAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);

            try
            {

                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Hiện tại không thế xóa sản phẩm này !";
                return View("Delete", sanPham);
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
