// --------------------------------------------------------------------------------
// <copyright file="CashTransactionModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the CashTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CashTransactionModel
    {
        #region Constructors and Destructors

        public CashTransactionModel()
        {
            this.IsImported = false;
        }

        #endregion

        #region Public Properties

        public AccountModel Account { get; set; }

        public decimal Amount { get; set; }

        public AssetTransactionModel AssetTransaction { get; set; }

        [Key, ForeignKey("AssetTransaction")]
        public int CashTransactionId { get; set; }

        public string Comment { get; set; }

        public string Description { get; set; }

        public bool IsImported { get; set; }

        public DateTime? SettlementDate { get; set; }

        public DateTime TransactionDate { get; set; }

        #endregion
    }
}