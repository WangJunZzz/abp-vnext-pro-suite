namespace Lion.AbpSuite.EntityFrameworkCore
{
    public static class AbpSuiteDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpSuite(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpSuiteConsts.DbTablePrefix + "YourEntities", AbpSuiteConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}