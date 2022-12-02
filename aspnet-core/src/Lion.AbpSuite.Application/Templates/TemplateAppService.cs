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

    public async Task<List<TemplateDto>> ListAsync()
    {
        var list = await _templateManager.GetListAsync(null, Int32.MaxValue, 0, false);
        return list;
    }

    public Task CreateAsync(CreateTemplateInput input)
    {
        return _templateManager.CreateAsync(input.Name, input.Remark);
    }

    public Task UpdateAsync(UpdateTemplateInput input)
    {
        return _templateManager.UpdateAsync(input.Id, input.Name, input.Remark);
    }

    public Task DeleteAsync(DeleteTemplateInput input)
    {
        return _templateManager.DeleteAsync(input.Id);
    }

    public Task CreateDetailAsync(CreateTemplateDetailInput input)
    {
        if (input.TemplateType == TemplateType.Folder)
        {
            input.ControlType = ControlType.Default;
        }
        return _templateManager.CreateDetailAsync(input.TemplateId, input.TemplateType, input.ControlType, input.Name, input.Description, input.Content, input.ParentId);
    }
    

    public Task UpdateDetailAsync(UpdateTemplateDetailInput input)
    {
        return _templateManager.UpdateDetailAsync(input.TemplateId, input.TemplateDetailId, input.Name, input.Description, input.Content);
    }

    public Task UpdateDetailAsync(UpdateTemplateDetailContentInput input)
    {
        return _templateManager.UpdateDetailAsync(input.TemplateId, input.TemplateDetailId, input.Content);
    }

    public Task UpdateDetailAsync(UpdateTemplateDetailNoContentInput input)
    {
        return _templateManager.UpdateDetailAsync(input.TemplateId, input.TemplateDetailId, input.Name, input.Description);
    }

    public Task DeleteDetailAsync(DeleteTemplateDetailInput input)
    {
        return _templateManager.DeleteDetailAsync(input.TemplateId, input.TemplateDetailId);
    }

    // TODO 移除待
    public async Task<List<GetTemplateTreeOutput>> TemplateTreeAsync(GetTemplteTreeInput input)
    {
        var template = await _templateManager.GetAsync(input.TemplateId);
        if (template.TemplateDetails.Count == 0) return new List<GetTemplateTreeOutput>();
        return RecursionTemplate(template.TemplateDetails, null);
    }

    private List<GetTemplateTreeOutput> RecursionTemplate(List<TemplateDetailDto> template, Guid? parentId)
    {
        var tree = new List<GetTemplateTreeOutput>();
        var list = template.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            var child = new GetTemplateTreeOutput()
            {
                Key = detail.Id,
                Name = detail.Name,
                Title = detail.Description,
                Description = detail.Description,
                Content = detail.Content,
                TemplateType = detail.TemplateType,
                Icon = detail.TemplateType == TemplateType.Folder ? "ant-design:folder-open-outlined" : "ant-design:file-outlined"
            };
            child.Children.AddRange(RecursionTemplate(template, detail.Id));
            tree.Add(child);
        }

        return tree;
    }
}