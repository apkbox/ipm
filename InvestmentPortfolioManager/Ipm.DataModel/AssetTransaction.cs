// --------------------------------------------------------------------------------
// <copyright file="AssetTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AssetTransaction
    {
        #region Public Properties

        public decimal Amount { get; set; }

        public string AssetName { get; set; }

        [Key]
        public int AssetTransactionId { get; set; }

        public CashTransaction CashTransaction { get; set; }

        public decimal Commission { get; set; }

        public string Comment { get; set; }

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