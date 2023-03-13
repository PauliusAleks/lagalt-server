using lagalt_web_api.Data;
using lagalt_web_api.Repositories.Interface; 

namespace lagalt_web_api.Repositories.Database;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="lagalt_web_api.Repositories.Interface.IRepository&lt;T&gt;" />
public class DbRepository<T> :  IRepository<T> where T : class
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
    /// <param name="repositoryContext">The repository context.</param>
    public DbRepository(IConfiguration config)
    {
        dbRepositoryContext = new LagaltDbContext(config);
    }
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>The collection of <see cref="T"/></returns>
    public IQueryable<T> GetAll() => dbRepositoryContext.Set<T>();
    /// <summary>
    /// Gets the specified entity.
    /// </summary>
    /// <param name="Id">The identifier.</param>
    /// <returns></returns>
    public T Get(int Id)=> dbRepositoryContext.Set<T>().Find(Id);
    public bool Save()=>dbRepositoryContext.SaveChanges() != 0;

    /// <summary>
    /// Creates the specified entity.
    /// <inheritdoc cref="Microsoft.EntityFrameworkCore.DbContext.Add(object)"/>
    /// </summary>
    /// <param name="entity">The entity.</param>
    public T Create(T entity) { var result = dbRepositoryContext.Set<T>().Add(entity); Save(); return result.Entity; }
    public bool Update(T entity) { var result = dbRepositoryContext.Set<T>().Update(entity); Save(); return result is not null; }
    public bool Delete(T entity) { var result = dbRepositoryContext.Set<T>().Remove(entity); Save(); return result is not null; }
}
