using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
namespace SachOnline.Controllers
{
    public class SanPhamsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: SanPhams
        public ActionResult Home(int? page)
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMucSanPham).Include(s => s.NhaXuatBan);
            sanPhams = sanPhams.OrderBy(s => s.Gia);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Index(string seachString, int ?page)
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMucSanPham).Include(s => s.NhaXuatBan);
            sanPhams = sanPhams.OrderBy(s => s.Gia);
            {
                if(seachString!=null)
                {
                    sanPhams = sanPhams.Where(p => p.TenSP.Contains(seachString));
                }   
                   
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber,pageSize));
        }
        
          
      
        

        // GET: SanPhams/Details/5
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

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Gia,MoTa,HinhAnh,MaDanhMuc,MaNXB")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan", sanPham.MaNXB);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
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

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Gia,MoTa,HinhAnh,MaDanhMuc,MaNXB")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNhaXuatBan", sanPham.MaNXB);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
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

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
