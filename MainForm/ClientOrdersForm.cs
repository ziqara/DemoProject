using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.DataModel.Orders;

namespace MainForm
{
    public partial class ClientOrdersForm : Form
    {
        public ClientOrdersForm()
        {
            InitializeComponent();
        }

        public void SetOrder(Order order)
        {
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = order.GetRecords();
        }
    }
}
