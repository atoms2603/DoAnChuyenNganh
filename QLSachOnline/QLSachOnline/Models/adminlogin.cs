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
        [StringLength(50),Display(Name ="Tài khoản")]
        [Required(ErrorMessage ="Tài khoản trống ! Vui lòng nhập tài khoản")]
        public string taikhoan { get; set; }

        [StringLength(50),Display(Name ="Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu trống ! Vui lòng nhập mật khẩu")]
        public string matkhau { get; set; }
    }
}
