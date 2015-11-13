// --------------------------------------------------------------------------------
// <copyright file="Currency.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the Currency type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    public class Currency
    {
        #region Public Properties

        public decimal Amount { get; set; }

        public CurrencyCode CurrencyCode { get; set; }

        #endregion
    }
}