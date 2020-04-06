using BackOfficeSystem.BLL;
using BackOfficeSystem.Controllers;
using BackOfficeSystem.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BackOfficeSystem.Tests.Controllers
{
	[TestFixture]
	public class InventoriesControllerTests
	{
		private List<BrandQuantityDto> brandQuantityDto;
		private InventoryAggregationDto inventoryAggregationDto;
		private Mock<IAggregationManagerService> aggregationManagerServiceMock;
		private InventoriesController inventoriesController;

		[SetUp]
		public void Initialize()
		{
			brandQuantityDto = new List<BrandQuantityDto>();
			inventoryAggregationDto = new InventoryAggregationDto();
			aggregationManagerServiceMock = new Mock<IAggregationManagerService>();

			aggregationManagerServiceMock.Setup(x => x.GetAggregationResultsAgainstInventory(inventoryAggregationDto))
				.Returns(brandQuantityDto);

			inventoriesController = new InventoriesController(aggregationManagerServiceMock.Object);
		}

		[Test]
		public void Get_ReturnsActionResltType_WhenAggregationTypeIsSupported()
		{
			var result = inventoriesController.Get(inventoryAggregationDto);

			Assert.IsInstanceOf(typeof(ActionResult<List<BrandQuantityDto>>), result);
		}

		[Test]
		public void Get_ReturnsEntityAsWasRecievedFromService_WhenAggregationTypeIsSupported()
		{
			var result = inventoriesController.Get(inventoryAggregationDto).Result as OkObjectResult;
			var dtoResult = result.Value as List<BrandQuantityDto>;

			Assert.AreEqual(brandQuantityDto, dtoResult);
		}

		[Test]
		public void Delete_CallsGetAggregationResultsAgainstInventoryWithProperAgrument_WhenAggregationTypeIsSupported()
		{
			var result = inventoriesController.Get(inventoryAggregationDto);

			aggregationManagerServiceMock.Verify(x => x.GetAggregationResultsAgainstInventory(inventoryAggregationDto), Times.Once);
		}
	}
}
