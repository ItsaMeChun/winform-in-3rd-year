using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19DTHJB1_Long_Phuc_Trung
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            customizeDesign();
        }
        #region thingUse
        private void customizeDesign()
        {
            panelBookSubMenu.Visible = false; //đặt panel của sách thành false là không nhìn thấy
            panelReaderSubMenu.Visible = false; //như trên nhưng cho độc giả
        }

        private void hideSubMenu()
        {
            if (panelBookSubMenu.Visible == true) //nếu cái panel của sách đang hiển thị, thì set nó thành false để nó không thể nhìn thấy
                panelBookSubMenu.Visible = false;
            if (panelReaderSubMenu.Visible == true) //như trên nhưng cho độc giả
                panelReaderSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm) //tại sao t lại suy nghĩ ra cái này, cũng không biết nhưng đau đầu cực
        {
            if (activeForm != null) //nếu đang có form nào mở
                activeForm.Close(); //tiến hành đóng form đó. Ví dụ: đang mở form mượn sách thì tiền hành đóng nó sau đó mới mở khác
            activeForm = childForm;//set form hoạt động thành cái form mà mình truyền vào
            childForm.TopLevel = false;//set toplevel của cái form con mà mình mở thành false, nghĩa là nó không chiếm hẳn quyền của cái form con
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; //set cái thuộc tính dock của form con thành fill, nghĩa là chiếm toàn bộ ô của cái để cho form con mở
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();//đem form con lên trên để không bị spawn ở dưới
            childForm.Show();//hiển thị form con lên
        }

        private void Exit()
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Bạn muốn thoát chứ ?", "Thông báo",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
                Application.Exit();
        }
        #endregion
        #region buttonSubMenuFunc
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReaderSubMenu);
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            openChildForm(new Member());
            hideSubMenu();
        }

        private void btnBorrowCard_Click(object sender, EventArgs e)
        {
            openChildForm(new BorrowBooks());
            hideSubMenu();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBookSubMenu);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            openChildForm(new AddBooks());
            hideSubMenu();
        }

        private void btnFindBook_Click(object sender, EventArgs e)
        {
            FindBooks f = new FindBooks();
            hideSubMenu();
            f.ShowDialog();
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            formTacGia f = new formTacGia();
            hideSubMenu();
            //f.TopLevel = false;
            f.ShowDialog();
        }
        #endregion
    }
}
