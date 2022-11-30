using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    class DG
    {
        Model1 db = new Model1();

        public DG(NguoiMuon dg)
        {
            this.MaDG = dg.MaDG;
            this.TenDG = dg.TenDG;
            this.GioiTinh = dg.GioiTinh;
            this.NgaySinh = dg.NgaySinh;
            this.DiaChi = dg.DiaChi;
        }

        public DG() { }

        public string MaDG { get; set; }

        public string TenDG { get; set; }

        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string DiaChi { get; set; }
    }
}
