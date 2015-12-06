// --------------------------------------------------------------------------------
// <copyright file="Account.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System.Collections.Generic;

    public class Account
    {
        #region Constructors and Destructors

        public Account()
        {
            this.CashTransactions = new HashSet<CashTransaction>();
            this.AssetTransactions = new HashSet<AssetTransaction>();
            this.Assets = new HashSet<AssetInstance>();
            this.BalanceBooks = new HashSet<AccountBalanceBookModel>();
        }

        #endregion

        #region Public Properties

        public virtual ICollection<AssetTransaction> AssetTransactions { get; set; }

        public virtual ICollection<AssetInstance> Assets { get; set; }

        public virtual ICollection<AccountBalanceBookModel> BalanceBooks { get; set; }

        public virtual ICollection<CashTransaction> CashTransactions { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        #endregion
    }
}
