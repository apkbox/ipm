// --------------------------------------------------------------------------------
// <copyright file="BalanceBase.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the BalanceBase type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;

    public class BalanceBase
    {
        #region Public Properties

        public decimal AssetsBookCost { get; set; }

        public decimal AssetsMarketCost { get; set; }

        public DateTime BalanceDate { get; set; }

        public decimal CashBalance { get; set; }

        public decimal Return { get; set; }

        public decimal ReturnPercent { get; set; }

        public decimal Yield { get; set; }

        public decimal YieldPercent { get; set; }

        #endregion
    }
}