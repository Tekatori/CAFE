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
    public partial class    Login : Form
    {
         SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");


        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private bool CheckDN(string username, string pass)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ktDN('"+ username + "','"+pass+"')", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                cn.Close();
            }
            return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = "", name = "", pass = "", type = "";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.loginDN('" + txtUsername.Text + "','" + txtPassword.Text + "')", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                if (rdbAdmin.Checked == true)
                {
                    type = "ADMIN";
                }
                else
                {
                    type = "CASHIER";
                }
                user = dt.Rows[0][0].ToString();
                name = dt.Rows[0][1].ToString();
                pass = dt.Rows[0][2].ToString();
                if (dt.Rows[0][3].ToString() != type)
                {
                    MessageBox.Show("Tài khoản và mật khẩu không đúng !");
                }
                else if (CheckDN(txtUsername.Text, txtPassword.Text) == true)
                        {
                            
                            Main main = new Main(user, name, pass, type);
                            main.Show();
                            this.Hide();

                        }
                            else
                            {
                                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
                            }
            }
            catch
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
                
        }
    }
}
