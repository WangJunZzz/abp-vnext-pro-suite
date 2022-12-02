using Lion.AbpSuite.EnumTypes;
using Lion.AbpSuite.EnumTypes.Dto;

namespace Lion.AbpSuite.Controllers;

[Route("EnumTypes")]
public class EnumTypeController : AbpSuiteController, IEnumTypeAppService
{
    private readonly IEnumTypeAppService _enumTypeAppService;

    public EnumTypeController(IEnumTypeAppService enumTypeAppService)
    {
        _enumTypeAppService = enumTypeAppService;
    }

    [HttpPost("Page")]
    [SwaggerOperation(summary: "分页获取枚举", Tags = new[] { "EnumTypes" })]
    public Task<PagedResultDto<PageEnumTypeOutput>> PageAsync(PageEnumTypeInput input)
    {
        return _enumTypeAppService.PageAsync(input);
    }

    [HttpPost("PageProperty")]
    [SwaggerOperation(summary: "分页获取枚举属性", Tags = new[] { "EnumTypes" })]
    public Task<PagedResultDto<PageEnumTypePropertyOutput>> PagePropertyAsync(PageEnumTypePropertyInput input)
    {
        return _enumTypeAppService.PagePropertyAsync(input);
    }

    [HttpPost("CreateEnumType")]
    [SwaggerOperation(summary: "创建枚举", Tags = new[] { "EnumTypes" })]
    public Task CreateEnumTypeAsync(CreateEnumTypeInput input)
    {
        return _enumTypeAppService.CreateEnumTypeAsync(input);
    }

    [HttpPost("UpdateEnumType")]
    [SwaggerOperation(summary: "更新枚举", Tags = new[] { "EnumTypes" })]
    public Task UpdateEnumTypeAsync(UpdateEnumTypeInput input)
    {
        return _enumTypeAppService.UpdateEnumTypeAsync(input);
    }

    [HttpPost("DeleteEnumType")]
    [SwaggerOperation(summary: "删除枚举", Tags = new[] { "EnumTypes" })]
    public Task DeleteEnumTypeAsync(DeleteEnumTypeInput input)
    {
        return _enumTypeAppService.DeleteEnumTypeAsync(input);
    }

    [HttpPost("CreateEnumTypeProperty")]
    [SwaggerOperation(summary: "创建枚举属性", Tags = new[] { "EnumTypes" })]
    public Task CreateEnumTypePropertyAsync(CreateEnumTypePropertyInput input)
    {
        return _enumTypeAppService.CreateEnumTypePropertyAsync(input);
    }

    [HttpPost("UpdateEnumTypeProperty")]
    [SwaggerOperation(summary: "更新枚举属性", Tags = new[] { "EnumTypes" })]
    public Task UpdateEnumTypePropertyAsync(UpdateEnumTypePropertyInput input)
    {
        return _enumTypeAppService.UpdateEnumTypePropertyAsync(input);
    }

    [HttpPost("DeleteEnumTypeProperty")]
    [SwaggerOperation(summary: "删除枚举属性", Tags = new[] { "EnumTypes" })]
    public Task DeleteEnumTypePropertyAsync(DeleteEnumTypePropertyInput input)
    {
        return _enumTypeAppService.DeleteEnumTypePropertyAsync(input);
    }
}