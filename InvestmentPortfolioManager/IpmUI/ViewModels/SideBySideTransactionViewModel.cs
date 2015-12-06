// --------------------------------------------------------------------------------
// <copyright file="SideBySideTransactionViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the SideBySideTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System;

    using Ipm.Model;

    public class SideBySideTransactionViewModel
    {
        #region Public Properties

        public AssetTransaction AssetTransaction { get; set; }

        public CashTransaction CashTransaction { get; set; }

        public DateTime TransactionDate { get; set; }

        #endregion
    }
}
