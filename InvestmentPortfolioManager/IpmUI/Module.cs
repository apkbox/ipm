// --------------------------------------------------------------------------------
// <copyright file="Module.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the Module type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI
{
    using IpmUI.Views;

    using Microsoft.Practices.Unity;

    using Prism.Modularity;
    using Prism.Regions;

    [Module(ModuleName = "IpmUI")]
    [ModuleDependency("IpmModel")]
    public class Module : IModule
    {
        #region Fields

        private readonly IRegionManager regionManager;

        private readonly IUnityContainer unityContainer;

        #endregion

        #region Constructors and Destructors

        public Module(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            this.RegisterView<HomeView>(ViewNames.HomeView, RegionNames.MainRegion);
            this.RegisterView<PortfolioView>(ViewNames.PortfolioView, RegionNames.MainRegion);
            this.RegisterView<AccountView>(ViewNames.AccountView, RegionNames.MainRegion);
        }

        private void RegisterView<T>(string viewName, string regionName)
        {
            this.unityContainer.RegisterType<T>(viewName);
            this.regionManager.RegisterViewWithRegion(regionName, typeof(T));
        }

        #endregion
    }
}
