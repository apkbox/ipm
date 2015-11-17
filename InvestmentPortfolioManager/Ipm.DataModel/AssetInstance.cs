// --------------------------------------------------------------------------------
// <copyright file="AssetInstance.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetInstance type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System.Collections.Generic;

    public class AssetInstance
    {
        #region Constructors and Destructors

        public AssetInstance()
        {
            this.RelatedTransactions = new List<AssetTransaction>();
        }

        #endregion

        #region Public Properties

        public Asset Asset { get; set; }

        public int AssetInstanceId { get; set; }

        public decimal BookCost { get; set; }

        public decimal MarketCost { get; set; }

        public ICollection<AssetTransaction> RelatedTransactions { get; private set; }

        #endregion
    }
}