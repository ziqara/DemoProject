using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib.DataModel.Clients;

namespace DemoLib.Models.Clients
{
    public interface IClientsModel
    {
        List<Client> ReadAllClients();

        int GetClientsCount();
    }
}
