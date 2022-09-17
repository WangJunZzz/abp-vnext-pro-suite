namespace Lion.AbpSuite.Templates;

public class TemplateManager : AbpSuiteDomainService
{
    private readonly ITemplateRepository _templateRepository;

    public TemplateManager(ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }

    public async Task<List<TemplateDto>> GetListAsync(string filter = null, int maxResultCount = 10, int skipCount = 0, bool includeDetails = true)
    {
        var list = await _templateRepository.GetListAsync(filter, maxResultCount, skipCount, includeDetails);
        return ObjectMapper.Map<List<Template>, List<TemplateDto>>(list);
    }

    public async Task<long> GetCountAsync(string filter = null)
    {
        return await _templateRepository.GetCountAsync(filter);
    }

    public async Task CreateAsync(string name, string remark)
    {
        var entity = await _templateRepository.FindByNameAsync(name, false);
        if (entity != null)
        {
            throw new UserFriendlyException("模板组已存在");
        }

        entity = new Template(GuidGenerator.Create(), name, remark, CurrentTenant.Id);
        await _templateRepository.InsertAsync(entity);
    }

    public async Task UpdateAsync(Guid id, string name, string remark)
    {
        var entity = await _templateRepository.FindAsync(id, false);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.Update(name, remark);
        await _templateRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _templateRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        await _templateRepository.DeleteAsync(entity);
    }

    public async Task CreateDetailAsync(Guid id, string name, string content, Guid? parentId)
    {
        var entity = await _templateRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.AddDetail(id, name, content, parentId);
        await _templateRepository.UpdateAsync(entity);
    }

    public async Task UpdateDetailAsync(Guid id, Guid detailId, string name, string content)
    {
        var entity = await _templateRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.UpdateDetail(detailId, name, content);
        await _templateRepository.UpdateAsync(entity);
    }

    public async Task DeleteDetailAsync(Guid id, Guid detailId)
    {
        var entity = await _templateRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.DeleteDetail(detailId);
        await _templateRepository.DeleteAsync(entity);
    }
}