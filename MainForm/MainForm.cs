using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using ClientCard;
using DemoLib.DataModel.Clients;
using DemoLib.DataModel.Users;
using DemoLib.Models.Clients;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private List<Client> allClients_ = new List<Client>();
        private User currentUser_ = null;
        private MySQLClientsModel model_;
        public MainForm(User user)
        {
            currentUser_ = user;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            model_ = new MySQLClientsModel();

            allClients_ = model_.ReadAllClients(); 
            ShowClients(allClients_);
        }

        private void ShowClients(List<Client> clients)
        {
            ClientsListBox.DataSource = null;
            ClientsListBox.DataSource = clients;
            ClientsListBox.DisplayMember = "Name";
        }

        private void ClientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ClientsListBox.SelectedItem;
            if (item == null)
            {
                return;
            }

            Client client = item as Client;
            if (client == null)
            {

                return;
            }

            cardClient.ShowClientInfo(client);
        }


        private void FilterAndSearch()
        {
            if (IsNotSettedFilterAndSearch())
            {
                ShowClients(allClients_);
                return;
            }

            string searchingText = SearchByNameTextBox.Text; // это условие поиска
            string alphabetText = AlphabetComboBox.Text; // это условие фильтра


            List<Client> resultClients = new List<Client>();
            foreach (Client client in allClients_)
            {
                if ((String.IsNullOrEmpty(searchingText)
                     || client.Name.ToLower().Contains(searchingText.ToLower()))
                    && (String.IsNullOrEmpty(alphabetText)
                     || client.Name[0] == alphabetText[0]))
                {
                    resultClients.Add(client);
                }
            }

            ShowClients(resultClients);
        }

        private bool IsNotSettedFilterAndSearch()
        {
            return string.IsNullOrEmpty(AlphabetComboBox.Text)
                        && string.IsNullOrEmpty(SearchByNameTextBox.Text);
        }

        private void AlphabetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAndSearch();
        }

        private void AlphabetComboBox_TextChanged(object sender, EventArgs e)
        {
            FilterAndSearch();
        }

        private void SearchByNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterAndSearch();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddClientForm addForm = new AddClientForm(model_, 0, null);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                model_.AddClient(addForm.GetNewClient());
                allClients_.Clear();
                allClients_ = model_.ReadAllClients();
                ShowClients(allClients_);
            }

            if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var item = ClientsListBox.SelectedItem;
            if (item == null)
            {
                return;
            }

            Client client = item as Client;
            if (client == null)
            {
                return;
            }
            AddClientForm addForm = new AddClientForm(model_, 1, client);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                model_.EditClient(addForm.GetNewClient());
                allClients_.Clear();
                allClients_ = model_.ReadAllClients();
                ShowClients(allClients_);
            }

            if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var item = ClientsListBox.SelectedItem;
            if (item == null)
            {
                return;
            }

            Client client = item as Client;
            if (client == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить клиента {client.Name}?", "Подтверждение удаления",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                model_.RemoveClient(client);
                allClients_.Clear();
                allClients_ = model_.ReadAllClients();
                ShowClients(allClients_);
                ClientsListBox.SelectedIndex = 0;
            }
        }
    }
}
