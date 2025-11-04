using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.Views;
using DemoLib.DataModel.Clients;
using System.Diagnostics;

namespace ClientCard
{
    public partial class Card: UserControl, IClientView
    {
        private Color defaultColor = Color.FromArgb(255, 255, 255);
        private Color enteringColor = Color.FromArgb(235, 235, 255);
        private Client client_;

        public event Action<Client> SelectedClient;

        public Card()
        {
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                control.MouseEnter += Card_MouseEnter;
                control.MouseLeave += Card_MouseLeave;
            }
        }

        public void ShowClientInfo(Client client)
        {
            client_ = client;

            nameLabel.Text = client.Name;
            descriptionLabel.Text = client.Description;
            phoneLabel.Text = client.Phone;
            mailLabel.Text = client.Mail;
            avatarBox.Load(client.ImagePath);
        }

        public Client GetClientInfo()
        {
            return client_;
        }

        public void HideView()
        {
            Visible = false;
        }

        public void ShowView()
        {
            Visible = true;
        }

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = enteringColor;
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = defaultColor;
        }

        private void Card_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedClient?.Invoke(client_);
        }
    }
}
