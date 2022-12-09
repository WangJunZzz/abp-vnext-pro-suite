
namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorProjectTemplateContext
{
    public ProjectContext Projects { get; set; }

    public List<TreeEntityModelContext> EntityModels { get; set; }

    
    public List<TreeEntityModelContext> FlatEntityModels { get; set; }
    
    public GeneratorProjectTemplateContext()
    {
        EntityModels = new List<TreeEntityModelContext>();
        FlatEntityModels = new List<TreeEntityModelContext>();
    }
}