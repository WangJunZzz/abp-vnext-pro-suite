namespace Lion.AbpSuite.Projects.Dto.Generators.Test;

public class EntityModelPropertyContenxt
{
    public Guid Id { get; set; }
    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid EntityModelId { get; set; }
    
    /// <summary>
    /// 名称
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// 首字母小写
    /// </summary>
    public string CodeCamelCase => Code.Camelize();
    
    /// <summary>
    /// 复数形式
    /// </summary>
    public string CodePluralized => Code.Pluralize();

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

    /// <summary>
    /// 枚举编码
    /// </summary>
    public string EnumTypeCode { get; set; }
    
    /// <summary>
    /// 枚举首字母小写
    /// </summary>
    public string EnumTypeCodeCamelCase => EnumTypeCode.Camelize();
    
    /// <summary>
    /// 枚举复数形式
    /// </summary>
    public string EnumTypeCodePluralized => EnumTypeCode.Pluralize();

    /// <summary>
    /// 枚举描述
    /// </summary>
    public string EnumTypeDescription { get; set; }

    /// <summary>
    /// 数据类型Id
    /// </summary>
    public Guid? DataTypeId { get; set; }

    /// <summary>
    /// 基础数据类型编码
    /// </summary>
    public string DataTypeCode { get; set; }

    /// <summary>
    /// 基础数据类型编码首字母小写
    /// </summary>
    public string DataTypeCodeCamelCase => DataTypeCode.Camelize();
    
    /// <summary>
    /// 基础数据类型编码复数形式
    /// </summary>
    public string DataTypeCodePluralized => DataTypeCode.Pluralize();
    
    /// <summary>
    /// 基础数据类型描述
    /// </summary>
    public string DataTypeDescription { get; set; }
    
}