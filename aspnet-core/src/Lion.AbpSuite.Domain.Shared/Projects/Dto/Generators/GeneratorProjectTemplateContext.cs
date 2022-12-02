
namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorProjectTemplateContext
{
    public GeneratorProjectContext Projects { get; set; }

    public List<GeneratorEntityModelContext> EntityModels { get; set; }
}