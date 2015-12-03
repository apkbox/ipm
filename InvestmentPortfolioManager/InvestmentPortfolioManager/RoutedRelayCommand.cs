// --------------------------------------------------------------------------------
// <copyright file="RoutedRelayCommand.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoutedRelayCommand type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using System.Windows;
    using System.Windows.Input;

    public class RoutedRelayCommand : DependencyObject
    {
        public static RoutedCommand OpenAccountCommand = new RoutedCommand();
    }
}