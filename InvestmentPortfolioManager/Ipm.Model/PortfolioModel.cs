// --------------------------------------------------------------------------------
// <copyright file="PortfolioModel.cs" company="Alex Kozlov">
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

    public class PortfolioModel
    {
        #region Constructors and Destructors

        public PortfolioModel()
        {
            this.Accounts = new HashSet<AccountModel>();
            this.BalanceBooks = new HashSet<PortfolioBalanceBookModel>();
        }

        #endregion

        #region Public Properties

        public ICollection<AccountModel> Accounts { get; set; }

        public ICollection<PortfolioBalanceBookModel> BalanceBooks { get; set; }

        public string Name { get; set; }

        [Key]
        public int PortfolioId { get; set; }

        #endregion
    }
}