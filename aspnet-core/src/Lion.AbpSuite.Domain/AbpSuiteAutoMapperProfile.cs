using Lion.AbpSuite.Projects.Dto.Generators;

namespace Lion.AbpSuite;

public class AbpSuiteAutoMapperProfile:Profile
{

    public AbpSuiteAutoMapperProfile()
    {
        CreateMap<Template, TemplateDto>();
        CreateMap<TemplateDetail, TemplateDetailDto>();
        CreateMap<DataType, DataTypeDto>();
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectDto, GeneratorProjectContext>();
        CreateMap<EntityModel, EntityModelDto>();
        CreateMap<EntityModelProperty, EntityModelPropertyDto>();
        CreateMap<EnumType, EnumTypeDto>();
        CreateMap<EnumTypeProperty, EnumTypePropertyDto>();
    }
}