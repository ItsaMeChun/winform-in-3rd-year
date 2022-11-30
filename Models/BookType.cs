using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    class BookType
    {
        Model1 db = new Model1();

        public BookType(LoaiSach bt)
        {
            this.MaLoaiSach = bt.MaLoaiSach;
            this.TenLoai = bt.TenLoai;
            this.KieuSach = bt.KieuSach;
        }

        public BookType() { }

        public string MaLoaiSach { get; set; }

        public string TenLoai { get; set; }

        public string KieuSach { get; set; }
    }
}
