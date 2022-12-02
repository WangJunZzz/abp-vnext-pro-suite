namespace Lion.AbpSuite.EnumTypes;

public sealed class EnumTypeManagerTests : AbpSuiteDomainTestBase
{
    private readonly EnumTypeManager _enumTypeManager;

    public EnumTypeManagerTests()
    {
        _enumTypeManager = GetRequiredService<EnumTypeManager>();
    }
    

    [Fact]
    public async Task CreateAsync()
    {
        var result = await _enumTypeManager.CreateAsync("xx", "data", AbpSuiteTestConst.AggregateId,AbpSuiteTestConst.ProjectId);
        result.Code.ShouldBe("xx");
        result.Description.ShouldBe("data");

        var throwResult = await Should.ThrowAsync<UserFriendlyException>(
            async () => { await _enumTypeManager.CreateAsync("Gender", "data", AbpSuiteTestConst.AggregateId,AbpSuiteTestConst.ProjectId); });
        throwResult.Message.ShouldBe($"枚举已存在");
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var result = await _enumTypeManager.UpdateAsync(AbpSuiteTestConst.EnumTypeId, "xx", "data");
        result.Code.ShouldBe("xx");
        result.Description.ShouldBe("data");
    }

    [Fact]
    public async Task UpdateAsync_Exception()
    {
        var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _enumTypeManager.UpdateAsync(Guid.NewGuid(), "xxx", "data");
        });
        throwResult.Message.ShouldBe($"枚举不存在");

        Guid id = default;
        await WithUnitOfWorkAsync(async () =>
        {
            var enumTypeDto=  await _enumTypeManager.CreateAsync("Age", "data", AbpSuiteTestConst.AggregateId,AbpSuiteTestConst.ProjectId);
            id = enumTypeDto.Id;
        });
        
        var throwResult2 = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _enumTypeManager.UpdateAsync(id, "Gender", "data");
        });
        throwResult2.Message.ShouldBe($"枚举已存在");
    }
    [Fact]
    public async Task DeleteAsync()
    {
        await WithUnitOfWorkAsync(async () => { await _enumTypeManager.DeleteAsync(AbpSuiteTestConst.EnumTypeId); });
        var result = await _enumTypeManager.FindAsync(AbpSuiteTestConst.EnumTypeId);
        result.ShouldBeNull();
    }
}