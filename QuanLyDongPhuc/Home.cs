using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDongPhuc
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        { 
            if(currentFormChild!=null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            pan_body.Controls.Add(childForm);
            pan_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form hiện tại
                Login l = new Login();
                l.Show(); // Hiển thị form đăng nhập
            }
        }


        private void Home_Load(object sender, EventArgs e)
        {
        }
        private void pan_top_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
            label1.Text = btnNhanVien.Text;
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhongBan());
            label1.Text = btnPhongBan.Text;
        }


        private void btnDongPhuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DongPhuc());
            label1.Text = btnDongPhuc.Text;
        }

        private void btnCapPhat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CapPhat());
            label1.Text = btnCapPhat.Text;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeCapPhat());
            label1.Text = btnTimKiem.Text;
        }
    }
}
