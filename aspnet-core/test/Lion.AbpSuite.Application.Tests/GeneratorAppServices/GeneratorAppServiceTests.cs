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
    public async Task PreViewAsync()
    {
        var result = await _generatorAppService.PreViewAsync(new PreViewInput()
        {
            AggregateId = Guid.Parse("3a07bad0-cc54-1dd7-1abe-da2c79dd8cda"),
            TemplateId = Guid.Parse("3a071f8f-e01f-6f0c-6f93-6573e4253eb0"),
            TemplateDetailId = Guid.Parse("3a071f8f-e01f-6f0c-6f93-6573e4253eb1")
        });
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