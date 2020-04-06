using BackOfficeSystem.DTO;
using System.Collections.Generic;

namespace BackOfficeSystem.BLL
{
	/// <summary>
	/// Provides inventories' corresponding logic
	/// </summary>
	public interface IInventoryService
	{
		/// <summary>
		/// Calculates quantity for presented brands in the inventory
		/// </summary>
		/// <returns>Returns list of <seealso cref="BrandQuantityDto"></seealso> type</returns>
		IEnumerable<BrandQuantityDto> GetBrandsQuantity();
	}
}
