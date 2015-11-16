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

    using Ipm.Model.Transactions;

    public class AccountModel
    {
        #region Fields

        private readonly AssetCollection<AssetModel> assets = new AssetCollection<AssetModel>();

        private readonly IList<TransactionBase> transactions = new List<TransactionBase>();

        #endregion

        #region Public Properties

        public CurrencyCode AccountCurrency { get; set; }

        public AssetCollection<AssetModel> Assets
        {
            get
            {
                return this.assets;
            }
        }

        // TODO: Cash amount can only be updated via debet or credit transactions or via cash linked transactions.
        public decimal Cash { get; private set; }

        public decimal Total { get; private set; }

        public IList<TransactionBase> Transactions
        {
            get
            {
                return this.transactions;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddTransaction(TransactionBase transaction)
        {
            if (!transaction.Validate())
            {
                return;
            }

            this.transactions.Add(transaction);
            this.RecalculateBalance();
        }

        #endregion

        #region Methods

        private void RecalculateBalance()
        {
            this.Cash = 0;
            this.Total = 0;
            foreach (var t in this.transactions)
            {
                if (t.IsCashLinked)
                {
                    // TODO: Decide how to treat transaction amount - relative to cash or assets value...
                    // Buy - amount is negative (pay cash)
                    // Sell - amount is positive (receive cash)
                    // Debit - amount is positive (add cash)
                    // Credit - amount is negative (deduct cash)
                    this.Cash += t.Amount;
                }

                this.Total += t.Amount;
            }
        }

        #endregion
    }
}