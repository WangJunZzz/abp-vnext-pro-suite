namespace Lion.AbpSuite.Controllers;

[Route("Templates")]
public class TemplateController : AbpSuiteController, ITemplateAppService
{
    private readonly ITemplateAppService _templateAppService;

    public TemplateController(ITemplateAppService templateAppService)
    {
        _templateAppService = templateAppService;
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
    public Task UpdateAsync(UpdateTemplteInput input)
    {
        return _templateAppService.UpdateAsync(input);
    }

    [HttpPost("Delete")]
    [SwaggerOperation(summary: "编辑模板组", Tags = new[] { "Templates" })]
    public Task DeleteAsync(DeleteTemplateInput input)
    {
        return _templateAppService.DeleteAsync(input);
    }
}