// --------------------------------------------------------------------------------
// <copyright file="InvestmentPortfolio.cs" company="Alex Kozlov">
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
    using System.ComponentModel.DataAnnotations;

    public class Portfolio
    {
        #region Constructors and Destructors

        public Portfolio()
        {
            this.InvestmentAccounts = new List<Account>();
        }

        #endregion

        #region Public Properties

        public ICollection<Account> InvestmentAccounts { get; private set; }

        [Key]
        public Guid PortfolioId { get; set; }

        #endregion

        public Account Account
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}