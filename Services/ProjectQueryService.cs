using ProjectsQueryAPI.DTOs;
using ProjectsQueryAPI.Models;
using ProjectsQueryAPI.Repositories;

namespace ProjectsQueryAPI.Services;

public class ProjectQueryService : IProjectQueryService
{
    private readonly IProjectQueryRepository _repository;

    public ProjectQueryService(IProjectQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllFromTypeEnAsync(string type)
    {
        var projects = await _repository.GetAllByTypeEnAsync(type);
        return projects.Select(MapToDto);
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllFromModuleEnAsync(int module)
    {
        var projects = await _repository.GetAllByModuleEnAsync(module);
        return projects.Select(MapToDto);
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllFromTypeSpAsync(string type)
    {
        var projects = await _repository.GetAllByTypeSpAsync(type);
        return projects.Select(MapToDto);
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllFromModuleSpAsync(int module)
    {
        var projects = await _repository.GetAllByModuleSpAsync(module);
        return projects.Select(MapToDto);
    }

    private static ProjectResponseDto MapToDto(Project p) => new()
    {
        Id = p.Id,
        Title = p.Title,
        Problem = p.Problem,
        Repository = p.Repository,
        Description = p.Description,
        Module = p.Module,
        Deploy = p.Deploy,
        Type = p.Type,
        Language = p.Language
    };
}
