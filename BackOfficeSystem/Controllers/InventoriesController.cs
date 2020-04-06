using BackOfficeSystem.BLL;
using BackOfficeSystem.DTO;
using BackOfficeSystem.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackOfficeSystem.Controllers
{
	/// <summary>
	/// Handle API calls for Inventories manipulations
	/// </summary>
	[Route("api/inventories")]
	[ApiController]
	public class InventoriesController : ControllerBase
	{
		/// <summary>
		/// Instance of <seealso cref="IAggregationManagerService"></seealso> type
		/// </summary>
		private readonly IAggregationManagerService _aggregationManagerService;

		/// <summary>
		/// Initializes <seealso cref="InventoriesController"></seealso> type
		/// </summary>
		/// <param name="aggregationManagerService"></param>
		public InventoriesController(IAggregationManagerService aggregationManagerService)
		{
			_aggregationManagerService = aggregationManagerService;
		}

		/// <summary>
		/// Returns sum of items for each brand
		/// </summary>
		/// <param name="aggregationInfo">Aggregation action info of <seealso cref="InventoryAggregationDto"></seealso> type</param>
		/// <returns>Returns list of <seealso cref="BrandQuantityDto"></seealso> type</returns>
		[HttpGet]
		public ActionResult<List<BrandQuantityDto>> Get([FromQuery]InventoryAggregationDto aggregationInfo)
		{
			var results = _aggregationManagerService.GetAggregationResultsAgainstInventory(aggregationInfo);

			return Ok(results);
		}
	}
}
