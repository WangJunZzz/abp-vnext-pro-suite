using Lion.AbpSuite.DataTypes.Dto;

namespace Lion.AbpSuite
{
    public class AbpSuiteApplicationAutoMapperProfile : Profile
    {
        public AbpSuiteApplicationAutoMapperProfile()
        {
            CreateMap<EntityModelPropertyDto, PageEntityModelPropertyOutput>();
            CreateMap<EnumTypeDto, DataTypeDto>();
            CreateMap<EnumTypeDto, PageEnumTypeOutput>();
            CreateMap<EnumTypePropertyDto, PageEnumTypePropertyOutput>();
        }
    }
}
