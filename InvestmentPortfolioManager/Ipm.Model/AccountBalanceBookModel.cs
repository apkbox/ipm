// --------------------------------------------------------------------------------
// <copyright file="AccountBalanceBookModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the AccountBalanceBookModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    public class AccountBalanceBookModel : BalanceBase
    {
        #region Public Properties

        public AccountModel Account { get; set; }

        public int Id { get; set; }

        #endregion
    }
}