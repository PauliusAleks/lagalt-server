using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using lagalt_back_end.Data;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace lagalt_back_end.Repositories.Base
{
    /// <summary>
    /// Generic database-repository base-class from which the repositories inherit.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="AssignmentThree.Repositories.Base.IRepository&lt;T&gt;" />
    public class DbRepositoryBase<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        protected LagaltDbContext repositoryContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public DbRepositoryBase(LagaltDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The collection of <see cref="T"/></returns>
        public IQueryable<T> GetAll() => repositoryContext.Set<T>();
        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public T Get(int Id)=> repositoryContext.Set<T>().Find(Id);
        public bool Save()=>repositoryContext.SaveChanges() != 0;

        /// <summary>
        /// Creates the specified entity.
        /// <inheritdoc cref="Microsoft.EntityFrameworkCore.DbContext.Add(object)"/>
        /// </summary>
        /// <param name="entity">The entity.</param>
        public bool Create(T entity) { var result = repositoryContext.Set<T>().Add(entity); Save(); return result is not null; }
        public bool Update(T entity) { var result = repositoryContext.Set<T>().Update(entity); Save(); return result is not null; }
        public bool Delete(T entity) { var result = repositoryContext.Set<T>().Remove(entity); Save(); return result is not null; }
    }
}
