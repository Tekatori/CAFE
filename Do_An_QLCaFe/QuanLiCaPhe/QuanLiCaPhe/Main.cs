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
using System.IO;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
namespace QuanLiCaPhe
{   //partial
    public partial class Main : Form
    {
        string strBill;
        private string username;
        private string password;

        string DisplayName;
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public Main()
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            loaddataTable();
            loaddataCategory();
        }
         public Main(string user, string name, string pass, string type) : this()
        {
            username = user;
            password = pass;
            DisplayName = name;
   
        
            if (type == "ADMIN")
            {
             
                tmiAdmin.Visible = true;
                tmiThongke.Visible = true;  
            }
        }
        private void loaddataTable()
        {
            try
            {
                
                pnlTable.Controls.Clear();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getTable()", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                //DataTable table = provider.loadTableF();
                int x = 10;
                int y = 10;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnTable" + i,
                        Text = dt.Rows[i][0].ToString(),
                        Tag = dt.Rows[i][2].ToString(),
                        Width = 100,
                        Height = 50,
                        Location = new Point(x, y),
                    };

                    if (dt.Rows[i][1].ToString() == "TRONG")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("snow");

                        btn.ContextMenuStrip = cmnSubTable2;
                    }
                    else if (dt.Rows[i][1].ToString() == "ONLINE")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("lime");

                        btn.ContextMenuStrip = cmnSubTable;
                    }
                    else if (dt.Rows[i][1].ToString() == "DATTRUOC")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("red");

                        btn.ContextMenuStrip = cmnSubTable3;
                    }

                    if (x < pnlTable.Width - 220)
                    {
                        x += 110;
                    }
                    else
                    {
                        x = 10;
                        y += 60;
                    }
                    btn.MouseClick += new MouseEventHandler(btnTable_MouseClick);
                    btn.MouseHover += new EventHandler(btnTable_MouseHover);
                    pnlTable.Controls.Add(btn);
                    
                }
            }
            catch
            {
                MessageBox.Show("Không thể tải bàn!", "Lỗi...");
            }
        }
        public void loaddataBill()
        {
            try
            {
                pnlBill.Controls.Clear();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getBillDK(N'" + txtNameTable.Text+"')", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                strBill = "";
                int y = 10;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    strBill += (i + 1) + ".     " + dt.Rows[i][2].ToString() + "  X  " + dt.Rows[i][3].ToString() + "\n";
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,

                        Text = (i + 1) + ".     " + dt.Rows[i][2].ToString() + "  X  " + dt.Rows[i][3].ToString(),
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
        private void loaddataCategory()
        {
            try
            {
                pnlCategory.Controls.Clear();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getCategory()", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cn.Close();
                int x = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnFood" + i,
                        Text = table.Rows[i][0].ToString(),
                        Width = 120,
                        Height = pnlCategory.Height - 40,
                        Location = new Point(x, pnlCategory.Location.Y - 20),
                        BackColor = ColorTranslator.FromHtml("Snow"),
                    };
                    x += 130;
                    pnlCategory.Controls.Add(btn);
                    btn.Click += new EventHandler(btnCategory_Click);
                }

                loaddataFood(table.Rows[0][0].ToString());

            }
            catch
            {
            }
        }
        private void loaddataFood(string nameCategory)
        {
            try
            {

                pnlFood.Controls.Clear();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM  dbo.getFood(N'" + nameCategory.ToString() + "')", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                cn.Close();
                txtNameFood.Text = table.Rows[0][0].ToString();
                txtPriceFood.Text = table.Rows[0][2].ToString();
                int y = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnFood" + i,
                        Text = table.Rows[i][0].ToString(),
                        Tag = table.Rows[i][2].ToString(),
                        Width = pnlFood.Width - 40,
                        Height = 50,
                        Location = new Point(pnlFood.Location.X, y),
                        BackColor = ColorTranslator.FromHtml("Snow"),
                    };
                    y += 60;
                    btn.Click += new EventHandler(btnFB_Click);
                    pnlFood.Controls.Add(btn);

                }
            }
            catch
            {
            }
        }
        private void btnTable_MouseHover(object sender, EventArgs e)
        {
            ClickTable(sender, e);
        }
        private void btnTable_MouseClick(object sender, EventArgs e)
        {
            ClickTable(sender, e);
        }
        private void ClickTable(object sender, EventArgs e)
        {

            if (((Button)sender).BackColor.ToString() == "Color [Snow]")
            {
                txtSTT.Text = "TRONG";
            }
            else if (((Button)sender).BackColor.ToString() == "Color [Lime]")
            {
                txtSTT.Text = "ONLINE";
            }
            else if (((Button)sender).BackColor.ToString() == "Color [Red]")
            {
                txtSTT.Text = "DATTRUOC";
            }

            txtNameTable.Text = ((Button)sender).Text;

            txtTotal.Text = ((Button)sender).Tag.ToString();
            loaddataBill();
        }
        private void btnCategory_Click(object sender, EventArgs e)
        {
            string nameCate = ((Button)sender).Text;

            loaddataFood(nameCate);
        }
        
        private void btnFB_Click(object sender, EventArgs e)
        {
            txtNameFood.Text = ((Button)sender).Text;
            txtPriceFood.Text = ((Button)sender).Tag.ToString();
        }
        private void tmiCategory_Click(object sender, EventArgs e)
        {
        
        }
        private void tmiFood_Click(object sender, EventArgs e)
        {
          
        }
        private void tmiTable_Click(object sender, EventArgs e)
        {
        }
        private void tmiAccount_Click(object sender, EventArgs e)
        {
           
        }
        private void gpbTable_SizeChanged(object sender, EventArgs e)
        {
            loaddataTable();
        }
        private void btnReplaceTable_Click(object sender, EventArgs e)
        {

        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            AddFood();
        }
        private void AddFood()
        {
            try
            {
                if (txtSTT.Text == "ONLINE")
                {
                    AddFood addF = new AddFood(txtNameTable.Text, txtNameFood.Text, txtSTT.Text);
                    addF.ShowDialog();
                    this.Show();
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "DATTRUOC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRONG")
                {
                    DialogResult ms = MessageBox.Show("Bàn này đang trống. Mở bàn nhé?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ms == DialogResult.Yes)
                    {
                        AddFood addF = new AddFood(txtNameTable.Text, txtNameFood.Text, txtSTT.Text);
                        addF.ShowDialog();
                        this.Show();
                        loaddataTable();
                        loaddataBill();
                    }
                }
            }
            catch { }

        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            PayFood();
        }
        private void PayFood()
        {
            try
            {
                if (txtSTT.Text == "ONLINE")
                {
                    Pay addF = new Pay(txtNameTable.Text);
                    addF.ShowDialog();
                    this.Show();
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "DATTRUOC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRONG")
                {
                    MessageBox.Show("Bàn này đang trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }
        private void ReplaceTable()
        {

        }
        private void btnPlusTable_Click(object sender, EventArgs e)
        {

        }
        private void PlusTable()
        {

        }
    
        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnFood();
        }
        private void ReturnFood()
        {
            try
            {
                if (txtSTT.Text == "ONLINE")
                {
                    ReFood addF = new ReFood(txtNameTable.Text);
                    addF.ShowDialog();
                    this.Show();
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "DATTRUOC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRONG")
                {
                    MessageBox.Show("Bàn này đang trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }
        private void btnBlock_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddFood frm = new frmAddFood();
                frm.ShowDialog();
                this.Show();
                loaddataCategory();
            }
            catch { }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }
        private void tmiChange_Click(object sender, EventArgs e)
        {

        }
        private void tmiLogout_Click(object sender, EventArgs e)
        {

        }
        private void cmnSubTable_Opening(object sender, CancelEventArgs e)
        {
        }
        private void cmnSubTable2_Opening(object sender, CancelEventArgs e)
        {
        }
        private void tsmThemMon_Click(object sender, EventArgs e)
        {
            AddFood();
        }
        private void tsmTraMon_Click(object sender, EventArgs e)
        {
            ReturnFood();
        }
        private void tsmThanhToan_Click(object sender, EventArgs e)
        {
            PayFood();
        }
        private void tsmChuyenBan_Click(object sender, EventArgs e)
        {
            ReplaceTable();
        }
        private void tsmGopBan_Click(object sender, EventArgs e)
        {
            PlusTable();
        }
   
        private void tmsThemMon2_Click(object sender, EventArgs e)
        {
            AddFood();
        }

        private void tsmDatBan_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cm = new SqlCommand("updatePreTable", cn);
                cm.Parameters.AddWithValue("@TableName", txtNameTable.Text);
                cm.CommandType = CommandType.StoredProcedure;
                cm.ExecuteNonQuery();

                cn.Close();
                loaddataTable();
            }
            catch { }
        }
        private void cmnSubTable3_Opening(object sender, CancelEventArgs e)
        {
        }

        private void tsmMoBan_Click(object sender, EventArgs e)
        {
            try
            {
         

                cn.Open();
                SqlCommand cm = new SqlCommand("openTable", cn);
                cm.Parameters.AddWithValue("@TableName", txtNameTable.Text);
                cm.CommandType = CommandType.StoredProcedure;
                cm.ExecuteNonQuery();
                cn.Close();
                loaddataTable();
            }
            catch { }
        }
        //string[] filenames, filepaths;
        private void btnAddMedia_Click(object sender, EventArgs e)
        {

        }
        private void lbMedia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlBill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void danhSachNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tmiCategory_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmAdCategory frm = new frmAdCategory();
                frm.ShowDialog();
                this.Show();
                loaddataCategory();
            }
            catch { }
        }

        private void tmiFood_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmAddFood frm = new frmAddFood();
                frm.ShowDialog();
                this.Show();
                loaddataCategory();
            }
            catch { }
        }

        private void tmiTable_Click_1(object sender, EventArgs e)
        {

            try
            {
                frmAdTables frm = new frmAdTables();
                frm.ShowDialog();
                this.Show();
                loaddataTable();
            }
            catch { }
        }

        private void tmiAccount_Click_1(object sender, EventArgs e)
        {

            try
            {
                frmAdAccount frm = new frmAdAccount();
                frm.ShowDialog();
                this.Show();
            }
            catch { }
        }

        private void tmiPeople_Click(object sender, EventArgs e)
        {

            try
            {
                frmNhanvien frm = new frmNhanvien();
                frm.ShowDialog();
                this.Show();
            }
            catch { }
        }

        private void tmiChange_Click_1(object sender, EventArgs e)
        {
            try
            {
                ChangePersional addF = new ChangePersional(username, DisplayName, password);
                addF.ShowDialog();
                this.Show();
                loaddataTable();
                loaddataBill();
                tmiChange.Enabled = false;
                
            }
            catch
            {
                MessageBox.Show("Không thể thay đổi thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tmiLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login frmlog  = new Login();
            frmlog.ShowDialog();
        }

        private void gpbFood_Enter(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            skin();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        private void btnMedia_Click(object sender, EventArgs e)
        {

        }
       public void ExportToExcel(DataTable dataTable, string ExcelFilePath)
        {
            try
            {
            int ColumnsCount;

            if (dataTable == null || (ColumnsCount = dataTable.Columns.Count) == 0)
            throw new Exception("ExportToExcel: Null or empty input table!\n");

            // create a new workbook
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbooks.Add(System.Reflection.Missing.Value);

            object misValue = System.Reflection.Missing.Value;

            // single worksheet
            Microsoft.Office.Interop.Excel._Worksheet Worksheet = (Microsoft.Office.Interop.Excel._Worksheet)Excel.ActiveSheet;

            object[] Header = new object[ColumnsCount];

            // column headings
            for (int i = 0; i < ColumnsCount; i++)
            Header[i] = dataTable.Columns[i].ColumnName;

            Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
            HeaderRange.Value2 = Header;
            HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            HeaderRange.Font.Bold = true;

            // DataCells
            int RowsCount = dataTable.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];

            for (int j = 0; j < RowsCount; j++)
            {
                for (int i = 0; i < ColumnsCount; i++)
                {
                    Cells[j, i] = dataTable.Rows[j][i];
                }
               
            }
            

            Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value2 = Cells;

            // check fielpath
            if (ExcelFilePath != null && ExcelFilePath !="" )
            {
            try
            {
                Worksheet.SaveAs(ExcelFilePath, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);

                Excel.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                + ex.Message);
            }
            }
            else // no filepath is given
            {
                Excel.Visible = true;
            }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
       }
        private void tmiNhanvien_Click(object sender, EventArgs e)
        {
           
        }
        //ham xuat txt
        public void CreateCSVFile(DataTable dt, string strFilePath)
        {
            try
            {
                
                StreamWriter sw = new StreamWriter(strFilePath, false);
                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);

        

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }

                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tmiMenu_Click(object sender, EventArgs e)
        {
            
        }

        public void skin()
        {
          
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void pnlFood_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        private void gpbTable_Enter(object sender, EventArgs e)
        {

        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from getNV()", cn);
                DataTable tb = new DataTable();
                da.Fill(tb);
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string a;
                    a = tb.Rows[0][2].ToString();
                    tb.Rows[0][2] = a;
                }
                string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                string path = deskDir + "\\ThongKeNhanVien.xlsx";

                ExportToExcel(tb, path);
                MessageBox.Show("Thống Kê Nhân Viên Thành Công Mời Bạn ra Desktop Xem File!", "Hoàn Thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void excelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from getThongKeFood()", cn);
                DataTable tb = new DataTable();
                da.Fill(tb);
                string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                string path = deskDir + "\\ThongKeMonAn.xlsx";

                ExportToExcel(tb, path);
                MessageBox.Show("Thống Kê Món Ăn Thành Công Mời Bạn ra Desktop Xem File!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void reportViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportNV frmReportNV = new frmReportNV();
            frmReportNV.ShowDialog();  
        }

        private void reportViewerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportFood frmReportFood = new frmReportFood();
            frmReportFood.ShowDialog();
        }

        private void backupAndRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup_Restore  frmbackup   = new Backup_Restore();
            frmbackup.ShowDialog();
        }
    }


}
