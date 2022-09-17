using AutoMapper;
using Lion.AbpSuite.Templates;

namespace Lion.AbpSuite;

public class AbpSuiteAutoMapperProfile:Profile
{

    public AbpSuiteAutoMapperProfile()
    {
        CreateMap<Template, TemplateDto>();
        CreateMap<TemplateDetail, TemplateDetailDto>();
    }
}