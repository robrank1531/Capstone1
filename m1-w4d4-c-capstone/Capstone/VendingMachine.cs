using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class VendingMachine : Item
    {
        private decimal balance = 0;
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public VendingMachine()
        {            
            string inputFile = @"C:\Users\rrankin\team5-c-week4-pair-exercises\m1-w4d4-c-capstone\etc\vendingmachine.csv";
            try
            {
                using (StreamReader sr = new StreamReader(inputFile))
                {                    
                    while (!sr.EndOfStream)
                    {
                        List<Item> tempList = new List<Item>();
                        string line = sr.ReadLine();
                        string[] itemArray = line.Split('|');
                        Item nameItem = new Item();
                        nameItem.Slot = itemArray[0];                        
                        nameItem.Name = itemArray[1];
                        nameItem.Price = Decimal.Parse(itemArray[2]);
                        nameItem.Quantity = 5;
                        Inventory.Add(nameItem);
                    }
                }
            }
            catch { return; }            
        }
        
        public decimal FeedMoney(decimal num)
        {
            balance = balance + num;
            return balance;
            
        }
        public Item FindItem(string item)
        {
            foreach(Item product in Inventory)
            {
                if(product.Slot == item)
                {
                    return product;
                }
                else
                {
                    //product doesnt exist return to purchase menu
                }
                
            }
            return null;
        }        
    }
}
