// --------------------------------------------------------------------------------
// <copyright file="AccountViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System.Windows.Input;

    using Ipm.Model;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class AccountViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmEntityModel entityModel;

        private readonly IRegionManager regionManager;

        private readonly DelegateCommand<int?> showBalanceBookCommand;

        private Account model;

        #endregion

        #region Constructors and Destructors

        public AccountViewModel(IpmEntityModel entityModel, IRegionManager regionManager)
        {
            this.entityModel = entityModel;
            this.regionManager = regionManager;
            this.showBalanceBookCommand = new DelegateCommand<int?>(this.ExecuteShowBalanceBook);
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                if (this.model == null)
                {
                    return string.Empty;
                }

                return this.model.Name;
            }
        }

        public string PortfolioName
        {
            get
            {
                if (this.model == null)
                {
                    return string.Empty;
                }

                return this.model.Portfolio.Name;
            }
        }

        public ICommand ShowBalanceBookCommand
        {
            get
            {
                return this.showBalanceBookCommand;
            }
        }

        public Account Model
        {
            get
            {
                return this.model;
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return navigationContext.Parameters["AccountId"] != null;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var accountId = (int?)navigationContext.Parameters["AccountId"];
            if (accountId != null)
            {
                this.SetModel((int)accountId);
            }
        }

        #endregion

        #region Methods

        private void ExecuteShowBalanceBook(int? accountId)
        {
            var parameters = new NavigationParameters
                                 {
                                     { "AccountId", accountId }
                                 };

            this.regionManager.RequestNavigate(
                RegionNames.AccountDetailsRegion,
                ViewNames.AccountBalanceBookView,
                parameters);
        }

        private void SetModel(int accountId)
        {
            this.model = this.entityModel.Accounts.Find(accountId);
            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}
