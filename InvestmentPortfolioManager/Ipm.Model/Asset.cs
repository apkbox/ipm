// --------------------------------------------------------------------------------
// <copyright file="Asset.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.Collections.Generic;

    public class Asset
    {
        #region Constructors and Destructors

        public Asset()
        {
            this.AssetInstances = new HashSet<AssetInstance>();
        }

        #endregion

        #region Public Properties

        public CurrencyCode AssetCurrency { get; set; }

        public virtual ICollection<AssetInstance> AssetInstances { get; set; }

        public string Desciption { get; set; }

        public int Id { get; set; }

        public decimal LastPrice { get; set; }

        public DateTime LastPriceTimestamp { get; set; }

        public decimal Quantity { get; set; }

        public string Ticker { get; set; }

        public decimal Yield { get; set; }

        #endregion
    }
}
