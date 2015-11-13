// --------------------------------------------------------------------------------
// <copyright file="AccountTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;

    public class AccountTransaction
    {
        #region Public Properties

        public string Id { get; set; }

        public bool IsImported { get; set; }

        public Currency Amount { get; set; }

        public string Comment { get; set; }

        public string Description { get; set; }

        public DateTime SettlementDate { get; set; }

        public DateTime TransactionDate { get; set; }

        #endregion
    }
}