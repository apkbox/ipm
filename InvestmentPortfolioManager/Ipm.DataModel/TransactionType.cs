// --------------------------------------------------------------------------------
// <copyright file="TransactionType.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetTransactionType type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    public enum TransactionType
    {
        /// <summary>
        /// Buy or sell assets. This transaction type may or may not be linked to a cash transaction.
        /// </summary>
        BuySell, 

        /// <summary>
        /// Dividend payment. This transaction is always linked to cash transaction.
        /// </summary>
        Dividend, 

        /// <summary>
        /// Dividend reinvestment. This transaction same as buy transaction, but never linked to cash transaction.
        /// </summary>
        DividendReinvestment
    }
}