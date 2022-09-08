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
namespace QuanLiCaPhe
{
    public partial class ChangePersional : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public ChangePersional()
        {
            InitializeComponent();
        }

        public ChangePersional(string user, string name, string pass)
            : this()
        {
            //load thog tin len
            txtUser.Text = user;
            txtName.Text = name;
            txtPass.Text = pass;

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                Save(txtUser.Text, txtName.Text, txtPass.Text);
                MessageBox.Show("Đã thay đổi", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Thông tin không hợp lệ", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save(string user, string name, string pass)
        {

            cn.Open();
            SqlCommand cm = new SqlCommand("UpdateAccountInfo", cn);
            cm.Parameters.AddWithValue("@PASSWORD", pass);
            cm.Parameters.AddWithValue("@DISPLAYNAME", name);
            cm.Parameters.AddWithValue("@USERNAME", user);
            cm.CommandType = CommandType.StoredProcedure;

            int rowCount = cm.ExecuteNonQuery();
            cm.ExecuteNonQuery();
            cn.Close();
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ChangePersional_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
    }
}
