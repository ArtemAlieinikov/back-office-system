using BackOfficeSystem.DAL;
using BackOfficeSystem.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BackOfficeSystem.BLL
{
	/// <summary>
	/// Provides inventories' corresponding logic
	/// </summary>
	public class InventoryService : IInventoryService
	{
		/// <summary>
		/// Instance of <seealso cref="IUnitOfWork"></seealso> type
		/// </summary>
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Initializes <seealso cref="InventoryService"></seealso> type
		/// </summary>
		/// <param name="unitOfWork">Unit of work abstraction</param>
		public InventoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Calculates quantity for presented brands in the inventory
		/// </summary>
		/// <returns>Returns list of <seealso cref="BrandQuantityDto"></seealso> type</returns>
		public IEnumerable<BrandQuantityDto> GetBrandsQuantity()
		{
			var receipts = _unitOfWork.Brands.Get("ReceiptDetailsEntities").ToList();
			var groupedReceipts = receipts.GroupBy(x => new { x.Id, x.Name });

			var result = groupedReceipts.Select(x => new BrandQuantityDto()
			{
				BrandId = x.Key.Id,
				BrandName = x.Key.Name,
				Quantity = receipts.Where(y => y.Id == x.Key.Id)
					.Sum(y => y.ReceiptDetailsEntities.Sum(z => z.Quantity))
			}).ToList();

			return result;
		}
	}
}
