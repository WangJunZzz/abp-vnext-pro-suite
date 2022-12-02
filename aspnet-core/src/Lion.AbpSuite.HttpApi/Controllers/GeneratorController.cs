using Lion.AbpSuite.Generators;
using Lion.AbpSuite.Generators.Dto;

namespace Lion.AbpSuite.Controllers;

[Route("Generator")]
public class GeneratorController : AbpSuiteController, IGeneratorAppService
{
    private readonly IGeneratorAppService _generatorAppService;

    public GeneratorController(IGeneratorAppService generatorAppService)
    {
        _generatorAppService = generatorAppService;
    }


    [HttpPost("PreView")]
    [SwaggerOperation(summary: "预览", Tags = new[] { "Generator" })]
    public Task<string> PreViewAsync(PreViewInput input)
    {
        return _generatorAppService.PreViewAsync(input);
    }
    [HttpPost("PreViewCode")]
    [SwaggerOperation(summary: "预览", Tags = new[] { "Generator" })]
    public Task<List<TemplateTreeDto>> PreViewCodeAsync(PreViewCodeInput input)
    {
        return _generatorAppService.PreViewCodeAsync(input);
    }
}