namespace Lion.AbpSuite.EnumTypes.Dto;

public class EnumTypePropertyDto : EntityDtoBase<Guid>
{
    public Guid EnumTypeId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 枚举值
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    public DateTime CreationTime { get; set; }
}