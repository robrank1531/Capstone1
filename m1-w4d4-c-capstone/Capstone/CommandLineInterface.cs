using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class CommandLineInterface : Item
    {
        decimal previousBalance = 0;
        decimal totalSales = 0;
        public VendingMachine myVending;

        public CommandLineInterface(VendingMachine name)
        {
            myVending = name;
        }
        public void RunProgram()
        {
            VendingMachine myVending = new VendingMachine();
            this.MainMenu();
        }

        public void MainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            string line = Console.ReadLine();
            if (line == "1")
            {
                this.DisplayItems();
            }
            else if (line == "2")
            {
                this.PurchaseMenu();

            }
            else if (line == "3")
            {
                this.FinishTransaction();
            }
        }
        public void DisplayItems()
        {
            Console.WriteLine("Slot" + "Name".PadLeft(15) + "Price".PadLeft(23) + "Quantity".PadLeft(23));
            Console.WriteLine("-".PadRight(100, '-'));
            foreach (Item product in myVending.Inventory)
            {                
                if (product.Quantity == 0)
                {
                    Console.WriteLine(product.Slot + product.Name.PadLeft(20) + product.Price.ToString("F2").PadLeft(20)+ " SOLD OUT".PadLeft(20));
                }
                else
                {
                    Console.WriteLine(product.Slot + product.Name.PadLeft(20) + product.Price.ToString().PadLeft(20) + product.Quantity.ToString().PadLeft(20));
                }
            }
            Console.WriteLine();  
            this.MainMenu();
        }

        public void PurchaseMenu()
        {
            bool finished = false;
            do
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Return to Main Menu");
                Console.WriteLine("(4) Finish Transaction");
                Console.WriteLine("Balance: " + "$" + myVending.Balance.ToString("F2"));
                string line = Console.ReadLine();

                if (line == "1")
                {
                    Console.WriteLine("How much do you want to feed?");
                    string input = Console.ReadLine();
                    if (input == "1.00" || input == "2.00" || input == "5.00" || input == "10.00")
                    {
                        myVending.FeedMoney(Decimal.Parse(input));
                        this.LogWriter("FEED MONEY:");
                    }
                    else
                    {
                        Console.WriteLine("Please feed 1.00, 2.00, 5.00 or 10.00");
                    }
                }
                else if (line == "2")
                {
                    Item myItem = new Item();
                    Console.WriteLine("What item would you like to select?");
                    string input = Console.ReadLine();
                    myItem = myVending.FindItem(input.ToUpper());
                    this.Purchase(myItem);
                }
                else if (line == "3")
                {
                    this.MainMenu();
                }
                else if (line == "4")
                {
                    finished = true;
                    this.FinishTransaction();
                }
            }
            while (finished == false);
        }

        public Item FindItem(string item)
        {
            foreach (Item product in myVending.Inventory)
            {
                if (product.Slot == item)
                {
                    return product;
                }
                else
                {
                    Console.WriteLine("Sorry, the item does not exist.");
                    Console.WriteLine();                    
                }
            }
            return null;
        }
        public void Purchase(Item product)
        {
            try
            {
                if (product.Quantity > 0 && myVending.Balance > product.Price)
                {
                    previousBalance = myVending.Balance;
                    product.Quantity = product.Quantity - 1;
                    myVending.Balance = myVending.Balance - product.Price;
                    totalSales += product.Price;
                    this.ConsumeItem(product);
                    this.LogWriter(product.Name + " " + product.Slot);
                }
                else if (product.Quantity == 0)
                {
                    Console.WriteLine("Sorry, the item is sold out.");
                    Console.WriteLine();
                }
                else if (myVending.Balance < product.Price)
                {
                    Console.WriteLine("Sorry, please feed more money.");
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Sorry, the item does not exist.");
                Console.WriteLine();
            }
        }
        public void FinishTransaction()
        {
            int quarterCounter = 0;
            int dimeCounter = 0;
            int nickelCounter = 0;

            while (myVending.Balance > 0)
            {
                while (myVending.Balance >= .25M)
                {
                    myVending.Balance -= .25M;
                    quarterCounter++;
                }
                while (myVending.Balance >= .10M)
                {
                    myVending.Balance -= .10M;
                    dimeCounter++;
                }
                while (myVending.Balance >= .05M)
                {
                    myVending.Balance -= .05M;
                    nickelCounter++;
                }
            }
            Console.WriteLine("Your change is: " + quarterCounter + " quarters, " + dimeCounter + " dimes, and " + nickelCounter + " nickels");
            this.LogWriter("GIVE CHANGE: ");
            this.SalesReport(totalSales);
            Console.WriteLine("Press enter to close");
            string nothing = Console.ReadLine();
        }

        public void ConsumeItem(Item product)
        {
            if (product.Slot.Contains('A'))
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            else if (product.Slot.Contains('B'))
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            else if (product.Slot.Contains('C'))
            {
                Console.WriteLine("Glug Glug, Yum!");
            }
            else if (product.Slot.Contains('D'))
            {
                Console.WriteLine("Chew Chew, Yum!");
            }
        }
        public void LogWriter(string action)
        {
            string inputPath = Environment.CurrentDirectory;
            string outputFile = "Log.txt";
            string outputFullPath = Path.Combine(inputPath, outputFile);

            using (StreamWriter sw = new StreamWriter(outputFullPath, true))
            {
                
                sw.WriteLine(DateTime.UtcNow + action.PadLeft(20) + previousBalance.ToString("F2").PadLeft(20) + myVending.Balance.ToString("F2").PadLeft(20));
            }
            previousBalance = myVending.Balance;
        }
        public void SalesReport(decimal finalTotalSales)
        {
            string inputPath = Environment.CurrentDirectory;
            string outputFile = "Sales_Report.txt";
            string outputFullPath = Path.Combine(inputPath, outputFile);

            using (StreamWriter sw = new StreamWriter(outputFullPath, true))
            {
                foreach(Item product in myVending.Inventory)
                {
                    sw.WriteLine(product.Name + "|" + product.Quantity);
                }
                sw.WriteLine();
                sw.WriteLine("*TOTAL SALES*: " + totalSales.ToString("F2"));
                sw.WriteLine();
            }
        }
    }
}
