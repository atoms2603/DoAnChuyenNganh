namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("giaodich")]
    public partial class giaodich
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10),Display(Name ="Mã giao dịch")]
        public string magd { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50), Display(Name = "Tài khoản")]
        public string taikhoan { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10), Display(Name = "Mã sách")]
        public string masach { get; set; }
        [Display(Name = "Ngày giao dịch")]
        public DateTime? ngaygiaodich { get; set; }

        public virtual sach sach { get; set; }

        public virtual userlogin userlogin { get; set; }
    }
}
