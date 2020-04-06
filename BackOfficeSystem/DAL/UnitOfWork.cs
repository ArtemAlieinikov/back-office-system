using BackOfficeSystem.Entities;
using System;

namespace BackOfficeSystem.DAL
{
	/// <summary>
	/// Representation of unit of work pattern
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private readonly BrandWarehouseDBContext _context;

		private bool disposed = false;

		private Lazy<IGenericRepository<BrandEntity>> lazyBrands;

		/// <summary>
		/// Instance of brand repository
		/// </summary>
		public IGenericRepository<BrandEntity> Brands => lazyBrands.Value;

		/// <summary>
		/// Initializes <seealso cref="UnitOfWork"></seealso> type
		/// </summary>
		/// <param name="context">Db context of <seealso cref="BrandWarehouseDBContext"></seealso> type</param>
		public UnitOfWork(BrandWarehouseDBContext context)
		{
			_context = context;
			lazyBrands = new Lazy<IGenericRepository<BrandEntity>>(new GenericRepository<BrandEntity>(context.BrandEntities));
		}

		/// <summary>
		/// Save context's changes
		/// </summary>
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		/// <summary>
		/// Release unmanages resourses from context
		/// </summary>
		/// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
					_context.Dispose();
                }
                this.disposed = true;
            }
        }

		/// <summary>
		/// Release unmanages resourses from context
		/// </summary>
		public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
