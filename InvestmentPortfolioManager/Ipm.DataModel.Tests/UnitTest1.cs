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
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        #region Fields

        private IpmModel model;

        #endregion

        // [TestMethod]
        #region Public Methods and Operators

        public void CreateAccount()
        {
            var portfolio = this.model.Portfolios.Add(new Portfolio { PortfolioId = Guid.NewGuid() });

            portfolio.Accounts.Add(
                new Account
                    {
                        AccountId = Guid.NewGuid(), 
                        Name = "TD TFSA", 
                        Description = "TD TFSA Account CAD", 
                        Currency = "CAD", 
                        CashBalance = 0, 
                        BookCost = 0, 
                    });

            this.model.SaveChanges();
        }

        // [TestMethod]

        // [TestMethod]
        public void CreateBuyTransactions()
        {
            var portfolio = this.model.Portfolios.Add(new Portfolio { PortfolioId = Guid.NewGuid() });

            var accountId = Guid.NewGuid();
            portfolio.Accounts.Add(
                new Account
                    {
                        AccountId = accountId, 
                        Name = "TD TFSA", 
                        Description = "TD TFSA Account CAD", 
                        Currency = "CAD", 
                        CashBalance = 0, 
                        BookCost = 0, 
                    });
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
            var account = portfolio.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                account.CashTransactions.Add(cashTransaction);
                account.AssetTransactions.Add(transaction);
            }

            this.model.SaveChanges();

            using (var vmodel = new IpmModel())
            {
                Assert.IsNotNull(vmodel);
                var pf = this.model.Portfolios.Find(portfolio.PortfolioId);
                Assert.IsNotNull(pf);
                var acc = pf.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                Assert.IsNotNull(acc);
                Assert.IsNotNull(acc.AssetTransactions.FirstOrDefault(t => t.TickerSymbol == "MSFT"));
            }
        }

        // [TestMethod]
        public void CreatePortfolio()
        {
            var portfolioId = Guid.NewGuid();
            this.model.Portfolios.Add(new Portfolio { PortfolioId = portfolioId });
            this.model.SaveChanges();
        }

        public void CreateTradeTransactions()
        {
            var portfolio = this.model.Portfolios.Add(new Portfolio { PortfolioId = Guid.NewGuid() });

            var accountId = Guid.NewGuid();
            portfolio.Accounts.Add(
                new Account
                    {
                        AccountId = accountId, 
                        Name = "TD TFSA", 
                        Description = "TD TFSA Account CAD", 
                        Currency = "CAD", 
                        CashBalance = 0, 
                        BookCost = 0, 
                    });
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
            var account = portfolio.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                account.AssetTransactions.Add(transaction);
            }

            this.model.SaveChanges();

            using (new IpmModel())
            {
                Assert.IsNotNull(this.model);
                var pf = this.model.Portfolios.Find(portfolio.PortfolioId);
                Assert.IsNotNull(pf);
                var acc = pf.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                Assert.IsNotNull(acc);
                Assert.IsNotNull(acc.AssetTransactions.FirstOrDefault(t => t.TickerSymbol == "MSFT"));
            }
        }

        [TestMethod]
        public void InitializeEmptyDatabase()
        {
            this.model.Database.Initialize(false);
            Assert.IsTrue(true);
        }

        [TestInitialize]
        public void SetUp()
        {
            this.model = new IpmModel();
            Assert.IsNotNull(this.model);
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