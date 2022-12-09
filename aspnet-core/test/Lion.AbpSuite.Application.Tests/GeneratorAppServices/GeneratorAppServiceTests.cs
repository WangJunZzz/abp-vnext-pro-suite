using Lion.AbpSuite.Data;
using Lion.AbpSuite.Generators;
using Lion.AbpSuite.Generators.Dto;

namespace Lion.AbpSuite.GeneratorAppServices;

public sealed class GeneratorAppServiceTests : AbpSuiteApplicationTestBase
{
    private readonly IGeneratorAppService _generatorAppService;

    public GeneratorAppServiceTests()
    {
        _generatorAppService = GetRequiredService<IGeneratorAppService>();
    }
    
    [Fact]
    public async Task GetCodeAsync()
    {
        // var result = await _generatorAppService.PreViewCodeAsync(new PreViewCodeInput()
        // {
        //     ProjectId = AbpSuiteTestConst.ProjectId,
        //     TemplateId = AbpSuiteTestConst.TemplateId
        // });
        var result = await _generatorAppService.PreViewCodeAsync(new PreViewCodeInput()
        {
            ProjectId = AbpSuiteTestConst.ProjectId,
            TemplateId = TemplateDataSeedConst.TemplateId
        });
    }
}