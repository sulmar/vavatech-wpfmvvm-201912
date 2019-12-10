using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Vavatech.Shop.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount => Details.Sum(d => d.DetailAmount);
        public IEnumerable<OrderDetail> Details { get; set; }

        public Order()
        {
            foreach (var detail in Details)
            {
                detail.PropertyChanged += Detail_PropertyChanged;
            }
        }

        private void Detail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OrderDetail.DetailAmount))
            {
                OnPropertyChanged(nameof(TotalAmount));
            }
        }
    }

    public class OrderDetail : BaseEntity
    {
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal DetailAmount => UnitPrice * Quantity;
    }
}
