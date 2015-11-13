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
    using System.Collections.Generic;

    public class PortfolioModel
    {
        public IEnumerator<AccountModel> Accounts { get; set; }
    }
}