using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLiCaPhe
{
    public partial class frmReportNV : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9R357LN;Initial Catalog=QL_QUANCAFE;Integrated Security=True");
        public frmReportNV()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void frmReportNV_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLiCaPhe.ReportNV.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = getNV();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable getNV()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.getNV1()", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cn.Close();
            return table;
        }
    }
}
