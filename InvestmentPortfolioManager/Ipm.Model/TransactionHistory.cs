// --------------------------------------------------------------------------------
// <copyright file="TransactionHistory.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the TransactionHistory type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System.Collections.Generic;

    public class TransactionHistory
    {
        #region Public Properties

        public IEnumerator<BuySellTransaction> Transactions { get; set; }

        #endregion
    }
}