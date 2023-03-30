using lagalt_web_api.Data;
using lagalt_web_api.Repositories.Database;
using lagalt_web_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace lagalt_web_api.Repositories
{
    /// <summary>
    /// This class serves as the main access point to the repositories. It allows for easier addition
    /// of more repositories in the future.
    /// </summary>
    public class Repositories : IRepositories
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;
        private IApplicationRepository _applicationRepository;
        private ISkillRepository _skillRepository;
        private IImageURLRepository _imageURLRepository;
        private IUserMessageRepository _userMessageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        /// <param name="projectRepository">The project repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="applicationRepository">The application repository.</param>
        /// <param name="skillRepository">The skill repository.</param>
        /// <param name="imageURLRepository">The image URL repository.</param>
        /// <param name="userMessageRepository">The user message repository.</param>
        public Repositories(IProjectRepository projectRepository,
                            IUserRepository userRepository,
                            IApplicationRepository applicationRepository,
                            ISkillRepository skillRepository,
                            IImageURLRepository imageURLRepository,
                            IUserMessageRepository userMessageRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _applicationRepository = applicationRepository;
            _skillRepository = skillRepository;
            _imageURLRepository = imageURLRepository;
            _userMessageRepository = userMessageRepository;
        }

        /// <summary>
        /// Gets the project repository.
        /// </summary>
        public IProjectRepository Projects => _projectRepository;

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        public IUserRepository Users => _userRepository;

        /// <summary>
        /// Gets the application repository.
        /// </summary>
        public IApplicationRepository Applications => _applicationRepository;

        /// <summary>
        /// Gets the skill repository.
        /// </summary>
        public ISkillRepository Skills => _skillRepository;

        /// <summary>
        /// Gets the image URL repository.
        /// </summary>
        public IImageURLRepository ImageURLs => _imageURLRepository;

        /// <summary>
        /// Gets the user message repository.
        /// </summary>
        public IUserMessageRepository UserMessages => _userMessageRepository;
    }
}
