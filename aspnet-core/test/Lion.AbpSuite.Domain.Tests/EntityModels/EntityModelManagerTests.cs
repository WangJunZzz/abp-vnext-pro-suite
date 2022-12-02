using Lion.AbpSuite.Data.DataType;

namespace Lion.AbpSuite.EntityModels;

public sealed class EntityModelManagerTests : AbpSuiteDomainTestBase
{
    private readonly EntityModelManager _entityModelManager;

    public EntityModelManagerTests()
    {
        _entityModelManager = GetRequiredService<EntityModelManager>();
    }

    [Fact]
    public async Task CreateAggregateAsync()
    {
        var result = await _entityModelManager.CreateAggregateAsync(AbpSuiteTestConst.ProjectId, "Roles", "角色");
        result.Code.ShouldBe("Roles");
        result.Description.ShouldBe("角色");
        result.ParentId.ShouldBeNull();

        var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _entityModelManager.CreateAggregateAsync(AbpSuiteTestConst.ProjectId, "Users", "用户");
        });
        throwResult.Message.ShouldBe("聚合根已经存在");
    }

    [Fact]
    public async Task CreateEntityAsync()
    {
        var result = await _entityModelManager.CreateEntityAsync(AbpSuiteTestConst.AggregateId, "UserClaims", "用户身份标识", RelationalType.OneToMany);
        result.Code.ShouldBe("UserClaims");
        result.Description.ShouldBe("用户身份标识");
        result.RelationalType.ShouldBe(RelationalType.OneToMany);
        result.ParentId.ShouldBe(AbpSuiteTestConst.AggregateId);

        var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _entityModelManager.CreateEntityAsync(Guid.NewGuid(), "UserClaims", "用户身份标识", RelationalType.OneToMany);
        });
        throwResult.Message.ShouldBe("聚合根不存在");

        var throwResult2 = await Should.ThrowAsync<UserFriendlyException>(async () =>
        {
            await _entityModelManager.CreateEntityAsync(AbpSuiteTestConst.AggregateId, "UserTokens", "用户Token", RelationalType.OneToMany);
        });
        throwResult2.Message.ShouldBe("实体已存在");
    }

    [Fact]
    public async Task UpdateAggregateAsync()
    {
        var result = await _entityModelManager.UpdateAggregateAsync(AbpSuiteTestConst.AggregateId, "UserInfo", "用户信息");
        result.Code.ShouldBe("UserInfo");
        result.Description.ShouldBe("用户信息");
        result.ParentId.ShouldBeNull();
        result.ProjectId.ShouldBe(AbpSuiteTestConst.ProjectId);
    }

    [Fact]
    public async Task UpdateEntityAsync()
    {
        var result = await _entityModelManager.UpdateEntityAsync(AbpSuiteTestConst.EntityId, "UserInfo", "用户信息", RelationalType.OnoToOne);
        result.Code.ShouldBe("UserInfo");
        result.Description.ShouldBe("用户信息");
        result.ParentId.ShouldBe(AbpSuiteTestConst.AggregateId);
        result.ProjectId.ShouldBe(AbpSuiteTestConst.ProjectId);
    }

    [Fact]
    public async Task DeleteAggregateAsync()
    {
        await WithUnitOfWorkAsync(async () => { await _entityModelManager.DeleteAggregateAsync(AbpSuiteTestConst.AggregateId); });
        var result = await _entityModelManager.FindAsync(AbpSuiteTestConst.AggregateId);
        result.ShouldBeNull();
        var result1 = await _entityModelManager.FindAsync(AbpSuiteTestConst.EntityId);
        result1.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteEntityAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await _entityModelManager.DeleteEntityAsync(AbpSuiteTestConst.AggregateId, AbpSuiteTestConst.EntityId);
        });

        var result = await _entityModelManager.FindAsync(AbpSuiteTestConst.EntityId);
        result.ShouldBeNull();

    }

    [Fact]
    public async Task CreatePropertyAsync()
    {
        var result = await _entityModelManager.CreatePropertyAsync(
            AbpSuiteTestConst.AggregateId,
            "Email",
            "邮箱",
            true,
            maxLength:128,
            minLength:10,
            dataTypeId: DataTypeDataSeedConst.DataTypeStringId);
       var property= result.EntityModelProperties.FirstOrDefault(e => e.Code == "Email");
       property.ShouldNotBeNull();
       property.Code.ShouldBe("Email");
       property.Description.ShouldBe("邮箱");
       property.IsRequired.ShouldBeTrue();
       property.MaxLength.ShouldBe(128);
       property.MinLength.ShouldBe(10);
       property.DataTypeId.ShouldBe(DataTypeDataSeedConst.DataTypeStringId);
       property.EnumTypeId.ShouldBeNull();

       var throwResult = await Should.ThrowAsync<UserFriendlyException>(async () =>
       {
         await _entityModelManager.CreatePropertyAsync(
               AbpSuiteTestConst.AggregateId,
               "Email",
               "邮箱");
       });
       throwResult.Message.ShouldBe("实体数据类型不能为空");
    }

    [Fact]
    public async Task DeletePropertyAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await _entityModelManager.DeletePropertyAsync(AbpSuiteTestConst.AggregateId, AbpSuiteTestConst.AggregatePropertyId);
        });

        var result = await _entityModelManager.FindAsync(AbpSuiteTestConst.AggregateId);
        result.EntityModelProperties.FirstOrDefault(e => e.Id == AbpSuiteTestConst.AggregatePropertyId).ShouldBeNull();
    }
}