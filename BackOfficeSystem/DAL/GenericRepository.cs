using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BackOfficeSystem.DAL
{
	/// <summary>
	/// Generic repository with basic CRUD operations
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DbSet<T> _dbSet;

		/// <summary>
		/// Initialize generic repository
		/// </summary>
		/// <param name="dbSet">Corresponding dbset</param>
		public GenericRepository(DbSet<T> dbSet)
		{
			_dbSet = dbSet;
		}

		/// <summary>
		/// Creates entity
		/// </summary>
		/// <param name="entity">Entity to create</param>
		/// <returns>Created entity</returns>
		public T Create(T entity)
		{
			return _dbSet.Add(entity).Entity;
		}

		/// <summary>
		/// Deletes entity
		/// </summary>
		/// <param name="item">Entity to delete</param>
		public void Delete(T item)
		{
			_dbSet.Remove(item);
		}

		/// <summary>
		/// Returns all entities
		/// </summary>
		/// <param name="propsToLoad">Properties for eager loading</param>
		/// <returns>Sequence of entities</returns>
		public IQueryable<T> Get(params string[] propsToLoad)
		{
			var dbSet = _dbSet.AsQueryable();
			foreach(var prop in propsToLoad)
			{
				dbSet = dbSet.Include(prop);
			}

			return dbSet;
		}

		/// <summary>
		/// Returns entities based on the predicate
		/// </summary>
		/// <param name="predicate">Predicate</param>
		/// <param name="propsToLoad">Properties for eager loading</param>
		/// <returns></returns>
		public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params string[] propsToLoad)
		{
			var dbSet = _dbSet;
			foreach (var prop in propsToLoad)
			{
				dbSet.Include(prop);
			}

			return dbSet.Where(predicate);
		}

		/// <summary>
		/// Returns entity to id
		/// </summary>
		/// <param name="id">Id of entity</param>
		/// <returns></returns>
		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		/// <summary>
		/// Updates entity
		/// </summary>
		/// <param name="item">Entity with entity's data to update</param>
		public void Update(T item)
		{
			_dbSet.Update(item);
		}
	}
}
