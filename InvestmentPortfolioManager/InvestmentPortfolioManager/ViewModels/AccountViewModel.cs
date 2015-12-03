// --------------------------------------------------------------------------------
// <copyright file="AccountViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager.ViewModels
{
    using System.Linq;

    using Ipm.DataModel;

    using Prism.Mvvm;

    public class AccountViewModel : BindableBase, IViewModel<Account>
    {
        #region Public Properties

        public Account Model { get; set; }

        public string Name
        {
            get
            {
                return this.Model.Name;
            }

            set
            {
                this.Model.Name = value;
                this.OnPropertyChanged(() => this.Name);
            }
        }

        public string Description
        {
            get
            {
                return this.Model.Description;
            }

            set
            {
                this.Model.Description = value;
                this.OnPropertyChanged(() => this.Description);
            }
        }

        public string Currency
        {
            get
            {
                return this.Model.Currency;
            }

            set
            {
                this.Model.Currency = value;
                this.OnPropertyChanged(() => this.Currency);
            }
        }

        public decimal CashBalance
        {
            get
            {
                var accountBalanceBook = this.Model.BalanceBooks.OrderByDescending(b => b.BalanceBase.BalanceDate).FirstOrDefault();
                if (accountBalanceBook != null)
                {
                    return accountBalanceBook.BalanceBase.CashBalance;
                }

                return 0;
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool IsViewModelOf(Account model)
        {
            return this.Model.AccountId == model.AccountId;
        }

        #endregion
    }
}