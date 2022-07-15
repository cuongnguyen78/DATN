

namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SDT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
