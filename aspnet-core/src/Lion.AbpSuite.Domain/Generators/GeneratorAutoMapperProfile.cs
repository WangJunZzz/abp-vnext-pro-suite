namespace Lion.AbpSuite.Generators;

public class GeneratorAutoMapperProfile : Profile
{
    public GeneratorAutoMapperProfile()
    {
        CreateMap<EnumTypeDto, GeneratorEnumTypeResult>();
        CreateMap<EnumTypePropertyDto, GeneratorEnumTypePropertyResult>();
        CreateMap<ProjectDto, GeneratorProjectResult>();
    }
}