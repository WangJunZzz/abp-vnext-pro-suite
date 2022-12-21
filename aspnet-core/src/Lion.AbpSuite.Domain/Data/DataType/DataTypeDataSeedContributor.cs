namespace Lion.AbpSuite.Data.DataType;

public class DataTypeDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IDataTypeRepository _dataTypeRepository;
    private readonly IGuidGenerator _guidGenerator;

    public DataTypeDataSeedContributor(IDataTypeRepository dataTypeRepository, IGuidGenerator guidGenerator)
    {
        _dataTypeRepository = dataTypeRepository;
        _guidGenerator = guidGenerator;
    }


    public async Task SeedAsync(DataSeedContext context)
    {
        var dic = new Dictionary<string, string>
        {
            { "string", "String" },
            { "int", "Int" },
            { "long", "Long" },
            { "decimal", "Decimal" },
            { "float", "Float" },
            { "bool", "Bool" },
            { "Guid", "Guid" },
            { "DateTime", "DateTime" }
        };

        foreach (var item in dic)
        {
            var entity = await _dataTypeRepository.FindByCodeAsync(item.Key);
            if (entity == null)
            {
                Guid id = default;
            
                if (item.Key == "string")
                {
                    id = DataTypeDataSeedConst.DataTypeStringId;
                }
                if (item.Key == "int")
                {
                    id = DataTypeDataSeedConst.DataTypeIntId;
                }
                if (item.Key == "long")
                {
                    id = DataTypeDataSeedConst.DataTypeLongId;
                }
                if (item.Key == "decimal")
                {
                    id = DataTypeDataSeedConst.DataTypeDecimalId;
                }
                if (item.Key == "float")
                {
                    id = DataTypeDataSeedConst.DataTypeFloatId;
                }
                if (item.Key == "bool")
                {
                    id = DataTypeDataSeedConst.DataTypeBoolId;
                }
                if (item.Key == "Guid")
                {
                    id = DataTypeDataSeedConst.DataTypeGuidId;
                }
                if (item.Key == "Datetime")
                {
                    id = DataTypeDataSeedConst.DataTypeDateTimeId;
                }
                entity = new DataTypes.Aggregates.DataType(id, item.Key, item.Value);
                await _dataTypeRepository.InsertAsync(entity);
            }
        }
    }
}