﻿// --------------------------------------------------------------------------------
// <copyright file="HomeView.xaml.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for HomeView.xaml.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.Views
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for HomeView.
    /// </summary>
    public partial class HomeView : UserControl
    {
        #region Constructors and Destructors

        public HomeView()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void CreateNewPortfolioButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.NewPortfolioName.Focus();
        }

        #endregion
    }
}
