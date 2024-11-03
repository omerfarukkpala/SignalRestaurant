using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class TableDetail
    {
        public int TableDetailID { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Basket>? Baskets { get; set; }
    }
}
