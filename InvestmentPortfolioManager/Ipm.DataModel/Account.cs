// --------------------------------------------------------------------------------
// <copyright file="Account.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvestmentAccount type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Account
    {
        #region Constructors and Destructors

        public Account()
        {
            this.CashTransactions = new List<CashTransaction>();
            this.AssetTransactions = new List<AssetTransaction>();
        }

        #endregion

        #region Public Properties

        [Key]
        public Guid AccountId { get; set; }

        public virtual ICollection<AssetTransaction> AssetTransactions { get; private set; }

        public BalanceBook BalanceBook { get; set; }

        public decimal BookCost { get; set; }

        public decimal CashBalance { get; set; }

        public virtual ICollection<CashTransaction> CashTransactions { get; private set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        #endregion
    }
}