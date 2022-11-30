namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiMuon")]
    public partial class NguoiMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiMuon()
        {
            MuonTraSaches = new HashSet<MuonTraSach>();
        }

        [Key]
        [StringLength(20)]
        public string MaDG { get; set; }

        [StringLength(200)]
        public string TenDG { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonTraSach> MuonTraSaches { get; set; }
    }
}
