using BackOfficeSystem.DTO;
using System.Collections.Generic;

namespace BackOfficeSystem.BLL
{
	/// <summary>
	/// Provides aggregation operations
	/// </summary>
	public interface IAggregationManagerService
	{
		/// <summary>
		/// Returns sum of items for each brand
		/// </summary>
		/// <param name="aggregationInfo">Aggregation operation info</param>
		/// <returns>Returns list of <seealso cref="BrandQuantityDto"></seealso> type</returns>
		List<BrandQuantityDto> GetAggregationResultsAgainstInventory(InventoryAggregationDto aggregationInfo);
	}
}
