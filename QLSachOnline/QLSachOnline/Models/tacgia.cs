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
        [StringLength(20),Display(Name ="Mã tác giả")]
        [Required(ErrorMessage ="Vui lòng nhập mã tác giả !")]
        public string matg { get; set; }

        [StringLength(50), Display(Name = "Tên tác giả")]
        [Required(ErrorMessage = "Vui lòng nhập tên tác giả !")]
        public string tentg { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(50), Display(Name = "Quê quán")]
        public string quequan { get; set; }

        [StringLength(20), Display(Name = "Nghệ danh")]
        public string nghedanh { get; set; }
        [Display(Name = "Giới tính")]
        public bool? gioitinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sach> saches { get; set; }

        public string getGioiTinh() { return (bool)gioitinh ? "Nam" : "Nữ"; }
        public string toString()
        {
            return "Mã: " + matg + "</br>Ngày sinh: " + ngaysinh.Value.ToShortDateString() + "</br>Giới tính:" + getGioiTinh() + "</br>Quê quán:" + quequan;
        }
    }
}
