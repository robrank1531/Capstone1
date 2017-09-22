using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class CapstoneErrorTests
    {
        [TestMethod]
        public void VendingMachineTests()
        {
            VendingMachine myVending = new VendingMachine();
            CommandLineInterface myCLI = new CommandLineInterface(myVending);
            //myCLI.RunProgram();
            Item testItem = new Item();
            testItem = myVending.FindItem("A3");
            myVending.FeedMoney(10);
            Assert.AreEqual(10.00.ToString(), myVending.Balance.ToString());
            myCLI.Purchase(testItem);
            Assert.AreEqual(7.25.ToString(), myVending.Balance.ToString());
            Assert.AreEqual(4, testItem.Quantity);
            Assert.AreEqual(null, myVending.FindItem("j27"));


        }
    }
}
