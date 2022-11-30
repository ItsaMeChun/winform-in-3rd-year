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
    public partial class formTacGia : Form
    {
        Model1 db = new Model1();
        List<Artist> objArtist = new List<Artist>();
        private BindingSource binding_sources = new BindingSource();
        public formTacGia()
        {
            InitializeComponent();
        }
        private void napVaodgv()
        {
            var list_Artist = from tg in db.TacGias
                            select new
                            {
                                MaTG = tg.MaTG,
                                TenTG = tg.TenTG
                            };
            foreach (var item in list_Artist)
            {
                Artist tG = new Artist();
                tG.MaTG = item.MaTG;
                tG.TenTG = item.TenTG;
                objArtist.Add(tG);
            }
            binding_sources.DataSource = objArtist;
            dataGridView1.DataSource = binding_sources;
        }

        private void formTacGia_Load(object sender, EventArgs e)
        {
            napVaodgv();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           txtMaTG.Text = dataGridView1.CurrentRow.Cells["colMaTG"].Value.ToString();
           txtTenTG.Text = dataGridView1.CurrentRow.Cells["colTenTG"].Value.ToString();
        }
    }
}
