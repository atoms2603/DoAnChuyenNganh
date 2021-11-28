namespace QLSachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tacgia")]
    public partial class tacgia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tacgia()
        {
            saches = new HashSet<sach>();
        }

        [Key]
        [StringLength(20)]
        public string matg { get; set; }

        [StringLength(50)]
        public string tentg { get; set; }

        public DateTime? ngaysinh { get; set; }

        [StringLength(50)]
        public string quequan { get; set; }

        [StringLength(20)]
        public string nghedanh { get; set; }

        public bool? gioitinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sach> saches { get; set; }
    }
}
