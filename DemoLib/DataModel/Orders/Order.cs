using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.DataModel.Orders
{
    public class Order
    {
        private List<OrderRecord> records_ = new List<OrderRecord>();

        public void AddRecord(OrderRecord record)
        {
            records_.Add(record);
        }

        public List<OrderRecord> GetRecords()
        {
            return records_;
        }
    }
}
