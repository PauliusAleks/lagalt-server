using lagalt_back_end.Data;
using lagalt_back_end.Repositories.Base;
using lagalt_web_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace lagalt_back_end.Repositories
{
    /// <summary>
    /// The main access point to the repositories, if we want to add more repositories this makes it easier.
    /// </summary>
    /// <seealso cref="AssignmentThree.Repositories.IRepositoryWrapper" />
    public class Repositories : IRepositories
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;
        private IHistoricEventRepository _historicEventRepository;
        private IApplicationRepository _applicationRepository;
        private ISkillRepository _skillRepository;
        private IImageURLRepository _imageURLRepository;
        private IAdminRepository _adminRepository;
        private IContributorRepository _contributorRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">Failed to initialize LagaltDbContext.</exception>
        public Repositories(IProjectRepository projectRepository,
                                   IUserRepository userRepository,
                                   IHistoricEventRepository historicEventRepository,
                                   IApplicationRepository applicationRepository,
                                   ISkillRepository skillRepository,
                                   IImageURLRepository imageURLRepository,
                                   IAdminRepository adminRepository,
                                   IContributorRepository contributorRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _historicEventRepository = historicEventRepository;
            _applicationRepository = applicationRepository;
            _skillRepository = skillRepository;
            _imageURLRepository = imageURLRepository;
            _adminRepository = adminRepository;
            _contributorRepository = contributorRepository;
        }

        public IProjectRepository Projects => _projectRepository;

        public IUserRepository Users => _userRepository;

        public IHistoricEventRepository History => _historicEventRepository;

        public IApplicationRepository Applications => _applicationRepository;

        public ISkillRepository Skills => _skillRepository;

        public IImageURLRepository ImageURLs => _imageURLRepository;

        public IAdminRepository Admins => _adminRepository;

        public IContributorRepository Contributors => _contributorRepository;

    }
}
