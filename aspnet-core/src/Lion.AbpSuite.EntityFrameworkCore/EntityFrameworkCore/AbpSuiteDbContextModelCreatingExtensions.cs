using Humanizer;
using Lion.AbpSuite.EntityModels.Aggregates;
using Lion.AbpSuite.EnumTypes.Aggregates;
using Lion.AbpSuite.Projects.Aggregates;
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
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(Template).Pluralize());
                b.Property(e => e.Name).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Remark).HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength512);
                b.ConfigureByConvention();
            });
            builder.Entity<TemplateDetail>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(TemplateDetail).Pluralize());
                b.Property(e => e.Name).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Description).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
            
            builder.Entity<Project>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(Project).Pluralize());
                b.Property(e => e.Name).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Owner).HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.CompanyName).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.ProjectName).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.NameSpace).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Remark).HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength512);
                b.ConfigureByConvention();
            });
            
            builder.Entity<EntityModel>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(EntityModel).Pluralize());
                b.Property(e => e.Code).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.HasIndex(e => e.Code);
                b.Property(e => e.Description).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
            
            builder.Entity<EntityModelProperty>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(EntityModelProperty).Pluralize());
                b.Property(e => e.Code).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Description).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
            
            builder.Entity<DataType>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(DataType));
                b.Property(e => e.Code).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.Property(e => e.Description).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
            
            builder.Entity<EnumType>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(EnumType));
                b.Property(e => e.Code).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.HasIndex(e => e.Code);
                b.Property(e => e.Description).HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
            
            builder.Entity<EnumTypeProperty>(b =>
            {
                b.ToTable(AbpSuiteConst.DbTablePrefix + nameof(EnumTypeProperty));
                b.Property(e => e.Code).IsRequired().HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.HasIndex(e => e.Code);
                b.Property(e => e.Description).HasMaxLength(AbpSuiteDomainSharedConsts.MaxLength128);
                b.ConfigureByConvention();
            });
        }
    }
}