using Lion.AbpSuite.Projects;
using Lion.AbpSuite.Projects.Aggregates;

namespace Lion.AbpSuite.Data;

public class ProjectTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IProjectRepository _projectRepository;

    public ProjectTestDataSeedContributor(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var entity = await _projectRepository.FindAsync(AbpSuiteTestConst.ProjectId);
        if (entity == null)
        {
            await _projectRepository.InsertAsync(new Project(AbpSuiteTestConst.ProjectId, "单元测试种子项目", "WangJun", "Lion.AbpSuite", "测试"));
        }
    }
}