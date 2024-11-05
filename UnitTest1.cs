namespace BankAccountMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(100,1100)]
        [DataRow(200,1200)]
        [DataRow(300,1300)]
        //Deposit Tests
        public void DepositMoneyToTheAccount(double inputAmount,double ExpectedAmount)
        {
            var account = new Account(101, "Dheeraj", "SBI", 1000);
            account.Deposit(inputAmount);
            Assert.AreEqual(ExpectedAmount, account.GetBalance());
        }

        [TestMethod]
        public void DepositNegativeMoneyToTheAccount()
        {
            var account = new Account(101, "Dheeraj", "SBI", 1000);
            Assert.ThrowsException<Exception>(() => account.Deposit(-10));
        }


        //Withdraw Tests

        [TestMethod]
        [DataRow(100, 1400)]
        [DataRow(200, 1300)]
        [DataRow(300, 1200)]
        public void WithdrawMoneyFromTheAccount(double inputAmount, double ExpectedAmount)
        {
            var account = new Account(101, "Dheeraj", "SBI", 1500);
            account.Withdraw(inputAmount);

            Assert.AreEqual(ExpectedAmount, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawMoneyGreaterthanBalanceFromTheAccount()
        {
            var account = new Account(101, "Dheeraj", "SBI", 1000);
            Assert.ThrowsException<Exception>(() => account.Withdraw(1500));
        }

        [TestMethod]
        public void WithdrawNegativeMoneyFromTheAccount()
        {
            var account = new Account(101, "Dheeraj", "SBI", 1000);
            Assert.ThrowsException<Exception>(() => account.Withdraw(-10));
        }

        //Account Transfer Tests

        [TestMethod]
        public void TransferMoneyfromAccount1_to_Account2()
        {
            var account1 = new Account(101, "Dheeraj", "SBI", 1000);
            var account2 = new Account(102, "Nani", "Axis", 700);

            account1.Transfer(account2, 400);

            Assert.AreEqual(600, account1.GetBalance());
            Assert.AreEqual(1100, account2.GetBalance());
        }

        [TestMethod]
        public void TransferMoneyfromAccount1_MorethanCurrentBalance_to_Account2()
        {
            var account1 = new Account(101, "Dheeraj", "SBI", 1000);
            var account2 = new Account(102, "Nani", "Axis", 700);

            Assert.ThrowsException<Exception>(() => account1.Transfer(account2, 1200));
        }

        [TestMethod]
        public void TransferMoneyfromAccount1_WhichisNotNegative_to_Account2()
        {
            var account1 = new Account(101, "Dheeraj", "SBI", 1000);
            var account2 = new Account(102, "Nani", "Axis", 700);

            Assert.ThrowsException<Exception>(() => account1.Transfer(account2, -120));
        }

        [TestMethod]
        public void TransferMoneyfromAccount1to_NULL_Account()
        {
            var account1 = new Account(101, "Dheeraj", "SBI", 1000);
            var account2 = new Account(102, "Nani", "Axis", 700);
            Assert.ThrowsException<ArgumentNullException>(() => account1.Transfer(null, 1200));
        }
    }
}