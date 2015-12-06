// --------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for App.xaml.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private Bootstrapper bootstraper;

        #endregion

        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.bootstraper = new Bootstrapper();
            this.bootstraper.Run();
        }

        #endregion
    }
}
