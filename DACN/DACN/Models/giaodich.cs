namespace DACN.Models
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
        [StringLength(10)]
        public string magd { get; set; }

        [Required]
        [StringLength(50)]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(10)]
        public string masach { get; set; }

        public virtual sach sach { get; set; }

        public virtual user_login user_login { get; set; }
    }
}
