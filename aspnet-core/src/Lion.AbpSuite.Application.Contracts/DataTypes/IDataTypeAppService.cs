namespace Lion.AbpSuite.DataTypes;

public interface IDataTypeAppService:IApplicationService
{
    /// <summary>
    /// 获取模型下数据类型
    /// </summary>
    Task<List<DataTypeDto>> ListAsync(GetDataTypeInput input);
}