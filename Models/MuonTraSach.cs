namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuonTraSach")]
    public partial class MuonTraSach
    {
        [Key]
        public int MaPhieuMuon { get; set; }

        [Required]
        [StringLength(20)]
        public string MaDG { get; set; }

        [Required]
        [StringLength(20)]
        public string MaSach { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHenTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual NguoiMuon NguoiMuon { get; set; }
    }
}
