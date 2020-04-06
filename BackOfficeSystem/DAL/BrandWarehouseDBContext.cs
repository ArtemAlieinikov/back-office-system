using BackOfficeSystem.Configuration;
using BackOfficeSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TsvReader.Reader;

namespace BackOfficeSystem.DAL
{
    /// <summary>
    /// Represents warehouse of brands context
    /// </summary>
    public class BrandWarehouseDBContext : DbContext
	{
        private readonly ITsvDataReader<BrandEntity> _brandEntityReader;

        private readonly ITsvDataReader<ReceiptDetailsEntity> _receiptDetailsReader;

        /// <summary>
        /// Brands db set
        /// </summary>
        public DbSet<BrandEntity> BrandEntities { get; set; }

        /// <summary>
        /// ReceiptDetails db set
        /// </summary>
        public DbSet<ReceiptDetailsEntity> ReceiptDetailsEntities { get; set; }

        /// <summary>
        /// Initializes <seealso cref="BrandWarehouseDBContext"></seealso> type
        /// </summary>
        /// <param name="options"><seealso cref="DbContextOptions"></seealso> type</param>
        /// <param name="brandEntityReader"></param>
        /// <param name="receiptDetailsReader"></param>
        public BrandWarehouseDBContext(
            DbContextOptions options, 
            ITsvDataReader<BrandEntity> brandEntityReader, 
            ITsvDataReader<ReceiptDetailsEntity> receiptDetailsReader) : base(options)
        {
            _brandEntityReader = brandEntityReader;
            _receiptDetailsReader = receiptDetailsReader;

            Database.EnsureCreated();
        }

        /// <summary>
        /// Containts database model creation and population
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptDetailsEntityConfiguration());

            var brands = _brandEntityReader.ReadData();
            modelBuilder.Entity<BrandEntity>().HasData(brands.ToArray());

            var receiptDetails = PopulateId(_receiptDetailsReader.ReadData());
            modelBuilder.Entity<ReceiptDetailsEntity>().HasData(receiptDetails.ToArray());
        }

        private IEnumerable<ReceiptDetailsEntity> PopulateId(IEnumerable<ReceiptDetailsEntity> entities)
        {
            var maxId = entities.Max(x => x.Id);
            var startId = maxId != 0 ? maxId : 1;

            foreach(var entity in entities)
            {
                entity.Id = startId++;
            }

            return entities;
        }
    }
}
