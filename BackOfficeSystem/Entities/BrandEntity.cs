using System.Collections.Generic;
using TsvReader.Reader;

namespace BackOfficeSystem.Entities
{
	/// <summary>
	/// Brand entity
	/// </summary>
	public class BrandEntity : ITsvConvertable
	{
		/// <summary>
		/// Id of brand
		/// </summary>
		[TsvColumnName("BRAND_ID")]
		public int Id { get; set; }

		/// <summary>
		/// Name of brand
		/// </summary>
		[TsvColumnName("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Receipt details entity
		/// </summary>
		public virtual ICollection<ReceiptDetailsEntity> ReceiptDetailsEntities { get; set; }
	}
}
