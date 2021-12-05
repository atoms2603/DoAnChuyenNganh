namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhaxuatban")]
    public partial class nhaxuatban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhaxuatban()
        {
            saches = new HashSet<sach>();
        }

        [Key]
        [StringLength(10),Display(Name ="Mã nhà xuất bản")]
        [Required(ErrorMessage ="Vui lòng nhập mã !")]
        public string manhaxuatban { get; set; }

        [StringLength(50), Display(Name = "Tên nhà xuất bản")]
        [Required(ErrorMessage = "Vui lòng nhập tên !")]
        public string tennhaxuatban { get; set; }

        [StringLength(50), Display(Name = "Địa chỉ")]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sach> saches { get; set; }
    }
}
