namespace Lion.AbpSuite;

public class AbpSuiteAutoMapperProfile : Profile
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
        CreateMap<TreeNode, TemplateTreeDto>();
        CreateMap<TemplateTreeDto, TreeNode>()
            .ForMember(e => e.FullTitle, opt => opt.Ignore())
            .ForMember(e => e.ParentFullTitle, opt => opt.Ignore());
        CreateMap<TemplateDetailDto, CopyTemplateDetailDto>()
            .ForMember(e => e.NewId, opt => opt.Ignore())
            .ForMember(e => e.NewTemplateId, opt => opt.Ignore())
            .ForMember(e => e.NewParentId, opt => opt.Ignore());

    }
}