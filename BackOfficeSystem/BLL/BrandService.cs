using BackOfficeSystem.DAL;
using BackOfficeSystem.DTO;
using BackOfficeSystem.Entities;
using BackOfficeSystem.Exceptions;
using System;
using System.Linq;

namespace BackOfficeSystem.BLL
{
	/// <summary>
	/// Provides brand's corresponding logic
	/// </summary>
	public class BrandService : IBrandService
	{
		/// <summary>
		/// Instance of <seealso cref="IUnitOfWork"></seealso> type
		/// </summary>
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Initializes <seealso cref="BrandService"></seealso> type
		/// </summary>
		/// <param name="unitOfwork">Unit of work abstraction</param>
		public BrandService(IUnitOfWork unitOfwork)
		{
			_unitOfWork = unitOfwork;
		}

		/// <summary>
		/// Create new Brand
		/// </summary>
		/// <param name="entityToCreate">Brand to create</param>
		/// <returns>Returns <seealso cref="BrandDto"></seealso> type</returns>
		public BrandDto Create(BrandDto entityToCreate)
		{
			ValidateName(entityToCreate.Name);

			var brandToCreate = MapDtoToEntity(entityToCreate);
			brandToCreate.Id = 0;

			var result = _unitOfWork.Brands.Create(brandToCreate);
			_unitOfWork.SaveChanges();

			return MapEntityToDto(result);
		}

		/// <summary>
		/// Returns brand by id
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <returns>Returns <seealso cref="BrandDto"></seealso> type</returns>
		public BrandDto Get(int id)
		{
			ValidateForExistance(id, out var brand);
			var result = new BrandDto()
			{
				Id = brand.Id,
				Name = brand.Name
			};

			return result;
		}

		/// <summary>
		/// Delete brand by id
		/// </summary>
		/// <param name="id">Id of brand</param>
		public void Delete(int id)
		{
			ValidateForExistance(id, out var brand);

			_unitOfWork.Brands.Delete(brand);
			_unitOfWork.SaveChanges();
		}

		/// <summary>
		/// Updates brand
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <param name="entityToUpdate">New properties of brand</param>
		public void Update(int id, BrandDto entityToUpdate)
		{
			ValidateForExistance(entityToUpdate.Id, out var brand);
			ValidateName(entityToUpdate.Name);

			var brandToCreate = MapDtoToEntity(entityToUpdate);

			_unitOfWork.Brands.Update(brandToCreate);
			_unitOfWork.SaveChanges();
		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}

		private void ValidateName(string name)
		{
			var isValid = !string.IsNullOrEmpty(name);
			var isUnique = false;

			if (isValid)
			{
				var toList = _unitOfWork.Brands
					.Get(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase)).ToList();
				isUnique = !_unitOfWork.Brands
					.Get(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase)).Any();
			}

			if (!isValid || !isUnique)
			{
				throw new UnsupportedValueException(name);
			}
		}

		private void ValidateForExistance(int id, out BrandEntity entity)
		{
			entity = _unitOfWork.Brands.GetById(id);

			if (entity == null)
			{
				throw new EntityDoesNotExistsException(id);
			}
		}

		private BrandEntity MapDtoToEntity(BrandDto entity)
		{
			return new BrandEntity()
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

		private BrandDto MapEntityToDto(BrandEntity entity)
		{
			return new BrandDto()
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
