// --------------------------------------------------------------------------------
// <copyright file="IViewModelProvider.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the IViewModelProvider type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    public interface IViewModelProvider<in TModel>
        where TModel : class
    {
        #region Public Methods and Operators

        TViewModel GetFor<TViewModel>(TModel model, object o);

        #endregion
    }
}