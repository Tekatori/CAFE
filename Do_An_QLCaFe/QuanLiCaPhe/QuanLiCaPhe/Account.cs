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
    public partial class frmAdAccount : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        string oldusername;
        public frmAdAccount()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        private void Account_Load(object sender, EventArgs e)
        {
            load();
        }
        //ham load thong tin
        private void load()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getAccount()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();

            dgvResult.DataSource = table;
        }
        private void clear()
        {
            txtUsername.ResetText();
            txtDisplayname.ResetText();
            txtPassword.ResetText();
            ckbAdmin.Checked = false;
        }
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                txtUsername.Text = row.Cells[0].Value.ToString();
                oldusername = row.Cells[0].Value.ToString();
                txtDisplayname.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "ADMIN")
                    ckbAdmin.Checked = true;
                else if (row.Cells[3].Value.ToString() == "CASHIER")
                    ckbAdmin.Checked = false;
            }
        }

        //Them tai khoan
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string displayname = txtDisplayname.Text;
                string password = txtPassword.Text;
                string type="CASHIER";
                if (ckbAdmin.Checked == true)
                {
                    type = "ADMIN";        //admin 
                }
                cn.Open();
                SqlCommand cm = new SqlCommand("InsertAccount", cn);
                cm.Parameters.AddWithValue("@USERNAME", username);           
                cm.Parameters.AddWithValue("@DISPLAYNAME", displayname);
                cm.Parameters.AddWithValue("@PASSWORD", password);     
                cm.Parameters.AddWithValue("@TYPEACCOUNT", type);
                cm.CommandType = CommandType.StoredProcedure;

                int rowCount = cm.ExecuteNonQuery();
                cn.Close();


                MessageBox.Show("Thêm thành công!\n Tài khoản "+displayname+" đã được thêm.", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                clear();
            }
            catch
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoa tai khoan
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa tài khoản " + oldusername + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    string username = txtUsername.Text;
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteAccount", cn);
                    cmd.Parameters.AddWithValue("@USERNAME", username);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Xóa thành công!\n Tài khoản " + username + " đã được xóa.", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    clear();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua tai khoan
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string newusername = txtUsername.Text;
                string newdisplayname = txtDisplayname.Text;
                string newpassword = txtPassword.Text;
                string type="CASHIER";
                if (ckbAdmin.Checked == true)
                {
                    type = "ADMIN";
                }
                cn.Open();
                SqlCommand cm = new SqlCommand("UpdateAccount", cn);
                cm.Parameters.AddWithValue("@USERNAME", newusername);
                cm.Parameters.AddWithValue("@DISPLAYNAME", newdisplayname);
                cm.Parameters.AddWithValue("@PASSWORD", newpassword);
                cm.Parameters.AddWithValue("@TYPEACCOUNT", type);
                cm.CommandType = CommandType.StoredProcedure;

                int rowCount = cm.ExecuteNonQuery();
                cn.Close();


                MessageBox.Show("Chỉnh sửa thành công!\n Tài khoản " + oldusername + " đã chỉnh sửa.", "Đã sửa",MessageBoxButtons.OK,MessageBoxIcon.Information);
                load();
                clear();
            }
            catch
            {
                MessageBox.Show("Không sữa được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
