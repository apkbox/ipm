// --------------------------------------------------------------------------------
// <copyright file="Portfolio.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the PortfolioModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Portfolio
    {
        #region Constructors and Destructors

        public Portfolio()
        {
            this.Accounts = new HashSet<Account>();
            this.BalanceBooks = new HashSet<PortfolioBalanceBookModel>();
        }

        #endregion

        #region Public Properties

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<PortfolioBalanceBookModel> BalanceBooks { get; set; }

        public string Name { get; set; }

        [Key]
        public int PortfolioId { get; set; }

        #endregion
    }
}
