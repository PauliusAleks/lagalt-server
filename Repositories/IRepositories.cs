using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories
{

    /// <summary>
    /// Defines a wrapper for repositories, which provides access to different repositories.
    /// </summary>
    public interface IRepositories
    {
        /// <summary>
        /// Gets the project repository.
        /// </summary>
        /// <value>The project repository.</value>
        IProjectRepository Projects { get; }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>The user repository.</value>
        IUserRepository Users { get; }

        /// <summary>
        /// Gets the application repository.
        /// </summary>
        /// <value>The application repository.</value>
        IApplicationRepository Applications { get; }

        /// <summary>
        /// Gets the skill repository.
        /// </summary>
        /// <value>The skill repository.</value>
        ISkillRepository Skills { get; }

        /// <summary>
        /// Gets the image URL repository.
        /// </summary>
        /// <value>The image URL repository.</value>
        IImageURLRepository ImageURLs { get; }

        /// <summary>
        /// Gets the user message repository.
        /// </summary>
        /// <value>The user message repository.</value>
        IUserMessageRepository UserMessages { get; }
    }
}
