// --------------------------------------------------------------------------------
// <copyright file="NewTransactionViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the NewTransactionViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows.Input;

    using Ipm.Model;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class NewTransactionViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private readonly IpmEntityModel entityModel;

        private string assetName;

        private string assetPrice;

        private string assetQuantity;

        private DateTime assetSettlementDate;

        private string assetTickerSymbol;

        private string assetTransactionAmount;

        private string assetTransactionComment;

        private string assetTransactionCommission;

        private DateTime assetTransactionDate;

        private string assetTransactionDescription;

        private DateTime? cashSettlementDate;

        private string cashTransactionAmount;

        private string cashTransactionComment;

        private DateTime cashTransactionDate;

        private string cashTransationDescription;

        private Account model;

        private TransactionUiType transactionType;

        #endregion

        #region Constructors and Destructors

        public NewTransactionViewModel(IpmEntityModel entityModel)
        {
            this.entityModel = entityModel;

            this.SaveCommand = new DelegateCommand(this.ExecuteSaveCommand);
        }

        #endregion

        #region Public Properties

        public string AssetName
        {
            get
            {
                return this.assetName;
            }

            set
            {
                this.SetProperty(ref this.assetName, value);
            }
        }

        public string AssetPrice
        {
            get
            {
                return this.assetPrice;
            }

            set
            {
                this.SetProperty(ref this.assetPrice, value);
            }
        }

        public string AssetQuantity
        {
            get
            {
                return this.assetQuantity;
            }

            set
            {
                this.SetProperty(ref this.assetQuantity, value);
            }
        }

        public DateTime AssetSettlementDate
        {
            get
            {
                return this.assetSettlementDate;
            }

            set
            {
                this.SetProperty(ref this.assetSettlementDate, value);
            }
        }

        public string AssetTickerSymbol
        {
            get
            {
                return this.assetTickerSymbol;
            }

            set
            {
                this.SetProperty(ref this.assetTickerSymbol, value);
            }
        }

        public string AssetTransactionAmount
        {
            get
            {
                return this.assetTransactionAmount;
            }

            set
            {
                this.SetProperty(ref this.assetTransactionAmount, value);
            }
        }

        public string AssetTransactionComment
        {
            get
            {
                return this.assetTransactionComment;
            }

            set
            {
                this.SetProperty(ref this.assetTransactionComment, value);
            }
        }

        public string AssetTransactionCommission
        {
            get
            {
                return this.assetTransactionCommission;
            }

            set
            {
                this.SetProperty(ref this.assetTransactionCommission, value);
            }
        }

        public DateTime AssetTransactionDate
        {
            get
            {
                return this.assetTransactionDate;
            }

            set
            {
                this.SetProperty(ref this.assetTransactionDate, value);
            }
        }

        public string AssetTransactionDescription
        {
            get
            {
                return this.assetTransactionDescription;
            }

            set
            {
                this.SetProperty(ref this.assetTransactionDescription, value);
            }
        }

        public DateTime? CashSettlementDate
        {
            get
            {
                return this.cashSettlementDate;
            }

            set
            {
                this.SetProperty(ref this.cashSettlementDate, value);
            }
        }

        public string CashTransactionAmount
        {
            get
            {
                return this.cashTransactionAmount;
            }

            set
            {
                this.SetProperty(ref this.cashTransactionAmount, value);
            }
        }

        public string CashTransactionComment
        {
            get
            {
                return this.cashTransactionComment;
            }

            set
            {
                this.SetProperty(ref this.cashTransactionComment, value);
            }
        }

        public DateTime CashTransactionDate
        {
            get
            {
                return this.cashTransactionDate;
            }

            set
            {
                if (this.SetProperty(ref this.cashTransactionDate, value))
                {
                    if (this.CashSettlementDate == null)
                    {
                        this.CashSettlementDate = value;
                    }
                }
            }
        }

        public string CashTransationDescription
        {
            get
            {
                return this.cashTransationDescription;
            }

            set
            {
                this.SetProperty(ref this.cashTransationDescription, value);
            }
        }

        public ICommand SaveCommand { get; private set; }

        public TransactionUiType TransactionType
        {
            get
            {
                return this.transactionType;
            }

            set
            {
                this.SetProperty(ref this.transactionType, value);
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

        private void ExecuteSaveCommand()
        {
            if (this.transactionType == TransactionUiType.Deposit)
            {
                this.model.CashTransactions.Add(
                    new CashTransaction
                        {
                            TransactionDate = this.CashTransactionDate, 
                            SettlementDate = this.CashSettlementDate, 
                            Description = this.CashTransationDescription, 
                            Comment = this.CashTransactionComment, 
                            Amount = decimal.Parse(this.CashTransactionAmount)
                        });
                this.entityModel.SaveChanges();
            }
            else if (this.transactionType == TransactionUiType.Withdraw)
            {
                this.model.CashTransactions.Add(
                    new CashTransaction
                        {
                            TransactionDate = this.CashTransactionDate, 
                            SettlementDate = this.CashSettlementDate, 
                            Description = this.CashTransationDescription, 
                            Comment = this.CashTransactionComment, 
                            Amount = -Convert.ToDecimal(this.CashTransactionAmount)
                        });
                this.entityModel.SaveChanges();
            }
            else if (this.transactionType == TransactionUiType.Buy)
            {
                var asset = this.entityModel.Assets.FirstOrDefault(a => a.Ticker == this.AssetTickerSymbol);
                if (asset == null)
                {
                    asset = new Asset()
                                {
                                    Ticker = this.AssetTickerSymbol, 
                                    Desciption = this.AssetName, 
                                    AssetCurrency = CurrencyCode.CAD, 
                                    Quantity = 0, 
                                    LastPrice = Convert.ToDecimal(this.AssetPrice), 
                                    LastPriceTimestamp = this.AssetTransactionDate, 
                                    Yield = 0
                                };
                    this.entityModel.Assets.Add(asset);
                }

                var cashTransaction = new CashTransaction
                                          {
                                              TransactionDate = this.CashTransactionDate, 
                                              SettlementDate = this.CashSettlementDate, 
                                              Description = this.CashTransationDescription, 
                                              Comment = this.CashTransactionComment, 
                                              Amount = -Convert.ToDecimal(this.CashTransactionAmount)
                                          };
                this.model.CashTransactions.Add(cashTransaction);

                var assetInstance = new AssetInstance
                                        {
                                            Asset = asset, 
                                            BookCost = Convert.ToDecimal(this.AssetTransactionAmount)
                                        };
                this.model.Assets.Add(assetInstance);
                this.model.AssetTransactions.Add(
                    new AssetTransaction()
                        {
                            TransactionType = Ipm.Model.TransactionType.BuySell, 
                            TransactionDate = this.AssetTransactionDate, 
                            SettlementDate = this.AssetSettlementDate, 
                            TickerSymbol = this.AssetTickerSymbol, 
                            AssetName = this.AssetName, 
                            Description = this.AssetTransactionDescription, 
                            Comment = this.AssetTransactionComment, 
                            Quantity = Convert.ToDecimal(this.AssetQuantity), 
                            Price = Convert.ToDecimal(this.AssetPrice), 
                            Commission = Convert.ToDecimal(this.AssetTransactionCommission), 
                            Amount = Convert.ToDecimal(this.AssetTransactionAmount), 
                            CashTransaction = cashTransaction, 
                            AssetInstance = assetInstance
                        });
                this.entityModel.SaveChanges();
            }
        }

        private void SetModel(int accountId)
        {
            this.model = this.entityModel.Accounts.Find(accountId);

            var now = DateTime.Now;
            this.cashTransactionDate = now;
            this.cashSettlementDate = now;
            this.assetTransactionDate = now;
            this.assetSettlementDate = now;

            this.OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}
