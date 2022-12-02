namespace Lion.AbpSuite.EnumTypes.Dto;

public class EnumTypeDto : AggregateDtoBase<Guid>
{
    public Guid? TenantId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }


    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid EntityModelId { get; set; }

    /// <summary>
    /// 是否是枚举
    /// </summary>
    public bool IsEnum { get; set; } = true;

    public List<EnumTypePropertyDto> EnumTypeProperties { get; set; }

    public EnumTypeDto()
    {
        EnumTypeProperties = new List<EnumTypePropertyDto>();
    }
}