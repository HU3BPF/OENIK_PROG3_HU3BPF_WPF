// <copyright file="ShopManagementLogicTest.cs" company="PlaceholderCompany">
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
    /// Shop management Logic Test.
    /// </summary>
    [TestFixture]
    public class ShopManagementLogicTest
    {
        private Mock<IRepositoryShop> mockedShopRepo;
        private Mock<IRepositoryProduct> mockedProductRepo;
        private List<ShopNumberOfProduct> expectedShopNumberOfProduct;

        /// <summary>
        /// Test Get Shop Number Of Product.
        /// </summary>
        [Test]
        public void TestGetShopNumberOfProduct()
        {
            // Arrange
            var logic = this.CreateLogicWithMockToTestGetShopNumberOfProduct();

            // ACT
            var actualNumberOfProducts = logic.GetNumberOfProducts();

            // Assert
            Assert.That(actualNumberOfProducts, Is.EquivalentTo(this.expectedShopNumberOfProduct));
            this.mockedProductRepo.Verify(pRepo => pRepo.GetALL(), Times.Once);
            this.mockedShopRepo.Verify(sRepo => sRepo.GetALL(), Times.Once);
        }

        /// <summary>
        /// Test Shop inserter Method.
        /// </summary>
        [Test]
        public void TestShopInsert()
        {
            // Arrange
            Mock<IRepositoryShop> mockedShopRepo = new Mock<IRepositoryShop>(MockBehavior.Loose);
            Mock<IRepositoryProduct> mockedProductRepo = new Mock<IRepositoryProduct>(MockBehavior.Loose);
            mockedShopRepo.Setup(repo => repo.Insert(It.IsAny<Shop>()));
            ShopManagementLogic logic = new ShopManagementLogic(mockedShopRepo.Object, mockedProductRepo.Object);
            Shop test1 = new Shop() { ShopName = "test1", ShopLocation = "Alaszka", ShopAnnualProfit = 1000, ShopNumberOfWorker = 60, ShopReliability = 10, ShopLeader = "Hulk", ShopId = 1 };
            Shop test2 = new Shop() { ShopName = "test2", ShopLocation = "New York", ShopAnnualProfit = 200, ShopNumberOfWorker = 2, ShopReliability = 10, ShopLeader = "Thor", ShopId = 2 };
            Shop test3 = new Shop() { ShopName = "test3", ShopLocation = "Atlanta", ShopAnnualProfit = 300, ShopNumberOfWorker = 4, ShopReliability = 7, ShopLeader = "Hulk", ShopId = 3 };

            // ACT
            logic.ShopInsert(test1);
            logic.ShopInsert(test2);
            logic.ShopInsert(test3);

            // Assert
            mockedShopRepo.Verify(repo => repo.Insert(test1), Times.Once);
            mockedShopRepo.Verify(repo => repo.Insert(test2), Times.Once);
            mockedShopRepo.Verify(repo => repo.Insert(test3), Times.Once);
        }

        /// <summary>
        /// Test Shop Remover Method.
        /// </summary>
        [Test]
        public void TestShopRemover()
        {
            // Arrange
            Mock<IRepositoryShop> mockedShopRepo = new Mock<IRepositoryShop>(MockBehavior.Loose);
            Mock<IRepositoryProduct> mockedProductRepo = new Mock<IRepositoryProduct>(MockBehavior.Loose);
            mockedShopRepo.Setup(repo => repo.Remove(It.IsAny<Shop>()));
            ShopManagementLogic logic = new ShopManagementLogic(mockedShopRepo.Object, mockedProductRepo.Object);
            Shop test1 = new Shop() { ShopName = "test1", ShopLocation = "Alaszka", ShopAnnualProfit = 1000, ShopNumberOfWorker = 60, ShopReliability = 10, ShopLeader = "Hulk", ShopId = 1 };
            Shop test2 = new Shop() { ShopName = "test2", ShopLocation = "New York", ShopAnnualProfit = 200, ShopNumberOfWorker = 2, ShopReliability = 10, ShopLeader = "Thor", ShopId = 2 };
            Shop test3 = new Shop() { ShopName = "test3", ShopLocation = "Atlanta", ShopAnnualProfit = 300, ShopNumberOfWorker = 4, ShopReliability = 7, ShopLeader = "Hulk", ShopId = 3 };

            // ACT
            logic.ShopRemove(test1);
            logic.ShopRemove(test2);
            logic.ShopRemove(test3);

            // Assert
            mockedShopRepo.Verify(repo => repo.Remove(test1), Times.Once);
            mockedShopRepo.Verify(repo => repo.Remove(test2), Times.Once);
            mockedShopRepo.Verify(repo => repo.Remove(test3), Times.Once);
        }

        /// <summary>
        /// Test Shop Remover Method.
        /// </summary>
        [Test]
        public void TestShopUpdater()
        {
            // Arrange
            Mock<IRepositoryShop> mockedShopRepo = new Mock<IRepositoryShop>(MockBehavior.Loose);
            Mock<IRepositoryProduct> mockedProductRepo = new Mock<IRepositoryProduct>(MockBehavior.Loose);
            mockedShopRepo.Setup(repo => repo.ShopUpdate(It.IsAny<Shop>()));
            ShopManagementLogic logic = new ShopManagementLogic(mockedShopRepo.Object, mockedProductRepo.Object);
            Shop test1 = new Shop() { ShopName = "test1", ShopLocation = "Alaszka", ShopAnnualProfit = 1000, ShopNumberOfWorker = 60, ShopReliability = 10, ShopLeader = "Hulk", ShopId = 1 };
            Shop test2 = new Shop() { ShopName = "test2", ShopLocation = "New York", ShopAnnualProfit = 200, ShopNumberOfWorker = 2, ShopReliability = 10, ShopLeader = "Thor", ShopId = 2 };
            Shop test3 = new Shop() { ShopName = "test3", ShopLocation = "Atlanta", ShopAnnualProfit = 300, ShopNumberOfWorker = 4, ShopReliability = 7, ShopLeader = "Hulk", ShopId = 3 };

            // ACT
            logic.ShopUpdate(test1);
            logic.ShopUpdate(test2);
            logic.ShopUpdate(test3);

            // Assert
            mockedShopRepo.Verify(repo => repo.ShopUpdate(test1), Times.Once);
            mockedShopRepo.Verify(repo => repo.ShopUpdate(test2), Times.Once);
            mockedShopRepo.Verify(repo => repo.ShopUpdate(test3), Times.Once);
        }

        /// <summary>
        /// Test Shop Remover Method.
        /// </summary>
        [Test]
        public void TestShopGetOne()
        {
            // Arrange
            Mock<IRepositoryShop> mockedShopRepo = new Mock<IRepositoryShop>(MockBehavior.Loose);
            Mock<IRepositoryProduct> mockedProductRepo = new Mock<IRepositoryProduct>(MockBehavior.Loose);
            Shop test1 = new Shop() { ShopName = "test1", ShopLocation = "Alaszka", ShopAnnualProfit = 1000, ShopNumberOfWorker = 60, ShopReliability = 10, ShopLeader = "Hulk", ShopId = 1 };
            Shop test2 = new Shop() { ShopName = "test2", ShopLocation = "New York", ShopAnnualProfit = 200, ShopNumberOfWorker = 2, ShopReliability = 10, ShopLeader = "Thor", ShopId = 2 };
            Shop test3 = new Shop() { ShopName = "test3", ShopLocation = "Atlanta", ShopAnnualProfit = 300, ShopNumberOfWorker = 4, ShopReliability = 7, ShopLeader = "Hulk", ShopId = 3 };
            List<Shop> shops = new List<Shop>() { test1, test2, test3 };
            mockedShopRepo.Setup(repo => repo.GetOne(1)).Returns(test1);
            mockedShopRepo.Setup(repo => repo.GetOne(2)).Returns(test2);
            mockedShopRepo.Setup(repo => repo.GetOne(3)).Returns(test3);
            ShopManagementLogic logic = new ShopManagementLogic(mockedShopRepo.Object, mockedProductRepo.Object);

            // ACT
            var result1 = logic.GetOne(1);
            var result2 = logic.GetOne(2);
            var result3 = logic.GetOne(3);

            // Assert
            Assert.That(result1, Is.EqualTo(test1));
            Assert.That(result2, Is.EqualTo(test2));
            Assert.That(result3, Is.EqualTo(test3));
            mockedShopRepo.Verify(repo => repo.GetOne(1), Times.Once);
            mockedShopRepo.Verify(repo => repo.GetOne(2), Times.Once);
            mockedShopRepo.Verify(repo => repo.GetOne(3), Times.Once);
        }

        private ShopManagementLogic CreateLogicWithMockToTestGetShopNumberOfProduct()
        {
            this.mockedProductRepo = new Mock<IRepositoryProduct>();
            this.mockedShopRepo = new Mock<IRepositoryShop>();
            Shop test1 = new Shop() { ShopName = "test1", ShopLocation = "Alaszka", ShopAnnualProfit = 500, ShopNumberOfWorker = 6, ShopReliability = 200, ShopLeader = "Hulk", ShopId = 1 };
            Shop test2 = new Shop() { ShopName = "test2", ShopLocation = "New York", ShopAnnualProfit = 500, ShopNumberOfWorker = 6, ShopReliability = 200, ShopLeader = "Thor", ShopId = 2 };
            Brand test3 = new Brand() { BrandName = "test1", BrandNumberOfProducts = 2, BrandAnnualProfit = 500, BrandQuality = 6, NumberOfUsers = 200, BrandId = 1, ShopID = 1 };
            Brand test4 = new Brand() { BrandName = "test2", BrandNumberOfProducts = 2, BrandAnnualProfit = 500, BrandQuality = 6, NumberOfUsers = 200, BrandId = 2, ShopID = 2 };
            List<Shop> shops = new List<Shop>() { test1, test2 };
            List<Product> products = new List<Product>()
            {
                new Product() { ProductName = "Test1", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 10, BrandrId = test3.BrandId, ProductdId = 1, Brand = test3 },
                new Product() { ProductName = "Test2", ProductColour = "Yellow", ProductPrice = 20, StockNumber = 10, UsresRating = 2, BrandrId = test3.BrandId, ProductdId = 2, Brand = test3 },
                new Product() { ProductName = "Test3", ProductColour = "Blue", ProductPrice = 25, StockNumber = 11, UsresRating = 4, BrandrId = test3.BrandId, ProductdId = 3, Brand = test3 },
                new Product() { ProductName = "Test4", ProductColour = "Pink", ProductPrice = 30, StockNumber = 10, UsresRating = 5, BrandrId = test3.BrandId, ProductdId = 4, Brand = test3 },
                new Product() { ProductName = "Test5", ProductColour = "Black", ProductPrice = 55, StockNumber = 25, UsresRating = 7, BrandrId = test4.BrandId, ProductdId = 5, Brand = test4 },
                new Product() { ProductName = "Test6", ProductColour = "Green", ProductPrice = 44, StockNumber = 33, UsresRating = 8, BrandrId = test4.BrandId, ProductdId = 6, Brand = test4 },
                new Product() { ProductName = "Test7", ProductColour = "Pink", ProductPrice = 100, StockNumber = 25, UsresRating = 9, BrandrId = test4.BrandId, ProductdId = 7, Brand = test4 },
            };
            this.expectedShopNumberOfProduct = new List<ShopNumberOfProduct>()
            {
                new ShopNumberOfProduct() { ShopName = "test1", NumberOfProduct = 4 },
                new ShopNumberOfProduct() { ShopName = "test2", NumberOfProduct = 3 },
            };
            this.mockedShopRepo.Setup(repo => repo.GetALL()).Returns(shops.AsQueryable());
            this.mockedProductRepo.Setup(repo => repo.GetALL()).Returns(products.AsQueryable());
            return new ShopManagementLogic(this.mockedShopRepo.Object, this.mockedProductRepo.Object);
        }
    }
}
