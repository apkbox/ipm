// --------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the Bootstrapper type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI
{
    using System.Windows;

    using Prism.Logging;
    using Prism.Modularity;
    using Prism.Unity;

    public class Bootstrapper : UnityBootstrapper
    {
        #region Methods

        /// <summary>
        /// The configure module catalog.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            this.ModuleCatalog.AddModule(
                new ModuleInfo(typeof(Module).FullName, typeof(Module).AssemblyQualifiedName));
            this.ModuleCatalog.AddModule(
                new ModuleInfo(typeof(Ipm.Model.Module).FullName, typeof(Ipm.Model.Module).AssemblyQualifiedName));
        }

        protected override ILoggerFacade CreateLogger()
        {
#if DEBUG
            return new DebugLogger();
#else
            return new EmptyLogger();
#endif
        }

        /// <summary>
        /// The create shell.
        /// </summary>
        /// <returns>
        /// The <see cref="DependencyObject"/>.
        /// </returns>
        protected override DependencyObject CreateShell()
        {
            return new MainWindow();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        #endregion
    }
}
