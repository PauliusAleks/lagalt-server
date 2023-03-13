using lagalt_web_api.Repositories.Interface; 

namespace lagalt_web_api.Repositories
{
    /// <summary>
    /// The main access point to the repositories, if we want to add more repositories this makes it easier.
    /// </summary>
    /// <seealso cref="AssignmentThree.Repositories.IRepositoryWrapper" />
    public class Repositories : IRepositories
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;
        private IApplicationRepository _applicationRepository;
        private ISkillRepository _skillRepository;
        private IImageURLRepository _imageURLRepository; 


        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">Failed to initialize LagaltDbContext.</exception>
        public Repositories(IProjectRepository projectRepository,
                                   IUserRepository userRepository,
                                   IApplicationRepository applicationRepository,
                                   ISkillRepository skillRepository,
                                   IImageURLRepository imageURLRepository )
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _applicationRepository = applicationRepository;
            _skillRepository = skillRepository;
            _imageURLRepository = imageURLRepository; 
        }

        public IProjectRepository Projects => _projectRepository;

        public IUserRepository Users => _userRepository;

        public IApplicationRepository Applications => _applicationRepository;

        public ISkillRepository Skills => _skillRepository;

        public IImageURLRepository ImageURLs => _imageURLRepository; 

    }
}
