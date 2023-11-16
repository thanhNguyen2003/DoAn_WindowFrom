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
    public partial class NhanVien : Form
    {
        SqlConnection connection;
        SqlCommand commmand;
        string str = @"Data Source=DESKTOP-27KTB9F\SQLEXPRESS;Initial Catalog=QuanLyDongPhuc;User ID=sa;Password=1234";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT * FROM NhanVien";
            adapter.SelectCommand = commmand;
            table.Clear();
            adapter.Fill(table);
            dgvDanhSach.DataSource = table;
            AutoGenerateMaNV();
            CountAndDisplayRowCount();
            // không thực hiện click vào ô dự liệu 
            txtMaNV.ReadOnly = true;

        }
        private bool isAdmin = false;
        private void NhanVien_Load(object sender, EventArgs e)
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
            LoadDataIntoCbTenPB();
        }

        private void AutoGenerateMaNV()
        {
            string queryMaNV = "SELECT TOP 1 MaNV FROM NhanVien ORDER BY MaNV DESC";
            commmand = new SqlCommand(queryMaNV, connection);
            object result = commmand.ExecuteScalar();

            if (result != null)
            {
                string lastMaNV = result.ToString();
                string prefix = lastMaNV.Substring(0, 2); 
                int number = int.Parse(lastMaNV.Substring(2)) + 1;
                string newMaNV = prefix + number.ToString().PadLeft(2, '0'); 
                txtMaNV.Text = newMaNV;
            }
            else
            {
                txtMaNV.Text = "nv__"; 
            }
        }

        private void LoadDataIntoCbTenPB()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT TenPhongBan, TrangThai FROM PhongBan";
            SqlDataReader reader = commmand.ExecuteReader();
            while (reader.Read())
            {
                string tenPhongBan = reader["TenPhongBan"].ToString();
                string trangThai = reader["TrangThai"].ToString();

                if (trangThai == "hoạt động")
                {
                    cbTenPB.Items.Add(tenPhongBan);
                }
                else if (trangThai == "ngưng hoạt động")
                {
                }
            }
            reader.Close();
        }


        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int i;
            i = dgvDanhSach.CurrentRow.Index;
            txtMaNV.Text = dgvDanhSach.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvDanhSach.Rows[i].Cells[1].Value.ToString();
            dTime.Text = dgvDanhSach.Rows[i].Cells[2].Value.ToString();
            cbGioiTinh.Text = dgvDanhSach.Rows[i].Cells[3].Value.ToString();
            txtChucVu.Text = dgvDanhSach.Rows[i].Cells[4].Value.ToString();
            cbTenPB.Text = dgvDanhSach.Rows[i].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(dTime.Text) ||
                string.IsNullOrWhiteSpace(cbGioiTinh.Text) ||
                string.IsNullOrWhiteSpace(txtChucVu.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem MaNV đã tồn tại hay chưa
                string checkExistQuery = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = '" + txtMaNV.Text + "'";
                commmand.CommandText = checkExistQuery;

                int count = Convert.ToInt32(commmand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("MaNV đã tồn tại. Vui lòng chọn chức năng làm mới và điền đầy đủ thông tin để thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm mới nếu MaNV chưa tồn tại
                string insertQuery = "INSERT INTO NhanVien VALUES ('" + txtMaNV.Text + "',N'" + txtTenNV.Text + "','" + dTime.Text + "',N'" + cbGioiTinh.Text + "',N'" + txtChucVu.Text + "',N'" + cbTenPB.Text + "')";
                commmand.CommandText = insertQuery;
                commmand.ExecuteNonQuery();

                loaddata();
                MessageBox.Show("Thao tác thêm thành công");
                CountAndDisplayRowCount();
                AutoGenerateMaNV();
                txtTenNV.Text = "";
                dTime.Text = "1/1/1990";
                cbGioiTinh.Text = "";
                txtChucVu.Text = "";
                cbTenPB.Text = "";
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
                if (string.IsNullOrEmpty(txtTenNV.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        commmand = connection.CreateCommand();
                        commmand.CommandText = "delete from NhanVien where MaNV='" + txtMaNV.Text + "'";
                        commmand.ExecuteNonQuery();
                        loaddata();
                        MessageBox.Show("Thao tác xóa thành công");
                        CountAndDisplayRowCount();
                        AutoGenerateMaNV();
                        txtTenNV.Text = "";
                        dTime.Text = "1/1/1990";
                        cbGioiTinh.Text = "";
                        txtChucVu.Text = "";
                        cbTenPB.Text = "";
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
                if (string.IsNullOrEmpty(txtTenNV.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    commmand = connection.CreateCommand();
                    commmand.CommandText = "update NhanVien set TenNV= N'" + txtTenNV.Text + "',NgaySinh='" + dTime.Text + "' ,GioiTinh= N'" + cbGioiTinh.Text + "',ChucVu= N'" + txtChucVu.Text + "',TenPhongBan= N'" + cbTenPB.Text + "' where MaNV= '" + txtMaNV.Text + "'";
                    commmand.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Thao tác sửa thành công");
                    CountAndDisplayRowCount();
                    AutoGenerateMaNV();
                    txtTenNV.Text = "";
                    dTime.Text = "1/1/1990";
                    cbGioiTinh.Text = "";
                    txtChucVu.Text = "";
                    cbTenPB.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
            }
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            CountAndDisplayRowCount();
            AutoGenerateMaNV();
            txtTenNV.Text = "";
            dTime.Text = "1/1/1990";
            cbGioiTinh.Text = "";
            txtChucVu.Text = "";
            cbTenPB.Text = "";
            MessageBox.Show("thao tác làm mới thành công");
        }
        private void CountAndDisplayRowCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["MaNV"].Value != null)
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
