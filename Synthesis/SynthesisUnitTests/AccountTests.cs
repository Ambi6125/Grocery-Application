using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynthesisDataLayer.Accounts;
using SynthesisEntities.Accounts;
using SynthesisLogic.Accounts;
using System;

namespace SynthesisUnitTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void AddAccountTest()
        {
            string username = "Test";
            Account account = new CustomerAccount(username, "abc", "test@gmail.com", "a");


            AccountManager am = new AccountManager(new MockAccountRepo());
            am.RegisterAccount(account);
            Assert.AreEqual("Test", am.GetByUsernameExact(username).Username);
        }
    }
}