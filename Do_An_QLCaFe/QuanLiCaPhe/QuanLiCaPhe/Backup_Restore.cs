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
    public partial class Backup_Restore : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");

        public Backup_Restore()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

        private void Backup_Restore_Load(object sender, EventArgs e)
        {

        }

        private void btnBackUpBrowse_Click(object sender, EventArgs e)
        {
         
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = dialog.SelectedPath;
                btnBackup.Enabled = true;
            }    
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {   
            
            string dtb = cn.Database.ToString();
            if (txtBackup.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn vị trí sao lưu dữ liệu!");
            }
            else
            {
                timer1.Start();
                string bak = "Backup Database [" + dtb + "] to Disk= '" + txtBackup.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                cn.Open();
                SqlCommand cmd = new SqlCommand(bak, cn);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Sao lưu dữ liệu thành công");
                cn.Close();
                btnBackup.Enabled = false;

            }




        }

        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Backup files(*.bak)|*.bak";
            dialog.Title = "Phục hồi dữ liệu";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = dialog.FileName;
                btnBackup.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            cn.Open();
            string dtb = cn.Database.ToString();
            
            try
            {
                if (txtRestore.Text == string.Empty)
                    MessageBox.Show("Vui lòng chọn vị trí Restore dữ liệu!");
                else
                {
                    timer2.Start();
                    string res = string.Format("Alter Database [" + dtb + "] set Single_User with Rollback Immediate");
                    SqlCommand cmd1 = new SqlCommand(res, cn);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Use Master restore Database[" + dtb + "] from Disk= '" + txtRestore.Text + "' with replace;", cn);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("Alter Database [" + dtb + "] set Multi_User", cn);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Phục hồi dữ liệu thành công");
                }
            }

            catch
            {
                MessageBox.Show("Phục hồi dữ liệu thất bại", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar2.PerformStep();
        }
    }
}
