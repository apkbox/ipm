// --------------------------------------------------------------------------------
// <copyright file="Asset.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the Asset type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    // TODO: Add reference to price history.
    // TODO: Add more facts - 52w low/high, etc.
    public class Asset
    {
        #region Public Properties

        public int AssetId { get; set; }

        public string AssetName { get; set; }

        public double DividendYield { get; set; }

        public decimal LastMarketPrice { get; set; }

        public DateTime LastQuoteDate { get; set; }

        // ReSharper disable once InconsistentNaming
        public double MER { get; set; }

        [Index(IsUnique = true)]
        public string TickerSymbol { get; set; }

        #endregion
    }
}