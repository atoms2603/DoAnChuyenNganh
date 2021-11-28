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
            giaodiches = new HashSet<giaodich>();
            luusaches = new HashSet<luusach>();
            tacgias = new HashSet<tacgia>();
            theloais = new HashSet<theloai>();
        }

        [Key]
        [StringLength(10)]
        public string masach { get; set; }

        [Required]
        [StringLength(10)]
        public string manhaxuatban { get; set; }

        [StringLength(50)]
        public string tensach { get; set; }

        public int? namxuatban { get; set; }

        [StringLength(200)]
        public string hinhanh { get; set; }

        [StringLength(1)]
        public string tomtat { get; set; }

        [Column(TypeName = "money")]
        public decimal? phi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuong> chuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giaodich> giaodiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<luusach> luusaches { get; set; }

        public virtual nhaxuatban nhaxuatban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tacgia> tacgias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<theloai> theloais { get; set; }
    }
}
