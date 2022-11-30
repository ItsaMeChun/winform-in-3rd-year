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
    public partial class Member : Form
    {
        Model1 db = new Model1();
        List<DG> objDocGia = new List<DG>();
        private BindingSource binding_sources = new BindingSource(); //binding source
        public Member()
        {
            InitializeComponent();
        }

        private void napVaodgv()
        {
            var list_DocGia = from dg in db.NguoiMuons
                              select new
                              {
                                  MaDG = dg.MaDG,
                                  TenDG = dg.TenDG,
                                  GioiTinh = dg.GioiTinh,
                                  NgaySinh = dg.NgaySinh,
                                  DiaChi = dg.DiaChi
                              };
            foreach (var item in list_DocGia)
            {
                DG dg = new DG();
                dg.MaDG = item.MaDG;
                dg.TenDG = item.TenDG;
                dg.GioiTinh = item.GioiTinh;
                dg.NgaySinh = item.NgaySinh;
                dg.DiaChi = item.DiaChi;
                objDocGia.Add(dg);
            }
            binding_sources.DataSource = objDocGia;
            //dataGridView1.DataSource = objDocGia.ToList<DG>();
            dataGridView1.DataSource = binding_sources;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Member_Load(object sender, EventArgs e)
        {
            setButton();
            napVaodgv();
        }

        private void setButton()
        {
            btnThem.Text = "Thêm";
            txtMaDG.Text = "";
            txtTenDG.Text = "";
            radNam.Checked = true;
            dtNgayMuon.Text = "";
            txtDiaChi.Text = "";
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            dataGridView1.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm") //nếu nhấn nút thêm, thì sẽ reset những ô thành rỗng
            {                           //sau đó đổi nút thêm thành hủy
                btnThem.Text = "Hủy";
                grbChiTietDG.Enabled = true;
                txtMaDG.Text = "";
                txtTenDG.Text = "";
                dtNgayMuon.Text = "";
                txtDiaChi.Text = "";
                txtMaDG.Focus();
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

        private void luuDG()
        {
            try
            {
                NguoiMuon dg = new NguoiMuon();
                dg.MaDG = txtMaDG.Text;
                dg.TenDG = txtTenDG.Text;
                if (radNam.Checked == true) //nếu check cái nút nam thì giới tính sẽ chọn theo nó
                    dg.GioiTinh = "Nam";
                else
                    dg.GioiTinh = "Nữ";
                dg.NgaySinh = dtNgayMuon.Value;
                dg.DiaChi = txtDiaChi.Text;

                DG dG = new DG(dg);
                binding_sources.Add(dG);

                db.NguoiMuons.Add(dg);
                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong việc lưu dữ liệu", "Thông báo");
            }
        }

        private void suaDG()
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    NguoiMuon nguoiMuon = db.NguoiMuons.Find(dataGridView1.SelectedCells[0].Value);
                    DG dg = new DG(nguoiMuon);
                    if (dg.MaDG == txtMaDG.Text && dg.TenDG == txtTenDG.Text && dg.NgaySinh == dtNgayMuon.Value && dg.DiaChi == txtDiaChi.Text && dg.GioiTinh == radNam.Name || dg.GioiTinh == radNu.Name)
                        MessageBox.Show("Xin hãy chỉnh sửa thông tin của độc giả", "Thông báo");
                    else
                    {
                        db.NguoiMuons.Remove(nguoiMuon);
                        binding_sources.RemoveAt(item.Index);
                        luuDG();

                        btnSua.Text = "Sửa";
                        grbChiTietDG.Enabled = true;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        dtNgayMuon.Text = "";
                    }
                }
                napVaodgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong việc sửa dữ liệu", "Thông báo");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaDG.Text = dataGridView1.CurrentRow.Cells["colMaDG"].Value.ToString();
            txtTenDG.Text = dataGridView1.CurrentRow.Cells["colTenDG"].Value.ToString();
            dtNgayMuon.Value = (DateTime)dataGridView1.CurrentRow.Cells["colNgaySinh"].Value;
            if (dataGridView1.CurrentRow.Cells["colGioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["colDiaChi"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã Độc Giả!", "Thông báo");
                txtMaDG.Focus();
            }
            else if (txtTenDG.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tên Độc Giả!", "Thông báo");
                txtTenDG.Focus();
            }
            else if (txtDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập địa chỉ Độc Giả!", "Thông báo");
                txtDiaChi.Focus();
            }
            else if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Chưa chọn Giới tính", "Thông báo");
                groupBox2.Focus();
            }
            else
            {
                if(btnSua.Text == "Sửa")//tại sao lại làm như này ?
                    luuDG();
                else
                    suaDG();
            }
                
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                if(btnSua.Text == "Sửa")
                {
                    btnSua.Text = "Hủy";
                    txtMaDG.ReadOnly = true;
                    grbChiTietDG.Enabled = true;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = true;
                    dtNgayMuon.Text = "";
                    txtTenDG.Focus();
                }
                else
                {
                    btnSua.Text = "Sửa";
                    txtMaDG.ReadOnly = false;
                    grbChiTietDG.Enabled = true;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    dtNgayMuon.Text = "";
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
                            NguoiMuon nguoiMuon = db.NguoiMuons.Find(dataGridView1.SelectedCells[0].Value);
                            db.NguoiMuons.Remove(nguoiMuon);
                            binding_sources.RemoveAt(item.Index);
                            //db.NguoiMuons.Remove(item.Index);
                            //dataGridView1.Rows.RemoveAt(item.Index);
                        }
                        db.SaveChanges();
                    }
                }
                else
                    MessageBox.Show("Hãy chọn dữ liệu cần xóa!", "Thông báo");
            }
            catch(Exception)
            {
                MessageBox.Show("Đã có lỗi xảy ra trong quá trình xóa dữ liệu!", "Thông báo");
            }
        }
    }
}
