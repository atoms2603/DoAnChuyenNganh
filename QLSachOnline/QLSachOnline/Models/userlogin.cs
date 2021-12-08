namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userlogin")]
    public partial class userlogin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userlogin()
        {
            luusaches = new HashSet<luusach>();
            usergois = new HashSet<usergoi>();
        }

        [Key]
        [StringLength(50),DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản !")]
        public string taikhoan { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập mật khẩu !")]
        [StringLength(50), DisplayName("Mật khẩu")]
        public string matkhau { get; set; }

        [StringLength(10), DisplayName("SĐT")]
        public string sdt { get; set; }

        //[Required(ErrorMessage ="Vui lòng nhập Email !")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập Email hợp lệ !")]
        [RegularExpression("^[_A-Za-z'`+-.]+([_A-Za-z0-9'+-.]+)*@([A-Za-z0-9-])+(\\.[A-Za-z0-9]+)*(\\.([A-Za-z]*){3,})$", ErrorMessage = "Vui lòng nhập Email hợp lệ !")]
        [StringLength(50), DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Trạng thái")]
        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usergoi> usergois { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<luusach> luusaches { get; set; }
    }
}
