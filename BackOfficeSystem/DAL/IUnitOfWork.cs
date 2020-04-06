using BackOfficeSystem.Entities;
using System;

namespace BackOfficeSystem.DAL
{
	/// <summary>
	/// Representation of unit of work pattern
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Instance of brand repository
		/// </summary>
		IGenericRepository<BrandEntity> Brands { get; }

		/// <summary>
		/// Save context's changes
		/// </summary>
		void SaveChanges();
	}
}
