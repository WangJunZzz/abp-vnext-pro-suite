namespace Lion.AbpSuite.Generators.Dto;

public class GeneratorCodeTreeOutput
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid Key { get; set; }

    /// <summary>
    ///  模板类型
    /// </summary>
    public TemplateType TemplateType { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    public List<GeneratorCodeTreeOutput> Children { get; set; }

    public GeneratorCodeTreeOutput()
    {
        Children = new List<GeneratorCodeTreeOutput>();
    }
}