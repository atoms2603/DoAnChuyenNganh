namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("goi")]
    public partial class goi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public goi()
        {
            usergois = new HashSet<usergoi>();
        }

        [Key]
        [StringLength(10),Display(Name ="Mã gói")]
        [Required(ErrorMessage ="Vui lòng nhập mã gói !")]
        public string magoi { get; set; }

        [StringLength(100), Display(Name = "Tên gói")]
        [Required(ErrorMessage = "Vui lòng nhập tên gói !")]
        public string tengoi { get; set; }

        [Display(Name = "Mô tả gói")]
        public string motagoi { get; set; }

        [Display(Name = "Thời hạn gói")]
        [Required(ErrorMessage = "Vui lòng nhập thời hạn gói !")]
        public int thoihan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usergoi> usergois { get; set; }
    }
}
