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

    /// <summary>
    /// 创建模板组
    /// </summary>
    /// <param name="name">模板组名称</param>
    /// <param name="remark">备注</param>
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

    /// <summary>
    /// 更新模板组
    /// </summary>
    public async Task UpdateAsync(Guid id, string name, string remark)
    {
        var entity = await _templateRepository.FindAsync(id, false);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        var template = await _templateRepository.FindByNameExcludeIdAsync(name, id, false);
        if (template != null)
        {
            throw new UserFriendlyException("模板组名称已存在");
        }

        entity.Update(name, remark);
        await _templateRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除模板组
    /// </summary>
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _templateRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        await _templateRepository.DeleteAsync(entity);
    }

    public async Task CreateDetailAsync(Guid templateId, TemplateType templateType, ControlType? controlType, string name, string description, string content, Guid? parentId)
    {
        var entity = await _templateRepository.FindAsync(templateId);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.AddTemplateDetail(GuidGenerator.Create(), templateType, controlType,name, description, content, parentId);
        await _templateRepository.UpdateAsync(entity);
    }
    
    // public async Task CreateDetailAsync(Guid templateId, TemplateType templateType, ControlType controlType, string name, string description, Guid? parentId)
    // {
    //     var entity = await _templateRepository.FindAsync(templateId);
    //     if (entity == null)
    //     {
    //         throw new UserFriendlyException("模板组不存在");
    //     }
    //
    //     entity.AddTemplateDetail(GuidGenerator.Create(), templateType, name, description, parentId);
    //     await _templateRepository.UpdateAsync(entity);
    // }
    public async Task UpdateDetailAsync(Guid templateId, Guid detailId, string name, string description, string content)
    {
        var entity = await _templateRepository.FindAsync(templateId);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.UpdateDetail(detailId, name, description, content);
        await _templateRepository.UpdateAsync(entity);
    }
    
    public async Task UpdateDetailAsync(Guid templateId, Guid detailId, string content)
    {
        var entity = await _templateRepository.FindAsync(templateId);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.UpdateDetailContent(detailId, content);
        await _templateRepository.UpdateAsync(entity);
    }
    public async Task UpdateDetailAsync(Guid templateId, Guid detailId, string name, string description)
    {
        var entity = await _templateRepository.FindAsync(templateId);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        entity.UpdateDetail(detailId, name, description);
        await _templateRepository.UpdateAsync(entity);
    }
    public async Task DeleteDetailAsync(Guid templateId, Guid templateDetailId)
    {
        var entity = await _templateRepository.FindAsync(templateId);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        foreach (var templateDetail in entity.TemplateDetails.Where(e=>e.ParentId==templateDetailId))
        {
            templateDetail.IsDeleted = true;
        }
        entity.DeleteDetail(templateDetailId);
        await _templateRepository.UpdateAsync(entity);
    }

    public async Task<TemplateDto> GetAsync(Guid templateId)
    {
        var entity = await _templateRepository.FindAsync(templateId);
        if (entity == null)
        {
            throw new UserFriendlyException("模板组不存在");
        }

        return ObjectMapper.Map<Template, TemplateDto>(entity);
    }
    
    public async Task<List<TemplateTreeDto>> TemplateTreeAsync(Guid id)
    {
        var template = await GetAsync(id);
        if (template.TemplateDetails.Count == 0) return new List<TemplateTreeDto>();
        return RecursionTemplate(template.TemplateDetails, null);
    }

    private List<TemplateTreeDto> RecursionTemplate(List<TemplateDetailDto> template, Guid? parentId)
    {
        var tree = new List<TemplateTreeDto>();
        var list = template.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            var child = new TemplateTreeDto()
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