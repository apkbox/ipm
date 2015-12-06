// --------------------------------------------------------------------------------
// <copyright file="AssetInstance.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetInstanceModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AssetInstance
    {
        #region Constructors and Destructors

        public AssetInstance()
        {
            this.AssetTransactions = new HashSet<AssetTransaction>();
        }

        #endregion

        #region Public Properties

        public Account Account { get; set; }

        public Asset Asset { get; set; }

        [Key]
        public int AssetInstanceId { get; set; }

        public virtual ICollection<AssetTransaction> AssetTransactions { get; set; }

        public decimal BookCost { get; set; }

        public decimal MarketValue { get; set; }

        #endregion
    }
}
