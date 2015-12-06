// --------------------------------------------------------------------------------
// <copyright file="Module.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the Module type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model
{
    using Microsoft.Practices.Unity;

    using Prism.Modularity;

    [Module(ModuleName = "IpmModel")]
    public class Module : IModule
    {
        #region Fields

        private readonly IUnityContainer unityContainer;

        #endregion

        #region Constructors and Destructors

        public Module(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            this.unityContainer.RegisterType<IpmEntityModel>(new PerThreadLifetimeManager());
        }

        #endregion
    }
}