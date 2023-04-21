using Lion.AbpSuite.Generators.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Lion.AbpSuite.Generators;

public interface IGeneratorAppService : IApplicationService
{

    /// <summary>
    /// 预览代码生成
    /// </summary>
    Task<List<TemplateTreeDto>> PreViewCodeAsync(PreViewCodeInput input);

    /// <summary>
    /// 下载源码
    /// </summary>
    Task<ActionResult> DownCodeAsync(DownCodeInput input);
}