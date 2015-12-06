// --------------------------------------------------------------------------------
// <copyright file="AssetTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetTransactionModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AssetTransaction
    {
        #region Constructors and Destructors

        public AssetTransaction()
        {
            this.IsImported = false;
        }

        #endregion

        #region Public Properties

        public virtual Account Account { get; set; }

        public decimal Amount { get; set; }

        public virtual AssetInstance AssetInstance { get; set; }

        public string AssetName { get; set; }

        [ForeignKey("CashTransaction")]
        public int Id { get; set; }

        public virtual CashTransaction CashTransaction { get; set; }

        public string Comment { get; set; }

        public decimal Commission { get; set; }

        public string Description { get; set; }

        public bool IsImported { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public DateTime? SettlementDate { get; set; }

        public string TickerSymbol { get; set; }

        public DateTime TransactionDate { get; set; }

        public TransactionType TransactionType { get; set; }

        #endregion
    }
}
