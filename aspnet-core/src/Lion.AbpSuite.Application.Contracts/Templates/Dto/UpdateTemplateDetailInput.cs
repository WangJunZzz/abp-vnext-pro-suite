namespace Lion.AbpSuite.Templates.Dto;

public class UpdateTemplateDetailInput
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid TemplateId { get; set; }

    public Guid TemplateDetailId { get; set; }
    
    public ControlType ControlType { get; set; }
    
    /// <summary>
    /// 模板类型
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
    
    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; set; }
}