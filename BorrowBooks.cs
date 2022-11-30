using _19DTHJB1_Long_Phuc_Trung.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _19DTHJB1_Long_Phuc_Trung
{
    public partial class BorrowBooks : Form
    {
        Model1 db = new Model1();
        List<BorrowBook> objBorrow = new List<BorrowBook>();
        //List<BorrowBook> objReturn = new List<BorrowBook>();
        private BindingSource binding_sources = new BindingSource(); //binding source

        public BorrowBooks()
        {
            InitializeComponent();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BorrowBooks_Load(object sender, EventArgs e)
        {
            dtNgayMuon.Value = System.DateTime.Now;
            napVaodgvMuonSach();
            //napVaodgvTraSach();
            loadComboBox();
            loadComboBoxTraSach();
        }

        private void loadComboBox()
        {
            cbMaDG.DataSource = db.NguoiMuons.ToList();
            cbMaDG.DisplayMember = "MaDG";
            cbMaDG.ValueMember = "MaDG";

            cbChonMaSach.DataSource = db.Saches.ToList();
            cbChonMaSach.ValueMember = "MaSach";
            cbChonMaSach.DisplayMember = "MaSach"; 
        }

        private void loadComboBoxTraSach()
        {
            cbMaDG_TraSach.DataSource = db.MuonTraSaches.ToList();
            cbMaDG_TraSach.DisplayMember = "MaDG";
            cbMaDG_TraSach.ValueMember = "MaPhieuMuon";
        }

        private void napVaodgvMuonSach()
        {
            dataGridView1.DataBindings.Clear();
            var list_MuonSach = from muon in db.MuonTraSaches
                                select new
                                {
                                    MaPM = muon.MaPhieuMuon,
                                    MaDG = muon.MaDG,
                                    MaSach = muon.MaSach,
                                    SoLuong = muon.SoLuong,
                                    NgayMuon = muon.NgayMuon,
                                    NgayHenTra = muon.NgayHenTra,
                                    NgayTra = muon.NgayTra
                                };
            foreach (var item in list_MuonSach)
            {
                BorrowBook bk = new BorrowBook();
                bk.MaPhieuMuon = item.MaPM;
                bk.MaDG = item.MaDG;
                bk.MaSach = item.MaSach;
                bk.SoLuong = item.SoLuong;
                bk.NgayMuon = item.NgayMuon;
                bk.NgayHenTra = item.NgayHenTra;
                bk.NgayTra = item.NgayTra;
                objBorrow.Add(bk);
            }
            binding_sources.DataSource = objBorrow;
            dataGridView1.DataSource = binding_sources;
            dataGridView2.DataSource = binding_sources;
            dataGridView1.Columns["MaPhieuMuon"].Visible = false; //ẩn cột mã phiếu mượn trong dgv mượn sách 
            dataGridView1.Columns["NgayTra"].Visible = false; // như trên nhưng cột ngày trả (chỉ hiển thị ở bảng trả)
            dataGridView2.Columns["MaPhieuMuon"].Visible = false;
        }

        /*private void napVaodgvTraSach()
        {
            var list_TraSach = from tra in db.MuonTraSaches
                               select new
                               {
                                   MaPM = tra.MaPhieuMuon,
                                   MaDG = tra.MaDG,
                                   MaSach = tra.MaSach,
                                   SoLuong = tra.SoLuong,
                                   NgayMuon = tra.NgayMuon,
                                   NgayHenTra = tra.NgayHenTra,
                                   NgayTra = tra.NgayTra
                               };
            foreach (var item in list_TraSach)
            {
                BorrowBook bk = new BorrowBook();
                bk.MaPhieuMuon = item.MaPM;
                bk.MaDG = item.MaDG;
                bk.MaSach = item.MaSach;
                bk.SoLuong = item.SoLuong;
                bk.NgayMuon = item.NgayMuon;
                bk.NgayHenTra = item.NgayHenTra;
                bk.NgayTra = item.NgayTra;
                objReturn.Add(bk);
            }
            binding_sources.DataSource = objReturn;
            dataGridView2.DataSource = binding_sources;
        }*/

        private void btnMuonMoi_Click(object sender, EventArgs e)
        {
            dtNgayMuon.Value = System.DateTime.Now;
            cbMaDG.Text = "";
            txtMaSach.Text = "";
            dtNgayMuon.Text = "";
            dtNgayHenTra.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            /*if(txtMaSach.Text == "")
            {
                MessageBox.Show("Chưa nhập mã sách!");
                txtMaSach.Focus();
            }*/
            int a = Convert.ToInt32(txtSoLuong.Text.Trim());
            int b = (int)db.Saches.Find(cbChonMaSach.Text).SoLuong;
            //MessageBox.Show("" + a+"\n"+b);
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng sách cho mượn!");
                txtSoLuong.Focus();
            }
            else if (b == 0) //kiểm tra xem sách trong kho còn hay không
                MessageBox.Show("Sách trong kho đã hết", "Thông báo");
            else if ((b-a) < 0) //Kiểm tra số lượng mượn với sách trong kho, nếu mượn nhiều hơn trong kho thì không được phép mượn
                MessageBox.Show("Sách trong kho không đủ để thực hiện việc cho mượn", "Thông báo");
            else
            {
                try
                {
                    MuonTraSach book = new MuonTraSach();
                    book.MaDG = cbMaDG.Text;
                    book.MaSach = cbChonMaSach.Text;
                    book.SoLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
                    db.Saches.Find(cbChonMaSach.Text).SoLuong -= Convert.ToInt32(txtSoLuong.Text.Trim()); //lấy số lượng hiện tại trừ số lượng mượn
                    book.NgayMuon = dtNgayMuon.Value;
                    book.NgayHenTra = dtNgayHenTra.Value;
                    db.MuonTraSaches.Add(book);
                    db.SaveChanges();                  
                    
                    //db.MuonTraSaches.Find().MaPhieuMuon; //nếu không add binding_sources thì cái dgv không lự load lại
                    //binding_sources.Add(book); //tại sao binding source lại bị null ? t nghĩ là do mã phiếu mượn được tạo tự động nên nó không lấy ra được
                    //napVaodgvMuonSach();
                    MessageBox.Show("Đã cho mượn thành công!");
                }
                catch (Exception exc)
                {
                    //MessageBox.Show("" + exc.Message);
                    MessageBox.Show("Mã sách " + txtMaSach.Text + " không có trong kho sách!\nHãy nhập mã sách khác!","Thông báo");
                    napVaodgvMuonSach();
                    txtMaSach.Focus();
                }
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            DateTime ngayhentra = dtNgayHenTra_TraSach.Value;
            DateTime ngaytra = dtNgayTra.Value;
            if (ngaytra <= ngayhentra)
            {
                lblTinhTrangTraSach.Text = "Đúng hạn";
            }
            else
            {
                lblTinhTrangTraSach.Text = "Quá hạn";
            }
            updateTraSach();
        }

        private void updateTraSach()//Update lại phiếu mượn đã có chứ không phải tạo mới
        {
            /*
             foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
             {
                 MuonTraSach a = db.MuonTraSaches.Find(dataGridView2.SelectedCells[0].Value);
                 BorrowBook b = new BorrowBook(a);
                 db.MuonTraSaches.Remove(a);
                 binding_sources.RemoveAt(item.Index);
                 //updateTraSach();
             }*/
            try
            {
                foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                {
                    MuonTraSach a = db.MuonTraSaches.Find(dataGridView2.SelectedCells[0].Value);
                    a.NgayTra = dtNgayTra.Value;
                    db.Saches.Find(txtMaSach_TraSach.Text).SoLuong += Convert.ToInt32(txtSoLuong_TraSach.Text);//Long lam nha phan du lieu nay t khong ranhh
                    //binding_sources.Add(a);
                    db.SaveChanges();
                    napVaodgvMuonSach();
                }
                MessageBox.Show("Đã trả sách thành công!");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Có lỗi xảy ra\nVui lòng thử lại sau", "Thông báo");
                //MessageBox.Show("" + exc.Message);
            }
        }
        
        private void cbChonMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBox();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            cbMaDG.Text = dataGridView1.CurrentRow.Cells["colMaDG"].Value.ToString();
            txtMaSach.Text = dataGridView1.CurrentRow.Cells["colMaSach"].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells["colSoLuong"].Value.ToString();
            dtNgayMuon.Value = (DateTime)dataGridView1.CurrentRow.Cells["colNgayMuon"].Value;
            dtNgayHenTra.Value = (DateTime)dataGridView1.CurrentRow.Cells["colNgayHenTra"].Value;
        }

        private void cbChonMaSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string strmasach = cbChonMaSach.SelectedValue.ToString();
            foreach (var item in db.Saches)
            {
                if(strmasach == item.MaSach)
                {
                    lblMaSach.Text = item.MaSach;
                    lblMaLoai.Text = item.MaLoaiSach;
                    lblSoLuong.Text = item.SoLuong.ToString();
                    lblMaTG.Text = item.MaTG;
                }
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            cbMaDG_TraSach.Text = dataGridView2.CurrentRow.Cells["Column6"].Value.ToString();
            txtMaSach_TraSach.Text = dataGridView2.CurrentRow.Cells["Column7"].Value.ToString();
            txtSoLuong_TraSach.Text = dataGridView2.CurrentRow.Cells["Column8"].Value.ToString();
            dtNgayMuon_TraSach.Value = (DateTime)dataGridView2.CurrentRow.Cells["Column9"].Value;
            dtNgayHenTra_TraSach.Value = (DateTime)dataGridView2.CurrentRow.Cells["Column10"].Value;
            //dtNgayTra.Value = (DateTime)dataGridView2.CurrentRow.Cells["Column10"].Value;
            dtNgayTra.Value = System.DateTime.Now;
        }
    }
}
