using Lion.AbpSuite.EntityModels;

namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorEntityModelContext 
{
    public GeneratorEntityModelContext()
    {
        Properties = new List<GeneratorEntityModelPropertyContext>();
        EntityModels = new List<GeneratorEntityModelContext>();
    }

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

    /// <summary>
    /// 是否是聚合根
    /// </summary>
    public bool IsRoot { get; set; }
    
    /// <summary>
    /// 实体关系
    /// </summary>
    public RelationalType? RelationalType { get; set; }

    // public string RelationalTypeDescription => RelationalType.ToDescription();

    /// <summary>
    /// 实体模型属性集合
    /// </summary>
    public List<GeneratorEntityModelPropertyContext> Properties { get; set; }

    public List<GeneratorEntityModelContext> EntityModels { get; set; }
}

