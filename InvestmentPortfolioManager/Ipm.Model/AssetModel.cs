// --------------------------------------------------------------------------------
// <copyright file="AssetModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;

    public class AssetModel
    {
        #region Public Properties

        public CurrencyCode AssetCurrency { get; set; }

        public string Desciption { get; set; }

        public decimal LastPrice { get; set; }

        public DateTime LastPriceTimestamp { get; set; }

        public decimal Quantity { get; set; }

        public string Ticker { get; set; }

        #endregion
    }
}