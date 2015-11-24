// --------------------------------------------------------------------------------
// <copyright file="PortfolioSummaryViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the PortfolioSummaryViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager.ViewModels
{
    using System.Collections.Generic;

    using Ipm.DataModel;

    using Prism.Mvvm;
    using Prism.Regions;

    public class PortfolioSummaryViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmModel ipmModel;

        private Portfolio portfolio;

        #endregion

        #region Constructors and Destructors

        public PortfolioSummaryViewModel(IpmModel ipmModel)
        {
            this.ipmModel = ipmModel;
        }

        #endregion

        #region Public Properties

        public IEnumerable<Account> Accounts
        {
            get
            {
                return this.ipmModel.Accounts;
            }
        }

        public string PortfolioName
        {
            get
            {
                return this.portfolio != null ? this.portfolio.Name : string.Empty;
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.SetPortfolio((int)navigationContext.Parameters["PortfolioId"]);
        }

        public void SetPortfolio(int portfolioId)
        {
            this.portfolio = this.ipmModel.Portfolios.Find(portfolioId);

            // ReSharper disable once ExplicitCallerInfoArgument
            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}