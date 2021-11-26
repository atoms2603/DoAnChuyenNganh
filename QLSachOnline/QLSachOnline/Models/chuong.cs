namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chuong")]
    public partial class chuong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string machuong { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string masach { get; set; }

        [StringLength(100)]
        public string tenchuong { get; set; }

        [StringLength(100)]
        public string noidung { get; set; }

        public virtual sach sach { get; set; }
    }
}
