namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? Gia { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDanhMuc { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }
    }
}
