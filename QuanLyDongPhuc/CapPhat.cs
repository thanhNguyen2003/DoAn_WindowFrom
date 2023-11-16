using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDongPhuc
{
    public partial class CapPhat : Form
    {
        SqlConnection connection;
        SqlCommand commmand;
        string str = @"Data Source=DESKTOP-27KTB9F\SQLEXPRESS;Initial Catalog=QuanLyDongPhuc;User ID=sa;Password=1234";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT * FROM CapPhat";
            adapter.SelectCommand = commmand;
            table.Clear();
            adapter.Fill(table);
            dgvDanhSach.DataSource = table;
            CountAndDisplayRowCount();
        }
        private bool isAdmin = false;
        private void CapPhat_Load(object sender, EventArgs e)
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
            // không thực hiện click vào ô dữ liệu
            txtMaCP.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenDP.ReadOnly = true;
            txtTenPB.ReadOnly = true;
            txtGioiTinh.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT nv.TenNV, nv.GioiTinh, pb.TenPhongBan, dp.TenDongPhuc " +
                           "FROM NhanVien nv " +
                           "JOIN PhongBan pb ON nv.TenPhongBan = pb.TenPhongBan " +
                           "JOIN DongPhuc dp ON pb.TenPhongBan = dp.TenPhongBan " +
                           "WHERE MaNV = @MaNV";

            commmand = new SqlCommand(query, connection);
            commmand.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
            SqlDataReader reader = commmand.ExecuteReader();
            if (reader.Read())
            {
                txtTenNV.Text = reader["TenNV"].ToString();
                txtGioiTinh.Text = reader["GioiTinh"].ToString();
                txtTenPB.Text = reader["TenPhongBan"].ToString();
                txtTenDP.Text = reader["TenDongPhuc"].ToString();
            }
            reader.Close();
            // Thêm đoạn mã để tự động tạo MaCP dựa trên MaNV tại đây
            string queryMaCP = "SELECT TOP 1 MaCapPhat FROM CapPhat ORDER BY MaCapPhat DESC";
            SqlCommand commandMaCP = new SqlCommand(queryMaCP, connection);
            object result = commandMaCP.ExecuteScalar();

            if (result != null)
            {
                string lastMaCP = result.ToString();
                string prefix = lastMaCP.Substring(0, 2);
                int number = int.Parse(lastMaCP.Substring(2)) + 1;
                string newMaCP = prefix + number.ToString().PadLeft(6, '0');
                txtMaCP.Text = newMaCP;
            }
            else
            {
                txtMaCP.Text = "cp__";
            }
            //lấy  ra size dựa theo tên đồng phục;
            if (!string.IsNullOrEmpty(txtTenPB.Text))
            {
                string querySize = "SELECT DISTINCT d.Size " +
                                    "FROM DongPhuc d " +
                                    "WHERE d.TenPhongBan = @TenPhongBan";

                SqlCommand commandSize = new SqlCommand(querySize, connection);
                commandSize.Parameters.AddWithValue("@TenPhongBan", txtTenPB.Text);

                cbSize.Items.Clear(); // Xóa các mục cũ trước khi thêm mới

                SqlDataReader readerSize = commandSize.ExecuteReader();
                while (readerSize.Read())
                {
                    cbSize.Items.Add(readerSize["Size"].ToString());
                }
                readerSize.Close();
            }
        }
        //lấy ra giá tiền dựa theo size
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenDP.Text) && !string.IsNullOrEmpty(cbSize.Text))
            {
                string queryDonGia = "SELECT DonGia FROM DongPhuc WHERE TenDongPhuc = @TenDongPhuc AND Size = @Size";
                SqlCommand commandDonGia = new SqlCommand(queryDonGia, connection);
                commandDonGia.Parameters.AddWithValue("@TenDongPhuc", txtTenDP.Text);
                commandDonGia.Parameters.AddWithValue("@Size", cbSize.Text);

                SqlDataReader readerDonGia = commandDonGia.ExecuteReader();
                if (readerDonGia.Read())
                {
                    txtDonGia.Text = readerDonGia["DonGia"].ToString();
                }
                readerDonGia.Close();
            }
        }

        public CapPhat()
        {
            InitializeComponent();
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDanhSach.CurrentRow.Index;
            txtMaCP.Text = dgvDanhSach.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvDanhSach.Rows[i].Cells[1].Value.ToString();
            txtTenDP.Text = dgvDanhSach.Rows[i].Cells[2].Value.ToString();
            txtTenPB.Text = dgvDanhSach.Rows[i].Cells[3].Value.ToString();
            txtGioiTinh.Text = dgvDanhSach.Rows[i].Cells[4].Value.ToString();
            txtSoLuong.Text = dgvDanhSach.Rows[i].Cells[5].Value.ToString();
            cbSize.Text = dgvDanhSach.Rows[i].Cells[6].Value.ToString();
            txtDonGia.Text = dgvDanhSach.Rows[i].Cells[7].Value.ToString();
            txtTongTien.Text = dgvDanhSach.Rows[i].Cells[8].Value.ToString();
            dtNgayNhan.Text = dgvDanhSach.Rows[i].Cells[9].Value.ToString();
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            CountAndDisplayRowCount();
            txtMaCP.Text = "";
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtTenDP.Text = "";
            txtTenPB.Text = "";
            txtGioiTinh.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            cbSize.Text = "";
            txtTongTien.Text = "";
            dtNgayNhan.Text = "1/1/1990";
            MessageBox.Show("thao tác làm mới thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrEmpty(txtTenDP.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        commmand = connection.CreateCommand();
                        commmand.CommandText = "delete from CapPhat where MaCapPhat='" + txtMaCP.Text + "'";
                        commmand.ExecuteNonQuery();
                        loaddata();
                        MessageBox.Show("Thao tác xóa thành công");
                        txtMaCP.Text = "";
                        txtMaNV.Text = "";
                        txtTenNV.Text = "";
                        txtTenDP.Text = "";
                        txtTenPB.Text = "";
                        txtGioiTinh.Text = "";
                        txtDonGia.Text = "";
                        txtSoLuong.Text = "";
                        cbSize.Text = "";
                        txtTongTien.Text = "";
                        dtNgayNhan.Text = "1/1/1990";
                        CountAndDisplayRowCount();
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
                    commmand.CommandText = "update CapPhat set TenNV= N'" + txtTenNV.Text +
                                           "',TenDongPhuc=N'" + txtTenDP.Text +
                                           "',TenPhongBan= N'" + txtTenPB.Text +
                                           "',GioiTinh= N'" + txtGioiTinh.Text +
                                           "',DonGia= '" + txtDonGia.Text +
                                           "',SoLuong= '" + txtSoLuong.Text +
                                           "',Size= '" + cbSize.Text +
                                           "',TongTien= '" + txtTongTien.Text +
                                           "',NgayNhan= '" + dtNgayNhan.Text +
                                           "' where MaCapPhat= '" + txtMaCP.Text + "'";
                    commmand.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Thao tác sửa thành công");
                    txtMaCP.Text = "";
                    txtMaNV.Text = "";
                    txtTenNV.Text = "";
                    txtTenDP.Text = "";
                    txtTenPB.Text = "";
                    txtGioiTinh.Text = "";
                    txtDonGia.Text = "";
                    txtSoLuong.Text = "";
                    cbSize.Text = "";
                    txtTongTien.Text = "";
                    dtNgayNhan.Text = "1/1/1990";
                    CountAndDisplayRowCount();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
            }
        } 

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if (string.IsNullOrWhiteSpace(txtMaCP.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenDP.Text) ||
                string.IsNullOrWhiteSpace(txtTenPB.Text) ||
                string.IsNullOrWhiteSpace(txtGioiTinh.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtTongTien.Text) ||
                string.IsNullOrWhiteSpace(dtNgayNhan.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Thoát khỏi hàm nếu thông tin không đầy đủ
                }

                // Kiểm tra xem MaCapPhat đã tồn tại hay chưa
                string checkExistQuery = "SELECT COUNT(*) FROM CapPhat WHERE MaCapPhat = '" + txtMaCP.Text + "'";
                commmand.CommandText = checkExistQuery;
                int count = Convert.ToInt32(commmand.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("MaCapPhat đã tồn tại.Vui lòng chọn chức năng làm mới và điền đầy đủ thông tin để thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Thoát khỏi hàm nếu MaCapPhat đã tồn tại
                }
                // Thêm mới nếu MaCapPhat chưa tồn tại
                string insertQuery = "INSERT INTO CapPhat(MaCapPhat, TenNV, TenDongPhuc, TenPhongBan, GioiTinh, DonGia, SoLuong, Size, TongTien, NgayNhan) " +
                                     "VALUES ('" + txtMaCP.Text + "'," +
                                             "N'" + txtTenNV.Text + "'," +
                                             "N'" + txtTenDP.Text + "'," +
                                             "N'" + txtTenPB.Text + "'," +
                                             "N'" + txtGioiTinh.Text + "'," +
                                             "'" + txtDonGia.Text + "'," +
                                             "'" + txtSoLuong.Text + "'," +
                                             "'" + cbSize.Text + "'," +
                                             "'" + txtTongTien.Text + "'," +
                                             "'" + dtNgayNhan.Text + "')";

                commmand.CommandText = insertQuery;
                commmand.ExecuteNonQuery();

                loaddata();
                MessageBox.Show("Thao tác thêm thành công");

                // Reset các control sau khi thêm thành công
                txtMaCP.Text = "";
                txtTenNV.Text = "";
                txtTenDP.Text = "";
                txtTenPB.Text = "";
                txtGioiTinh.Text = "";
                txtDonGia.Text = "";
                txtSoLuong.Text = "";
                cbSize.Text = "";
                txtTongTien.Text = "";
                dtNgayNhan.Text = "1/1/1990";
                CountAndDisplayRowCount();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDonGia.Text) && !string.IsNullOrEmpty(txtSoLuong.Text))
            {
                try
                {
                    int donGia = Convert.ToInt32(txtDonGia.Text);
                    int soLuong = Convert.ToInt32(txtSoLuong.Text);
                    int tongTien = donGia * soLuong;
                    txtTongTien.Text = tongTien.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CountAndDisplayRowCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["MaCapPhat"].Value != null)
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
