using System.Linq.Expressions;

namespace lagalt_web_api.Repositories.Interface
{
    // Should be called IBaseRepository actually...
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>The entity.</returns>
        T Get(int Id);
        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Creation success.</returns>
        T Create(T entity);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Update success.</returns>
        bool Update(T entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Deletion success.</returns>
        bool Delete(T entity);
    }
}
