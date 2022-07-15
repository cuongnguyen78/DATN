using PagedList;
using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public void add()// ADD VÀO HÓA ĐƠN;
        {

            // TẠO HÓA ĐƠN BAN ĐẦU
            DataBase mydb = new DataBase();
            HoaDon hoaDon = new HoaDon();
            hoaDon.NgayTao = DateTime.Now;
            hoaDon.TinhTrang = "Chưa giao hàng";
            hoaDon.SDT = Session["SDT"].ToString();
            mydb.HoaDons.Add(hoaDon);
            mydb.SaveChanges();


            var sohoadon = mydb.HoaDons.Select(p => p);  // LẤY RA SỐ HÓA ĐƠN
            int ma = sohoadon.Count();
            // CHÈN HÓA SẢN PHẨM VÀO CHI TIẾT HÓA ĐƠN
            var q = from m in mydb.GioHangs
                     select m;


            // THEM VÀO ĐƠN HÀNG
            foreach (var item in q)
            {
                if (item.SDT == Session["SDT"].ToString())
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.MAHD = ma;
                    ct.MaSP = item.MaSP;
                    ct.SoLuong = (int)item.SoLuong;
                    mydb.ChiTietHoaDons.Add(ct);
                   
                }
            }
            mydb.SaveChanges();

            foreach (var item in q)
            {
                if(item.SDT== Session["SDT"].ToString())
                {
                    mydb.GioHangs.Remove(item);
                }
            }
            mydb.SaveChanges();

        }
        public ActionResult Index()
        {
            add();
            return View();
        }

        public ActionResult XemDonHang(int page = 1, int pagesize = 10)
        {
            DataBase mydb = new DataBase();
            string sdt = Session["SDT"].ToString();
            var hd = mydb.HoaDons.Select(p => p);
            hd = hd.OrderBy(p => p.MAHD);
            hd = hd.Where(s => s.SDT == sdt);
            return View(hd.ToPagedList(page, pagesize));
        }
        public ActionResult XemChiTietDonHang(int id,int page = 1, int pagesize = 10)
        {
            DataBase mydb = new DataBase();
            var hd = mydb.ChiTietHoaDons.Select(p => p);
            hd = hd.OrderBy(p => p.MaSP);
            hd = hd.Where(s => s.MAHD == id);
            Session["DonHang"] = id;
            var check = mydb.HoaDons.Where(p => p.MAHD == id).FirstOrDefault();
            Session["TinhTrang"] = check.TinhTrang;
            Session["TenKH"] = check.KhachHang.TenKH;
            Session["SDT"] = check.KhachHang.SDT;
            Session["DiaChi"] = check.KhachHang.DiaChi;
            Session["NgayTao"] = check.NgayTao;
            return View(hd.ToPagedList(page, pagesize));
        }

    }
}