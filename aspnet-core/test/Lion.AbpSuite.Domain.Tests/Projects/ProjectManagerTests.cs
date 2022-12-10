namespace Lion.AbpSuite.Projects;

public sealed class ProjectManagerTests : AbpSuiteDomainTestBase
{
    private readonly ProjectManager _projectManager;

    public ProjectManagerTests()
    {
        _projectManager = GetRequiredService<ProjectManager>();
    }

    [Fact]
    public async Task PageAsync()
    {
        var list = await _projectManager.GetListAsync();
        var count = await _projectManager.GetCountAsync();
        list.ShouldNotBeNull();
        list.Count.ShouldBe(Convert.ToInt32(count));
    }

    [Fact]
    public async Task CreateAsync()
    {
        var result = await _projectManager.CreateAsync("xx", "xx", "data", "owner",remark:"remark");
        result.Name.ShouldBe("xx");
        result.CompanyName.ShouldBe("xx");
        result.ProjectName.ShouldBe("data");
        result.NameSpace.ShouldBe("xx.data");
        result.Owner.ShouldBe("owner");
        result.Remark.ShouldBe("remark");

        var name = "单元测试种子项目";
        var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () => { await _projectManager.CreateAsync(name, "data","xx"); });
        throwResult.Message.ShouldBe($"{name}项目已存在");
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var result = await _projectManager.UpdateAsync(AbpSuiteTestConst.ProjectId, "xx", "xx", "data", "owner",remark:"remark");
        result.Name.ShouldBe("xx");
        result.CompanyName.ShouldBe("xx");
        result.ProjectName.ShouldBe("data");
        result.NameSpace.ShouldBe("xx.data");
        result.Owner.ShouldBe("owner");
        result.Remark.ShouldBe("remark");
        
        var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _projectManager.UpdateAsync(Guid.NewGuid(), "xx", "data", "owner", "remark");
        });
        throwResult.Message.ShouldBe($"项目不存在");

      
        var name = "multi-name";
        await WithUnitOfWorkAsync(async () =>
        {
           await _projectManager.CreateAsync(name, "data", "owner", "remark");
        });
        
        var throwResult2 = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _projectManager.UpdateAsync(AbpSuiteTestConst.ProjectId, name, "data", "owner", "remark");
        });
        throwResult2.Message.ShouldBe($"{name}项目已存在");
    }

    [Fact]
    public async Task DeleteAsync()
    {
        await WithUnitOfWorkAsync(async () => { await _projectManager.DeleteAsync(AbpSuiteTestConst.ProjectId); });
        var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _projectManager.GetAsync(AbpSuiteTestConst.ProjectId);
        });
        throwResult.Message.ShouldBe($"项目不存在");
    }
}