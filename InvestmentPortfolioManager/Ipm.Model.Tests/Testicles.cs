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

        private IpmModel model;

        #endregion

        #region Public Methods and Operators

        [Test]
        public void CreatePortfolioMethod()
        {
            var pf = this.model.Portfolios.Add(new PortfolioModel() { Name = "Test Portfolio" });
            Assert.IsNotNull(pf);
            Assert.AreEqual(pf.Name, "Test Portfolio");
        }

        [SetUp]
        public void SetUp()
        {
            this.model = new IpmModel();
            Assert.IsNotNull(this.model);
            this.model.Database.Log = Console.Write;
        }

        [TearDown]
        public void TearDown()
        {
            if (this.model != null)
            {
                this.model.Dispose();
            }
        }

        #endregion
    }
}