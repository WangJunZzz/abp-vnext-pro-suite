namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorEnumTypePropertyContext
{
    public Guid Id { get; set; }

    /// <summary>
    /// 编码
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
    /// 枚举值
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }
}