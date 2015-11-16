// --------------------------------------------------------------------------------
// <copyright file="IpmModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the IpmModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System.Data.Entity;

    public class IpmModel : DbContext
    {
        // Your context has been configured to use a 'IpmModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ipm.DataModel.IpmModel' database on your LocalDb instance. 
        // If you wish to target a different database and/or database provider, modify the 'IpmModel' 
        // connection string in the application configuration file.
        #region Constructors and Destructors

        public IpmModel()
            : base("name=IpmModel")
        {
        }

        #endregion

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        #region Public Properties

        public virtual DbSet<CashTransaction> CashTransactions { get; set; }

        public virtual DbSet<InvestmentAccount> InvestmentAccounts { get; set; }

        public virtual DbSet<InvestmentPortfolio> InvestmentPortfolios { get; set; }

        public virtual DbSet<TradeTransaction> TradeTransactions { get; set; }

        #endregion
    }
}