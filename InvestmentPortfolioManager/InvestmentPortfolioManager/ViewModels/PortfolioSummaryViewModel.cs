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
    using System.Diagnostics;
    using System.Net;
    using System.Windows.Input;

    using Ipm.DataModel;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class PortfolioSummaryViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmModel ipmModel;

        private ViewModelCollection<AccountViewModel, Account> accounts;

        private Portfolio portfolio;

        private DelegateCommand openAccountCommand;

        #endregion

        #region Constructors and Destructors

        public PortfolioSummaryViewModel(IpmModel ipmModel)
        {
            this.ipmModel = ipmModel;
            this.openAccountCommand = new DelegateCommand(this.ExecuteOpenAccount);
        }

        private void ExecuteOpenAccount()
        {
            Debug.WriteLine("Opening account");
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

        public string PortfolioName
        {
            get
            {
                return this.portfolio != null ? this.portfolio.Name : string.Empty;
            }
        }

        public ICommand OpenAccountCommand
        {
            get
            {
                return this.openAccountCommand;
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
                (model, context) => new AccountViewModel() { Model = model });

            // ReSharper disable once ExplicitCallerInfoArgument
            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}