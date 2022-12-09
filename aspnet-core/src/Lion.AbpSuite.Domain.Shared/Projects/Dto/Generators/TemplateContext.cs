namespace Lion.AbpSuite.Projects.Dto.Generators;

/// <summary>
/// 模板上下文
/// </summary>
public class TemplateContext
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public ProjectContext Project { get; set; }

    /// <summary>
    /// 实体
    /// </summary>
    public TreeEntityModelContext TreeEntityModel { get; set; }

    /// <summary>
    /// 当前实体枚举
    /// </summary>
    public EnumTypeContext EnumType { get; set; }

    /// <summary>
    /// 当前项目所有实体
    /// </summary>
    public List<TreeEntityModelContext> EntityModels { get; set; }

    public TemplateContext()
    {
        EntityModels = new List<TreeEntityModelContext>();
    }
}