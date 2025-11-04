using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.DataModel.Users;
using DemoLib.Models.Users;

namespace MainForm
{
    public partial class AuthorizeForm : Form
    {
        private UsersModel model_ = new UsersModel();

        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            loginBox.DataSource = model_.GetAllLogins();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            string login = loginBox.SelectedItem.ToString();
            string password = passwordBox.Text;

            User user = model_.Authorization(login, password);
            if (user != null)
            {
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Пароль неверен. Убедитесь, что:\n• Используется правильный регистр\n• Нет лишних пробелов\n• Выбран правильный пользователь",
                "Не удалось войти",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
