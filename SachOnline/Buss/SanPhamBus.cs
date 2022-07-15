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
    public class SanPhamBus
    {
        public static IEnumerable<SanPham> DanhSachLay3() // HÀM TRẢ NHIỀU SẢN PHẨM
        {
            DataBase mydb = new DataBase();
            var dm = mydb.SanPhams.Select(p => p).Take(3);
            return (dm);
        }
    }
}