using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLSachOnline.Models
{
    public partial class QLySachOnline : DbContext
    {
        public QLySachOnline()
            : base("name=QLySachOnline")
        {
        }

        public virtual DbSet<adminlogin> adminlogins { get; set; }
        public virtual DbSet<chuong> chuongs { get; set; }
        public virtual DbSet<goi> gois { get; set; }
        public virtual DbSet<luusach> luusaches { get; set; }
        public virtual DbSet<nhaxuatban> nhaxuatbans { get; set; }
        public virtual DbSet<sach> saches { get; set; }
        public virtual DbSet<tacgia> tacgias { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<usergoi> usergois { get; set; }
        public virtual DbSet<userlogin> userlogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adminlogin>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<adminlogin>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<chuong>()
                .Property(e => e.machuong)
                .IsUnicode(false);

            modelBuilder.Entity<chuong>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<goi>()
                .Property(e => e.magoi)
                .IsUnicode(false);

            modelBuilder.Entity<goi>()
                .Property(e => e.tengoi)
                .IsUnicode(false);

            modelBuilder.Entity<goi>()
                .Property(e => e.gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<goi>()
                .HasMany(e => e.usergois)
                .WithRequired(e => e.goi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<luusach>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<luusach>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<nhaxuatban>()
                .Property(e => e.manhaxuatban)
                .IsUnicode(false);

            modelBuilder.Entity<nhaxuatban>()
                .HasMany(e => e.saches)
                .WithRequired(e => e.nhaxuatban)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.manhaxuatban)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.chuongs)
                .WithRequired(e => e.sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.luusaches)
                .WithRequired(e => e.sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.tacgias)
                .WithMany(e => e.saches)
                .Map(m => m.ToTable("tacgiasach").MapLeftKey("masach").MapRightKey("matg"));

            modelBuilder.Entity<sach>()
                .HasMany(e => e.theloais)
                .WithMany(e => e.saches)
                .Map(m => m.ToTable("theloaisach").MapLeftKey("masach").MapRightKey("maloai"));

            modelBuilder.Entity<tacgia>()
                .Property(e => e.matg)
                .IsUnicode(false);

            modelBuilder.Entity<theloai>()
                .Property(e => e.maloai)
                .IsUnicode(false);

            modelBuilder.Entity<usergoi>()
                .Property(e => e.magoi)
                .IsUnicode(false);

            modelBuilder.Entity<usergoi>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<userlogin>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<userlogin>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<userlogin>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<userlogin>()
                .HasMany(e => e.luusaches)
                .WithRequired(e => e.userlogin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<userlogin>()
                .HasMany(e => e.usergois)
                .WithRequired(e => e.userlogin)
                .WillCascadeOnDelete(false);
        }
    }
}
