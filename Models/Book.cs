using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    class Book
    {
        Model1 db = new Model1();

        public Book(Sach book)
        {
            this.MaSach = book.MaSach;
            this.TenSach = book.TenSach;
            this.MaLoaiSach = book.MaLoaiSach;
            this.SoLuong = book.SoLuong;
            this.MaTG = book.MaTG;
        }

        public Book() { }

        public string MaSach { get; set; }

        public string TenSach { get; set; }

        public string MaLoaiSach { get; set; }

        public int? SoLuong { get; set; }

        public string MaTG { get; set; }
    }
}
