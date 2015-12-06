// --------------------------------------------------------------------------------
// <copyright file="IpmEntityModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the IpmModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;

    public class IpmEntityModel : DbContext
    {
        // Your context has been configured to use a 'IpmEntityModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ipm.Model.IpmEntityModel' database on your LocalDb instance. 
        // If you wish to target a different database and/or database provider, modify the 'IpmEntityModel' 
        // connection string in the application configuration file.
        #region Constructors and Destructors

        public IpmEntityModel()
            : base("name=IpmEntityModel")
        {
            this.Database.Log = s => Debug.Write(s);
            Database.SetInitializer(new DatabaseInitializer());

            Debug.WriteLine(this.Configuration.LazyLoadingEnabled);
            Debug.WriteLine(this.Configuration.ProxyCreationEnabled);
        }

        #endregion

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        #region Public Properties

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<AssetTransaction> AssetTransactions { get; set; }

        public virtual DbSet<CashTransaction> CashTransactions { get; set; }

        public virtual DbSet<Portfolio> Portfolios { get; set; }

        #endregion

        #region Public Methods and Operators

        public virtual Account CreateAccount(
            int portfolioId, 
            string name, 
            string description, 
            string currency, 
            decimal? startingBalance)
        {
            var portfolio = this.GetPorfolio(portfolioId);
            if (portfolio == null)
            {
                return null;
            }

            var account = this.Accounts.Add(
                new Account()
                    {
                        Portfolio = portfolio, 
                        Name = name, 
                        Description = description, 
                        Currency = currency
                    });
            account.BalanceBooks.Add(
                new AccountBalanceBookModel
                    {
                        BalanceDate = DateTime.Now
                    });

            if (startingBalance != null)
            {
                account.CashTransactions.Add(
                    new CashTransaction()
                        {
                            Account = account, 
                            Amount = (decimal)startingBalance, 
                            Description = "Starting balance", 
                            TransactionDate = DateTime.Now, 
                            SettlementDate = DateTime.Now
                        });
            }

            this.SaveChanges();
            return account;
        }

        public virtual Portfolio CreatePortfolio(string name)
        {
            var portfolio = this.Portfolios.Add(new Portfolio() { Name = name });
            portfolio.BalanceBooks.Add(
                new PortfolioBalanceBookModel()
                    {
                        BalanceDate = DateTime.Now
                    });
            this.SaveChanges();
            return portfolio;
        }

        public virtual Portfolio GetPorfolio(int portfolioId)
        {
            return this.Portfolios.Find(portfolioId);
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
