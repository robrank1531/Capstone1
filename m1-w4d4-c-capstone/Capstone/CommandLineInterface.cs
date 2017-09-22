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
                return;
            }
        }
        public void DisplayItems()
        {
            foreach (Item product in myVending.Inventory)
            {
                if (product.Quantity == 0)
                {
                    Console.WriteLine(product.Slot + " " + product.Name + " " + product.Price + " SOLD OUT");
                }
                else
                {
                    Console.WriteLine(product.Slot + " " + product.Name + " " + product.Price + " " + product.Quantity);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Hit any key to return to main menu");
            string blankString = Console.ReadLine();
            this.MainMenu();
        }

        public void PurchaseMenu()
        {
            bool finished = false;
            do
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("Balance: " + "$" + myVending.Balance.ToString("F2"));
                string line = Console.ReadLine();

                if (line == "1")
                {
                    Console.WriteLine("How much do you want to feed?");
                    string input = Console.ReadLine();
                    if (input == "1.00" || input == "2.00" || input == "5.00" || input == "10.00")
                    {
                        myVending.FeedMoney(Decimal.Parse(input));
                        this.LogWriter("Feed money:");
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
                    myItem = myVending.FindItem(input);
                    this.Purchase(myItem);
                }
                else if (line == "3")
                {
                    finished = true;
                    this.FinishTransaction();
                }
            }
            while (finished == false);
        }



        public Item FindItem(string item)
        {
            foreach (Item product in Inventory)
            {
                if (product.Slot == item)
                {
                    return product;
                }
                else
                {
                    Console.WriteLine("Sorry, the item does not exist.");
                    Console.WriteLine("Press any key to return to main menu.");
                    string clearOut = Console.ReadLine();
                    this.MainMenu();
                }
            }
            return null;
        }
        public void Purchase(Item product)
        {
            if (product.Quantity > 0 && myVending.Balance > product.Price)
            {
                previousBalance = myVending.Balance;
                product.Quantity = product.Quantity - 1;
                myVending.Balance = myVending.Balance - product.Price;
                this.ConsumeItem(product);
                this.LogWriter(product.Name + " " + product.Slot);
            }
            else if (product.Quantity == 0)
            {
                Console.WriteLine("Sorry, the item is sold out.");
                Console.WriteLine("Press any key to return to purchase menu.");
                string clearOut = Console.ReadLine();
            }
            else if (myVending.Balance < product.Price)
            {
                Console.WriteLine("Sorry, please feed more money.");
                string clearOut = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry, the item does not exist.");
                Console.WriteLine("Press any key to return to purchase menu.");
                string clearOut = Console.ReadLine();
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
            this.LogWriter("Give change: ");
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
                sw.WriteLine(DateTime.UtcNow + " " + action + " " + previousBalance.ToString("F2") + " " + myVending.Balance.ToString("F2"));
            }
        }
    }
}
