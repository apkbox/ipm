// --------------------------------------------------------------------------------
// <copyright file="ViewModelCommandBindingCollection.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the ViewModelCommandBindingCollection type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using System.Collections.Generic;
    using System.Windows;

    public class ViewModelCommandBindingCollection : FreezableCollection<ViewModelCommandBinding>, 
                                                     ICollection<ViewModelCommandBinding>
    {
    }
}