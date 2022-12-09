namespace Lion.AbpSuite.Projects.Dto.Generators.Render;

/// <summary>
/// 聚合根模板渲染上下文
/// </summary>
public class AggregateRenderContext : BaseRenderContext
{
    /// <summary>
    /// 树形结构的实体上下文信息
    /// </summary>
    public TreeEntityModelContext TreeEntityModel { get; set; }
}