namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorTemplateContext
{
    public GeneratorProjectContext Project { get; set; }

    public GeneratorEntityModelContext EntityModel { get; set; }
    
    public GeneratorEnumTypeContext EnumType { get; set; }
}