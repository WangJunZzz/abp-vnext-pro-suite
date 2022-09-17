namespace Lion.AbpSuite.Data
{
    /* This is used if database provider does't define
     * IAbpSuiteDbSchemaMigrator implementation.
     */
    public class NullAbpSuiteDbSchemaMigrator : IAbpSuiteDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}