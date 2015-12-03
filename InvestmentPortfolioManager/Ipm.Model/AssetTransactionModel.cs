// --------------------------------------------------------------------------------
// <copyright file="AssetTransactionModel.cs" company="Alex Kozlov">
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

    public class AssetTransactionModel
    {
        #region Constructors and Destructors

        public AssetTransactionModel()
        {
            this.IsImported = false;
        }

        #endregion

        #region Public Properties

        public virtual AccountModel Account { get; set; }

        public decimal Amount { get; set; }

        public virtual AssetInstanceModel AssetInstance { get; set; }

        public string AssetName { get; set; }

        [Key, ForeignKey("CashTransaction")]
        public int AssetTransactionId { get; set; }

        public virtual CashTransactionModel CashTransaction { get; set; }

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