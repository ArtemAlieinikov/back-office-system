using BackOfficeSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackOfficeSystem.Configuration
{
	/// <summary>
	/// Fluent API configuration for <seealso cref="BrandEntity"></seealso> entity type
	/// </summary>
	public class BrandEntityConfiguration : IEntityTypeConfiguration<BrandEntity>
	{
		public void Configure(EntityTypeBuilder<BrandEntity> builder)
		{
			builder.ToTable("Brands");
			builder.HasKey(x => x.Id);
			builder.HasMany(x => x.ReceiptDetailsEntities);
		}
	}
}
