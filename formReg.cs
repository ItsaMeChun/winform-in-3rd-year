using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using _19DTHJB1_Long_Phuc_Trung.Models;

namespace _19DTHJB1_Long_Phuc_Trung
{
    public partial class formReg : Form
    {
        string Con = ("Data Source=NUEHOUJUU;Initial Catalog=testLogin;Integrated Security=true");
        HashEnc he = new HashEnc();
        public formReg()
        {
            InitializeComponent();
            txtMK.PasswordChar = '*';
        }

        private void Clear()
        {
            txtMK.Text = txtTDN.Text = "";
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTDN.Text.Length == 0 && txtMK.Text.Length == 0)
                    MessageBox.Show("Tên Đăng Nhập, Mật Khẩu, Tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtTDN.Text.Length == 0)
                    MessageBox.Show("Tên Đăng Nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtMK.Text.Length == 0)
                    MessageBox.Show("Mật Khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    SqlConnection sql = new SqlConnection(Con); //lấy connection từ sql
                    SqlCommand cmd = new SqlCommand("insert into dbo.UserLogins([UserName],[Password]) values(@name,@pass)",sql);
                    
                    cmd.Parameters.AddWithValue("@name", txtTDN.Text.Trim()); //add vào với giá trị lấy từ txtTDN
                    cmd.Parameters.AddWithValue("@pass", he.hash(txtMK.Text.Trim())); //add vào với giá trị txtMK nhưng được mã hóa bằng SHA1

                    sql.Open(); //mở connection với sql
                    cmd.ExecuteNonQuery(); //tiến hành thực hiện lệnh
                    sql.Close(); //đóng connection với sql
                    //if()
                    MessageBox.Show("Đăng Ký thành công","Thông báo");
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show("" + exc.Message);
                MessageBox.Show("Đã có lỗi xảy ra","Thông báo");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
