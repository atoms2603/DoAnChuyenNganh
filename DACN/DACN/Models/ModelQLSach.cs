using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DACN.Models
{
    public partial class ModelQLSach : DbContext
    {
        public ModelQLSach()
            : base("name=ModelQLSach")
        {
        }

        public virtual DbSet<giaodich> giaodiches { get; set; }
        public virtual DbSet<nhaxuatban> nhaxuatbans { get; set; }
        public virtual DbSet<sach> saches { get; set; }
        public virtual DbSet<tacgia> tacgias { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<user_login> user_login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<giaodich>()
                .Property(e => e.magd)
                .IsUnicode(false);

            modelBuilder.Entity<giaodich>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<giaodich>()
                .Property(e => e.masach)
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
                .Property(e => e.maloai)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.matg)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.manhaxuatban)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.phi)
                .HasPrecision(19, 4);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.giaodiches)
                .WithRequired(e => e.sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tacgia>()
                .Property(e => e.matg)
                .IsUnicode(false);

            modelBuilder.Entity<tacgia>()
                .HasMany(e => e.saches)
                .WithRequired(e => e.tacgia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<theloai>()
                .Property(e => e.maloai)
                .IsUnicode(false);

            modelBuilder.Entity<theloai>()
                .HasMany(e => e.saches)
                .WithRequired(e => e.theloai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .HasMany(e => e.giaodiches)
                .WithRequired(e => e.user_login)
                .WillCascadeOnDelete(false);
        }
    }
}
