// --------------------------------------------------------------------------------
// <copyright file="BuySellTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the BuySellTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    public class BuySellTransaction : AccountTransaction
    {
        #region Public Properties

        public Currency AssetPrice { get; set; }

        public Currency Comission { get; set; }

        public bool IsCashLinked { get; set; }

        public decimal Quantity { get; set; }

        public Currency SettlementPrice { get; set; }

        public string Ticker { get; set; }

        public TransactionType TransactionType { get; set; }

        #endregion
    }
}