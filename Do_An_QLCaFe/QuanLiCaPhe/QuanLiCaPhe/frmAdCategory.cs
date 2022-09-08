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
    public partial class frmAdCategory : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public frmAdCategory()
        {
            InitializeComponent();
        }

        private void frmAdCategory_Load(object sender, EventArgs e)
        {
            load();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

        //ham load thong tin
        private void load()
        {
            try
            {
      
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getCategory()", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cn.Close();
                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Không thể tải dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Them moi
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
           
                    cn.Open();
              
                    SqlCommand cm = new SqlCommand("InsertCategory", cn);
                    cm.Parameters.AddWithValue("@NAME", lblText.Text);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();



                    cn.Close();



                    MessageBox.Show("Thêm thành công!", "Đã thêm",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtName.ResetText();
                    load();
                }
                else
                {
                    MessageBox.Show("Tên mới trống!", "Thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Khi click chon => datagidview
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            load();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                    lblText.Text = row.Cells[0].Value.ToString();
                    
                }
            }
            catch
            {
                MessageBox.Show("Lỗi data!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Xoa 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
              
                    cn.Open();
                    SqlCommand cm = new SqlCommand("DeleteCategory", cn);
                    cm.Parameters.AddWithValue("@NAME", lblText.Text);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();



                    cn.Close();


                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không thể xóa danh mục này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cHINH SUA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchCategory(N'" + txtName.Text + "')", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cn.Close();
                dgvResult.DataSource = table;
            }
            else
            {
                load();
            }
            
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
