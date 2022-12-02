namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorDataTypeContext
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
    /// 描述
    /// </summary>
    public string Description { get; set; }
}