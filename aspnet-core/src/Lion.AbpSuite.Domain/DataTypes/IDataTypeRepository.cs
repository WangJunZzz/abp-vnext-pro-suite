namespace Lion.AbpSuite.DataTypes;

/// <summary>
/// 实体 仓储接口
/// </summary>
public interface IDataTypeRepository : IBasicRepository<DataType, Guid>
{
    Task<DataType> FindByCodeAsync(string code);
}