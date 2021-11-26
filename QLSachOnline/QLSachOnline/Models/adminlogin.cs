namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adminlogin")]
    public partial class adminlogin
    {
        [Key]
        [StringLength(50)]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string matkhau { get; set; }
    }
}
