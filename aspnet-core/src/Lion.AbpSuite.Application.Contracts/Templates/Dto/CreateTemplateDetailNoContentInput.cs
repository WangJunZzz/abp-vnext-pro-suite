namespace Lion.AbpSuite.Templates.Dto;

public class CreateTemplateDetailNoContentInput
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid TemplateId { get; set; }

    public Guid? ParentId { get; set; }
    public TemplateType TemplateType { get; set; }

    /// <summary>
    /// 模板类型
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
}