// --------------------------------------------------------------------------------
// <copyright file="PortfolioViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the PortfolioViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;

    using Ipm.Model;

    using Prism.Mvvm;
    using Prism.Regions;

    public class PortfolioViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly ObservableCollection<AccountEntryViewModel> accounts =
            new ObservableCollection<AccountEntryViewModel>();

        private readonly IpmEntityModel entityModel;

        private NewAccountEntryViewModel newAccountEntryViewModel;

        private Portfolio portfolio;

        #endregion

        #region Constructors and Destructors

        public PortfolioViewModel(IpmEntityModel entityModel)
        {
            this.entityModel = entityModel;
        }

        #endregion

        #region Public Properties

        public ObservableCollection<AccountEntryViewModel> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        public string Name
        {
            get
            {
                if (this.portfolio != null)
                {
                    return this.portfolio.Name;
                }

                return string.Empty;
            }

            set
            {
                if (this.portfolio != null)
                {
                    this.portfolio.Name = value;
                    this.OnPropertyChanged(() => this.Name);
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return navigationContext.Parameters["PortfolioId"] != null;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var portfolioId = (int?)navigationContext.Parameters["PortfolioId"];
            if (portfolioId != null)
            {
                this.SetPortfolio((int)portfolioId);
            }
        }

        #endregion

        #region Methods

        internal bool CreateNewAccount()
        {
            this.Accounts.Remove(this.newAccountEntryViewModel);

            var accountModel = this.newAccountEntryViewModel.Model;
            decimal startingBalance;
            var hasStartingBalance = decimal.TryParse(
                this.newAccountEntryViewModel.StartingCashBalance, 
                out startingBalance);

            var newModel = this.entityModel.CreateAccount(
                this.portfolio.PortfolioId, 
                accountModel.Name, 
                accountModel.Description, 
                accountModel.Currency, 
                hasStartingBalance ? (decimal?)startingBalance : null);

            this.accounts.Add(new AccountEntryViewModel { Model = newModel });

            this.Accounts.Remove(this.newAccountEntryViewModel);
            this.newAccountEntryViewModel = new NewAccountEntryViewModel(this.entityModel, this);
            this.accounts.Add(this.newAccountEntryViewModel);
            return true;
        }

        private void SetPortfolio(int portfolioId)
        {
            this.portfolio = this.entityModel.GetPorfolio(portfolioId);
            this.accounts.Clear();

            var viewModels =
                from accountEntity in
                    this.entityModel.Accounts
                where
                    accountEntity.Portfolio.PortfolioId == portfolioId
                select new AccountEntryViewModel() { Model = accountEntity };

            this.accounts.AddRange(viewModels);

            this.newAccountEntryViewModel = new NewAccountEntryViewModel(this.entityModel, this);
            this.accounts.Add(this.newAccountEntryViewModel);
            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}
