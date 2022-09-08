using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLiCaPhe
{
    public partial class frmAdTables : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public frmAdTables()
        {
            InitializeComponent();
        }

        private void frmAdTables_Load(object sender, EventArgs e)
        {
            loadTable();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        //ham load thong tin
        private void loadTable()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getTableF()", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cn.Close();

                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Không thể tải bàn!", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //click vao bang
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvResult.CurrentCell.RowIndex;
            lblText.Text = dgvResult.Rows[t].Cells[0].Value.ToString();
        }

        //Them ban
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if (name != "")
                {
                    cn.Open();
                    SqlCommand cm = new SqlCommand("InsertTableF", cn);
                    cm.Parameters.AddWithValue("@NAME", name);
                    cm.Parameters.AddWithValue("@STT", "TRONG");
                    cm.Parameters.AddWithValue("@TOTAL", 0);
                    cm.CommandType = CommandType.StoredProcedure;

                    int rowCount = cm.ExecuteNonQuery();

                    cn.Close();

                    loadTable();
                    MessageBox.Show("Đã thêm bàn thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tên bàn trống kìa!", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Không thể thêm bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoa ban
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteTableF", cn);
                    cmd.Parameters.AddWithValue("@NAME", lblText.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    loadTable();
                    MessageBox.Show("Đã xóa bàn thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không thể xóa bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua ban
        private void btnEdit_Click(object sender, EventArgs e)
        {
          
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvResult.SelectedRows)
            {

                lblText.Text = row.Cells[0].Value.ToString();
            
            }
        }
    }
}
