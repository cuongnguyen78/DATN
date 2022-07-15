using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Buss
{
    public class DanhMucSanPhamBus
    {
        // CỦA KHÁCH HÀNG
        
        public static IEnumerable<DanhMucSanPham> DanhSach() // HÀM TRẢ NHIỀU DANH MỤC SẢN PHẨM
        {
            DataBase mydb = new DataBase();
            var dm = mydb.DanhMucSanPhams.Select(p => p);
            return (dm);
            
        }
    }
}