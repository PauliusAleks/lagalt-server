using lagalt_back_end.Data;
using lagalt_back_end.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace lagalt_back_end.Repositories
{
    /// <summary>
    /// The main access point to the repositories, if we want to add more repositories this makes it easier.
    /// </summary>
    /// <seealso cref="AssignmentThree.Repositories.IRepositoryWrapper" />
    public class DbRepositoryWrapper : IRepositoryWrapper
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        private LagaltDbContext _context { get; }

 
        private IProjectRepository _projectRepository;
 

        /// <summary>
        /// Initializes a new instance of the <see cref="DbRepositoryWrapper"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">Failed to initialize MovieDbContext.</exception>
        public DbRepositoryWrapper(LagaltDbContext context)
        {
            _context = context ?? throw new ArgumentNullException("Failed to initialize MovieDbContext.");
        }
        /// <summary>
        /// Gets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public IProjectRepository Projects
        {
            get
            {
                if (_projectRepository is null)
                {
                    _projectRepository = new DbProjectRepository(_context);
                }
                return _projectRepository;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
