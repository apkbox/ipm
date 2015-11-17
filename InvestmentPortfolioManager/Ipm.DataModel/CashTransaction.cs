// --------------------------------------------------------------------------------
// <copyright file="CashTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the CashTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CashTransaction
    {
        #region Public Properties

        public string Comment { get; set; }

        public string Description { get; set; }

        [Key]
        public int CashTransactionId { get; set; }

        public bool IsImported { get; set; }

        public DateTime? SettlementDate { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        #endregion
    }
}