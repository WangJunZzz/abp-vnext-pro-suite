namespace Lion.AbpSuite.Templates.Dto;

public class UpdateTemplateDetailContentInput
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid TemplateId { get; set; }

    public Guid TemplateDetailId { get; set; }

    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; set; }
}