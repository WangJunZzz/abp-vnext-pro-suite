using Lion.AbpSuite.Generators;

namespace Lion.AbpSuite.Templates;

public sealed class GeneratorManagerTests:AbpSuiteDomainTestBase
{
    private readonly GeneratorManager _generatorManager;

    public GeneratorManagerTests()
    {
        _generatorManager = GetRequiredService<GeneratorManager>();
    }

    // [Fact]
    // public void Render_Should_Ok()
    // {
    //     var result = _generatorManager.RenderAsync("hi {{name}}",new { name = "tobi" });
    //     result.ShouldBe("hi tobi");
    // }
    
}