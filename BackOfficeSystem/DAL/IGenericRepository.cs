using System;
using System.Linq;
using System.Linq.Expressions;

namespace BackOfficeSystem.DAL
{
    /// <summary>
    /// Generic repository with basic CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T: class
	{
        /// <summary>
        /// Creates entity
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>Created entity</returns>
        T Create(T entity);

        /// <summary>
        /// Returns entity to id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <param name="propsToLoad">Properties for eager loading</param>
        /// <returns>Sequence of entities</returns>
        IQueryable<T> Get(params string[] propsToLoad);

        /// <summary>
        /// Returns entities based on the predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <param name="propsToLoad">Properties for eager loading</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params string[] propsToLoad);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="item">Entity to delete</param>
        void Delete(T item);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="item">Entity with entity's data to update</param>
        void Update(T item);
    }
}
