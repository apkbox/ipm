// --------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel.Tests
{
    using System;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        #region Fields

        private IpmModel model;

        #endregion

        #region Public Methods and Operators

        [TestMethod]
        public void CreatePortfolioMethod()
        {
            var pf = this.model.Portfolios.Add(new Portfolio() { Name = "Test Portfolio" });
            Assert.IsNotNull(pf);
            Assert.AreEqual(pf.Name, "Test Portfolio");
        }

        [TestMethod]
        public void CreateAccount()
        {
            var portfolio = new Portfolio { Name = "Test Portfolio" };
            var account = new Account
            {
                Name = "TD TFSA",
                Description = "TD TFSA Account CAD",
                Currency = "CAD",
            };
            portfolio.Accounts.Add(account);
            this.model.Portfolios.Add(portfolio);
            this.model.SaveChanges();
        }

        [TestMethod]
        public void CreateBuyTransactions()
        {
            var portfolio = new Portfolio { Name = "Test Portfolio" };
            var account = new Account
            {
                Name = "TD TFSA",
                Description = "TD TFSA Account CAD",
                Currency = "CAD",
            };
            portfolio.Accounts.Add(account);
            this.model.Portfolios.Add(portfolio);
            this.model.SaveChanges();

            var date = DateTime.Now;
            const decimal Price = (decimal)23.02;
            const decimal Quantity = (decimal)1000;
            const decimal Amount = (Price * Quantity) + (decimal)9.99;

            var cashTransaction = new CashTransaction
                                      {
                                          TransactionDate = date, 
                                          Description = "Buying 1000 x $23.02 MSFT shares.", 
                                          Comment = "Great deal", 
                                          Amount = -Amount
                                      };

            var transaction = new AssetTransaction
                                  {
                                      TransactionDate = DateTime.Now, 
                                      TickerSymbol = "MSFT", 
                                      Description = "Microsoft Corporation", 
                                      Price = Price, 
                                      Quantity = Quantity, 
                                      Commission = (decimal)9.95, 
                                      Amount = Amount
                                  };
            account.CashTransactions.Add(cashTransaction);
            account.AssetTransactions.Add(transaction);

            this.model.SaveChanges();

            using (var vmodel = new IpmModel())
            {
                Assert.IsNotNull(vmodel);
                var pf = this.model.Portfolios.Find(portfolio.PortfolioId);
                Assert.IsNotNull(pf);
                var acc = pf.Accounts.FirstOrDefault(a => a.AccountId == account.AccountId);
                Assert.IsNotNull(acc);
                Assert.IsNotNull(acc.AssetTransactions.FirstOrDefault(t => t.TickerSymbol == "MSFT"));
            }
        }

        [TestMethod]
        public void CreatePortfolio()
        {
            this.model.Portfolios.Add(new Portfolio { Name = "Test Portfolio" });
            this.model.SaveChanges();
        }

        [TestMethod]
        public void CreateTradeTransactions()
        {
            var portfolio = new Portfolio { Name = "Test Portfolio" };
            var account = new Account
                              {
                                  Name = "TD TFSA",
                                  Description = "TD TFSA Account CAD",
                                  Currency = "CAD",
                              };
            portfolio.Accounts.Add(account);
            this.model.Portfolios.Add(portfolio);
            this.model.SaveChanges();

            var transaction = new AssetTransaction
                                  {
                                      TransactionDate = DateTime.Now, 
                                      TickerSymbol = "MSFT", 
                                      Description = "Microsoft Corporation", 
                                      Price = (decimal)23.02, 
                                      Quantity = 1000, 
                                      Commission = (decimal)9.95, 
                                      Amount = (decimal)(23.02 * 1000)
                                  };
            account.AssetTransactions.Add(transaction);

            this.model.SaveChanges();

            using (new IpmModel())
            {
                Assert.IsNotNull(this.model);
                var pf = this.model.Portfolios.Find(portfolio.PortfolioId);
                Assert.IsNotNull(pf);
                var acc = pf.Accounts.FirstOrDefault(a => a.AccountId == account.AccountId);
                Assert.IsNotNull(acc);
                Assert.IsNotNull(acc.AssetTransactions.FirstOrDefault(t => t.TickerSymbol == "MSFT"));
            }
        }

        [TestInitialize]
        public void SetUp()
        {
            this.model = new IpmModel();
            Assert.IsNotNull(this.model);
            this.model.Database.Log = Console.Write;
        }

        [TestCleanup]
        public void TearDown()
        {
            if (this.model != null)
            {
                this.model.Dispose();
            }
        }

        #endregion
    }
}