// --------------------------------------------------------------------------------
// <copyright file="MainModule.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the MainModule type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using Microsoft.Practices.Unity;

    using Prism.Modularity;
    using Prism.Regions;

    public class MainModule : IModule
    {
        #region Fields

        private readonly IRegionManager regionManager;

        private readonly IUnityContainer unityContainer;

        #endregion

        #region Constructors and Destructors

        public MainModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("MainRegion", typeof(PortfolioSummaryView));
        }

        #endregion
    }
}