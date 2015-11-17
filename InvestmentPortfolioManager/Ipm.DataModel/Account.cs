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

    public class Account
    {
        #region Constructors and Destructors

        public Account()
        {
            this.CashTransactions = new List<CashTransaction>();
            this.TradesTransactions = new List<TradeTransaction>();
        }

        #endregion

        #region Public Properties

        [Key]
        public Guid AccountId { get; set; }

        public virtual ICollection<CashTransaction> CashTransactions { get; private set; }

        public decimal BookCost { get; set; }

        public decimal CashBalance { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TradeTransaction> TradesTransactions { get; private set; }

        #endregion

        public CashTransaction CashTransaction
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TradeTransaction TradeTransaction
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