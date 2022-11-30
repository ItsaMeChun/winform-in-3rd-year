using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    class Artist
    {
        Model1 db = new Model1();

       
        public Artist(TacGia tg)
        {
            this.MaTG = tg.MaTG;
            this.TenTG = tg.TenTG;
        }

        public Artist() { }

        public string MaTG { get; set; }

        public string TenTG { get; set; }
    }
}
