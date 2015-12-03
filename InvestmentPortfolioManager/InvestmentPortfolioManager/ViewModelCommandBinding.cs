// --------------------------------------------------------------------------------
// <copyright file="ViewModelCommandBinding.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the ViewModelCommandBinding type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    public class ViewModelCommandBinding : Freezable
    {
        #region Static Fields

        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.Register(
                "ViewModelCommand", 
                typeof(ICommand), 
                typeof(ViewModelCommandBinding), 
                new PropertyMetadata(default(ICommand)));

        #endregion

        #region Public Properties

        public ICommand RoutedCommand { get; set; }

        public ICommand ViewModelCommand
        {
            get
            {
                return (ICommand)this.GetValue(ViewModelCommandProperty);
            }

            set
            {
                this.SetValue(ViewModelCommandProperty, value);
            }
        }

        #endregion

        #region Methods

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}