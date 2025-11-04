using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib.DataModel.Orders;

namespace DemoLib.DataModel.Clients
{
    public class Client
    {
        private int id_;

        public int ID { get { return id_; } }

        public Order order = new Order();

        public string Name { get; set; }
        public string Description { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string ImagePath { get; set; }

        public Client(int id)
        {
            id_ = id;
        }
    }
}
