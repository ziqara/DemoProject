using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib.DataModel.Clients;

namespace DemoLib.Views
{
    public interface IClientView
    {
        void ShowClientInfo(Client client);

        Client GetClientInfo();

        void ShowView();
        void HideView();
    }
}
