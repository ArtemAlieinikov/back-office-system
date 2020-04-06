using BackOfficeSystem.BLL;
using BackOfficeSystem.DAL;
using BackOfficeSystem.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BackOfficeSystem.Tests.BLL
{
	[TestFixture]
	public class InventoryServiceTests
	{
		private const string FirstBrandName = "Test_Brand1";
		private const string SecondBrandName = "Test_Brand2";

		private const int FirstBrandId = 1;
		private const int SecondBrandId = 2;

		private List<BrandEntity> brandEntities;
		private Mock<IUnitOfWork> unitOfWorkMock;
		private InventoryService inventoryService;

		[SetUp]
		public void Initialize()
		{
			brandEntities = GetBrandEntities();

			unitOfWorkMock = new Mock<IUnitOfWork>();

			unitOfWorkMock.Setup(x => x.Brands.Get("ReceiptDetailsEntities"))
				.Returns(brandEntities.AsQueryable);

			inventoryService = new InventoryService(unitOfWorkMock.Object);
		}

		[Test]
		public void GetBrandsQuantity_ReturnsTwoDtoObjects_WhenOnlyTwoBrandsArePresented()
		{
			var expectedNumberOfDtoObjects = 2;

			var result = inventoryService.GetBrandsQuantity();

			Assert.AreEqual(expectedNumberOfDtoObjects, result.Count());
		}

		[Test]
		public void GetBrandsQuantity_ReturnsExpectedQuantity_WhenOnlyTwoBrandsArePresented()
		{
			var expectedQuantityFirstBrand = 14;
			var expectedQuantitySecondBrand = 2;

			var result = inventoryService.GetBrandsQuantity().ToList();

			Assert.AreEqual(expectedQuantityFirstBrand, result[0].Quantity);
			Assert.AreEqual(expectedQuantitySecondBrand, result[1].Quantity);
		}

		[Test]
		public void GetBrandsQuantity_ReturnsExpectedBrandNames_WhenOnlyTwoBrandsArePresented()
		{
			var result = inventoryService.GetBrandsQuantity().ToList();

			Assert.AreEqual(FirstBrandName, result[0].BrandName);
			Assert.AreEqual(SecondBrandName, result[1].BrandName);
		}

		[Test]
		public void GetBrandsQuantity_ReturnsExpectedBrandId_WhenOnlyTwoBrandsArePresented()
		{
			var result = inventoryService.GetBrandsQuantity().ToList();

			Assert.AreEqual(FirstBrandId, result[0].BrandId);
			Assert.AreEqual(SecondBrandId, result[1].BrandId);
		}

		private List<BrandEntity> GetBrandEntities()
		{
			return new List<BrandEntity>()
			{
				new BrandEntity()
				{
					Id = FirstBrandId,
					Name = FirstBrandName,
					ReceiptDetailsEntities = new List<ReceiptDetailsEntity>()
					{
						new ReceiptDetailsEntity()
						{
							Quantity = 1
						},
						new ReceiptDetailsEntity()
						{
							Quantity = 2
						}
					}
				},
				new BrandEntity()
				{
					Id = FirstBrandId,
					Name = FirstBrandName,
					ReceiptDetailsEntities = new List<ReceiptDetailsEntity>()
					{
						new ReceiptDetailsEntity()
						{
							Quantity = 3
						},
						new ReceiptDetailsEntity()
						{
							Quantity = 5
						}
					}
				},
				new BrandEntity()
				{
					Id = FirstBrandId,
					Name = FirstBrandName,
					ReceiptDetailsEntities = new List<ReceiptDetailsEntity>()
					{
						new ReceiptDetailsEntity()
						{
							Quantity = 1
						},
						new ReceiptDetailsEntity()
						{
							Quantity = 2
						}
					}
				},
				new BrandEntity()
				{
					Id = SecondBrandId,
					Name = SecondBrandName,
					ReceiptDetailsEntities = new List<ReceiptDetailsEntity>()
					{
						new ReceiptDetailsEntity()
						{
							Quantity = 1
						},
						new ReceiptDetailsEntity()
						{
							Quantity = 1
						}
					}
				}
			};
		}
	}
}
