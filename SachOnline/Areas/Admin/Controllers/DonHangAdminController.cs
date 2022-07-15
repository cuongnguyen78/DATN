using PagedList;
using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class DonHangAdminController : Controller
    {
        // GET: Admin/DonHangAdmin
        public ActionResult Index(string searchString, int? page)
        { 
            DataBase db = new DataBase();
            var dh = db.HoaDons.Select(p => p);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            try
            {
                int mahd = Convert.ToInt32(searchString);
                if (searchString != null)
                {
                    dh = dh.Where(p => p.MAHD == (mahd));
                }
                dh = dh.OrderByDescending(s => s.MAHD);

                return View(dh.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception)
            {
                dh = dh.OrderBy(s => s.MAHD);
                return View(dh.ToPagedList(pageNumber, pageSize));
            }

        }
        public ActionResult XemChiTietDonHang(int id, int page = 1, int pagesize = 10)
        {
            DataBase mydb = new DataBase();
            var hd = mydb.ChiTietHoaDons.Select(p => p);
            var check = mydb.HoaDons.Where(p => p.MAHD==id).FirstOrDefault();
            Session["TinhTrang"] = check.TinhTrang;
            Session["NgayTao"] = check.NgayTao;
            Session["TenKH"] = check.KhachHang.TenKH;
            Session["SDT"] = check.KhachHang.SDT;
            Session["DiaChi"] = check.KhachHang.DiaChi;
            //var checkTaiKhoan = mydb.AccountAdmins.FirstOrDefault(s => s.MaTK == id.ToString());
            //Session["Ten"] = checkTaiKhoan.Ten;
            hd = hd.OrderBy(p => p.MaSP);
            hd = hd.Where(s => s.MAHD == id);
            Session["DonHang"] = id;
            return View(hd.ToPagedList(page, pagesize));
        }
        public ActionResult HuyDonHang(int id)
        {
            DataBase mydb = new DataBase();
            var check = mydb.HoaDons.FirstOrDefault(s => s.MAHD == id);
            //var checkTaiKhoan = mydb.AccountAdmins.FirstOrDefault(s => s.MaTK == id.ToString());
            //Session["Ten"] = checkTaiKhoan.Ten;
            check.TinhTrang = "Đã bị hủy";
            mydb.SaveChanges();
            return RedirectToAction("Index","DonHangAdmin");
        }
        public ActionResult CungCapDonHang(int id)
        {
            DataBase mydb = new DataBase();
            var check = mydb.HoaDons.FirstOrDefault(s => s.MAHD == id);
            //var checkTaiKhoan = mydb.AccountAdmins.FirstOrDefault(s => s.MaTK == id.ToString());
            //Session["Ten"] = checkTaiKhoan.Ten;
            check.TinhTrang = "Đã giao hàng";
            mydb.SaveChanges();
            return RedirectToAction("Index", "DonHangAdmin");
        }

    }
}