// --------------------------------------------------------------------------------
// <copyright file="DatabaseInitializer.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the DatabaseInitializer type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.Data.Entity;

    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<IpmEntityModel>
    {
        #region Methods

        protected void SeedImpl(IpmEntityModel context)
        {
            var accountModel = new Account
                                   {
                                       Name = "TFSA", 
                                       Description = "TD TFSA Account CAD", 
                                       Currency = "CAD", 
                                   };

            var portfolio = new Portfolio();
            portfolio.Accounts.Add(accountModel);

            var cashTransaction = new CashTransaction
                                      {
                                          TransactionDate = DateTime.Parse("2015/03/06"), 
                                          Description = "Contribution", 
                                          Amount = 5000
                                      };
            accountModel.CashTransactions.Add(cashTransaction);

            this.CreateBuyTransaction(
                accountModel, 
                DateTime.Parse("2015/03/10"), 
                "ZHY", 
                "ZHY - BMO HIGH YIELD US CORPORATE BOND HEDGED TO CAD INDEX ETF UNSOLICITED DA 30 x $15.54", 
                (decimal)15.54, 
                30, 
                (decimal)9.95);

            this.CreateBuyTransaction(
                accountModel, 
                DateTime.Parse("2015/03/10"), 
                "XRE", 
                "XRE - ISHARES S&P/TSX CAPPED REIT INDEX ETF WE ACTED AS PRINCIPAL UNSOLICITED DA 30 x $16.52", 
                (decimal)16.52, 
                30, 
                (decimal)9.95);

            cashTransaction = new CashTransaction
                                  {
                                      TransactionDate = DateTime.Parse("2015/03/12"), 
                                      Description =
                                          "ACCOUNT ADJUSTMENTJ~0TF60133V4 BRANCH OFFERS - TRADE REBATE", 
                                      Amount = (decimal)9.95
                                  };
            accountModel.CashTransactions.Add(cashTransaction);

            cashTransaction = new CashTransaction
                                  {
                                      TransactionDate = DateTime.Parse("2015/03/12"), 
                                      Description =
                                          "ACCOUNT ADJUSTMENTJ~0TF60133V6 BRANCH OFFERS - TRADE REBATE", 
                                      Amount = (decimal)9.95
                                  };
            accountModel.CashTransactions.Add(cashTransaction);

            cashTransaction = new CashTransaction
                                  {
                                      TransactionDate = DateTime.Parse("2015/04/07"), 
                                      Description =
                                          "ZHY - BMO HIGH YIELD US CORPORATE BOND HEDGED TO CAD INDEX ETF DIST ON 30 SHS REC 03/30/15 PAY 04/07/15", 
                                      Amount = (decimal)2.28
                                  };
            accountModel.CashTransactions.Add(cashTransaction);

            context.Portfolios.Add(portfolio);
            context.SaveChanges();
        }

        private void CreateBuyTransaction(
            Account account, 
            DateTime transactionDate, 
            string tickerSymbol, 
            string description, 
            decimal price, 
            decimal quantity, 
            decimal comission)
        {
            var total = (price * quantity) + comission;

            var cashTransaction = new CashTransaction
                                      {
                                          TransactionDate = transactionDate, 
                                          Description = description, 
                                          Amount = -total
                                      };

            var assetTransaction = new AssetTransaction
                                       {
                                           TransactionType = TransactionType.BuySell, 
                                           TransactionDate = transactionDate, 
                                           TickerSymbol = tickerSymbol, 
                                           Description = description, 
                                           Price = price, 
                                           Quantity = quantity, 
                                           Commission = comission, 
                                           Amount = total, 
                                           CashTransaction = cashTransaction
                                       };

            account.CashTransactions.Add(cashTransaction);
            account.AssetTransactions.Add(assetTransaction);
        }

        private void CreateDividendTransaction(
            Account account, 
            DateTime transactionDate, 
            string tickerSymbol, 
            string description, 
            decimal amount)
        {
            var cashTransaction = new CashTransaction
                                      {
                                          TransactionDate = transactionDate, 
                                          Description = description, 
                                          Amount = amount
                                      };

            var assetTransaction = new AssetTransaction
                                       {
                                           TransactionType = TransactionType.Dividend, 
                                           TransactionDate = transactionDate, 
                                           TickerSymbol = tickerSymbol, 
                                           Description = description, 
                                           Amount = amount, 
                                           CashTransaction = cashTransaction
                                       };

            account.CashTransactions.Add(cashTransaction);
            account.AssetTransactions.Add(assetTransaction);
        }

        #endregion
    }
}