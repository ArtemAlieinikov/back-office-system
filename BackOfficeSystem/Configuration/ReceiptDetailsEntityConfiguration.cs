using BackOfficeSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackOfficeSystem.Configuration
{
	/// <summary>
	/// Fluent API configuration for <seealso cref="ReceiptDetailsEntity"></seealso> entity type
	/// </summary>
	public class ReceiptDetailsEntityConfiguration : IEntityTypeConfiguration<ReceiptDetailsEntity>
	{
		public void Configure(EntityTypeBuilder<ReceiptDetailsEntity> builder)
		{
			builder.ToTable("ReceiptDetails");
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.BrandEntity);
		}
	}
}
