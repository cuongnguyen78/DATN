namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountAdmin")]
    public partial class AccountAdmin
    {
        [Key]
        [StringLength(50)]
        public string MaTK { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Quyen { get; set; }
    }
}
