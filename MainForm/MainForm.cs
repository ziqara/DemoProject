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
        private User currentUser_ = null;
        private MySQLClientsModel model_;
        private List<Client> allClients_ = new List<Client>();

        public MainForm(User user)
        {
            currentUser_ = user;
            InitializeComponent();

            model_ = new MySQLClientsModel();

            int countClients = 0;
            try
            {
                countClients = model_.GetClientsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Ошибка работы с БД",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // первичная загрузка клиентов (списком)
            try
            {
                allClients_ = model_.ReadAllClients();
                ShowClients(allClients_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Ошибка загрузки клиентов",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ограничения UI по ролям
            if (isLowRoleUser())
            {
                this.SearchByNameTextBox.Enabled = false;
                this.SearchByNameLabel.Text = "Поиск по клиенту Вам недоступен";
                this.SearchByNameLabel.ForeColor = System.Drawing.Color.Red;

                this.AlphabetComboBox.Visible = false;
                this.SearchByNameTextBox.Visible = false;
                this.addBtn.Enabled = false;
                this.editBtn.Enabled = false;
                this.deleteBtn.Enabled = false;
            }

            // отражаем пользователя в заголовке
            if (currentUser_ != null)
            {
                Text = this.Text + " - " + currentUser_.Login + " - " + currentUser_.Role;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool isLowRoleUser()
        {
            /// currentUser_ == null - это гость
            return currentUser_ == null || currentUser_.Role == UserRole.Client;
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

            var client = item as Client;
            if (client == null)
            {
                return;
            }

            cardClient.ShowClientInfo(client);
        }

        private void SearchByNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterAndSearch();
        }

        private void AlphabetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAndSearch();
        }

        private void AlphabetComboBox_TextChanged(object sender, EventArgs e)
        {
            FilterAndSearch();
        }

        private void FilterAndSearch()
        {
            if (IsNotSettedFilterAndSearch())
            {
                ShowClients(allClients_);
                return;
            }

            string searchingText = SearchByNameTextBox.Text; // условие поиска
            string alphabetText = AlphabetComboBox.Text;     // условие фильтра

            List<Client> resultClients = new List<Client>();
            foreach (Client client in allClients_)
            {
                if ((string.IsNullOrEmpty(searchingText)
                        || client.Name.ToLower().Contains(searchingText.ToLower()))
                    && (string.IsNullOrEmpty(alphabetText)
                        || (client.Name != null && client.Name.Length > 0 && client.Name[0] == alphabetText[0])))
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddClientForm addForm = new AddClientForm(model_, 0, null);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    model_.AddClient(addForm.GetNewClient());
                    allClients_.Clear();
                    allClients_ = model_.ReadAllClients();
                    ShowClients(allClients_);
                    if (ClientsListBox.Items.Count > 0)
                        ClientsListBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка добавления клиента",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

            var item = ClientsListBox.SelectedItem;
            if (item == null) return;

            var client = item as Client;
            if (client == null) return;

            AddClientForm addForm = new AddClientForm(model_, 1, client);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    model_.EditClient(addForm.GetNewClient());
                    allClients_.Clear();
                    allClients_ = model_.ReadAllClients();
                    ShowClients(allClients_);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка редактирования клиента",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var item = ClientsListBox.SelectedItem;
            if (item == null) return;

            var client = item as Client;
            if (client == null) return;

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить клиента {client.Name}?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    model_.RemoveClient(client);
                    allClients_.Clear();
                    allClients_ = model_.ReadAllClients();
                    ShowClients(allClients_);
                    if (ClientsListBox.Items.Count > 0)
                        ClientsListBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка удаления клиента",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void cardClient_MouseClick(object sender, MouseEventArgs e)
        {
            var item = ClientsListBox.SelectedItem;
            if (item == null) return;

            var client = item as Client;
            if (client == null) return;

            if (isLowRoleUser())
            {
                MessageBox.Show("У Вас не хватает прав, чтобы посмотреть заказы.\n" +
                                "Обратитесь, пожалуйста, к администратору",
                                "Сообщение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            ClientOrdersForm ordersForm = new ClientOrdersForm(client, model_);
            ordersForm.Text = "Заказы клиента " + client.Name;
            ordersForm.ShowDialog();
        }
    }
}
