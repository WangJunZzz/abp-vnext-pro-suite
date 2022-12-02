namespace Lion.AbpSuite.EnumTypes.Dto;

public class PageEnumTypePropertyOutput
{
    public Guid? Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    public DateTime CreationTime { get; set; }
}