namespace Lion.AbpSuite.Extensions;

public class StringExtensionTests:AbpSuiteDomainTestBase
{
    [Fact]
    public void IsPlaceholder()
    {
        var text = "{q}";
        var result = text.IsPlaceholder();
        result.ShouldBeTrue();
    }
}