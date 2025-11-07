using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.DataModel.Clients;
using DemoLib.DataModel.Orders;
using DemoLib.Models.Clients;

namespace MainForm
{
    public partial class ClientOrdersForm : Form
    {
        private Client client_;
        private MySQLClientsModel model_;
        List<OrderRecord> orders_;
        public ClientOrdersForm(Client client, MySQLClientsModel model)
        {
            InitializeComponent();
            client_ = client;
            model_ = model;
        }

        private void ClientOrdersForm_Load(object sender, EventArgs e)
        {
            RefreshOrdersTable();
            this.Text = "Заказы клиента - " + client_.Name;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddOrderForm addForm = new AddOrderForm();
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                model_.AddOrder(addForm.GetNewRecord(), client_.ID);
                client_.order.AddRecord(addForm.GetNewRecord());
                RefreshOrdersTable();
            }
        }

        private void RefreshOrdersTable()
        {
            OrdersTable.DataSource = null;
            orders_ = client_.order.GetRecords();
            OrdersTable.DataSource = orders_;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
            var row = OrdersTable.CurrentRow;
            var order = row.DataBoundItem as OrderRecord;
            if (order == null)
            {
                MessageBox.Show("Не удалось получить данные заказа", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dr = MessageBox.Show(
                $"Вы уверены, что хотите удалить заказ?\nНаименование: {order.NameProduct}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dr != DialogResult.Yes) 
            { 
                return; 
            }
                

            try
            {
                model_.DeleteOrder(order);
                client_.order.RemoveRecord(order);

                RefreshOrdersTable();

                MessageBox.Show("Заказ успешно удалён", "Готово",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (OrdersTable.Rows.Count > 0)
                    OrdersTable.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sortDownBtn_Click(object sender, EventArgs e)
        {
            List<OrderRecord> sortedOrders = orders_.OrderBy(order => order.Cost).ToList();
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = sortedOrders;
        }

        private void sortUpBtn_Click(object sender, EventArgs e)
        {
            List<OrderRecord> sortedOrders = orders_.OrderByDescending(order => order.Cost).ToList();
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = sortedOrders;
        }

        private void refrezhBtn_Click(object sender, EventArgs e)
        {
            RefreshOrdersTable();
        }
    }
}
