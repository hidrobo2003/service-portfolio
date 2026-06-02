using ProjectsQueryAPI.DTOs;

namespace ProjectsQueryAPI.Services;

public interface IProjectQueryService
{
    Task<IEnumerable<ProjectResponseDto>> GetAllFromTypeEnAsync(string type);
    Task<IEnumerable<ProjectResponseDto>> GetAllFromModuleEnAsync(int module);
    Task<IEnumerable<ProjectResponseDto>> GetAllFromTypeSpAsync(string type);
    Task<IEnumerable<ProjectResponseDto>> GetAllFromModuleSpAsync(int module);
}
