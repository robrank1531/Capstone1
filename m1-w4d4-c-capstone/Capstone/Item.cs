using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Item
    {
        private decimal price = 0;
        public string Slot
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public int Quantity
        {
            get;
            set;
        }
        private List<Item> inventory = new List<Item>();
        public List<Item> Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }
    }
}
