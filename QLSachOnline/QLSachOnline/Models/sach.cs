namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sach")]
    public partial class sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sach()
        {
            chuongs = new HashSet<chuong>();
            luusaches = new HashSet<luusach>();
            tacgias = new HashSet<tacgia>();
            theloais = new HashSet<theloai>();
        }

        [Key]
        [StringLength(10), Display(Name = "Mã sách")]
        [Required(ErrorMessage = "Vui lòng nhập mã sách !")]
        public string masach { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã nhà xuất bản !")]
        [StringLength(10), Display(Name = "Mã nhà xuất bản")]
        public string manhaxuatban { get; set; }

        [StringLength(50), Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Vui lòng nhập tên sách !")]
        public string tensach { get; set; }
        [Display(Name = "Năm xuất bản")]
        [Required(ErrorMessage = "Vui lòng nhập năm xuất bản !")]
        public int? namxuatban { get; set; }

        [StringLength(200), Display(Name = "Hình ảnh")]
        public string hinhanh { get; set; }

        [Display(Name = "Tóm tắt")]
        public string tomtat { get; set; }

        [Display(Name = "Premium")]
        public bool premium { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuong> chuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<luusach> luusaches { get; set; }

        public virtual nhaxuatban nhaxuatban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tacgia> tacgias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<theloai> theloais { get; set; }
    }
}
