namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("theloai")]
    public partial class theloai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public theloai()
        {
            saches = new HashSet<sach>();
        }

        [Key]
        [StringLength(10),Display(Name ="Mã thể loại")]
        [Required(ErrorMessage ="Vui lòng nhập mã thể loại !")]
        public string maloai { get; set; }

        [StringLength(50), Display(Name = "Tên thể loại")]
        [Required(ErrorMessage = "Vui lòng nhập tên thể loại !")]
        public string tentl { get; set; }

        [StringLength(200), Display(Name = "Ghi chú")]
        public string ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sach> saches { get; set; }
    }
}
