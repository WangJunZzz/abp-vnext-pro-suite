using Lion.AbpSuite.DataTypes;
using Lion.AbpSuite.DataTypes.Dto;

namespace Lion.AbpSuite.Controllers;

[Route("DataTypes")]
public class DataTypeController : AbpSuiteController, IDataTypeAppService
{
    private readonly IDataTypeAppService _dataTypeAppService;

    public DataTypeController(IDataTypeAppService dataTypeAppService)
    {
        _dataTypeAppService = dataTypeAppService;
    }
    
    [HttpPost("List")]
    [SwaggerOperation(summary: "获取类型", Tags = new[] { "DataTypes" })]
    public Task<List<DataTypeDto>> ListAsync(GetDataTypeInput input)
    {
        return _dataTypeAppService.ListAsync(input);
    }
}