// --------------------------------------------------------------------------------
// <copyright file="TransactionBase.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the TransactionBase type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model.Transactions
{
    using System;

    public abstract class TransactionBase
    {
        #region Fields

        private readonly string id;

        #endregion

        #region Constructors and Destructors

        protected TransactionBase()
        {
            this.id = Guid.NewGuid().ToString();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets transaction amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets user comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets transaction description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a unique transaction ID.
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction is cash linked.
        /// </summary>
        public virtual bool IsCashLinked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether transaction was imported.
        /// </summary>
        public bool IsImported { get; set; }

        /// <summary>
        /// Gets or sets a settlement date.
        /// </summary>
        public DateTime SettlementDate { get; set; }

        /// <summary>
        /// Gets or sets a transaction date.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a transaction type.
        /// </summary>
        public TransactionType TransactionType { get; protected set; }

        #endregion

        #region Public Methods and Operators

        public virtual bool Validate()
        {
            return true;
        }

        #endregion
    }
}