using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VendingMachineTests()
        {
            VendingMachine myVending = new VendingMachine();
            CommandLineInterface myCLI = new CommandLineInterface(myVending);
            myVending.FeedMoney(10);
            Assert.AreEqual(10.00.ToString(), myVending.Balance.ToString());

            Item myItem = myVending.FindItem("A3");
            myCLI.Purchase(myItem);
            Assert.AreEqual(7.25.ToString(), myVending.Balance.ToString());

        }
    }
}
