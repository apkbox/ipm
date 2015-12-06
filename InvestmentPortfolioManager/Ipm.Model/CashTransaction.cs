// --------------------------------------------------------------------------------
// <copyright file="CashTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the CashTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CashTransaction
    {
        #region Constructors and Destructors

        public CashTransaction()
        {
            this.IsImported = false;
        }

        #endregion

        #region Public Properties

        public Account Account { get; set; }

        public decimal Amount { get; set; }

        public virtual AssetTransaction AssetTransaction { get; set; }

        public int Id { get; set; }

        public string Comment { get; set; }

        public string Description { get; set; }

        public bool IsImported { get; set; }

        public DateTime? SettlementDate { get; set; }

        public DateTime TransactionDate { get; set; }

        #endregion
    }
}
