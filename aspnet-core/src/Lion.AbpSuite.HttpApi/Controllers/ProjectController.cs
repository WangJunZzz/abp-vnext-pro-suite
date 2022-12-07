using Lion.AbpSuite.Projects;
using Lion.AbpSuite.Projects.Dto;

namespace Lion.AbpSuite.Controllers;

[Route("Projects")]
public class ProjectController : AbpSuiteController, IProjectAppService
{
    private readonly IProjectAppService _projectAppService;

    public ProjectController(IProjectAppService projectAppService)
    {
        _projectAppService = projectAppService;
    }

    [HttpPost("All")]
    [SwaggerOperation(summary: "获取所有项目", Tags = new[] { "Projects" })]
    public Task<List<ProjectDto>> AllAsync()
    {
        return _projectAppService.AllAsync();
    }

    [HttpPost("Page")]
    [SwaggerOperation(summary: "分页获取项目", Tags = new[] { "Projects" })]
    public Task<PagedResultDto<ProjectDto>> PageAsync(PageProjectInput input)
    {
        return _projectAppService.PageAsync(input);
    }

    [HttpPost("Create")]
    [SwaggerOperation(summary: "创建项目", Tags = new[] { "Projects" })]
    public Task CreateAsync(CreateProjectInput input)
    {
        return _projectAppService.CreateAsync(input);
    }

    [HttpPost("Update")]
    [SwaggerOperation(summary: "更新项目", Tags = new[] { "Projects" })]
    public Task UpdateAsync(UpdateProjectInput input)
    {
        return _projectAppService.UpdateAsync(input);
    }

    [HttpPost("Delete")]
    [SwaggerOperation(summary: "删除项目", Tags = new[] { "Projects" })]
    public Task DeleteAsync(DeleteProjectInput input)
    {
        return _projectAppService.DeleteAsync(input);
    }
}