namespace Lion.AbpSuite.Controllers;

[Route("Templates")]
public class TemplateController : AbpSuiteController, ITemplateAppService
{
    private readonly ITemplateAppService _templateAppService;

    public TemplateController(ITemplateAppService templateAppService)
    {
        _templateAppService = templateAppService;
    }

    [HttpPost("All")]
    [SwaggerOperation(summary: "获取所有模板组", Tags = new[] { "Templates" })]
    public Task<List<TemplateDto>> AllAsync()
    {
        return _templateAppService.AllAsync();
    }

    [HttpPost("Page")]
    [SwaggerOperation(summary: "分页获取模板组", Tags = new[] { "Templates" })]
    public Task<PagedResultDto<TemplateDto>> PageAsync(PageTemplateInput input)
    {
        return _templateAppService.PageAsync(input);
    }

    [HttpPost("Create")]
    [SwaggerOperation(summary: "创建模板组", Tags = new[] { "Templates" })]
    public Task CreateAsync(CreateTemplateInput input)
    {
        return _templateAppService.CreateAsync(input);
    }

    [HttpPost("Update")]
    [SwaggerOperation(summary: "更新模板组", Tags = new[] { "Templates" })]
    public Task UpdateAsync(UpdateTemplateInput input)
    {
        return _templateAppService.UpdateAsync(input);
    }

    [HttpPost("Delete")]
    [SwaggerOperation(summary: "删除模板组", Tags = new[] { "Templates" })]
    public Task DeleteAsync(DeleteTemplateInput input)
    {
        return _templateAppService.DeleteAsync(input);
    }

    [HttpPost("CreateDetail")]
    [SwaggerOperation(summary: "创建模板", Tags = new[] { "Templates" })]
    public Task CreateDetailAsync(CreateTemplateDetailInput input)
    {
        return _templateAppService.CreateDetailAsync(input);
    }

    [HttpPost("UpdateDetail")]
    [SwaggerOperation(summary: "编辑模板", Tags = new[] { "Templates" })]
    public Task UpdateDetailAsync(UpdateTemplateDetailInput input)
    {
        return _templateAppService.UpdateDetailAsync(input);
    }


    [HttpPost("UpdateDetailContent")]
    [SwaggerOperation(summary: "编辑模板", Tags = new[] { "Templates" })]
    public Task UpdateDetailAsync(UpdateTemplateDetailContentInput input)
    {
        return _templateAppService.UpdateDetailAsync(input);
    }

    [HttpPost("DeleteDetail")]
    [SwaggerOperation(summary: "删除模板", Tags = new[] { "Templates" })]
    public Task DeleteDetailAsync(DeleteTemplateDetailInput input)
    {
        return _templateAppService.DeleteDetailAsync(input);
    }

    [HttpPost("Tree")]
    [SwaggerOperation(summary: "获取模板树形结构", Tags = new[] { "Templates" })]
    public Task<List<GetTemplateTreeOutput>> TemplateTreeAsync(GetTemplteTreeInput input)
    {
        return _templateAppService.TemplateTreeAsync(input);
    }

    [HttpPost("List")]
    [SwaggerOperation(summary: "获取所有模板", Tags = new[] { "Templates" })]
    public Task<List<TemplateDto>> ListAsync()
    {
        return _templateAppService.ListAsync();
    }

    [HttpPost("ControlType")]
    [SwaggerOperation(summary: "获取模板策略", Tags = new[] { "Templates" })]
    public List<KeyValuePair<string, int>> GetControlTypeAsync()
    {
        return _templateAppService.GetControlTypeAsync();
    }

    [HttpPost("TemplateType")]
    [SwaggerOperation(summary: "获取模板类型", Tags = new[] { "Templates" })]
    public List<KeyValuePair<string, int>> GetTemplateTypeAsync()
    {
        return _templateAppService.GetTemplateTypeAsync();
    }

    [HttpPost("Copy")]
    [SwaggerOperation(summary: "复制模板", Tags = new[] { "Templates" })]
    public Task CopyTemplateAsync(CopyTemplateInput input)
    {
        return _templateAppService.CopyTemplateAsync(input);
    }
}