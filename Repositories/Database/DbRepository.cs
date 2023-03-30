using lagalt_web_api.Data;
using lagalt_web_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace lagalt_web_api.Repositories.Database
{
    /// <summary>
    /// Generic database repository base class from which the repositories inherit.
    /// </summary>
    /// <typeparam name="T">The type of the repository.</typeparam>
    public class DbRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        private LagaltDbContext dbRepositoryContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbRepository{T}"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public DbRepository(IConfiguration config)
        {
            dbRepositoryContext = new LagaltDbContext(config);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The collection of <see cref="T"/>.</returns>
        public IQueryable<T> GetAll() => dbRepositoryContext.Set<T>();

        /// <summary>
        /// Gets the specified entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity.</returns>
        public T Get(int id) => dbRepositoryContext.Set<T>().Find(id);

        /// <summary>
        /// Saves the changes made to the database.
        /// </summary>
        /// <returns>True if changes were saved successfully, false otherwise.</returns>
        public bool Save() => dbRepositoryContext.SaveChanges() != 0;

        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        public T Create(T entity)
        {
            var result = dbRepositoryContext.Set<T>().Add(entity);
            Save();
            return result.Entity;
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public T Update(T entity)
        {
            var result = dbRepositoryContext.Set<T>().Update(entity);
            Save();
            return result.Entity;
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>The deleted entity.</returns>
        public T Delete(T entity)
        {
            var result = dbRepositoryContext.Set<T>().Remove(entity);
            Save();
            return result.Entity;
        }

        /// <summary>
        /// Checks if an entity with the specified identifier exists in the database.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>True if an entity with the specified identifier exists, false otherwise.</returns>
        public bool Exists(int id) => dbRepositoryContext.Set<T>().Find(id) != null;
    }
}
