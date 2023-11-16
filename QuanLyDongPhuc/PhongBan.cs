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
using System.Text.RegularExpressions;

namespace QuanLyDongPhuc
{
    public partial class PhongBan : Form
    {
        SqlConnection connection;
        SqlCommand commmand;
        string str = @"Data Source=DESKTOP-27KTB9F\SQLEXPRESS;Initial Catalog=QuanLyDongPhuc;User ID=sa;Password=1234";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public PhongBan()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT * FROM PhongBan ORDER BY MaPhongBan ASC"; 
            adapter.SelectCommand = commmand;
            table.Clear();
            adapter.Fill(table);
            dgvDanhSach.DataSource = table;
        }
        private bool isAdmin = false;
        private void PhongBan_Load(object sender, EventArgs e)
        {
            // Kiểm tra loại tài khoản và thực hiện các thay đổi tương ứng
            if (Login.LoaiTaiKhoan.ToLower() == "admin")
            {
                isAdmin = true;
            }
            else if (Login.LoaiTaiKhoan.ToLower() == "")
            {
                isAdmin = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            AutoGenerateMaPB();
            CountAndDisplayRowCount();
            // không thực hiện click vào ô dự liệu 
            txtMaPB.ReadOnly = true;
        }
        private void AutoGenerateMaPB()
        {
            string queryMaPB = "SELECT TOP 1 MaPhongBan FROM PhongBan ORDER BY MaPhongBan DESC";
            commmand = new SqlCommand(queryMaPB, connection);
            object result = commmand.ExecuteScalar();

            if (result != null)
            {
                string lastMaPB = result.ToString();
                string prefix = lastMaPB.Substring(0, 2);
                int number = int.Parse(lastMaPB.Substring(2)) + 1;
                string newMaPB = prefix + number.ToString().PadLeft(3, '0');
                txtMaPB.Text = newMaPB;
            }
            else
            {
                txtMaPB.Text = "pb__";
            }
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            CountAndDisplayRowCount();
            AutoGenerateMaPB();
            txtTenPB.Text = "";
            cbTrangThai.Text = "";
            MessageBox.Show("thao tác làm mới thành công");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrWhiteSpace(txtMaPB.Text) || string.IsNullOrWhiteSpace(txtTenPB.Text) || string.IsNullOrWhiteSpace(cbTrangThai.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Thoát khỏi hàm nếu thông tin không đầy đủ
                }

                // Kiểm tra xem MaPhongBan đã tồn tại hay chưa
                string checkExistQuery = "SELECT COUNT(*) FROM PhongBan WHERE MaPhongBan = '" + txtMaPB.Text + "'";
                commmand.CommandText = checkExistQuery;

                int count = Convert.ToInt32(commmand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("MaPhongBan đã tồn tại.Vui lòng chọn chức năng làm mới và điền đầy đủ thông tin để thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Thoát khỏi hàm nếu MaPhongBan đã tồn tại
                }

                // Thêm mới nếu MaPhongBan chưa tồn tại
                string insertQuery = "INSERT INTO PhongBan VALUES ('" + txtMaPB.Text + "',N'" + txtTenPB.Text + "',N'" + cbTrangThai.Text + "')";
                commmand.CommandText = insertQuery;
                commmand.ExecuteNonQuery();

                loaddata();
                MessageBox.Show("Thao tác thêm thành công");
                AutoGenerateMaPB();
                CountAndDisplayRowCount();
                txtTenPB.Text = "";
                cbTrangThai.Text = "";
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrEmpty(txtTenPB.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng ban cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        commmand = connection.CreateCommand();
                        commmand.CommandText = "delete from PhongBan where MaPhongBan='" + txtMaPB.Text + "'";
                        commmand.ExecuteNonQuery();
                        loaddata();
                        MessageBox.Show("Thao tác xóa thành công");
                        AutoGenerateMaPB();
                        CountAndDisplayRowCount();
                        txtTenPB.Text = "";
                        cbTrangThai.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrEmpty(txtTenPB.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng ban cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    commmand = connection.CreateCommand();
                    commmand.CommandText = "update PhongBan set TenPhongBan= N'" + txtTenPB.Text + "',TrangThai= N'" + cbTrangThai.Text +"' where MaPhongBan= '" + txtMaPB.Text + "'";
                    commmand.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Thao tác sửa thành công");
                    AutoGenerateMaPB();
                    CountAndDisplayRowCount();
                    txtTenPB.Text = "";
                    cbTrangThai.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDanhSach.CurrentRow.Index;
            txtMaPB.Text = dgvDanhSach.Rows[i].Cells[0].Value.ToString();
            txtTenPB.Text = dgvDanhSach.Rows[i].Cells[1].Value.ToString();
            cbTrangThai.Text = dgvDanhSach.Rows[i].Cells[2].Value.ToString();
        }
        private void CountAndDisplayRowCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["MaPhongBan"].Value != null)
                {
                    count++;
                }
            }
            txtTong.Text = count.ToString();
        }
        private void txtTong_TextChanged(object sender, EventArgs e)
        {
            CountAndDisplayRowCount();
        }
    }
}
