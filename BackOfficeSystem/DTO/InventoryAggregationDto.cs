using Microsoft.AspNetCore.Mvc;

namespace BackOfficeSystem.DTO
{
	/// <summary>
	/// Inventory agragation operation summary dto
	/// </summary>
	[BindProperties(SupportsGet = true)]
	public class InventoryAggregationDto
	{
		/// <summary>
		/// Aggregation operation type
		/// </summary>
		[BindProperty(Name = "agg")]
		public string AggregateType { get; set; }

		/// <summary>
		/// Column name against which will be performed aggregation operation
		/// </summary>
		[BindProperty(Name = "column")]
		public string ColumnName { get; set; }
	}
}
