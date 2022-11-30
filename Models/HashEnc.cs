using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace _19DTHJB1_Long_Phuc_Trung.Models
{
    public class HashEnc
    {
        public string hash(string data)
        {
            SHA1 sha = SHA1.Create(); //tạo object
            byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(data)); //truyền data vào để mã hóa ?
            StringBuilder returnValue = new StringBuilder(); //cái này dùng save cái hashData lại

            for(int i=0; i<hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString()); //copy cái hashData
            }
            return returnValue.ToString();
        }
    }
}
