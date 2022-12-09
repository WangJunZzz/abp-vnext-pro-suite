namespace Lion.AbpSuite.Projects.Dto.Generators.Test;

public class GeneratorResult
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public GeneratorProjectResult Project { get; set; }

    /// <summary>
    /// 实体信息
    /// </summary>
    public List<GeneratorEntityModelResult> EntityModels { get; set; }

    /// <summary>
    /// 枚举信息
    /// </summary>
    public List<GeneratorEnumTypeResult> EnumTypes { get; set; }
}