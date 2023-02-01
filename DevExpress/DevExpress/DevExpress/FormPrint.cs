using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress
{
    public partial class FormPrint : DevExpress.XtraEditors.XtraForm
    {
        public FormPrint()
        {
            InitializeComponent();
        }


        public void Print(Model.Order order,List<Model.OrderDetail> data)
        {
            //lấy đối tượng report (cái in hóa đơn)
            Report report = new Report();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            report.InitData(order.OrderId.ToString(), order.CustomerName, order.CustomerAddress, data);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}