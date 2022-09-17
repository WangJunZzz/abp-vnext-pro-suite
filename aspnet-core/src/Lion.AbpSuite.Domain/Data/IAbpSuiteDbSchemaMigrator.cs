namespace Lion.AbpSuite.Data
{
    public interface IAbpSuiteDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
