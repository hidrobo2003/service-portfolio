using ProjectsQueryAPI.Models;

namespace ProjectsQueryAPI.Repositories;

public interface IProjectQueryRepository
{
    Task<IEnumerable<Project>> GetAllByTypeEnAsync(string type);
    Task<IEnumerable<Project>> GetAllByModuleEnAsync(int module);
    Task<IEnumerable<Project>> GetAllByTypeSpAsync(string type);
    Task<IEnumerable<Project>> GetAllByModuleSpAsync(int module);
}
