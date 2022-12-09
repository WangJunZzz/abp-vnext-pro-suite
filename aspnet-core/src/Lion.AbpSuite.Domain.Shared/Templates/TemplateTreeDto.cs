namespace Lion.AbpSuite.Templates;

public class TemplateTreeDto
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
    /// 模板策略
    /// </summary>
    public ControlType ControlType { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }
    
    /// <summary>
    /// 是否是文件夹
    /// </summary>
    public bool IsFolder { get; set; }

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

    public List<TemplateTreeDto> Children { get; set; }

    public TemplateTreeDto()
    {
        Children = new List<TemplateTreeDto>();
    }
}

