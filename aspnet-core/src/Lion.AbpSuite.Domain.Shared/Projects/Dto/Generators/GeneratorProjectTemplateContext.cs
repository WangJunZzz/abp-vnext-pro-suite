
namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorProjectTemplateContext
{
    public GeneratorProjectContext Projects { get; set; }

    public List<GeneratorEntityModelContext> EntityModels { get; set; }
    
    
    /// <summary>
    /// 项目下所有实体包括聚合根
    /// </summary>
    public List<GeneratorProjectEntityContext> ProjectEntities { get; set; }

    public GeneratorProjectTemplateContext()
    {
        ProjectEntities = new List<GeneratorProjectEntityContext>();
        EntityModels = new List<GeneratorEntityModelContext>();
    }
}