// --------------------------------------------------------------------------------
// <copyright file="AccountEntryViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountEntryViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System.Globalization;
    using System.Linq;

    using Ipm.Model;

    using Prism.Mvvm;

    public class AccountEntryViewModel : BindableBase
    {
        #region Public Properties

        public string AssetsBookCost
        {
            get
            {
                if (this.Model == null)
                {
                    return string.Empty;
                }

                var amount = this.GetAssetsBookCostInternal();
                return amount.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public string AssetsMarketValue
        {
            get
            {
                if (this.Model == null)
                {
                    return string.Empty;
                }

                var amount = this.GetAssetsMarketValueInternal();
                return amount.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public string CashAmount
        {
            get
            {
                if (this.Model == null)
                {
                    return string.Empty;
                }

                var amount = this.Model.CashTransactions.Sum(c => c.Amount);
                return amount.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public string Currency
        {
            get
            {
                return this.Model != null ? this.Model.Currency : string.Empty;
            }

            set
            {
                if (this.Model != null)
                {
                    this.Model.Currency = value;
                    this.OnPropertyChanged(() => this.Currency);
                }
            }
        }

        public string Description
        {
            get
            {
                return this.Model != null ? this.Model.Description : string.Empty;
            }

            set
            {
                if (this.Model != null)
                {
                    this.Model.Description = value;
                    this.OnPropertyChanged(() => this.Description);
                }
            }
        }

        public Account Model { get; set; }

        public string Name
        {
            get
            {
                return this.Model != null ? this.Model.Name : string.Empty;
            }

            set
            {
                if (this.Model != null)
                {
                    this.Model.Name = value;
                    this.OnPropertyChanged(() => this.Name);
                }
            }
        }

        public string ReturnAmount
        {
            get
            {
                if (this.Model == null)
                {
                    return string.Empty;
                }

                var amount = this.GetReturnAmountInternal();
                return amount.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public string ReturnPercent
        {
            get
            {
                if (this.Model == null)
                {
                    return string.Empty;
                }

                var bookCost = this.GetAssetsBookCostInternal();
                if (bookCost == 0)
                {
                    return 0.ToString("P", CultureInfo.CurrentCulture);
                }

                decimal amount = this.GetReturnAmountInternal() / bookCost * 100.0m;
                return amount.ToString("P", CultureInfo.CurrentCulture);
            }
        }

        public string Yield
        {
            get
            {
                if (this.Model == null)
                {
                    return string.Empty;
                }

                if (this.Model.Assets.Count == 0)
                {
                    return 0.ToString("P", CultureInfo.CurrentCulture);
                }

                var amount = this.Model.Assets.Sum(c => c.Asset.Yield);
                amount /= this.Model.Assets.Count;
                return amount.ToString("P", CultureInfo.CurrentCulture);
            }
        }

        #endregion

        #region Methods

        private decimal GetAssetsBookCostInternal()
        {
            var amount = this.Model.Assets.Sum(c => c.BookCost);
            return amount;
        }

        private decimal GetAssetsMarketValueInternal()
        {
            var amount = this.Model.Assets.Sum(c => c.MarketValue);
            return amount;
        }

        private decimal GetReturnAmountInternal()
        {
            decimal amount =
                this.Model.AssetTransactions.Where(
                    assetTransaction => assetTransaction.TransactionType == TransactionType.Dividend)
                    .Sum(assetTransaction => assetTransaction.Amount);

            amount += this.GetAssetsMarketValueInternal() - this.GetAssetsBookCostInternal();
            return amount;
        }

        #endregion
    }
}
