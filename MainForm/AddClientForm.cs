using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.DataModel.Clients;
using DemoLib.Models.Clients;

namespace MainForm
{
    public partial class AddClientForm : Form
    {
        private Client newClient_;
        private string selectedImagePath_;
        private MySQLClientsModel model_;
        private int type_;

        public AddClientForm(MySQLClientsModel model, int type, Client client)
        {
            InitializeComponent();
            model_ = model;
            type_ = type;
            newClient_ = client;
        }
    }
}
