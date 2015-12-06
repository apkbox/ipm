// --------------------------------------------------------------------------------
// <copyright file="PortfolioBalanceBookModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the PortfolioBalanceBook type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    public class PortfolioBalanceBookModel : BalanceBase
    {
        #region Constructors and Destructors

        public PortfolioBalanceBookModel()
        {
        }

        #endregion

        #region Public Properties

        public int Id { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        #endregion
    }
}