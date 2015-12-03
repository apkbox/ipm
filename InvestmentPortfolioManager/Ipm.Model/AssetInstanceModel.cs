// --------------------------------------------------------------------------------
// <copyright file="AssetInstanceModel.cs" company="Alex Kozlov">
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

    public class AssetInstanceModel
    {
        #region Constructors and Destructors

        public AssetInstanceModel()
        {
            this.AssetTransactions = new HashSet<AssetTransactionModel>();
        }

        #endregion

        #region Public Properties

        public AccountModel Account { get; set; }

        public AssetModel Asset { get; set; }

        [Key]
        public int AssetInstanceId { get; set; }

        public ICollection<AssetTransactionModel> AssetTransactions { get; set; }

        public decimal BookCost { get; set; }

        public decimal MarketPrice { get; set; }

        #endregion
    }
}