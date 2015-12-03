// --------------------------------------------------------------------------------
// <copyright file="IpmModel.cs" company="Alex Kozlov">
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
    using System.Linq;

    public class IpmModel : DbContext
    {
        // Your context has been configured to use a 'IpmEntityModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ipm.Model.IpmEntityModel' database on your LocalDb instance. 
        // If you wish to target a different database and/or database provider, modify the 'IpmEntityModel' 
        // connection string in the application configuration file.
        #region Constructors and Destructors

        public IpmModel()
            : base("name=IpmEntityModel")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        #endregion

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        #region Public Properties

        public virtual DbSet<PortfolioModel> Portfolios { get; set; }

        #endregion

        #region Public Methods and Operators

        public void CreatePortfolio(string name)
        {
            var portfolio = this.Portfolios.Add(new PortfolioModel() { Name = name });
            portfolio.BalanceBooks.Add(new PortfolioBalanceBookModel()
                                           {
                                               BalanceDate = DateTime.Now
                                           });
            this.SaveChanges();
        }

        public PortfolioModel GetPorfolio(int portfolioId)
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