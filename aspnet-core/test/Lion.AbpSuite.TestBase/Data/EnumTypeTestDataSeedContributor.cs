using Lion.AbpSuite.EnumTypes;
using Lion.AbpSuite.EnumTypes.Aggregates;
using Lion.AbpSuite.Projects;
using Lion.AbpSuite.Projects.Aggregates;

namespace Lion.AbpSuite.Data;

public class EnumTypeTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IEnumTypeRepository _enumTypeRepository;

    public EnumTypeTestDataSeedContributor(IEnumTypeRepository enumTypeRepository)
    {
        _enumTypeRepository = enumTypeRepository;
    }


    public async Task SeedAsync(DataSeedContext context)
    {
        var entity = await _enumTypeRepository.FindAsync(AbpSuiteTestConst.EnumTypeId);
        if (entity == null)
        {
            entity = new EnumType(AbpSuiteTestConst.EnumTypeId, "Gender", "性别", AbpSuiteTestConst.AggregateId,AbpSuiteTestConst.ProjectId,null);
            entity.AddPropery(AbpSuiteTestConst.EnumTypePropertyId,"Man",10,"男");
            entity.AddPropery(Guid.NewGuid(), "WoMan",20,"女");
            await _enumTypeRepository.InsertAsync(entity);
        }
    }
}