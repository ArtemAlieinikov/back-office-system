using BackOfficeSystem.BLL;
using BackOfficeSystem.DAL;
using BackOfficeSystem.DTO;
using BackOfficeSystem.Entities;
using BackOfficeSystem.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BackOfficeSystem.Tests.BLL
{
	[TestFixture]
	public class BrandServiceTests
	{
		private const string FirstBrandName = "Test_Brand1";
		private const string SecondBrandName = "Test_Brand2";

		private const int FirstBrandId = 1;
		private const int SecondBrandId = 2;

		private Mock<IUnitOfWork> unitOfWorkMock;

		private BrandService brandService;

		[SetUp]
		public void Initialize()
		{
			unitOfWorkMock = new Mock<IUnitOfWork>();
			brandService = new BrandService(unitOfWorkMock.Object);
		}

		[Test]
		public void Create_ThrowsUnsupportedValueExceptionWithExpectedMessage_WhenBrandNameIsNull()
		{
			var brandToCreate = new BrandDto();
			var expectedExceptionMessage = new UnsupportedValueException(null);

			var exception = Assert.Throws<UnsupportedValueException>(() => brandService.Create(brandToCreate));
			Assert.AreEqual(expectedExceptionMessage.Message, exception.Message);
		}

		[Test]
		public void Create_ThrowsUnsupportedValueExceptionWithExpectedMessage_WhenBrandNameIsEmpty()
		{
			var brandToCreate = new BrandDto()
			{
				Name = string.Empty
			};
			var expectedExceptionMessage = new UnsupportedValueException(brandToCreate.Name);

			var exception = Assert.Throws<UnsupportedValueException>(() => brandService.Create(brandToCreate));
			Assert.AreEqual(expectedExceptionMessage.Message, exception.Message);
		}

		[Test]
		public void Create_ThrowsUnsupportedValueExceptionWithExpectedMessage_WhenBrandNameIsNotUnique()
		{	
			var brandToCreate = new BrandDto()
			{
				Name = FirstBrandName
			};
			var expectedExceptionMessage = new UnsupportedValueException(brandToCreate.Name);

			unitOfWorkMock.Setup(x => x.Brands.Get(It.IsAny<Expression<Func<BrandEntity, bool>>>(), It.IsAny<string[]>()))
				.Returns(new List<BrandEntity>() { new BrandEntity() { Name = FirstBrandName } }.AsQueryable);

			var exception = Assert.Throws<UnsupportedValueException>(() => brandService.Create(brandToCreate));
			Assert.AreEqual(expectedExceptionMessage.Message, exception.Message);
		}
	}
}
