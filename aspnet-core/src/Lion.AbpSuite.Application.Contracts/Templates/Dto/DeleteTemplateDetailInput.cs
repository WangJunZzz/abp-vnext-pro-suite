namespace Lion.AbpSuite.Templates.Dto;

public class DeleteTemplateDetailInput
{
    public Guid TemplateId { get; set; }
    
    public Guid TemplateDetailId { get; set; }
}