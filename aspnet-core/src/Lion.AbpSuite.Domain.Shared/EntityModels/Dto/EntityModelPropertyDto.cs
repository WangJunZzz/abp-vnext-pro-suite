namespace Lion.AbpSuite.EntityModels.Dto;

public class EntityModelPropertyDto : EntityDtoBase<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }

    /// <summary>
    /// 必填
    /// </summary>
    public bool IsRequired { get;  set; }

    /// <summary>
    /// 字符串最大长度
    /// </summary>
    public int? MaxLength { get;  set; }

    /// <summary>
    /// 字符串最小长度
    /// </summary>
    public int? MinLength { get;  set; }

    /// <summary>
    /// 当类型为decimal时的小数位数 (18,4) 中的18
    /// </summary>
    public int? DecimalPrecision { get;  set; }

    /// <summary>
    /// 当类型为decimal时的字段长度 (18,4) 中的4
    /// </summary>
    public int? DecimalScale { get;  set; }

    /// <summary>
    /// 枚举类型Id
    /// </summary>
    public Guid? EnumTypeId { get;  set; }

    /// <summary>
    /// 数据类型Id
    /// </summary>
    public Guid? DataTypeId { get;  set; }

    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid EntityModelId { get;  set; }
    
    public DateTime CreationTime { get; set; }

}