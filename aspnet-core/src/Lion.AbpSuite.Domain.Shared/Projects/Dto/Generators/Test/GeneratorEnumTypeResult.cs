namespace Lion.AbpSuite.Projects.Dto.Generators.Test;

public class GeneratorEnumTypeResult
{
    public Guid Id { get; set; }

    /// <summary>
    /// 枚举编码
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
    /// 枚举描述
    /// </summary>
    public string Description { get; set; }
    
    public List<GeneratorEnumTypePropertyResult> Properties { get; set; }

    public GeneratorEnumTypeResult()
    {
        Properties = new List<GeneratorEnumTypePropertyResult>();
    }
}