using lagalt_back_end.Repositories.Base;

namespace lagalt_back_end.Repositories
{

    public interface IRepositoryWrapper 
    {

        IProjectRepository Projects { get; }
 
        void Save();
    }
}
