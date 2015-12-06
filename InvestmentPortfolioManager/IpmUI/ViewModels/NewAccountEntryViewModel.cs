// --------------------------------------------------------------------------------
// <copyright file="NewAccountEntryViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the NewAccountEntryViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System.Windows.Input;

    using Ipm.Model;

    using Prism.Commands;

    public class NewAccountEntryViewModel : AccountEntryViewModel
    {
        #region Fields

        private readonly DelegateCommand cancelAccountCreationCommand;

        private readonly DelegateCommand createAccountCommand;

        private readonly IpmEntityModel entityModel;

        private readonly PortfolioViewModel portfolioViewModel;

        private bool isCreatingAccount;

        private string startingCashBalance;

        #endregion

        #region Constructors and Destructors

        public NewAccountEntryViewModel(IpmEntityModel entityModel, PortfolioViewModel portfolioViewModel)
        {
            this.entityModel = entityModel;
            this.portfolioViewModel = portfolioViewModel;

            this.createAccountCommand = new DelegateCommand(this.ExecuteCreateAccount);
            this.cancelAccountCreationCommand = new DelegateCommand(this.ExecuteCancelAccountCreation);

            this.Model = new Account();
        }

        #endregion

        #region Public Properties

        public ICommand CancelAccountCreationCommand
        {
            get
            {
                return this.cancelAccountCreationCommand;
            }
        }

        public ICommand CreateAccountCommand
        {
            get
            {
                return this.createAccountCommand;
            }
        }

        public bool IsCreatingAccount
        {
            get
            {
                return this.isCreatingAccount;
            }

            set
            {
                this.SetProperty(ref this.isCreatingAccount, value);
            }
        }

        public string StartingCashBalance
        {
            get
            {
                return this.startingCashBalance;
            }

            set
            {
                this.SetProperty(ref this.startingCashBalance, value);
            }
        }

        #endregion

        #region Methods

        private void ExecuteCancelAccountCreation()
        {
            this.IsCreatingAccount = false;
            this.Model = new Account();
            this.OnPropertyChanged(string.Empty);
        }

        private void ExecuteCreateAccount()
        {
            if (this.portfolioViewModel.CreateNewAccount())
            {
                this.IsCreatingAccount = false;
                this.Model = new Account();
                this.OnPropertyChanged(string.Empty);
            }
        }

        #endregion
    }
}
