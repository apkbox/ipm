// --------------------------------------------------------------------------------
// <copyright file="AccountModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AccountModel
    {
        #region Constructors and Destructors

        public AccountModel()
        {
            this.CashTransactions = new HashSet<CashTransactionModel>();
            this.AssetTransactions = new HashSet<AssetTransactionModel>();
            this.Assets = new HashSet<AssetInstanceModel>();
            this.BalanceBooks = new HashSet<AccountBalanceBookModel>();
        }

        #endregion

        #region Public Properties

        [Key]
        public int AccountId { get; set; }

        public ICollection<AssetTransactionModel> AssetTransactions { get; set; }

        public ICollection<AssetInstanceModel> Assets { get; set; }

        public ICollection<AccountBalanceBookModel> BalanceBooks { get; set; }

        public ICollection<CashTransactionModel> CashTransactions { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public virtual PortfolioModel Portfolio { get; set; }

        #endregion
    }
}