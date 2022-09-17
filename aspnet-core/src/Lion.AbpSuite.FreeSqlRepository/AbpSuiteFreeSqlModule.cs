namespace Lion.AbpSuite.FreeSqlRepository;

public class AbpSuiteFreeSqlModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var connectionString = configuration.GetConnectionString("Default");
        var freeSql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.MySql, connectionString)
            .Build();
        
        context.Services.AddSingleton<IFreeSql>(freeSql);
    }
}