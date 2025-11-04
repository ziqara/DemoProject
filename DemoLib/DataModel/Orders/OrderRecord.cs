using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.DataModel.Orders
{
    public class OrderRecord
    {
        [DisplayName("Товар")]
        public string NameProduct { get; set; }

        [DisplayName("Дата заказа")]
        public DateTime SaleDate { get; set; }

        [DisplayName("Цена")]
        public double Price { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Стоимость")]
        public double Cost { get { return Price * Count; } }
    }
}
