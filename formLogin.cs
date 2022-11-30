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
using _19DTHJB1_Long_Phuc_Trung.Models;

namespace _19DTHJB1_Long_Phuc_Trung
{
    public partial class formLogin : Form
    {
        string Con = ("Data Source=NUEHOUJUU;Initial Catalog=testLogin;Integrated Security=true");
        HashEnc he = new HashEnc(); //gọi class để mã hóa
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            txtTDN.Focus();
            txtMK.Focus();
            txtMK.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTDN.Text.Length == 0 && txtMK.Text.Length == 0)
                    MessageBox.Show("Tên Đăng Nhập, Mật Khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtTDN.Text.Length == 0)
                    MessageBox.Show("Tên Đăng Nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtMK.Text.Length == 0)
                    MessageBox.Show("Mật Khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    SqlConnection sql = new SqlConnection(Con); //lấy connection từ sql
                    SqlCommand cmd = new SqlCommand("select * from UserLogins where UserName=@Name and Password=@Pass", sql); //tạo tham số truyền lệnh vào sql

                    cmd.Parameters.AddWithValue("@Name", txtTDN.Text); //lấy giá trị từ textbox
                    cmd.Parameters.AddWithValue("@pass",he.hash(txtMK.Text)); //lấy gía trị từ textbox sau đó de-encrypted 
                    
                    sql.Open();//mở connection với sql lên
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd); //truyền vào sql
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    sql.Close();

                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo");
                        FormMain f = new FormMain();
                        f.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Xin hãy kiểm tra lại\nTên đăng nhập hoặc mật khẩu có thể không tồn tại","Thông báo");
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show("" + exc.Message);
                MessageBox.Show("Đã có lỗi xảy ra", "Thông báo");
            }
        }

        private void txtTDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender,e);
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            formReg f = new formReg();
            f.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
