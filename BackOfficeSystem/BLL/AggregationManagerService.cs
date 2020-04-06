using BackOfficeSystem.DTO;
using BackOfficeSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackOfficeSystem.BLL
{
	/// <summary>
	/// Provides aggregation operations
	/// </summary>
	public class AggregationManagerService : IAggregationManagerService
	{
		/// <summary>
		/// Instance of <seealso cref="IInventoryService"></seealso> type
		/// </summary>
		private readonly IInventoryService _inventoryService;

		/// <summary>
		/// Initializes <seealso cref="AggregationManagerService"></seealso> type
		/// </summary>
		/// <param name="inventoryService">Inventory service abstraction</param>
		public AggregationManagerService(IInventoryService inventoryService)
		{
			_inventoryService = inventoryService;
		}

		/// <summary>
		/// Returns sum of items for each brand
		/// </summary>
		/// <param name="aggregationInfo">Aggregation operation info</param>
		/// <returns>Returns list of <seealso cref="BrandQuantityDto"></seealso> type</returns>
		public List<BrandQuantityDto> GetAggregationResultsAgainstInventory(InventoryAggregationDto aggregationInfo)
		{
			if (!(string.Equals(aggregationInfo.AggregateType, "sum", StringComparison.InvariantCultureIgnoreCase) && 
				string.Equals(aggregationInfo.ColumnName, "quantity", StringComparison.InvariantCultureIgnoreCase)))
			{
				throw new UnsupportedAggregationActionException(aggregationInfo.AggregateType, aggregationInfo.ColumnName);
			}

			var aggregationResult = _inventoryService.GetBrandsQuantity().ToList();
			return aggregationResult;
		}
	}
}
