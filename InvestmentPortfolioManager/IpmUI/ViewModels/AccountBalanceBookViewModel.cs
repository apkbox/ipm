// --------------------------------------------------------------------------------
// <copyright file="AccountBalanceBookViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountBalanceBookViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Ipm.Model;

    using Prism.Mvvm;
    using Prism.Regions;

    public class AccountBalanceBookViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmEntityModel entityModel;

        private readonly IRegionManager regionManager;

        private Account model;

        #endregion

        #region Constructors and Destructors

        public AccountBalanceBookViewModel(IpmEntityModel entityModel, IRegionManager regionManager)
        {
            this.entityModel = entityModel;
            this.regionManager = regionManager;
        }

        #endregion

        #region Public Properties

        public ICollection<int> SideBySideTransactions
        {
            get
            {
                return new List<int>
                           {
                               1, 
                               2, 
                               3, 
                               4, 
                               5, 
                               6, 
                               56, 
                               546, 
                               546, 
                               45, 
                               66, 
                               45, 
                               56, 
                               456, 
                               456, 
                               54
                           };
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

        private void SetModel(int accountId)
        {
            this.model = this.entityModel.Accounts.Find(accountId);

            // TODO: Here we need to create a full outer join across Cash and Asset transactions.
            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}
