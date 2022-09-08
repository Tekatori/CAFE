using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace QuanLiCaPhe
{

    public partial class frmNhanvien : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public frmNhanvien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
          
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        void Hienthinhanvien()

        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.getNV1()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();
            dgvResult.DataSource = table;
        }
        void HienThiViTri()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.getVT()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            cboVitri.DataSource = dt;
            cboVitri.DisplayMember = "TenVT";
            cboVitri.ValueMember = "MaVT";
        }
        void HienThiGioiTinh()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.getGT()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable gt = new DataTable();
            da.Fill(gt);
            cn.Close();
            cboGioitinh.DataSource = gt;
            cboGioitinh.DisplayMember = "Phai";
            cboGioitinh.ValueMember = "MaPhai";

        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            Hienthinhanvien();
            HienThiViTri();
            HienThiGioiTinh();
            
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                String ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaysinh.Value);

                cn.Open();
                SqlCommand cm = new SqlCommand("InsertNV", cn);
                cm.Parameters.AddWithValue("@TENNV", txtHoten.Text);
                cm.Parameters.AddWithValue("@NGAYSINH", ngay);
                cm.Parameters.AddWithValue("@MAPHAI", 0);
                cm.Parameters.AddWithValue("@DIACHI", txtDiachi.Text);
                cm.Parameters.AddWithValue("@SDT", txtDienthoai.Text);
                cm.Parameters.AddWithValue("@MAVT", int.Parse(cboVitri.SelectedValue.ToString()));
                cm.Parameters.AddWithValue("@LUONG", float.Parse(txtLuongcoban.Text));
                cm.CommandType = CommandType.StoredProcedure;

                int rowCount = cm.ExecuteNonQuery();
                cn.Close();


                Hienthinhanvien();
                MessageBox.Show("Đã thêm Nhân Viên thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoten.Focus();


            }
            catch
            {
                MessageBox.Show("thêm Nhân Viên Thất Bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn Có Chắc Muốn Thoát?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    cn.Open();
                    SqlCommand cm = new SqlCommand("DeleteNV", cn);
                    cm.Parameters.AddWithValue("@TENNV", txtHoten.Text);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();
                    cn.Close();

                    Hienthinhanvien();
                    MessageBox.Show("Đã Xoá Nhân Viên thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Xoá Thất Bại!");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtHoten.Text = "";
            txtLuongcoban.Text = "";
            txtHoten.Focus();

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            String ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaysinh.Value);

            cn.Open();
            SqlCommand cm = new SqlCommand("UpdateNV", cn);
            cm.Parameters.AddWithValue("@manv", labelmanv.Text);
            cm.Parameters.AddWithValue("@TENNV", txtHoten.Text);
            cm.Parameters.AddWithValue("@NGAYSINH", ngay);
            cm.Parameters.AddWithValue("@MAPHAI", Boolean.Parse(cboGioitinh.SelectedValue.ToString()));
            cm.Parameters.AddWithValue("@DIACHI", txtDiachi.Text);
            cm.Parameters.AddWithValue("@SDT", txtDienthoai.Text);
            cm.Parameters.AddWithValue("@MAVT", int.Parse(cboVitri.SelectedValue.ToString()));
            cm.Parameters.AddWithValue("@LUONG", float.Parse(txtLuongcoban.Text));
            cm.CommandType = CommandType.StoredProcedure;

            int rowCount = cm.ExecuteNonQuery();
            cn.Close();
            Hienthinhanvien();


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {



        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboGioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvResult.CurrentCell.RowIndex;
            labelmanv.Text = dgvResult.Rows[t].Cells[0].Value.ToString();
            txtHoten.Text = dgvResult.Rows[t].Cells[1].Value.ToString();
            txtDiachi.Text = dgvResult.Rows[t].Cells[4].Value.ToString();
            txtDienthoai.Text = dgvResult.Rows[t].Cells[5].Value.ToString();
            txtLuongcoban.Text = dgvResult.Rows[t].Cells[7].Value.ToString();
            dtpNgaysinh.Value = DateTime.Parse(dgvResult.Rows[t].Cells[2].Value.ToString());

            if (dgvResult.Rows[t].Cells[3].Value.ToString() == "True")
            {
                cboGioitinh.SelectedIndex = 1;
            }
            else
            {
                cboGioitinh.SelectedIndex = 0;
            }

            if (dgvResult.Rows[t].Cells[6].Value.ToString() == "1")
            {
                cboVitri.SelectedIndex = 0;
            }
            else 
                if (dgvResult.Rows[t].Cells[6].Value.ToString() == "2")
                {
                    cboVitri.SelectedIndex = 1;
                }
                else
                    if (dgvResult.Rows[t].Cells[6].Value.ToString() == "3")
                    {
                        cboVitri.SelectedIndex = 2;
                    }
                    else
                        if (dgvResult.Rows[t].Cells[6].Value.ToString() == "4")
                        {
                            cboVitri.SelectedIndex = 3;
                        }
                        else
                            if (dgvResult.Rows[t].Cells[6].Value.ToString() == "5")
                            {
                                cboVitri.SelectedIndex = 4;
                            }
                            else
                                if (dgvResult.Rows[t].Cells[6].Value.ToString() == "6")
                                {
                                    cboVitri.SelectedIndex = 5;
                                }
                                else
                                     if (dgvResult.Rows[t].Cells[6].Value.ToString() == "7")
                                    {
                                        cboVitri.SelectedIndex = 6;
                                    }
                                    else
                                    {
                                        cboVitri.SelectedIndex = 7;
                                    }
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvResult.SelectedRows)
            {

                labelmanv.Text = row.Cells[0].Value.ToString();
                txtHoten.Text = row.Cells[1].Value.ToString();
                txtDiachi.Text = row.Cells[4].Value.ToString();
                txtDienthoai.Text = row.Cells[5].Value.ToString();
                txtLuongcoban.Text = row.Cells[7].Value.ToString();
                dtpNgaysinh.Value = DateTime.Parse(row.Cells[2].Value.ToString());

                if (row.Cells[3].Value.ToString() == "True")
                {
                    cboGioitinh.SelectedIndex = 1;
                }
                else
                {
                    cboGioitinh.SelectedIndex = 0;
                }

                if (row.Cells[6].Value.ToString() == "1")
                {
                    cboVitri.SelectedIndex = 0;
                }
                else
                    if (row.Cells[6].Value.ToString() == "2")
                    {
                        cboVitri.SelectedIndex = 1;
                    }
                    else
                        if (row.Cells[6].Value.ToString() == "3")
                            {
                                cboVitri.SelectedIndex = 2;
                            }
                        else
                            if (row.Cells[6].Value.ToString() == "4")
                            {
                            cboVitri.SelectedIndex = 3;
                            }
                            else
                                if (row.Cells[6].Value.ToString() == "5")
                                {
                                    cboVitri.SelectedIndex = 4;
                                }
                                else
                                    if (row.Cells[6].Value.ToString() == "6")
                                    {
                                        cboVitri.SelectedIndex = 5;
                                    }
                                    else
                                         if (row.Cells[6].Value.ToString() == "7")
                                            {
                                                cboVitri.SelectedIndex = 6;
                                            }
                                         else
                                            {
                                                cboVitri.SelectedIndex = 7;
                                            }

            }
        }
    }

}