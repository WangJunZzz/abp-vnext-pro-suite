namespace Lion.AbpSuite.EntityModels.Dto;

public class CreateEntityModelPropertyInput
{
    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid Id { get;  set; }
    
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    [Required(ErrorMessage = "描述不能为空")]
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


 
}