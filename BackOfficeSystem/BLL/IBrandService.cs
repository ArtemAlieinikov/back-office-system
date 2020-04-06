using BackOfficeSystem.DTO;
using System;

namespace BackOfficeSystem.BLL
{
	/// <summary>
	/// Provides brand's corresponding logic
	/// </summary>
	public interface IBrandService : IDisposable
	{
		/// <summary>
		/// Returns brand by id
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <returns>Returns <seealso cref="BrandDto"></seealso> type</returns>
		BrandDto Get(int id);

		/// <summary>
		/// Create new Brand
		/// </summary>
		/// <param name="entityToCreate">Brand to create</param>
		/// <returns>Returns <seealso cref="BrandDto"></seealso> type</returns>
		BrandDto Create(BrandDto entityToCreate);

		/// <summary>
		/// Delete brand by id
		/// </summary>
		/// <param name="id">Id of brand</param>
		void Delete(int id);

		/// <summary>
		/// Updates brand
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <param name="entityToUpdate">New properties of brand</param>
		void Update(int id, BrandDto entityToUpdate);
	}
}
