namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("luusach")]
    public partial class luusach
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string masach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string taikhoan { get; set; }

        public DateTime? ngayluu { get; set; }

        public virtual sach sach { get; set; }

        public virtual userlogin userlogin { get; set; }
    }
}
