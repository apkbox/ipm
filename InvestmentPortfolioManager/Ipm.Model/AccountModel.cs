// --------------------------------------------------------------------------------
// <copyright file="AccountModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using System.Collections.Generic;

    public class AccountModel
    {
        #region Public Properties

        public IEnumerator<AssetModel> Assets { get; private set; }

        public Currency Cash { get; set; }

        public AssetModel Buy()
        {
            return null;
        }

        #endregion
    }
}