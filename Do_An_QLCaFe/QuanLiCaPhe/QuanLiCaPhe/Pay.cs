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
    public partial class Pay : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public Pay()
        {
            InitializeComponent();
        }
        public Pay(string nameT)
            : this()
        {
            txtNameTable.Text = nameT;
            loadDataForm();
            loadDataBill();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadDataForm()
        {
            
            
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TABLEF where NAME=N'" + txtNameTable.Text + "'", cn);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();
            txtSTT.Text = table.Rows[0][0].ToString();
            txtTotal.Text = table.Rows[0][2].ToString();
        }
        private void loadDataBill()
        {
            try
            {
                //Don rac
                pnlBill.Controls.Clear();
               
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BILL where NAMETABLE=N'" + txtNameTable.Text + "'", cn);
                DataTable table = new DataTable();
                da.Fill(table);
                cn.Close();
                //Load thong tin cac mon trong bill 
                int y = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,
                        //in ra man hinh tung mon nhu vay no moi dep :)
                        Text = (i + 1) + ".     " + table.Rows[i][2].ToString() + "  X  " + table.Rows[i][3].ToString(),
                        Width = pnlBill.Width - 20,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    y += 25;
                    pnlBill.Controls.Add(lbl);
                }
            }
            catch
            {
            }
        }
        //nhan nut chap nhan thanh toan
        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thanh toán " + txtNameTable.Text + "\nTổng tiền: " + txtTotal.Text + " VNĐ", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            if (ms == DialogResult.Yes)
            {
                //Tih tien
                setTableNull();
                deleteBill();
                MessageBox.Show("Đã thanh toán " + txtNameTable.Text, "Xong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (ms == DialogResult.No)
            {
                this.Close();
            }
        }

        //set ban ve rong
        public void setTableNull()
        {
         
            cn.Open();
            SqlCommand cm = new SqlCommand("UpdateTableNull", cn);
            cm.Parameters.AddWithValue("@NAMETABLE", txtNameTable.Text);
            cm.CommandType = CommandType.StoredProcedure;

            int rowCount = cm.ExecuteNonQuery();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        //Xoa het bill trong ban
        public void deleteBill()
        {
       
            cn.Open();
            SqlCommand cm = new SqlCommand("DeleteBillTable", cn);
            cm.Parameters.AddWithValue("@NAMETABLE", txtNameTable.Text);
            cm.CommandType = CommandType.StoredProcedure;

            int rowCount = cm.ExecuteNonQuery();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Pay_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
    }
}
