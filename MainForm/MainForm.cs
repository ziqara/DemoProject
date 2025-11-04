using System;
using System.Collections.Generic;
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
        public MainForm(User user)
        {
            currentUser_ = user;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MySQLClientsModel model = new MySQLClientsModel();

            allClients_ = model.ReadAllClients();
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
    }
}
