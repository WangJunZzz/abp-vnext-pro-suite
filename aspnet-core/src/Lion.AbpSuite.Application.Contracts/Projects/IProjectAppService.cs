namespace Lion.AbpSuite.Projects;

public interface IProjectAppService : IApplicationService
{
    Task<List<ProjectDto>> AllAsync();
    
    Task<PagedResultDto<ProjectDto>> PageAsync(PageProjectInput input);

    Task CreateAsync(CreateProjectInput input);

    Task UpdateAsync(UpdateProjectInput input);

    Task DeleteAsync(DeleteProjectInput input);
}