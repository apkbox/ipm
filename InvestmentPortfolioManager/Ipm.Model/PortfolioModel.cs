// --------------------------------------------------------------------------------
// <copyright file="PortfolioModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the PortfolioModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class PortfolioModel
    {
        #region Fields

        private readonly Collection<AccountModel> accounts = new Collection<AccountModel>();

        #endregion

        #region Constructors and Destructors

        public PortfolioModel()
        {
            var account = new AccountModel()
                              {
                                  // Cash = new Currency { CurrencyCode = CurrencyCode.CAD, Amount = 100000 }
                              };
            var asset = new AssetModel
                            {
                                AssetCurrency = CurrencyCode.CAD, 
                                Ticker = "MSFT", 
                                Desciption = "Microsoft Corporation", 
                                LastPrice = new decimal(56.33), 
                                LastPriceTimestamp = DateTime.Now, 
                                Quantity = 500
                            };

            account.Assets.Add(asset);
        }

        #endregion

        #region Public Properties

        public IList<AccountModel> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        #endregion
    }
}