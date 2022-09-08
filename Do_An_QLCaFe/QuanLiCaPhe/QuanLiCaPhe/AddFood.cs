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
    public partial class AddFood : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        bool isFood = false;
        SqlDataAdapter da_BILL;
        DataSet ds_BILL;
        DataColumn[] key = new DataColumn[1];
        DataColumn[] key2 = new DataColumn[1];
        public AddFood()
        {
            InitializeComponent();
            string truyVan = "select * from dbo.getBill()";
            da_BILL = new SqlDataAdapter(truyVan, cn);
            ds_BILL = new DataSet();
            da_BILL.Fill(ds_BILL, "bill");
            key[0] = ds_BILL.Tables["bill"].Columns[0];
            ds_BILL.Tables["bill"].PrimaryKey = key;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

        }
        public AddFood(string nameT, string nameF, string sttT)
            : this()
        {
            loadFood();
            //chon gia tri goi y
            txtBan.Text = nameT;
            cbbFood.Text = nameF;
            txtSTT.Text = sttT;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ham load thong tin
        private void loadFood()
        {
      
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getThongKeFood()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbbFood.Items.Add(table.Rows[i][0].ToString());
            }
        }

        //Ham Mở bàn
        SqlDataAdapter da_TableF;
        DataSet ds_TableF;
        public void openTable()
        {


            da_TableF = new SqlDataAdapter("select * from dbo.getTableF()", cn);
            ds_TableF = new DataSet();
            da_TableF.Fill(ds_TableF, "tablef");
            key2[0] = ds_TableF.Tables["tablef"].Columns[0];
            ds_TableF.Tables["tablef"].PrimaryKey = key2;
            DataRow dr = ds_TableF.Tables["tablef"].Rows.Find(txtBan.Text);
            if (dr != null)
            {
                dr["STT"] = "ONLINE";
            }

            SqlCommandBuilder cmdb = new SqlCommandBuilder(da_TableF);
            da_TableF.Update(ds_TableF, "tablef");
            ds_TableF.AcceptChanges();
        }
 
        //Them mon moi
        public void addFood()
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("InsertBill", cn);
            cm.Parameters.AddWithValue("@NAMETABLE", txtBan.Text);
            cm.Parameters.AddWithValue("@NAMEFOOD", cbbFood.Text);
            cm.Parameters.AddWithValue("@COUNTS", int.Parse(cbbCount.Value.ToString()));
           
            cm.CommandType = CommandType.StoredProcedure;

            int rowCount = cm.ExecuteNonQuery();

            cn.Close();

            setTotal();
        }
        //Tang so luong mon len
        public void addCountFood()
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("updatecount", cn);
            cm.Parameters.AddWithValue("@NAMEFOOD", cbbFood.Text);
            cm.Parameters.AddWithValue("@NAMETABLE", txtBan.Text);
            cm.Parameters.AddWithValue("@Cadd", int.Parse(cbbCount.Value.ToString()));
            cm.CommandType = CommandType.StoredProcedure;

            cm.ExecuteNonQuery();
            cn.Close();
            setTotal();
        }
 
        //khi nhan nut chap nhan them mon
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiem tra ban trong k
                if (txtSTT.Text == "TRONG")
                {
                    //Neu ban trong thi mo ban moi va them mon
                    openTable();
                    addFood();
                    this.Close();
                }
                else if (txtSTT.Text == "ONLINE")
                {
                    //Ban dang hoat dong. chi them mon
                    isCountFood();
                    
                    if (isFood == false)
                    {
                        //Neu mon chua co thi them mon
                        addFood();
                        this.Close();
                    }
                    else
                    {
                        addCountFood();
                        this.Close();
                    }
                }
                MessageBox.Show("Thêm món thành công!", "Đã thêm",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Thêm món không thành công!", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        public void isCountFood()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getCountsBill (N'" + txtBan.Text + "',N'"+cbbFood.Text+"')", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                isFood = true;
            }
            else
            {
                isFood = false;
            }
            cn.Close();
        }


        //Ham tra ve don gia mon hien tai
        private float getDonGia()
        {

            DataTable table = getPrice(cbbFood.Text);
            return int.Parse(table.Rows[0][0].ToString());
           
        }
        public DataTable getPrice(string NAMEFood)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getFoodPrice (N'" + NAMEFood+"')", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();
            return table;
        }
        //Set Tong tien
        private void setTotal()
        {
            float total = getDonGia() * (float)cbbCount.Value;

            da_TableF = new SqlDataAdapter("select * from dbo.getTableF()", cn);
            ds_TableF = new DataSet();
            da_TableF.Fill(ds_TableF, "tablef");
            key2[0] = ds_TableF.Tables["tablef"].Columns[0];
            ds_TableF.Tables["tablef"].PrimaryKey = key2;


            DataRow dr = ds_TableF.Tables["tablef"].Rows.Find(txtBan.Text);
            if (dr != null)
            {
                dr["TOTAL"] =float.Parse(dr["TOTAL"].ToString()) + float.Parse(total.ToString());
            }
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da_TableF);
            da_TableF.Update(ds_TableF, "tablef");
            ds_TableF.AcceptChanges();
        }

        private void frmAddFood_Load(object sender, EventArgs e)
        {

        }
    }
}
