namespace BackOfficeSystem.DTO
{
	/// <summary>
	/// Brand quantity dto
	/// </summary>
	public class BrandQuantityDto
	{
		/// <summary>
		/// Id of brand
		/// </summary>
		public int BrandId { get; set; }

		/// <summary>
		/// Quantity of brand presented in the inventory
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Name of brand
		/// </summary>
		public string BrandName { get; set; }
	}
}
