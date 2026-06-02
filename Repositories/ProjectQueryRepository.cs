using Dapper;
using ProjectsQueryAPI.Data;
using ProjectsQueryAPI.Models;

namespace ProjectsQueryAPI.Repositories;

public class ProjectQueryRepository : IProjectQueryRepository
{
    private readonly DbConnection _db;

    public ProjectQueryRepository(DbConnection db)
    {
        _db = db;
    }

    // Proyectos en inglés filtrados por type
    public async Task<IEnumerable<Project>> GetAllByTypeEnAsync(string type)
    {
        const string sql = @"
            SELECT id, problem, repository, description, module, deploy, type, language
            FROM projects
            WHERE language = 'english' AND type = @Type";

        using var connection = _db.CreateConnection();
        return await connection.QueryAsync<Project>(sql, new { Type = type.ToLower() });
    }

    // Proyectos en inglés de tipo riwi filtrados por module
    public async Task<IEnumerable<Project>> GetAllByModuleEnAsync(int module)
    {
        const string sql = @"
            SELECT id, problem, repository, description, module, deploy, type, language
            FROM projects
            WHERE language = 'english' AND type = 'riwi' AND module = @Module";

        using var connection = _db.CreateConnection();
        return await connection.QueryAsync<Project>(sql, new { Module = module });
    }

    // Proyectos en español filtrados por type
    public async Task<IEnumerable<Project>> GetAllByTypeSpAsync(string type)
    {
        const string sql = @"
            SELECT id, problem, repository, description, module, deploy, type, language
            FROM projects
            WHERE language = 'español' AND type = @Type";

        using var connection = _db.CreateConnection();
        return await connection.QueryAsync<Project>(sql, new { Type = type.ToLower() });
    }

    // Proyectos en español de tipo riwi filtrados por module
    public async Task<IEnumerable<Project>> GetAllByModuleSpAsync(int module)
    {
        const string sql = @"
            SELECT id, problem, repository, description, module, deploy, type, language
            FROM projects
            WHERE language = 'español' AND type = 'riwi' AND module = @Module";

        using var connection = _db.CreateConnection();
        return await connection.QueryAsync<Project>(sql, new { Module = module });
    }
}
