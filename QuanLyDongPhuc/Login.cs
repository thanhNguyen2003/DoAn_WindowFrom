using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyDongPhuc
{
    public partial class Login : Form
    {
        private object dta;

        public Login()
        {
            InitializeComponent();
        }
        public static string LoaiTaiKhoan { get; private set; }


        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình không", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-27KTB9F\SQLEXPRESS;Initial Catalog=QuanLyDongPhuc;User ID=sa;Password=1234");
            try
            {
                conn.Open();
                string tk = txtTenTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = "select * from Login where TaiKhoan='" + tk + "'and MatKhau='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    LoaiTaiKhoan = tk; // Lưu loại tài khoản vào biến tĩnh
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

    private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
