namespace DACN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_login()
        {
            giaodiches = new HashSet<giaodich>();
        }

        [Key]
        [StringLength(50)]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string matkhau { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giaodich> giaodiches { get; set; }
    }
}
