namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorProjectTemplateContext
{
    public GeneratorProjectContext Project { get; set; }

    public List<GeneratorTreeEntityModelContext> TreeEntityModels { get; set; }

    public List<GeneratorEntityModelContext> EntityModels { get; set; }

    public GeneratorProjectTemplateContext()
    {
        TreeEntityModels = new List<GeneratorTreeEntityModelContext>();
    }
}