using System.Linq.Expressions;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// Provides the base functionality for a generic repository for entities.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The collection of entities.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>The entity, or null if not found.</returns>
        T Get(int Id);

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        T Create(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        T Update(T entity);

        /// <summary>
        /// Deletes an existing entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>The deleted entity.</returns>
        T Delete(T entity);

        /// <summary>
        /// Determines whether an entity with the specified identifier exists.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>True if the entity exists, false otherwise.</returns>
        bool Exists(int id);
    }
}
