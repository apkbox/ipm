// --------------------------------------------------------------------------------
// <copyright file="AccountSummaryViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountSummaryViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager.ViewModels
{
    using Ipm.DataModel;

    using Prism.Regions;

    public class AccountSummaryViewModel : AccountViewModel, INavigationAware
    {
        #region Fields

        private readonly IpmModel ipmModel;

        private readonly IRegionManager regionManager;

        #endregion

        #region Constructors and Destructors

        public AccountSummaryViewModel(IpmModel ipmModel, IRegionManager regionManager)
        {
            this.ipmModel = ipmModel;
            this.regionManager = regionManager;
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
            this.SetAccount((int)navigationContext.Parameters["AccountId"]);
        }

        public void SetAccount(int accountId)
        {
            this.Model = this.ipmModel.Accounts.Find(accountId);

            // ReSharper disable once ExplicitCallerInfoArgument
            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}