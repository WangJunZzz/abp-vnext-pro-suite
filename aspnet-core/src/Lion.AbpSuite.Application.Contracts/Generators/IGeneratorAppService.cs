using Lion.AbpSuite.Generators.Dto;
using Lion.AbpSuite.Templates;

namespace Lion.AbpSuite.Generators;

public interface IGeneratorAppService : IApplicationService
{

    /// <summary>
    /// 预览代码生成
    /// </summary>
    Task<List<TemplateTreeDto>> PreViewCodeAsync(PreViewCodeInput input);
}