using Lion.AbpSuite.Projects;

namespace Lion.AbpSuite.Data.Projects;

public class ProjectTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IProjectRepository _projectRepository;

    public ProjectTestDataSeedContributor(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var entity = await _projectRepository.FindAsync(ProjectDataSeedConst.ProjectId);
        if (entity == null)
        {
            await _projectRepository.InsertAsync(new Project(ProjectDataSeedConst.ProjectId, "默认项目", "WangJun", "Lion.Erp", "请勿删除"));
        }
    }
}