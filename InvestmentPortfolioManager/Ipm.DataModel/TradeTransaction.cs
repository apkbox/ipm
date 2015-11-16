// --------------------------------------------------------------------------------
// <copyright file="TradeTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the TradeTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TradeTransaction
    {
        #region Public Properties

        public decimal Comission { get; set; }

        public string Comment { get; set; }

        public string Description { get; set; }

        [Key]
        public int Id { get; set; }

        public bool IsImported { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public DateTime? SettlementDate { get; set; }

        public string TickerSymbol { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Value { get; set; }

        #endregion
    }
}