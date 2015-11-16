// --------------------------------------------------------------------------------
// <copyright file="BuySellTransaction.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the BuySellTransaction type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model.Transactions
{
    public class BuySellTransaction : TransactionBase
    {
        #region Constructors and Destructors

        public BuySellTransaction()
        {
        }

        #endregion

        #region Public Properties

        public decimal Price { get; set; }

        public decimal Comission { get; set; }

        public decimal Quantity { get; set; }

        public decimal SettlementPrice { get; set; }

        public string Ticker { get; set; }

        #endregion

        #region Public Methods and Operators

        public override bool Validate()
        {
            if (!base.Validate())
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.Ticker))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}