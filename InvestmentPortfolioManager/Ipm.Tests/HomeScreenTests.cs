// --------------------------------------------------------------------------------
// <copyright file="HomeScreenTests.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeScreenTests type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Tests
{
    using System.ComponentModel;
    using System.Data.Entity.Infrastructure;

    using InvestmentPortfolioManager.ViewModels;

    using Ipm.DataModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Prism.Mvvm;
    using Prism.Regions;

    [TestClass]
    public class HomeScreenTests
    {
        #region Public Methods and Operators

        [TestMethod]
        public void ClearNameBeforeCreatingPortfolio()
        {
            var vm = new HomeScreenViewModel(new Mock<IpmModel>().Object, new Mock<IRegionManager>().Object);

            vm.StartCreatingPortfolioCommand.Execute(null);
            vm.NewPortfolioName = "First Portfolio";
            vm.CreatePortfolioCommand.Execute(null);

            var propertyChangedMock = new Mock<PropertyChangedEventHandler>();
            vm.PropertyChanged += propertyChangedMock.Object;
            vm.StartCreatingPortfolioCommand.Execute(null);
            Assert.AreEqual(string.Empty, vm.NewPortfolioName);

            propertyChangedMock.Verify(
                m => m(It.IsAny<object>(), It.IsAny<PropertyChangedEventArgs>()),
                Times.Exactly(1));
        }

        #endregion
    }
}