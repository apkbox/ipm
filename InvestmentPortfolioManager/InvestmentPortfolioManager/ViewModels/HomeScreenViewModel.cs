// --------------------------------------------------------------------------------
// <copyright file="HomeScreenViewModel.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeScreenViewModel type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager.ViewModels
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Input;

    using Ipm.DataModel;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class HomeScreenViewModel : BindableBase
    {
        #region Fields

        private readonly IpmModel ipmModel;

        private readonly IRegionManager regionManager;

        private bool isCreatingPortfolio;

        private string newPortfolioName;

        #endregion

        #region Constructors and Destructors

        public HomeScreenViewModel(IpmModel ipmModel, IRegionManager regionManager)
        {
            this.ipmModel = ipmModel;
            this.regionManager = regionManager;
            this.StartCreatingPortfolioCommand = new DelegateCommand(this.ExecuteStartCreatingPortfolio);
            this.CancelPortfolioCreationCommand = new DelegateCommand(this.ExecuteCancelPortfolioCreation);
            this.CreatePortfolioCommand = new DelegateCommand(this.ExecuteCreatePortfolio);
            this.OpenPortfolioCommand = new DelegateCommand<Portfolio>(this.ExecuteOpenPortfolio);
        }

        #endregion

        #region Public Properties

        public ICommand CancelPortfolioCreationCommand { get; private set; }

        public ICommand CreatePortfolioCommand { get; private set; }

        public bool HasPortfolios
        {
            get
            {
                return this.ipmModel.Portfolios.Any();
            }
        }

        public bool IsCreatingPortfolio
        {
            get
            {
                return this.isCreatingPortfolio;
            }

            set
            {
                this.SetProperty(ref this.isCreatingPortfolio, value);
            }
        }

        public string NewPortfolioName
        {
            get
            {
                return this.newPortfolioName;
            }

            set
            {
                this.SetProperty(ref this.newPortfolioName, value);
            }
        }

        public ICommand OpenPortfolioCommand { get; private set; }

        public IList<Portfolio> Portfolios
        {
            get
            {
                this.ipmModel.Portfolios.Load();
                return this.ipmModel.Portfolios.Local;
            }
        }

        public ICommand StartCreatingPortfolioCommand { get; private set; }

        #endregion

        #region Methods

        private void ExecuteCancelPortfolioCreation()
        {
            this.IsCreatingPortfolio = false;
        }

        private void ExecuteCreatePortfolio()
        {
            if (string.IsNullOrWhiteSpace(this.NewPortfolioName))
            {
                return;
            }

            var portfolio = new Portfolio { Name = this.NewPortfolioName };
            this.ipmModel.Portfolios.Add(portfolio);
            this.ipmModel.SaveChanges();
            this.IsCreatingPortfolio = false;
        }

        private void ExecuteOpenPortfolio(Portfolio portfolio)
        {
            var parameters = new NavigationParameters();
            parameters.Add("PortfolioId", portfolio.PortfolioId);
            this.regionManager.RequestNavigate("MainRegion", "PortfolioSummary", parameters);
        }

        private void ExecuteStartCreatingPortfolio()
        {
            this.IsCreatingPortfolio = true;
            this.NewPortfolioName = string.Empty;
        }

        #endregion
    }
}