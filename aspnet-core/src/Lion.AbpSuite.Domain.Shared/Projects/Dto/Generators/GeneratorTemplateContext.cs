namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorTemplateContext
{
    public GeneratorProjectContext Project { get; set; }

    public GeneratorTreeEntityModelContext EntityModel { get; set; }
    
    public GeneratorEnumTypeContext EnumType { get; set; }
    
    public List<GeneratorEntityModelContext> AllEntityModels { get; set; }
}