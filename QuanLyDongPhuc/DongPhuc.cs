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
    public partial class DongPhuc : Form
    {
        SqlConnection connection;
        SqlCommand commmand;
        string str = @"Data Source=DESKTOP-27KTB9F\SQLEXPRESS;Initial Catalog=QuanLyDongPhuc;User ID=sa;Password=1234";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public DongPhuc()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT * FROM DongPhuc"; 
            adapter.SelectCommand = commmand;
            table.Clear();
            adapter.Fill(table);
            dgvDanhSach.DataSource = table;
            AutoGenerateMaDP();
            // không thực hiện click vào ô dự liệu 
            txtMaDP.ReadOnly = true;
        }
        private void AutoGenerateMaDP()
        {
            string queryMaDP = "SELECT TOP 1 MaDongPhuc FROM DongPhuc ORDER BY MaDongPhuc DESC";
            commmand = new SqlCommand(queryMaDP, connection);
            object result = commmand.ExecuteScalar();

            if (result != null)
            {
                string lastMaDP = result.ToString();
                string prefix = lastMaDP.Substring(0, 2);
                int number = int.Parse(lastMaDP.Substring(2)) + 1;
                string newMaDP = prefix + number.ToString().PadLeft(3, '0');
                txtMaDP.Text = newMaDP;
            }
            else
            {
                txtMaDP.Text = "dp__";
            }
        }
        private bool isAdmin = false;
        private void DongPhuc_Load(object sender, EventArgs e)
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
            LoadTenPBToComboBox();
            CountAndDisplayRowCount();
        }
        private void LoadTenPBToComboBox()
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
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDanhSach.CurrentRow.Index;
            txtMaDP.Text = dgvDanhSach.Rows[i].Cells[0].Value.ToString();
            cbTenPB.Text = dgvDanhSach.Rows[i].Cells[1].Value.ToString();
            txtTenDP.Text = dgvDanhSach.Rows[i].Cells[2].Value.ToString();
            txtDonGia.Text = dgvDanhSach.Rows[i].Cells[3].Value.ToString();
            cbDonViTinh.Text = dgvDanhSach.Rows[i].Cells[4].Value.ToString();
            cbSize.Text = dgvDanhSach.Rows[i].Cells[5].Value.ToString();
            cbTrangThai.Text = dgvDanhSach.Rows[i].Cells[6].Value.ToString();
            dtNgayTao.Text = dgvDanhSach.Rows[i].Cells[7].Value.ToString();
        }
        private bool IsMatching(string tenDP, string tenPB)
        {
            if (tenDP.Length > 0 && tenPB.Length > 0)
            {
                char lastCharTenDP = tenDP[tenDP.Length - 1];
                char lastCharTenPB = tenPB[tenPB.Length - 1];
                return lastCharTenDP == lastCharTenPB;
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrWhiteSpace(txtMaDP.Text) ||
                    string.IsNullOrWhiteSpace(cbTenPB.Text) ||
                    string.IsNullOrWhiteSpace(txtTenDP.Text) ||
                    string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                    string.IsNullOrWhiteSpace(cbDonViTinh.Text) ||
                    string.IsNullOrWhiteSpace(cbSize.Text) ||
                    string.IsNullOrWhiteSpace(cbTrangThai.Text) ||
                    string.IsNullOrWhiteSpace(dtNgayTao.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    float dongia;
                    if (!float.TryParse(txtDonGia.Text, out dongia))
                    {
                        MessageBox.Show("Dongia phải là một số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!IsMatching(txtTenDP.Text, cbTenPB.Text))
                    {
                        MessageBox.Show("Tên đồng phục phải thuộc phòng ban tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra xem MaDongPhuc đã tồn tại hay chưa
                    string checkExistQuery = "SELECT COUNT(*) FROM DongPhuc WHERE MaDongPhuc = '" + txtMaDP.Text + "'";
                    commmand.CommandText = checkExistQuery;

                    int count = Convert.ToInt32(commmand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("MaDongPhuc đã tồn tại. Vui lòng chọn chức năng làm mới và điền đầy đủ thông tin để thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thêm mới nếu MaDongPhuc chưa tồn tại
                    string insertQuery = "INSERT INTO DongPhuc VALUES ('" + txtMaDP.Text + "',N'" + cbTenPB.Text + "',N'" + txtTenDP.Text + "','" + txtDonGia.Text + "',N'" + cbDonViTinh.Text + "','" + cbSize.Text + "',N'" + cbTrangThai.Text + "','" + dtNgayTao.Text + "')";
                    commmand.CommandText = insertQuery;
                    commmand.ExecuteNonQuery();

                    loaddata();
                    MessageBox.Show("Thao tác thêm thành công");
                    CountAndDisplayRowCount();
                    AutoGenerateMaDP();
                    cbTenPB.Text = "";
                    txtTenDP.Text = "";
                    txtDonGia.Text = "";
                    cbDonViTinh.Text = "";
                    cbSize.Text = "";
                    cbTrangThai.Text = "";
                    dtNgayTao.Text = "1/1/1990";
                }
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
                if (string.IsNullOrEmpty(txtTenDP.Text))
                {
                    MessageBox.Show("Vui lòng chọn đồng phục cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        commmand = connection.CreateCommand();
                        commmand.CommandText = "delete from DongPhuc where MaDongPhuc='" + txtMaDP.Text + "'";
                        commmand.ExecuteNonQuery();
                        loaddata();
                        MessageBox.Show("Thao tác xóa thành công");
                        CountAndDisplayRowCount();
                        AutoGenerateMaDP();
                        cbTenPB.Text = "";
                        txtTenDP.Text = "";
                        txtDonGia.Text = "";
                        cbDonViTinh.Text = "";
                        cbSize.Text = "";
                        cbTrangThai.Text = "";
                        dtNgayTao.Text = "1/1/1990";
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
                if (string.IsNullOrEmpty(txtTenDP.Text))
                {
                    MessageBox.Show("Vui lòng chọn đồng phục cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!IsMatching(txtTenDP.Text, cbTenPB.Text))
                    {
                        MessageBox.Show("Tên đồng phục phải thuộc phòng ban tương ứng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    commmand = connection.CreateCommand();
                    commmand.CommandText = "update DongPhuc set TenPhongBan= N'" + cbTenPB.Text + "',TenDongPhuc= N'" + txtTenDP.Text + "',DonGia='" + txtDonGia.Text + "' ,DonViTinh= N'" + cbDonViTinh.Text + "',Size= '" + cbSize.Text + "',TrangThai=N'" + cbTrangThai.Text + "',NgayTao= '" + dtNgayTao.Text + "' where MaDongPhuc= '" + txtMaDP.Text + "'";
                    commmand.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Thao tác sửa thành công");
                    CountAndDisplayRowCount();
                    AutoGenerateMaDP();
                    cbTenPB.Text = "";
                    txtTenDP.Text = "";
                    txtDonGia.Text = "";
                    cbDonViTinh.Text = "";
                    cbSize.Text = "";
                    cbTrangThai.Text = "";
                    dtNgayTao.Text = "1/1/1990";
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
            AutoGenerateMaDP();
            cbTenPB.Text = "";
            txtTenDP.Text = "";
            txtDonGia.Text = "";
            cbDonViTinh.Text = "";
            cbSize.Text = "";
            cbTrangThai.Text = "";
            dtNgayTao.Text = "1/1/1990";
            MessageBox.Show("Thao tác làm mới thành công");
        }
        private void CountAndDisplayRowCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["MaDongPhuc"].Value != null)
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

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
