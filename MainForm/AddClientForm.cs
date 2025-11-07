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

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Поле 'Имя' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(desBox.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                desBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phoneBox.Text))
            {
                MessageBox.Show("Поле 'Телефон' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneBox.Focus();
                return;
            }

            string phone = phoneBox.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[\d\s\-\+\(\)]+$"))
            {
                MessageBox.Show("Некорректный формат телефона!\nТелефон должен содержать только цифры и символы: - + ( )",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneBox.Focus();
                phoneBox.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(mailBox.Text))
            {
                MessageBox.Show("Поле 'Email' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                mailBox.Focus();
                return;
            }

            string email = mailBox.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email!\nПример: example@mail.ru",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mailBox.Focus();
                mailBox.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath_))
            {
                MessageBox.Show("Необходимо выбрать изображение клиента!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                imageBtn.Focus();
                return;
            }

            if (type_ == 0)
            {
                Client addClient = new Client(model_.GenerateNextID());
                addClient.Name = nameBox.Text;
                addClient.Description = desBox.Text;
                addClient.Phone = phoneBox.Text;
                addClient.Mail = mailBox.Text;
                addClient.ImagePath = selectedImagePath_;
                newClient_ = (Client)addClient;
                DialogResult = DialogResult.OK;
            }

            if (type_ == 1)
            {
                newClient_.Name = nameBox.Text;
                newClient_.Description = desBox.Text;
                newClient_.Phone = phoneBox.Text;
                newClient_.Mail = mailBox.Text;
                newClient_.ImagePath = selectedImagePath_;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
