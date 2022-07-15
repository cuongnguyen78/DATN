namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BLOG")]
    public partial class BLOG
    {
        [Key]
        [StringLength(50)]
        public string MaBlog { get; set; }

        [Column(TypeName = "ntext")]
        public string TenBlog { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungBlog { get; set; }
    }
}
