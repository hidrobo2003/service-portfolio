namespace ProjectsQueryAPI.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Problem { get; set; } = string.Empty;
    public string Repository { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? Module { get; set; }
    public string? Deploy { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
}
