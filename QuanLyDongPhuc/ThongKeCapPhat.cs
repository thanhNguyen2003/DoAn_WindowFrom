using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDongPhuc
{
    public partial class ThongKeCapPhat : Form
    {
        SqlConnection connection;
        SqlCommand commmand;
        string str = @"Data Source=DESKTOP-27KTB9F\SQLEXPRESS;Initial Catalog=QuanLyDongPhuc;User ID=sa;Password=1234";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ThongKeCapPhat()
        {
            InitializeComponent();
           
        }
        void loaddata()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT * FROM CapPhat";
            adapter.SelectCommand = commmand;
            table.Clear();
            adapter.Fill(table);
            dgvDanhSach.DataSource = table;
        }
        private void ThongKeDongPhuc_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();

            // Gọi phương thức để hiển thị số lượng khi form được mở
            CountAndDisplayRowCount();
        }
       

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            if (maNV != "")
            {
                string tenNV = "";
                // Tìm thông tin nhân viên ứng với mã vừa nhập trong bảng NhanVien
                SqlCommand cmd = new SqlCommand("SELECT TenNV FROM NhanVien WHERE MaNV = @MaNV", connection);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tenNV = reader["TenNV"].ToString();
                }
                else
                {
                    MessageBox.Show("không có thông tin cần tìm, vui lòng nhập lại MaNV khác!");
                }
                reader.Close();

                // Hiển thị thông tin nhân viên được tìm thấy trong bảng CapPhat
                commmand = connection.CreateCommand();
                commmand.CommandText = "SELECT * FROM CapPhat WHERE TenNV = @TenNV";
                commmand.Parameters.AddWithValue("@TenNV", tenNV);
                adapter.SelectCommand = commmand;
                table.Clear();
                adapter.Fill(table);
                dgvDanhSach.DataSource = table;

                // Gọi phương thức để hiển thị số lượng sau khi tìm kiếm
                CountAndDisplayRowCount();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần tìm.");
            }
        }
        private void txtTong_TextChanged(object sender, EventArgs e)
        {
            CountAndDisplayRowCount();
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

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            loaddata(); 
            CountAndDisplayRowCount(); 
            txtMaNV.Text = "";
            MessageBox.Show("Thao tác làm mới thành công");
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
