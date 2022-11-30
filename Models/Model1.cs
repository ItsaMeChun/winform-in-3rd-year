using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model19")
        {
        }

        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<MuonTraSach> MuonTraSaches { get; set; }
        public virtual DbSet<NguoiMuon> NguoiMuons { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSach>()
                .Property(e => e.MaLoaiSach)
                .IsUnicode(false);

            modelBuilder.Entity<MuonTraSach>()
                .Property(e => e.MaDG)
                .IsUnicode(false);

            modelBuilder.Entity<MuonTraSach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiMuon>()
                .Property(e => e.MaDG)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiMuon>()
                .HasMany(e => e.MuonTraSaches)
                .WithRequired(e => e.NguoiMuon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaLoaiSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTG)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.MuonTraSaches)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.MaTG)
                .IsUnicode(false);
        }
    }
}
