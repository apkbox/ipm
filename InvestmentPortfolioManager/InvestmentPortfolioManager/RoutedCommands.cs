// --------------------------------------------------------------------------------
// <copyright file="RoutedCommands.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoutedCommands type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using System.Windows.Input;

    public class RoutedCommands
    {
        #region Static Fields

        public static readonly RoutedCommand OpenAccountCommand = new RoutedCommand();

        #endregion
    }
}