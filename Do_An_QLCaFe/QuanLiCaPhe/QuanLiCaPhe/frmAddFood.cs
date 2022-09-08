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
    public partial class frmAddFood : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        string oldname;
        SqlDataAdapter da_Food;
        DataSet ds_Food;
        DataColumn[] key = new DataColumn[1];
        public frmAddFood()
        {
            InitializeComponent();
            string truyVan = "select * from dbo.getThongKeFood()";
            da_Food = new SqlDataAdapter(truyVan, cn);
            ds_Food = new DataSet();
            da_Food.Fill(ds_Food, "food");
            key[0] = ds_Food.Tables["food"].Columns[0];
            ds_Food.Tables["food"].PrimaryKey = key;
        }
        private void frmAddFood_Load(object sender, EventArgs e)
        {
            load();
            setNameCategory();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        private void setNameCategory()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getCategory()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbbAddCate.Items.Add(table.Rows[i][0].ToString());
            }
        }
        private void load()
        {
            try
            {
                dgvResult.DataSource = ds_Food.Tables[0];
            }
            catch
            {
                MessageBox.Show("Tải không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clear()
        {
            txtAddName.ResetText();
            cbbAddCate.ResetText();
            nudAddPrice.Value = 1000;
            cbbAddCate.Focus();
        }
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                    txtAddName.Text = row.Cells[0].Value.ToString();
                    oldname = row.Cells[0].Value.ToString();
                    cbbAddCate.Text = row.Cells[1].Value.ToString();
                    nudAddPrice.Value = Int32.Parse(row.Cells[2].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lỗi data!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newrow = ds_Food.Tables[0].NewRow();
                newrow["NAME"] = txtAddName.Text;
                newrow["NAMECATEGORY"] = cbbAddCate.Text;
                newrow["PRICE"] = Convert.ToInt64(nudAddPrice.Value);
                ds_Food.Tables[0].Rows.Add(newrow);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da_Food);
                da_Food.Update(ds_Food, "Food");

                MessageBox.Show("Thêm thành công", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                load();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Xoa mon
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    DataRow dr = ds_Food.Tables["food"].Rows.Find(txtAddName.Text);
                    if (dr != null)
                    {
                        dr.Delete();
                    }
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(da_Food);
                    da_Food.Update(ds_Food, "food");
                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    load();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua mon
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string newname = txtAddName.Text;
                string nameCate = cbbAddCate.Text;
                float price = Convert.ToInt32(nudAddPrice.Value);
                DataRow dr = ds_Food.Tables["food"].Rows.Find(txtAddName.Text);
                if (dr != null)
                {
                    dr["NAMECATEGORY"] = cbbAddCate.Text;
                    dr["PRICE"] = Convert.ToInt64(nudAddPrice.Value);
                }
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da_Food);
                da_Food.Update(ds_Food, "food");

                MessageBox.Show("Sửa thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                load();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbAddCate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvResult.SelectedRows)
            {
                txtAddName.Text = row.Cells[0].Value.ToString();
                oldname = row.Cells[0].Value.ToString();
                cbbAddCate.Text = row.Cells[1].Value.ToString();
                nudAddPrice.Value = Int32.Parse(row.Cells[2].Value.ToString());
            }
        }
    }
}
