namespace Lion.AbpSuite.Projects;

public class ProjectManager : AbpSuiteDomainService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectManager(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectDto>> GetListAsync(string filter = null, int maxResultCount = 10, int skipCount = 0, bool includeDetails = true)
    {
        var list = await _projectRepository.GetListAsync(filter, maxResultCount, skipCount, includeDetails);
        return ObjectMapper.Map<List<Project>, List<ProjectDto>>(list);
    }

    public async Task<long> GetCountAsync(string filter = null)
    {
        return await _projectRepository.GetCountAsync(filter);
    }

    public async Task<ProjectDto> CreateAsync(string name, string companyName,
        string projectName, string owner = null, string remark = null)
    {
        if (name.IsNullOrWhiteSpace()) throw new UserFriendlyException("项目名称不能为空");
        if (companyName.IsNullOrWhiteSpace()) throw new UserFriendlyException("公司名称不能为空");
        if (projectName.IsNullOrWhiteSpace()) throw new UserFriendlyException("项目名称不能为空");

        var entity = await _projectRepository.FindAsync(name);
        if (entity != null) throw new UserFriendlyException($"{name}项目已存在");
        entity = new Project(GuidGenerator.Create(), name, owner, companyName, projectName, remark, CurrentTenant.Id);

        await _projectRepository.InsertAsync(entity);
        return ObjectMapper.Map<Project, ProjectDto>(entity);
    }

    public async Task<ProjectDto> UpdateAsync(Guid id, string name, string companyName,
        string projectName, string owner = null, string remark = null)
    {
        if (name.IsNullOrWhiteSpace()) throw new UserFriendlyException("项目名称不能为空");
        if (companyName.IsNullOrWhiteSpace()) throw new UserFriendlyException("公司名称不能为空");
        if (projectName.IsNullOrWhiteSpace()) throw new UserFriendlyException("项目名称不能为空");
        var entity = await _projectRepository.FindAsync(id);
        if (entity == null) throw new UserFriendlyException($"项目不存在");
        var exist = await _projectRepository.FindByNameExcludeIdAsync(name, id);
        if (exist != null) throw new UserFriendlyException($"{name}项目已存在");
        entity.Update(name, companyName, projectName, owner, remark);
        await _projectRepository.UpdateAsync(entity);
        return ObjectMapper.Map<Project, ProjectDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _projectRepository.FindAsync(id);
        if (entity == null) throw new UserFriendlyException($"项目不存在");
        await _projectRepository.DeleteAsync(entity);
    }

    public async Task<ProjectDto> GetAsync(Guid id)
    {
        var entity = await _projectRepository.FindAsync(id);
        if (entity == null) throw new UserFriendlyException($"项目不存在");
        return ObjectMapper.Map<Project, ProjectDto>(entity);
    }
}