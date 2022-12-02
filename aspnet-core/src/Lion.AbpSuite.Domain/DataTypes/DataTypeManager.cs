namespace Lion.AbpSuite.DataTypes;

public class DataTypeManager : AbpSuiteDomainService
{
    private readonly IDataTypeRepository _dataTypeRepository;

    public DataTypeManager(IDataTypeRepository dataTypeRepository)
    {
        _dataTypeRepository = dataTypeRepository;
    }

    public async Task<List<DataTypeDto>> ListAsync()
    {
        var list = await _dataTypeRepository.GetListAsync();
        return ObjectMapper.Map<List<DataType>, List<DataTypeDto>>(list);
    }
}