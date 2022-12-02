namespace Lion.AbpSuite.EnumTypes.Dto;

public class PageEnumTypeOutput
{
    public Guid? Id { get; set; }
    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid EntityModelId { get;  set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
    
    public DateTime CreationTime { get; set; }
}