using System;
using TsvReader.Reader;

namespace BackOfficeSystem.Entities
{
	/// <summary>
	/// Receipt details entity
	/// </summary>
	public class ReceiptDetailsEntity : ITsvConvertable
	{
		/// <summary>
		/// Id of reciept details entity 
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Quantity of assosiated brand
		/// </summary>
		[TsvColumnName("QUANTITY")]
		public int Quantity { get; set; }

		/// <summary>
		/// Recieving time
		/// </summary>
		[TsvColumnName("TIME_RECEIVED")]
		public DateTime RecievingTime { get; set; }

		/// <summary>
		/// Id of brand
		/// </summary>
		[TsvColumnName("BRAND_ID")]
		public int BrandEntityId { get; set; }
		
		/// <summary>
		/// Brand entity
		/// </summary>
		public virtual BrandEntity BrandEntity { get; set; }
	}
}
