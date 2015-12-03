// --------------------------------------------------------------------------------
// <copyright file="IViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the IViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    public interface IViewModel<TModel>
    {
        #region Public Properties

        TModel Model { get; set; }

        #endregion

        #region Public Methods and Operators

        bool IsViewModelOf(TModel model);

        #endregion
    }
}