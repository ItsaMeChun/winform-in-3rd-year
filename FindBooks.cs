using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19DTHJB1_Long_Phuc_Trung.Models;

namespace _19DTHJB1_Long_Phuc_Trung
{
    public partial class FindBooks : Form
    {
        Model1 db = new Model1();
        List<Book> objBooks = new List<Book>();
        private BindingSource binding_sources = new BindingSource(); //binding source
        public FindBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)//chưa suy nghĩ xong
        {
            int i = 0;
            if(btnTimKiem.Text == "Tìm Kiếm")
            {
                if (txtTimSach.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTimSach.Focus();
                }
                else
                {
                    if (radMasach.Checked == false && radTensach.Checked == false)//nếu không check gì cả
                    {
                        MessageBox.Show("Vui lòng lựa chọn tìm kiếm theo mã sách hoặc tên sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            btnTimKiem.Text = "Thử lại";
                            txtTimSach.Enabled = false;
                            string s = txtTimSach.Text.ToString().Trim();   //đặt cái chữ vừa nhập thành string và cắt bỏ mấy thứ như khoảng cách
                            if (radMasach.Checked == true) //chọn mã sách
                            {
                                Sach bk = db.Saches.Find(s); //tìm trong database
                                txtMaSach.Text = bk.MaSach;
                                txtTenSach.Text = bk.TenSach;
                                txtSoLuong.Text = bk.SoLuong.ToString();
                                txtMaTacGia.Text = bk.MaTG;
                                txtMaLoai.Text = bk.MaLoaiSach;
                                i++;
                            }
                            if (radTensach.Checked == true) //chọn tên sách
                            {
                                foreach (var n in db.Saches)
                                {
                                    if (n.TenSach == s) //nếu cái chuỗi nhập bằng với cái trong database
                                    {
                                        txtMaSach.Text = n.MaSach;
                                        txtTenSach.Text = n.TenSach;
                                        txtSoLuong.Text = n.SoLuong.ToString();
                                        txtMaTacGia.Text = n.MaTG;
                                        txtMaLoai.Text = n.MaLoaiSach;
                                        i++;
                                    }
                                }//end foreach
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra trong quá trình tìm kiếm sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    if(i!=0) //nếu tìm thấy thông tin sách
                        lblTTTimKiem.Text = "Thông tin về sách:  " + txtTimSach.Text;
                    else //không tìm thấy
                        lblTTTimKiem.Text = "Không tìm thấy sách này trong thông tin sách";
                }
            }
            else
            {
                btnTimKiem.Text = "Tìm Kiếm";
                txtTimSach.Enabled = true;
                txtTimSach.Text = "";
                txtTimSach.Focus();

                txtMaSach.Text = "";
                txtTenSach.Text = "";
                txtSoLuong.Text = "";
                txtMaTacGia.Text = "";
                txtMaLoai.Text = "";
                lblTTTimKiem.Text = "";
            }
        }
    }
}
