// --------------------------------------------------------------------------------
// <copyright file="Testicles.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the Testicles type.
// </summary>
// --------------------------------------------------------------------------------
namespace Ipm.Model.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Testicles
    {
        #region Fields

        private IpmEntityModel entityModel;

        #endregion

        #region Public Methods and Operators

        [Test]
        public void CreatePortfolioMethod()
        {
            var pf = this.entityModel.Portfolios.Add(new Portfolio() { Name = "Test Portfolio" });
            Assert.IsNotNull(pf);
            Assert.AreEqual(pf.Name, "Test Portfolio");
        }

        [SetUp]
        public void SetUp()
        {
            this.entityModel = new IpmEntityModel();
            Assert.IsNotNull(this.entityModel);
            this.entityModel.Database.Log = Console.Write;
        }

        [TearDown]
        public void TearDown()
        {
            if (this.entityModel != null)
            {
                this.entityModel.Dispose();
            }
        }

        #endregion
    }
}