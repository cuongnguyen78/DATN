using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnline.Buss
{
    public class CartItem
    {
        public static void  add(String id,string sdt)
        {
            DataBase mydb = new DataBase();
            var check = mydb.GioHangs.FirstOrDefault(s => s.MaSP == id && s.SDT==sdt);
            
            if(check ==null )
            {
                GioHang gh = new GioHang();
                gh.MaSP = id;
                gh.SDT = sdt;
                gh.SoLuong = 1;
                mydb.GioHangs.Add(gh);
                mydb.SaveChanges();
            }
            else 
            {
                int soluong = (int)check.SoLuong;
                check.SoLuong = soluong + 1;
                mydb.SaveChanges();
                
            }    
            
        }
    }
}