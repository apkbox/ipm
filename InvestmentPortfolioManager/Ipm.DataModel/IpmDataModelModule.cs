// --------------------------------------------------------------------------------
// <copyright file="IpmDataModelModule.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the IpmDataModelModule type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.DataModel
{
    using Microsoft.Practices.Unity;

    using Prism.Modularity;

    [Module(ModuleName = "Models")]
    public class IpmDataModelModule : IModule
    {
        #region Fields

        private readonly IUnityContainer container;

        #endregion

        #region Constructors and Destructors

        public IpmDataModelModule(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            this.container.RegisterType<IpmModel>();
        }

        #endregion
    }
}