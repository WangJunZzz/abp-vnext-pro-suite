using Lion.AbpSuite.Projects.Dto.Generators.Test;

namespace Lion.AbpSuite.Projects.Dto.Generators;

/// <summary>
/// 树形实体上下文
/// </summary>
public class EntityModelContext
{
    public EntityModelContext()
    {
        Properties = new List<EntityModelPropertyContenxt>();
    }
    /// <summary>
    ///  实体Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// 实体父级Id
    /// </summary>
    public Guid? ParentId { get; set; }
    
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

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
    
    /// <summary>
    /// 编码首字母小写
    /// </summary>
    public string CodeCamelCase => Code.Camelize();

    /// <summary>
    /// 编码复数形式
    /// </summary>
    public string CodePluralized => Code.Pluralize();

    /// <summary>
    /// 聚合根编码
    /// </summary>
    public string AggregateCode { get; set; }

    /// <summary>
    /// 聚合根首字母小写
    /// </summary>
    public string AggregateCodeCamelCase => AggregateCode.Camelize();

    /// <summary>
    /// 聚合根复数形式
    /// </summary>
    public string AggregateCodePluralized => AggregateCode.Pluralize();
    
    /// <summary>
    /// 实体模型属性集合
    /// </summary>
    public List<EntityModelPropertyContenxt> Properties { get; set; }
}