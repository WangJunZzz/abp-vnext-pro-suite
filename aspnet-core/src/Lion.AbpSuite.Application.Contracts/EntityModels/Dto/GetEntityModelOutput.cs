namespace Lion.AbpSuite.EntityModels.Dto;

public class GetEntityModelOutput
{
    public GetEntityModelOutput()
    {
        EntityModelProperties = new List<GetEntityModelPropertyOutput>();
        EntityModelOutputs = new List<GetEntityModelOutput>();
    }

    public Guid Id { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 实体关系
    /// </summary>
    public RelationalType? RelationalType { get; set; }

    // public string RelationalTypeDescription => RelationalType.ToDescription();
    
    /// <summary>
    /// 实体模型属性集合
    /// </summary>
    public List<GetEntityModelPropertyOutput> EntityModelProperties { get; set; }

    public List<GetEntityModelOutput> EntityModelOutputs { get; set; }
}

public class GetEntityModelPropertyOutput
{

    public Guid Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 必填
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// 字符串最大长度
    /// </summary>
    public int? MaxLength { get; set; }

    /// <summary>
    /// 字符串最小长度
    /// </summary>
    public int? MinLength { get; set; }

    /// <summary>
    /// 当类型为decimal时的小数位数 (18,4) 中的18
    /// </summary>
    public int? DecimalPrecision { get; set; }

    /// <summary>
    /// 当类型为decimal时的字段长度 (18,4) 中的4
    /// </summary>
    public int? DecimalScale { get; set; }

    /// <summary>
    /// 枚举类型Id
    /// </summary>
    public Guid? EnumTypeId { get; set; }

    public bool IsEnum { get; set; }

    public GetEnumTypeOutput EnumTypeOutput { get; set; }
    
    /// <summary>
    /// 数据类型Id
    /// </summary>
    public Guid? DataTypeId { get; set; }

    public GetDataTypeOutput DataTypeOutput { get; set; }

    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid EntityModelId { get; set; }
}

public class GetDataTypeOutput
{
    public Guid Id { get; set; }

    /// <summary>
    /// 枚举编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 枚举描述
    /// </summary>
    public string Description { get; set; }
}

public class GetEnumTypeOutput
{
    public Guid Id { get; set; }

    /// <summary>
    /// 枚举编码
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// 枚举描述
    /// </summary>
    public string Description { get; set; }
}