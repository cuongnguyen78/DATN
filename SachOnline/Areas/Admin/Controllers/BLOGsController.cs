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
    public class BLOGsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Admin/BLOGs
        public ActionResult Index(string searchString, int? page)
        {
            var blogs = db.BLOGs.Select(p => p);
            if (searchString!=null)
            {
                blogs = blogs.Where(p => p.TenBlog.Contains(searchString));
            }
            blogs = blogs.OrderBy(s => s.MaBlog);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(blogs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/BLOGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // GET: Admin/BLOGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BLOGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBlog,TenBlog,NoiDungBlog")] BLOG bLOG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BLOGs.Add(bLOG);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu !";
                return View(bLOG);
            }
        }

        // GET: Admin/BLOGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: Admin/BLOGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBlog,TenBlog,NoiDungBlog")] BLOG bLOG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bLOG).State = EntityState.Modified;
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu !";
                return View(bLOG);
             
            }
        }

        // GET: Admin/BLOGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: Admin/BLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BLOG bLOG = db.BLOGs.Find(id);
            db.BLOGs.Remove(bLOG);
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
