// --------------------------------------------------------------------------------
// <copyright file="BalanceBook.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the BalanceBook type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    public class BalanceBook
    {
        #region Public Properties

        public int BalanceBookId { get; set; }

        public decimal AssetsBookCost { get; set; }

        public decimal AssetsMarketCost { get; set; }

        public decimal CashBalance { get; set; }

        public decimal Return { get; set; }

        public double ReturnPercent { get; set; }

        public decimal Yield { get; set; }

        public double YieldPercent { get; set; }

        #endregion
    }
}