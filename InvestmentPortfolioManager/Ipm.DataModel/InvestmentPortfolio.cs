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

    public class InvestmentPortfolio
    {
        #region Constructors and Destructors

        public InvestmentPortfolio()
        {
            this.InvestmentAccounts = new List<InvestmentAccount>();
        }

        #endregion

        #region Public Properties

        public ICollection<InvestmentAccount> InvestmentAccounts { get; private set; }

        [Key]
        public Guid PortfolioId { get; set; }

        #endregion
    }
}