// --------------------------------------------------------------------------------
// <copyright file="InvestmentAccount.cs" company="Alex Kozlov">
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

    public class InvestmentAccount
    {
        #region Constructors and Destructors

        public InvestmentAccount()
        {
            this.AccountTransactions = new List<CashTransaction>();
            this.TradesHistory = new List<TradeTransaction>();
        }

        #endregion

        #region Public Properties

        [Key]
        public Guid AccountId { get; set; }

        public virtual ICollection<CashTransaction> AccountTransactions { get; private set; }

        public decimal BookCost { get; set; }

        public decimal CashBalance { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TradeTransaction> TradesHistory { get; private set; }

        #endregion
    }
}