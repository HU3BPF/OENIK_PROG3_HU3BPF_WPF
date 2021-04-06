// <copyright file="GoodsManagementLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Logic.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using Shops.Data.Models;
    using Shops.Logic.NonCrudClasses;
    using Shops.Repository;

    /// <summary>
    /// Goods Management Logic Test.
    /// </summary>
    [TestFixture]
    public class GoodsManagementLogicTest
    {
        private Mock<IRepositoryBrand> mockedBrandRepo;
        private Mock<IRepositoryProduct> mockedProductRepo;
        private List<BrandAverageProductRating> expectedAveragesRating;
        private List<Product> expectedProducts;

        /// <summary>
        /// Brand GetALL Test().
        /// </summary>
        [Test]
        public void TestGetByBrand()
        {
            // Arrange
            var logic = this.CreateLogicWithMockToTestGetByBrand();

            // ACT
            var result = logic.GetProductByBrand(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(this.expectedProducts.Count));
            Assert.That(result, Is.EquivalentTo(this.expectedProducts));

            this.mockedProductRepo.Verify(repo => repo.GetALL(), Times.Once);
            this.mockedProductRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Brand Insert MEthod Test.
        /// </summary>
        [Test]
        public void TestAddBrand()
        {
            Mock<IRepositoryBrand> mockedBrandRepo = new Mock<IRepositoryBrand>(MockBehavior.Loose);
            Mock<IRepositoryProduct> mockedProductRepo = new Mock<IRepositoryProduct>(MockBehavior.Loose);
            mockedBrandRepo.Setup(repo => repo.Insert(It.IsAny<Brand>()));
            GoodsManagementLogic logic = new GoodsManagementLogic(mockedBrandRepo.Object, mockedProductRepo.Object);
            Brand brand1 = new Brand { BrandName = "test1", BrandNumberOfProducts = 2, BrandAnnualProfit = 500, BrandQuality = 6, NumberOfUsers = 200 };
            logic.BrandInsert(brand1);
            mockedBrandRepo.Verify(repo => repo.Insert(brand1), Times.Once);
        }

        /// <summary>
        /// Test Averages RAting Non CRUD METHOD.
        /// </summary>
        [Test]
        public void TestGetAverages()
        {
            // Arrange
            var logic = this.CreateLogicWithMockToTestGetAveragesRating();

            // Act
            var actualAveragesRating = logic.GetBrandAveragesRating();

            // Assert
            Assert.That(actualAveragesRating, Is.EquivalentTo(this.expectedAveragesRating));
            this.mockedBrandRepo.Verify(repo => repo.GetALL(), Times.Once);
            this.mockedProductRepo.Verify(repo => repo.GetALL(), Times.Once);
        }

        private GoodsManagementLogic CreateLogicWithMockToTestGetAveragesRating()
        {
            this.mockedProductRepo = new Mock<IRepositoryProduct>();
            this.mockedBrandRepo = new Mock<IRepositoryBrand>();
            Brand test1 = new Brand() { BrandName = "test1", BrandNumberOfProducts = 2, BrandAnnualProfit = 500, BrandQuality = 6, NumberOfUsers = 200, BrandId = 1 };
            Brand test2 = new Brand() { BrandName = "test2", BrandNumberOfProducts = 2, BrandAnnualProfit = 500, BrandQuality = 6, NumberOfUsers = 200, BrandId = 2 };
            List<Brand> brands = new List<Brand>() { test1, test2 };
            List<Product> products = new List<Product>()
            {
                new Product() { ProductName = "Test1", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 10, BrandrId = test1.BrandId, ProductdId = 1 },
                new Product() { ProductName = "Test2", ProductColour = "Yellow", ProductPrice = 20, StockNumber = 10, UsresRating = 2, BrandrId = test1.BrandId, ProductdId = 2 },
                new Product() { ProductName = "Test3", ProductColour = "Blue", ProductPrice = 25, StockNumber = 11, UsresRating = 4, BrandrId = test1.BrandId, ProductdId = 3 },
                new Product() { ProductName = "Test4", ProductColour = "Pink", ProductPrice = 30, StockNumber = 10, UsresRating = 5, BrandrId = test1.BrandId, ProductdId = 4 },
                new Product() { ProductName = "Test5", ProductColour = "Black", ProductPrice = 55, StockNumber = 25, UsresRating = 7, BrandrId = test2.BrandId, ProductdId = 5 },
                new Product() { ProductName = "Test6", ProductColour = "Green", ProductPrice = 44, StockNumber = 33, UsresRating = 8, BrandrId = test2.BrandId, ProductdId = 6 },
                new Product() { ProductName = "Test7", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 9, BrandrId = test2.BrandId, ProductdId = 7 },
            };
            this.expectedAveragesRating = new List<BrandAverageProductRating>()
            {
                new BrandAverageProductRating() { BrandName = "test2", AverageRating = 8 },
                new BrandAverageProductRating() { BrandName = "test1", AverageRating = 5 },
            };
            this.mockedBrandRepo.Setup(repo => repo.GetALL()).Returns(brands.AsQueryable());
            this.mockedProductRepo.Setup(repo => repo.GetALL()).Returns(products.AsQueryable());
            return new GoodsManagementLogic(this.mockedBrandRepo.Object, this.mockedProductRepo.Object);
        }

        private GoodsManagementLogic CreateLogicWithMockToTestGetByBrand()
        {
            this.mockedBrandRepo = new Mock<IRepositoryBrand>(MockBehavior.Loose);

            this.mockedProductRepo = new Mock<IRepositoryProduct>(MockBehavior.Loose);

            List<Product> products = new List<Product>()
            {
                new Product() { ProductName = "Test1", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 10, BrandrId = 1, ProductdId = 1 },
                new Product() { ProductName = "Test2", ProductColour = "Yellow", ProductPrice = 20, StockNumber = 10, UsresRating = 2, BrandrId = 7, ProductdId = 2 },
                new Product() { ProductName = "Test3", ProductColour = "Blue", ProductPrice = 25, StockNumber = 11, UsresRating = 4, BrandrId = 2, ProductdId = 3 },
                new Product() { ProductName = "Test4", ProductColour = "Pink", ProductPrice = 30, StockNumber = 10, UsresRating = 5, BrandrId = 3, ProductdId = 4 },
                new Product() { ProductName = "Test5", ProductColour = "Black", ProductPrice = 55, StockNumber = 25, UsresRating = 7, BrandrId = 1, ProductdId = 5 },
                new Product() { ProductName = "Test6", ProductColour = "Green", ProductPrice = 44, StockNumber = 33, UsresRating = 8, BrandrId = 1, ProductdId = 6 },
                new Product() { ProductName = "Test7", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 10, BrandrId = 1, ProductdId = 7 },
            };
            this.expectedProducts = new List<Product>()
            {
               new Product() { ProductName = "Test1", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 10, BrandrId = 1, ProductdId = 1 },
               new Product() { ProductName = "Test5", ProductColour = "Black", ProductPrice = 55, StockNumber = 25, UsresRating = 7, BrandrId = 1, ProductdId = 5 },
               new Product() { ProductName = "Test6", ProductColour = "Green", ProductPrice = 44, StockNumber = 33, UsresRating = 8, BrandrId = 1, ProductdId = 6 },
               new Product() { ProductName = "Test7", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 10, BrandrId = 1, ProductdId = 7 },
            };

            this.mockedProductRepo.Setup(repo => repo.GetALL()).Returns(products.AsQueryable);
            return new GoodsManagementLogic(this.mockedBrandRepo.Object, this.mockedProductRepo.Object);
        }
    }
}
