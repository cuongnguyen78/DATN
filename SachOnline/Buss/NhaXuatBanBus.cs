using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnline.Buss
{
    public class NhaXuatBanBus
    {
        public static IEnumerable<NhaXuatBan> DanhSach() // HÀM TRẢ NHIỀU NHÀ XUẤT BẢN
        {
            DataBase mydb = new DataBase();
            var dm = mydb.NhaXuatBans.Select(p => p);
            return (dm);
        }
    }
}