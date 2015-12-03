// --------------------------------------------------------------------------------
// <copyright file="TransactionType.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the TransactionType type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    public enum TransactionType
    {
        BuySell = 0, 

        Dividend = 1, 

        DividendReinvestment = 2
    }
}