namespace Lion.AbpSuite.EntityFrameworkCore.DataTypes
{
    /// <summary>
    /// 数据类型 仓储Ef core 实现
    /// </summary>
    public class EfCoreDataTypeRepository :
        EfCoreRepository<IAbpSuiteDbContext, DataType, Guid>,
        IDataTypeRepository
    {
        public EfCoreDataTypeRepository(IDbContextProvider<IAbpSuiteDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<DataType> FindByCodeAsync(string code)
        {
            return await (await GetDbSetAsync())
                .FirstOrDefaultAsync(t => t.Code == code);
        }
    }
}