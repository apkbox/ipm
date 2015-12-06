// --------------------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using Ipm.Model;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class HomeViewModel : BindableBase
    {
        #region Fields

        private readonly IpmEntityModel entityModel;

        private readonly DelegateCommand<int?> openPortfolioCommand;

        private readonly ObservableCollection<PortfolioEntryViewModel> portfolios =
            new ObservableCollection<PortfolioEntryViewModel>();

        private readonly IRegionManager regionManager;

        private bool isCreatingPortfolio;

        #endregion

        #region Constructors and Destructors

        public HomeViewModel(IpmEntityModel entityModel, IRegionManager regionManager)
        {
            this.entityModel = entityModel;
            this.regionManager = regionManager;
            this.CreateNewPortfolioCommand = new DelegateCommand<string>(this.ExecuteCreateNewPortfolio);
            this.CancelPortfolioCreationCommand = new DelegateCommand(this.ExecuteCancelPortfolioCreation);
            this.openPortfolioCommand = new DelegateCommand<int?>(
                this.ExecuteOpenPortfolio, 
                this.CanExecuteOpenPortfolio);

            this.portfolios.AddRange(
                this.entityModel.Portfolios.Select(p => new PortfolioEntryViewModel { Model = p }));
        }

        #endregion

        #region Public Properties

        public ICommand CancelPortfolioCreationCommand { get; private set; }

        public ICommand CreateNewPortfolioCommand { get; private set; }

        public bool IsCreatingPortfolio
        {
            get
            {
                return this.isCreatingPortfolio;
            }

            set
            {
                this.SetProperty(ref this.isCreatingPortfolio, value);
                this.openPortfolioCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand OpenPortfolioCommand
        {
            get
            {
                return this.openPortfolioCommand;
            }
        }

        public ICollection<PortfolioEntryViewModel> Portfolios
        {
            get
            {
                return this.portfolios;
            }
        }

        #endregion

        #region Methods

        private bool CanExecuteOpenPortfolio(int? i)
        {
            return !this.IsCreatingPortfolio;
        }

        private void ExecuteCancelPortfolioCreation()
        {
            this.IsCreatingPortfolio = false;
        }

        private void ExecuteCreateNewPortfolio(string portfolioName)
        {
            var newPortfolio = this.entityModel.CreatePortfolio(portfolioName);
            if (newPortfolio != null)
            {
                this.IsCreatingPortfolio = false;
                this.portfolios.Add(new PortfolioEntryViewModel { Model = newPortfolio });
            }
        }

        private void ExecuteOpenPortfolio(int? i)
        {
            var parameters = new NavigationParameters
                                 {
                                     { "PortfolioId", i }
                                 };
            this.regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.PortfolioView, parameters);
        }

        #endregion
    }
}
