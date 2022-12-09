using Lion.AbpSuite.Extensions;

namespace Lion.AbpSuite;

public class AbpSuiteAutoMapperProfile : Profile
{
    public AbpSuiteAutoMapperProfile()
    {
        CreateMap<Template, TemplateDto>();
        CreateMap<TemplateDetail, TemplateDetailDto>();
        CreateMap<DataType, DataTypeDto>();
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectDto, ProjectContext>();
        CreateMap<EntityModel, EntityModelDto>();
        CreateMap<EntityModelProperty, EntityModelPropertyDto>();
        CreateMap<EnumType, EnumTypeDto>();
        CreateMap<EnumTypeProperty, EnumTypePropertyDto>();
        CreateMap<TreeNode, TemplateTreeDto>();
        CreateMap<TemplateTreeDto, TreeNode>()
            .ForMember(e => e.FullTitle, opt => opt.Ignore())
            .ForMember(e => e.ParentFullTitle, opt => opt.Ignore());

        CreateMap<EntityModelDto, TreeEntityModelContext>();
        CreateMap<EntityModelPropertyDto, TreeEntityModelPropertyContext>();
        CreateMap<EnumTypeDto, EnumTypeContext>();
        CreateMap<EnumTypePropertyDto, EnumTypePropertyContext>();
    }
}