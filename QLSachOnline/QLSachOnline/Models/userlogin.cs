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
            giaodiches = new HashSet<giaodich>();
            luusaches = new HashSet<luusach>();
        }

        [Key]
        [StringLength(50),DisplayName("Tài khoản")]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(50), DisplayName("Mật khẩu")]
        public string matkhau { get; set; }

        [StringLength(10), DisplayName("SĐT")]
        public string sdt { get; set; }

        [Required]
        [StringLength(50), DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Trạng thái")]
        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giaodich> giaodiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<luusach> luusaches { get; set; }
    }
}
