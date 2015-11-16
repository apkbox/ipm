// --------------------------------------------------------------------------------
// <copyright file="CashTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the CashTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model.Transactions
{
    using System;

    public class CashTransaction : TransactionBase
    {
        #region Public Properties

        public override bool IsCashLinked
        {
            get
            {
                return true;
            }

            set
            {
                throw new InvalidOperationException("Cannot change IsCashLinked: cash transactions always cash linked.");
            }
        }

        #endregion
    }
}