namespace DACN.Models
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
            giaodiches = new HashSet<giaodich>();
        }

        [Key]
        [StringLength(10)]
        public string masach { get; set; }

        [Required]
        [StringLength(10)]
        public string maloai { get; set; }

        [Required]
        [StringLength(10)]
        public string matg { get; set; }

        [Required]
        [StringLength(10)]
        public string manhaxuatban { get; set; }

        [StringLength(50)]
        public string tensach { get; set; }

        public int? namxuatban { get; set; }

        public int? sochuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? phi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giaodich> giaodiches { get; set; }

        public virtual nhaxuatban nhaxuatban { get; set; }

        public virtual theloai theloai { get; set; }

        public virtual tacgia tacgia { get; set; }
    }
}
