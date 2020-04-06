using BackOfficeSystem.BLL;
using BackOfficeSystem.DTO;
using BackOfficeSystem.Exceptions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BackOfficeSystem.Tests.BLL
{
	[TestFixture]
	public class AggregationManagerServiceTest
	{
		const string SupporterAggregateType = "sum";
		const string SupporterColumnName = "quantity";

		private List<BrandQuantityDto> brandQuantityDto;
		private InventoryAggregationDto inventoryAggregationDto;
		private Mock<IInventoryService> inventoryServiceMock;
		private AggregationManagerService aggregationManagerService;

		[SetUp]
		public void Initialize()
		{
			brandQuantityDto = new List<BrandQuantityDto>();
			inventoryAggregationDto = new InventoryAggregationDto();
			inventoryServiceMock = new Mock<IInventoryService>();

			inventoryServiceMock.Setup(x => x.GetBrandsQuantity())
				.Returns(brandQuantityDto);

			aggregationManagerService = new AggregationManagerService(inventoryServiceMock.Object);
		}

		[Test]
		public void GetAggregationResultsAgainstInventory_ThrowsUnsupportedAggregationActionException_WhenAggregationTypeIsNotSupported()
		{
			inventoryAggregationDto.AggregateType = SupporterAggregateType;

			Assert.Throws<UnsupportedAggregationActionException>(() => {
				aggregationManagerService.GetAggregationResultsAgainstInventory(inventoryAggregationDto);
			});
		}

		[Test]
		public void GetAggregationResultsAgainstInventory_ThrowsUnsupportedAggregationActionException_WhenColumnNameIsNotSupported()
		{
			inventoryAggregationDto.ColumnName = SupporterColumnName;

			Assert.Throws<UnsupportedAggregationActionException>(() => {
				aggregationManagerService.GetAggregationResultsAgainstInventory(inventoryAggregationDto);
			});
		}

		[Test]
		public void GetAggregationResultsAgainstInventory_ReturnsListOfDto_WhenAggregationIsSupported()
		{
			inventoryAggregationDto.ColumnName = SupporterColumnName;
			inventoryAggregationDto.AggregateType = SupporterAggregateType;

			var result = aggregationManagerService.GetAggregationResultsAgainstInventory(inventoryAggregationDto);

			Assert.AreEqual(brandQuantityDto, result);
		}
	}
}
