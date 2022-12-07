namespace Lion.AbpSuite.Templates.Dto;

public class GetTemplateTreeOutput
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid Key { get; set; }

    /// <summary>
    ///  模板类型
    /// </summary>
    public TemplateType TemplateType { get; set; }
    
    public ControlType ControlType { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; set; }

    public List<GetTemplateTreeOutput> Children { get; set; }

    public GetTemplateTreeOutput()
    {
        Children = new List<GetTemplateTreeOutput>();
    }
}

