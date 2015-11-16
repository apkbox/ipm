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

        #region Public Methods and Operators

        [TestMethod]
        public void CreateAccount()
        {
            var portfolio =
                this.model.InvestmentPortfolios.Add(new InvestmentPortfolio() { PortfolioId = Guid.NewGuid() });

            portfolio.InvestmentAccounts.Add(
                new InvestmentAccount()
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

        [TestMethod]
        public void CreateTradeTransactions()
        {
            var portfolio =
                this.model.InvestmentPortfolios.Add(new InvestmentPortfolio() { PortfolioId = Guid.NewGuid() });

            var accountId = Guid.NewGuid();
            portfolio.InvestmentAccounts.Add(
                new InvestmentAccount()
                    {
                        AccountId = accountId, 
                        Name = "TD TFSA", 
                        Description = "TD TFSA Account CAD", 
                        Currency = "CAD", 
                        CashBalance = 0, 
                        BookCost = 0, 
                    });
            this.model.SaveChanges();

            var transaction = new TradeTransaction()
                                  {
                                      TransactionDate = DateTime.Now, 
                                      TickerSymbol = "MSFT", 
                                      Description = "Microsoft Corporation", 
                                      Price = (decimal)23.02, 
                                      Quantity = 1000, 
                                      Comission = (decimal)9.95, 
                                      Value = (decimal)(23.02 * 1000)
                                  };
            var account = portfolio.InvestmentAccounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                account.TradesHistory.Add(transaction);
            }

            this.model.SaveChanges();

            using (var vmodel = new IpmModel())
            {
                Assert.IsNotNull(model);
                var pf = this.model.InvestmentPortfolios.Find(portfolio.PortfolioId);
                Assert.IsNotNull(pf);
                var acc = pf.InvestmentAccounts.FirstOrDefault(a => a.AccountId == accountId);
                Assert.IsNotNull(acc);
                Assert.IsNotNull(acc.TradesHistory.FirstOrDefault(t => t.TickerSymbol == "MSFT"));
            }
        }

        [TestMethod]
        public void CreateBuyTransactions()
        {
            var portfolio =
                this.model.InvestmentPortfolios.Add(new InvestmentPortfolio() { PortfolioId = Guid.NewGuid() });

            var accountId = Guid.NewGuid();
            portfolio.InvestmentAccounts.Add(
                new InvestmentAccount()
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
            var price = (decimal)23.02;
            var quantity = (decimal)1000;
            var amount = price * quantity + (decimal)9.99;

            var cashTransaction = new CashTransaction()
                                      {
                                          TransactionDate = date,
                                          Description = "Buying 1000 x $23.02 MSFT shares.",
                                          Comment = "Great deal",
                                          Value = -amount
                                      };

            var transaction = new TradeTransaction()
                                  {
                                      TransactionDate = DateTime.Now, 
                                      TickerSymbol = "MSFT", 
                                      Description = "Microsoft Corporation", 
                                      Price = price, 
                                      Quantity = quantity, 
                                      Comission = (decimal)9.95, 
                                      Value = amount
                                  };
            var account = portfolio.InvestmentAccounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                account.AccountTransactions.Add(cashTransaction);
                account.TradesHistory.Add(transaction);
            }

            this.model.SaveChanges();

            using (var vmodel = new IpmModel())
            {
                Assert.IsNotNull(vmodel);
                var pf = this.model.InvestmentPortfolios.Find(portfolio.PortfolioId);
                Assert.IsNotNull(pf);
                var acc = pf.InvestmentAccounts.FirstOrDefault(a => a.AccountId == accountId);
                Assert.IsNotNull(acc);
                Assert.IsNotNull(acc.TradesHistory.FirstOrDefault(t => t.TickerSymbol == "MSFT"));
            }
        }

        [TestMethod]
        public void CreatePortfolio()
        {
            var portfolioId = Guid.NewGuid();
            var portfolio =
                this.model.InvestmentPortfolios.Add(new InvestmentPortfolio() { PortfolioId = portfolioId });
            this.model.SaveChanges();
        }

        [TestInitialize]
        public void SetUp()
        {
            this.model = new IpmModel();
            if (this.model != null)
            {
                this.model.Database.Delete();
                this.model.Database.CreateIfNotExists();
            }
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