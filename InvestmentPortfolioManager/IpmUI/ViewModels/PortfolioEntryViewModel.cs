// --------------------------------------------------------------------------------
// <copyright file="PortfolioEntryViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the PortfolioViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using Ipm.Model;

    using Prism.Mvvm;

    public class PortfolioEntryViewModel : BindableBase
    {
        #region Public Properties

        public Portfolio Model { get; set; }

        public string Name
        {
            get
            {
                return this.Model.Name;
            }

            set
            {
                this.Model.Name = value;
                this.OnPropertyChanged(() => this.Name);
            }
        }

        #endregion
    }
}
