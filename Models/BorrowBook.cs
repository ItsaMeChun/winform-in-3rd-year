using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    class BorrowBook
    {
        Model1 db = new Model1();

        public BorrowBook(MuonTraSach borrow)
        {
            this.MaPhieuMuon = borrow.MaPhieuMuon;
            this.MaDG = borrow.MaDG;
            this.MaSach = borrow.MaSach;
            this.NgayMuon = borrow.NgayMuon;
            this.NgayHenTra = borrow.NgayHenTra;
            this.NgayTra = borrow.NgayTra;
        }
       
        public BorrowBook() {}

        public int MaPhieuMuon { get; set; }

        public string MaDG { get; set; }

        public string MaSach { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? NgayMuon { get; set; }

        public DateTime? NgayHenTra { get; set; }

        public DateTime? NgayTra { get; set; }
    }
}
