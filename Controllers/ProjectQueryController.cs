using Microsoft.AspNetCore.Mvc;
using ProjectsQueryAPI.Common;
using ProjectsQueryAPI.DTOs;
using ProjectsQueryAPI.Services;

namespace ProjectsQueryAPI.Controllers;

[ApiController]
[Route("api/projects")]
[Produces("application/json")]
public class ProjectQueryController : ControllerBase
{
    private readonly IProjectQueryService _service;

    public ProjectQueryController(IProjectQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Proyectos en inglés filtrados por type.
    /// Valores válidos: riwi | professional | personal
    /// </summary>
    [HttpGet("en/type")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProjectResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFromTypeEn([FromQuery] string type)
    {
        if (!IsValidType(type))
            return BadRequest(new ApiResponse<object>(
                success: false,
                message: "Tipo inválido. Valores aceptados: riwi, professional, personal.",
                data: null
            ));

        var result = await _service.GetAllFromTypeEnAsync(type);
        return Ok(new ApiResponse<IEnumerable<ProjectResponseDto>>(
            success: true,
            message: $"Proyectos en inglés de tipo '{type}'.",
            data: result
        ));
    }

    /// <summary>
    /// Proyectos en inglés filtrados por número de módulo.
    /// </summary>
    [HttpGet("en/module")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProjectResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFromModuleEn([FromQuery] int module)
    {
        if (module < 1)
            return BadRequest(new ApiResponse<object>(
                success: false,
                message: "El módulo debe ser un número mayor a 0.",
                data: null
            ));

        var result = await _service.GetAllFromModuleEnAsync(module);
        return Ok(new ApiResponse<IEnumerable<ProjectResponseDto>>(
            success: true,
            message: $"Proyectos Riwi en inglés del módulo {module}.",
            data: result
        ));
    }

    /// <summary>
    /// Proyectos en español filtrados por type.
    /// Valores válidos: riwi | professional | personal
    /// </summary>
    [HttpGet("sp/type")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProjectResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFromTypeSp([FromQuery] string type)
    {
        if (!IsValidType(type))
            return BadRequest(new ApiResponse<object>(
                success: false,
                message: "Tipo inválido. Valores aceptados: riwi, professional, personal.",
                data: null
            ));

        var result = await _service.GetAllFromTypeSpAsync(type);
        return Ok(new ApiResponse<IEnumerable<ProjectResponseDto>>(
            success: true,
            message: $"Proyectos en español de tipo '{type}'.",
            data: result
        ));
    }

    /// <summary>
    /// Proyectos en español filtrados por número de módulo.
    /// </summary>
    [HttpGet("sp/module")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProjectResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFromModuleSp([FromQuery] int module)
    {
        if (module < 1)
            return BadRequest(new ApiResponse<object>(
                success: false,
                message: "El módulo debe ser un número mayor a 0.",
                data: null
            ));

        var result = await _service.GetAllFromModuleSpAsync(module);
        return Ok(new ApiResponse<IEnumerable<ProjectResponseDto>>(
            success: true,
            message: $"Proyectos Riwi en español del módulo {module}.",
            data: result
        ));
    }

    // ── Helpers ─────────────────────────────────────────────────────────────

    private static readonly HashSet<string> ValidTypes =
        new(StringComparer.OrdinalIgnoreCase) { "riwi", "professional", "personal" };

    private static bool IsValidType(string type) =>
        !string.IsNullOrWhiteSpace(type) && ValidTypes.Contains(type);
}
