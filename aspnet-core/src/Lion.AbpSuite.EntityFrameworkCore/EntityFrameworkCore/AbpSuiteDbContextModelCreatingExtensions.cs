using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lion.AbpSuite.EntityFrameworkCore
{
    public static class AbpSuiteDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpSuite(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Template>(b =>
            {
                b.ToTable(AbpSuiteConsts.DbTablePrefix + nameof(Template));
                b.Property(e => e.Name).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Remark).HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength512);
                b.ConfigureByConvention();
            });
            builder.Entity<TemplateDetail>(b =>
            {
                b.ToTable(AbpSuiteConsts.DbTablePrefix + nameof(TemplateDetail));
                b.Property(e => e.Name).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
        }
    }
}