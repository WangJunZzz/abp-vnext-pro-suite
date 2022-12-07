using Lion.AbpSuite.Data.DataType;
using Lion.AbpSuite.EntityModels;
using Lion.AbpSuite.EntityModels.Aggregates;
using Lion.AbpSuite.EnumTypes;
using Lion.AbpSuite.EnumTypes.Aggregates;
using Lion.AbpSuite.Projects;
using Lion.AbpSuite.Projects.Aggregates;

namespace Lion.AbpSuite.Data;

public class EntityModelTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IEntityModelRepository _entityModelRepository;

    public EntityModelTestDataSeedContributor(IEntityModelRepository entityModelRepository)
    {
        _entityModelRepository = entityModelRepository;
    }


    public async Task SeedAsync(DataSeedContext context)
    {
        var aggregate = await _entityModelRepository.FindAsync(AbpSuiteTestConst.AggregateId);
        if (aggregate == null)
        {
            aggregate = new EntityModel(AbpSuiteTestConst.AggregateId, AbpSuiteTestConst.ProjectId, "Users", "用户",AbpSuiteTestConst.AggregateId);
            aggregate.AddProperty(
                Guid.NewGuid(),
                "Name",
                "姓名",
                true,
                dataTypeId: DataTypeDataSeedConst.DataTypeStringId);
            aggregate.AddProperty(
                Guid.NewGuid(),
                "Age",
                "年龄",
                true,
                dataTypeId: DataTypeDataSeedConst.DataTypeIntId);
            aggregate.AddProperty(
                Guid.NewGuid(),
                "Gender",
                "性别",
                true,
                enumTypeId: AbpSuiteTestConst.EnumTypeId);
            aggregate.AddProperty(
                Guid.NewGuid(),
                "Wallet",
                "钱包",
                dataTypeId: DataTypeDataSeedConst.DataTypeFloatId);
            aggregate.AddProperty(
                AbpSuiteTestConst.AggregatePropertyId,
                "Count",
                "数量",
                decimalPrecision: 6,
                decimalScale: 3,
                dataTypeId: DataTypeDataSeedConst.DataTypeDecimalId);

            await _entityModelRepository.InsertAsync(aggregate);
        }

        var entity = await _entityModelRepository.FindAsync(AbpSuiteTestConst.EntityId);
        if (entity == null)
        {
            entity = new EntityModel(AbpSuiteTestConst.EntityId, AbpSuiteTestConst.ProjectId, "UserTokens", "用户Token",AbpSuiteTestConst.AggregateId, RelationalType.OneToMany,
                AbpSuiteTestConst.AggregateId);
            entity.AddProperty(
                Guid.NewGuid(),
                "UserId",
                "用户Id",
                true,
                dataTypeId: DataTypeDataSeedConst.DataTypeGuidId);
            entity.AddProperty(
                Guid.NewGuid(),
                "ExpirationDate",
                "有效期",
                true,
                dataTypeId: DataTypeDataSeedConst.DataTypeDateTimeId);
            entity.AddProperty(
                Guid.NewGuid(),
                "Token",
                "Token",
                true,
                dataTypeId: DataTypeDataSeedConst.DataTypeStringId);

            await _entityModelRepository.InsertAsync(entity);
        }
    }
}