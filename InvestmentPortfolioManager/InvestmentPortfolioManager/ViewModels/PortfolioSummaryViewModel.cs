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
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    using Ipm.DataModel;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class PortfolioSummaryViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmModel ipmModel;

        private readonly DelegateCommand<int?> openAccountCommand;

        private readonly IRegionManager regionManager;

        private ViewModelCollection<AccountViewModel, Account> accounts;

        private Portfolio portfolio;

        #endregion

        #region Constructors and Destructors

        public PortfolioSummaryViewModel(IpmModel ipmModel, IRegionManager regionManager)
        {
            this.ipmModel = ipmModel;
            this.regionManager = regionManager;
            this.openAccountCommand = new DelegateCommand<int?>(this.ExecuteOpenAccount);
        }

        #endregion

        #region Public Properties

        public ICollection<AccountViewModel> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        public ICommand OpenAccountCommand
        {
            get
            {
                return this.openAccountCommand;
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
            this.accounts = new ViewModelCollection<AccountViewModel, Account>(
                this.portfolio.Accounts, 
                (model, context) => new AccountViewModel { Model = model });

            // ReSharper disable once ExplicitCallerInfoArgument
            this.OnPropertyChanged(string.Empty);
        }

        #endregion

        #region Methods

        private void ExecuteOpenAccount(int? accountId)
        {
            if (accountId != null)
            {
                var parameters = new NavigationParameters { { "AccountId", accountId } };
                this.regionManager.RequestNavigate("MainRegion", "AccountSummary", parameters);
            }
        }

        #endregion
    }
}