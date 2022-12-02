using Lion.AbpSuite.Generators.Dto;
using Lion.AbpSuite.Templates;

namespace Lion.AbpSuite.Generators;

public interface IGeneratorAppService : IApplicationService
{
    /// <summary>
    /// 预览代码生成
    /// </summary>
    Task<string> PreViewAsync(PreViewInput input);

    Task<List<TemplateTreeDto>> PreViewCodeAsync(PreViewCodeInput input);
}