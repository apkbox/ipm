// --------------------------------------------------------------------------------
// <copyright file="HomeViewModelTests.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeViewModelTests type.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.Tests
{
    using System.Data.Entity;
    using System.Linq;

    using Ipm.Model;

    using IpmUI.ViewModels;

    using JetBrains.Annotations;

    using Moq;

    using NUnit.Framework;

    using Prism.Regions;

    [TestFixture]
    [NoReorder]
    public class HomeViewModelTests
    {
        private const string PortfolioName = "MyPortfolio";

        #region Public Methods and Operators

        [Test]
        public void IsCreatingPortfolioTest()
        {
            var entityModelMock = CreateEntityModelMock();
            entityModelMock.Setup(m => m.CreatePortfolio(It.IsAny<string>())).Returns(new Portfolio());
            var viewModel = new HomeViewModel(entityModelMock.Object, new Mock<IRegionManager>().Object);

            // Initial state
            Assert.That(viewModel.IsCreatingPortfolio, Is.False);

            // State changes upon property change
            viewModel.IsCreatingPortfolio = true;
            Assert.That(viewModel.IsCreatingPortfolio, Is.True);

            // State changes upon property change
            viewModel.IsCreatingPortfolio = false;
            Assert.That(viewModel.IsCreatingPortfolio, Is.False);

            // Cancel command changes the state
            viewModel.IsCreatingPortfolio = true;
            viewModel.CancelPortfolioCreationCommand.Execute(null);
            Assert.That(viewModel.IsCreatingPortfolio, Is.False);

            // Create command changes the state
            viewModel.IsCreatingPortfolio = true;
            viewModel.CreateNewPortfolioCommand.Execute("Name");
            Assert.That(viewModel.IsCreatingPortfolio, Is.False);
        }

        [Test]
        public void CreateNewPortfolioCommandUsesName()
        {
            var entityModel = CreateEntityModelMock();
            entityModel.Setup(a => a.CreatePortfolio(PortfolioName))
                .Returns(new Portfolio() { Name = PortfolioName }).Verifiable();

            var viewModel = new HomeViewModel(entityModel.Object, new Mock<IRegionManager>().Object);
            viewModel.CreateNewPortfolioCommand.Execute(PortfolioName);
            entityModel.Verify();
        }

        private static Mock<IpmEntityModel> CreateEntityModelMock()
        {
            var entityModel = new Mock<IpmEntityModel>();
            entityModel.SetupGet(p => p.Portfolios).Returns(
                GetQueryableMockDbSet(
                    new Portfolio[]
                        {
                        }));

            return entityModel;
        }

        #endregion

        private static DbSet<T> GetQueryableMockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
