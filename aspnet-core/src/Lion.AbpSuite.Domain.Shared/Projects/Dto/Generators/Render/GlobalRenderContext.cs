namespace Lion.AbpSuite.Projects.Dto.Generators.Render;

/// <summary>
/// 全局模板渲染上下文
/// </summary>
public class GlobalRenderContext : BaseRenderContext
{
    public List<EntityModelContext> EntityModels { get; set; }

    public GlobalRenderContext()
    {
        EntityModels = new List<EntityModelContext>();
    }
}