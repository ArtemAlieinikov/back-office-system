using BackOfficeSystem.BLL;
using BackOfficeSystem.Controllers;
using BackOfficeSystem.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BackOfficeSystem.Tests.Controllers
{
	[TestFixture]
	public class BrandsControllerTests
	{
		const int existedBrandId = 1;

		private BrandDto brandDto;
		private Mock<IBrandService> brandServiceMock;
		private BrandsController brandController;

		[SetUp]
		public void Initialize()
		{
			brandDto = new BrandDto
			{
				Id = existedBrandId
			};
			brandServiceMock = new Mock<IBrandService>();

			brandServiceMock.Setup(x => x.Get(existedBrandId))
				.Returns(brandDto);

			brandController = new BrandsController(brandServiceMock.Object);
		}

		[Test]
		public void Get_ReturnsActionResltType_WhenBrandExists()
		{
			var result = brandController.Get(existedBrandId);

			Assert.IsInstanceOf(typeof(ActionResult<BrandDto>), result);
		}

		[Test]
		public void Get_ReturnsEntityWithTheSameId_AsWasRequester_WhenBrandExists()
		{
			var okObjectResult = brandController.Get(existedBrandId).Result as OkObjectResult;
			var dtoResult = okObjectResult.Value as BrandDto;

			Assert.AreEqual(existedBrandId, dtoResult.Id);
		}

		[Test]
		public void Delete_ReturnsNoContentType_WhenBrandExists()
		{
			var result = brandController.Delete(existedBrandId);

			Assert.IsInstanceOf(typeof(NoContentResult), result);
		}

		[Test]
		public void Delete_CallsDeleteMethodWithProperId_WhenBrandExists()
		{
			var result = brandController.Delete(existedBrandId);

			brandServiceMock.Verify(x => x.Delete(existedBrandId), Times.Once);
		}

		[Test]
		public void Post_ReturnsNoContentType_WhenBrandExists()
		{
			var result = brandController.Post(brandDto);

			Assert.IsInstanceOf(typeof(NoContentResult), result);
		}

		[Test]
		public void Post_CallsCreateMethodWithProperId_WhenBrandExists()
		{
			var result = brandController.Post(brandDto);

			brandServiceMock.Verify(x => x.Create(brandDto), Times.Once);
		}

		[Test]
		public void Put_ReturnsNoContentType_WhenBrandExists()
		{
			var result = brandController.Put(existedBrandId, brandDto);

			Assert.IsInstanceOf(typeof(NoContentResult), result);
		}

		[Test]
		public void Put_CallsCreateMethodWithProperId_WhenBrandExists()
		{
			var result = brandController.Put(existedBrandId, brandDto);

			brandServiceMock.Verify(x => x.Update(existedBrandId, brandDto), Times.Once);
		}
	}
}
