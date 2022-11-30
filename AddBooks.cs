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
    public partial class AddBooks : Form
    {
        Model1 db = new Model1();
        List<Book> objBooks = new List<Book>();
        private BindingSource binding_sources = new BindingSource(); //binding source
        public AddBooks()
        {
            InitializeComponent();
        }

        private void napVaodgv()
        {
            var list_Book = from book in db.Saches
                            select new
                            {
                                MaSach = book.MaSach,
                                TenSach = book.TenSach,
                                LoaiSach = book.MaLoaiSach,
                                SoLuong = book.SoLuong,
                                TacGia = book.MaTG
                            };
            foreach (var item in list_Book)
            {
                Book book = new Book();
                book.MaSach = item.MaSach;
                book.TenSach = item.TenSach;
                book.MaLoaiSach = item.LoaiSach;
                book.SoLuong = item.SoLuong;
                book.MaTG = item.TacGia;
                objBooks.Add(book);
            }
            binding_sources.DataSource = objBooks;
            dataGridView1.DataSource = binding_sources;
        }

        private void setButton()
        {
            btnThemSach.Text = "Thêm";
            txtMaLoai.Text = "";
            txtMaSach.Text = "";
            txtMaTG.Text = "";
            txtSoLuong.Text = "";
            txtTenSach.Text = "";
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            dataGridView1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            setButton();
            napVaodgv();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaSach.Text = dataGridView1.CurrentRow.Cells["colMaSach"].Value.ToString();
            txtTenSach.Text = dataGridView1.CurrentRow.Cells["colTenSach"].Value.ToString();
            txtMaLoai.Text = dataGridView1.CurrentRow.Cells["colMaLoai"].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells["colSoLuong"].Value.ToString();
            txtMaTG.Text = dataGridView1.CurrentRow.Cells["colTacGia"].Value.ToString();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (btnThemSach.Text == "Thêm")
            {
                btnThemSach.Text = "Hủy";
                txtMaLoai.Text = "";
                txtMaSach.Text = "";
                txtMaTG.Text = "";
                txtSoLuong.Text = "";
                txtTenSach.Text = "";
                txtMaSach.Focus();
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                dataGridView1.Enabled = false;
            }
            else
            {
                setButton();
            }
        }

        public void luuSach()
        {
            try
            {
                Sach book = new Sach();
                book.MaSach = txtMaSach.Text;
                book.TenSach = txtTenSach.Text;
                book.MaLoaiSach = txtMaLoai.Text;
                book.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                book.MaTG = txtMaTG.Text;

                Book b = new Book(book);
                binding_sources.Add(b);

                db.Saches.Add(book);
                db.SaveChanges();

                napVaodgv();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong việc lưu dữ liệu", "Thông báo");
            }
        }

        private void suaSach()
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    Sach sach = db.Saches.Find(dataGridView1.SelectedCells[0].Value);
                    Book b = new Book(sach);
                    if (b.MaSach == txtMaSach.Text
                        && b.TenSach == txtTenSach.Text
                        && b.MaLoaiSach == txtMaLoai.Text
                        && b.MaTG == txtMaTG.Text
                        && b.SoLuong == Convert.ToInt32(txtSoLuong.Text))
                        MessageBox.Show("Xin hãy chỉnh sửa thông tin sách", "Thông báo");
                    else
                    {
                        db.Saches.Remove(sach);
                        binding_sources.RemoveAt(item.Index);
                        luuSach();
                    }
                }
                napVaodgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong việc sửa dữ liệu", "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã Sách!", "Thông báo");
                txtMaSach.Focus();
            }
            else if (txtTenSach.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tên Sách!", "Thông báo");
                txtTenSach.Focus();
            }
            else if (txtMaLoai.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã Loại Sách!", "Thông báo");
                txtMaLoai.Focus();
            }
            else if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập Số lượng!", "Thông báo");
                txtSoLuong.Focus();
            }
            else if (txtMaTG.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã Tác Giả!", "Thông báo");
                txtMaTG.Focus();
            }
            else
            {
                if (btnSua.Text == "Sửa")
                    luuSach();
                else
                    suaSach();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (btnSua.Text == "Sửa")
                {
                    btnSua.Text = "Hủy";
                    txtMaSach.ReadOnly = true;
                    btnThemSach.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = true;
                    txtMaSach.Focus();
                }
                else
                {
                    btnSua.Text = "Sửa";
                    txtMaSach.ReadOnly = false;
                    btnThemSach.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn dữ liệu cần sửa!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult dl = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                        {
                            Sach book = db.Saches.Find(dataGridView1.SelectedCells[0].Value);
                            db.Saches.Remove(book);
                            binding_sources.RemoveAt(item.Index);
                        }
                        db.SaveChanges();
                    }
                }
                else
                    MessageBox.Show("Hãy chọn dữ liệu cần xóa!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra trong quá trình xóa dữ liệu!", "Thông báo");
            }
        }
    }
}
