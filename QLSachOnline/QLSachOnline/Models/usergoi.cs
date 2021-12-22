namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usergoi")]
    public partial class usergoi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string magoi { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string taikhoan { get; set; }

        public DateTime ngaymua { get; set; }

        public DateTime ngayhethan { get; set; }

        public virtual goi goi { get; set; }

        public virtual userlogin userlogin { get; set; }
    }
}
