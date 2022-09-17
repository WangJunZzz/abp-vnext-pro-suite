namespace Lion.AbpSuite.Templates;

public class TemplateAppService : AbpSuiteAppService, ITemplateAppService
{
    private readonly TemplateManager _templateManager;

    public TemplateAppService(TemplateManager templateManager)
    {
        _templateManager = templateManager;
    }

    public async Task<PagedResultDto<TemplateDto>> PageAsync(PageTemplateInput input)
    {
        var result = new PagedResultDto<TemplateDto>();
        var totalCount = await _templateManager.GetCountAsync(input.Filter);
        result.TotalCount = totalCount;
        if (totalCount <= 0) return result;

        var list = await _templateManager.GetListAsync(input.Filter, input.PageSize,
            input.SkipCount, false);
        result.Items = list;

        return result;
    }

    public Task CreateAsync(CreateTemplateInput input)
    {
        return _templateManager.CreateAsync(input.Name, input.Remark);
    }

    public Task UpdateAsync(UpdateTemplteInput input)
    {
        return _templateManager.UpdateAsync(input.Id, input.Name, input.Remark);
    }

    public Task DeleteAsync(DeleteTemplateInput input)
    {
        return _templateManager.DeleteAsync(input.Id);
    }
}