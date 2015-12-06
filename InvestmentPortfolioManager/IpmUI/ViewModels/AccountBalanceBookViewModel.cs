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
    using System.Collections.ObjectModel;
    using System.Linq;

    using Ipm.Model;

    using Prism.Mvvm;
    using Prism.Regions;

    public class AccountBalanceBookViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmEntityModel entityModel;

        private readonly IRegionManager regionManager;

        private readonly ObservableCollection<SideBySideTransactionViewModel> sideBySideTransactions =
            new ObservableCollection<SideBySideTransactionViewModel>();

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

        public ICollection<SideBySideTransactionViewModel> SideBySideTransactions
        {
            get
            {
                return this.sideBySideTransactions;
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

            var cashOnly = this.model.CashTransactions.Where(t => t.AssetTransaction == null).Select(
                t => new SideBySideTransactionViewModel { CashTransaction = t, TransactionDate = t.TransactionDate });

            var assetsAndCash = this.model.AssetTransactions.Select(
                assetTransaction => new SideBySideTransactionViewModel
                                        {
                                            CashTransaction = assetTransaction.CashTransaction, 
                                            AssetTransaction = assetTransaction, 
                                            TransactionDate = assetTransaction.TransactionDate
                                        });

            this.sideBySideTransactions.Clear();
            this.sideBySideTransactions.AddRange(cashOnly.Concat(assetsAndCash).OrderBy(t => t.TransactionDate));

            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}
