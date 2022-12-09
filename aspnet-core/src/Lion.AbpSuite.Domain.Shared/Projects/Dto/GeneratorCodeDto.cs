namespace Lion.AbpSuite.Projects.Dto.Generators.Render;

public class GeneratorCodeDto
{
    public ProjectContext Project { get; set; }

    public List<TreeEntityModelContext> TreeEntityModels { get; set; }
    
    public List<EntityModelContext> EntityModels { get; set; }
    
    public GeneratorCodeDto()
    {
        EntityModels = new List<EntityModelContext>();
        TreeEntityModels = new List<TreeEntityModelContext>();
    }
}