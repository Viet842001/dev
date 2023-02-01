using Dapper;
using DevExpress.PivotGrid.ServerMode.OperationGraph;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DevExpress
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill the SqlDataSource asynchronously
            sqlDataSource2.FillAsync();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill the SqlDataSource asynchronously
            sqlDataSource3.FillAsync();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Model.Order obj = orderBindingSource.Current as Model.Order;
            
            if(obj != null)
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }
                    string query = "select OrderDetailId,OrderId,ProductCode,ProductName,Qty,Price,UnitPrice from OrderDetail_TB " +
                        $"Where OrderId='{obj.OrderId}'";
                    List<Model.OrderDetail> list = db.Query<Model.OrderDetail>(query, commandType: CommandType.Text).ToList();
                    using (FormPrint frm = new FormPrint())
                    {
                        frm.Print(obj, list);
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            //Code su dung cho viec sai model de luu du lieu tu database
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                string query = "select * from Order_TB";
                orderBindingSource.DataSource = db.Query<Model.Order>(query, commandType: CommandType.Text);
            }
        }
    }
}