namespace Lion.AbpSuite.Projects.Dto.Generators.Render;

/// <summary>
/// 枚举模板渲染上下文
/// </summary>
public class EnumTypeRenderContext : AggregateRenderContext
{
    /// <summary>
    /// 枚举
    /// </summary>
    public EnumTypeContext EnumType { get; set; }
}