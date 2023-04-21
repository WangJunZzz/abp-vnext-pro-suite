namespace Lion.AbpSuite.DataTypes;

public class DataTypeAppService : AbpSuiteAppService, IDataTypeAppService
{
    private readonly DataTypeManager _dataTypeManager;
    private readonly EnumTypeManager _enumTypeManager;

    public DataTypeAppService(DataTypeManager dataTypeManager, EnumTypeManager enumTypeManager)
    {
        _dataTypeManager = dataTypeManager;
        _enumTypeManager = enumTypeManager;
    }

    public async Task<List<DataTypeDto>> ListAsync(GetDataTypeInput input)
    {
        var enumList = await _enumTypeManager.ListAsync(input.EntityModelId);
        var dataTypeList = await _dataTypeManager.ListAsync();
        var result = new List<DataTypeDto>();
        result.AddRange(dataTypeList);
        result.AddRange(ObjectMapper.Map<List<EnumTypeDto>, List<DataTypeDto>>(enumList));
        return result;
    }
}