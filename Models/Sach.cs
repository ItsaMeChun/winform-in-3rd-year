namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            MuonTraSaches = new HashSet<MuonTraSach>();
        }

        [Key]
        [StringLength(20)]
        public string MaSach { get; set; }

        [StringLength(200)]
        public string TenSach { get; set; }

        [StringLength(20)]
        public string MaLoaiSach { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(20)]
        public string MaTG { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonTraSach> MuonTraSaches { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
