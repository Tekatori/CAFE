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
    public partial class ReFood : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        DataTable datatable;
        SqlDataAdapter da;   
        DataColumn[] key = new DataColumn[1];
        DataSet ds_table;
        private bool condition = true;
        public ReFood()
        {
            InitializeComponent();
            da = new SqlDataAdapter("SELECT * FROM Tablef", cn);
            ds_table = new DataSet();
            da.Fill(ds_table,"tablef");
            key[0] = ds_table.Tables["tablef"].Columns[0];
            ds_table.Tables["tablef"].PrimaryKey = key;


            
        }
        public ReFood(string nameTableFrom)
            : this()
        {
      
            
            txtBan.Text = nameTableFrom;
        }
        private void cbbTable_TextChanged(object sender, EventArgs e)

        {

            
        }

        private void cbbFood_TextChanged(object sender, EventArgs e)
        {
           
            cbbCount.Value = int.Parse(datatable.Rows[cbbFood.SelectedIndex][6].ToString());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbbCountReF.Value <= cbbCount.Value && condition == true && cbbFood.Text != "")
            {
                DialogResult ms = MessageBox.Show("Bạn có muốn bỏ " + cbbCountReF.Text + " món " + cbbFood.Text + " ở bàn " + txtBan.Text + " không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (ms == DialogResult.Yes)
                {
                    //Bo mon
                    reFood();
                    MessageBox.Show("Đã bỏ món thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (ms == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không thể giảm món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //sua bill
        private void reFood()
        {
            //sua bill
            cn.Open();
            int count = Int16.Parse((cbbCount.Value - cbbCountReF.Value).ToString());
            float total = float.Parse((float.Parse(txtTotal.Text) - float.Parse(datatable.Rows[cbbFood.SelectedIndex][2].ToString()) * (float)cbbCountReF.Value).ToString());

            //SqlDataAdapter kt_count = new SqlDataAdapter("select * from dbo.getCountsBill (N'" + txtBan.Text+ ", N'" +cbbFood.Text+ "'", cn);
            //DataTable dt_count = new DataTable();
            SqlDataAdapter kt_count = new SqlDataAdapter("select COUNTS FROM BILL WHERE NAMEFOOD=N'" + cbbFood.Text + "' AND NAMETABLE=N'" + txtBan.Text + "'", cn);
            DataTable dt_count = new DataTable();
            kt_count.Fill(dt_count);
            if (dt_count.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("DeleteBill", cn);
                cmd.Parameters.AddWithValue("@NAMEFOOD", cbbFood.Text);
                cmd.Parameters.AddWithValue("@NAMETABLE", txtBan.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("UpdateBill", cn);
                cmd2.Parameters.AddWithValue("@NAMEFOOD", cbbFood.Text);
                cmd2.Parameters.AddWithValue("@NAMETABLE", txtBan.Text);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.ExecuteNonQuery();


            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select * FROM dbo.getIDBill (N'" + cbbFood.Text + "', N'" + txtBan.Text + "')", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SqlCommand cmd = new SqlCommand("UpdateBillCount", cn);
                cmd.Parameters.AddWithValue("@COUNTS", count);
                cmd.Parameters.AddWithValue("@ID", int.Parse(dt.Rows[0][0].ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("UpdateBill", cn);
                cmd2.Parameters.AddWithValue("@NAMEFOOD", cbbFood.Text);
                cmd2.Parameters.AddWithValue("@NAMETABLE", txtBan.Text);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.ExecuteNonQuery();
            }


            cn.Close();
        }


        //Huy bo
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlDataAdapter da_tbill;
        //DataTable dsbill;
        private void ReFood_Load(object sender, EventArgs e)
        {
            DataRow dr = ds_table.Tables["tablef"].Rows.Find(txtBan.Text);
            if (dr != null)
            {
                txtTotal.Text = dr["TOTAL"].ToString();
            }
            da_tbill = new SqlDataAdapter("SELECT * FROM dbo.getTableF_Food (N'" + txtBan.Text + "')", cn);
        
            datatable = new DataTable();
            da_tbill.Fill(datatable);


            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                cbbFood.Items.Add(datatable.Rows[i][5].ToString());
            }
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

   

        private void txtprice_Click(object sender, EventArgs e)
        {

        }
        private void txtprice_TextChanged(object sender, EventArgs e)
        {
           
        }
 
   

     

    }
}
