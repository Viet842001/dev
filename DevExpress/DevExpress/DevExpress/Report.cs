using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace DevExpress
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Report()
        {
            InitializeComponent();
        }

        public void InitData(string orderid, string customername, string address, List<Model.OrderDetail> list)
        {
            pOrderId.Value = orderid;
            pDate.Value = DateTime.Today.ToString("dd-MM-yyyy");
            pCustomerName.Value = customername;
            pAddress.Value = address;
            objectDataSource1.DataSource = list;
        }
    }
}
