// --------------------------------------------------------------------------------
// <copyright file="Portfolio.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvestmentPortfolio type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System;
    using System.Collections.Generic;

    public class Portfolio
    {
        #region Constructors and Destructors

        public Portfolio()
        {
            this.Accounts = new List<Account>();
        }

        #endregion

        #region Public Properties

        public ICollection<Account> Accounts { get; private set; }

        public BalanceBook BalanceBook { get; set; }

        public Guid PortfolioId { get; set; }

        #endregion
    }
}