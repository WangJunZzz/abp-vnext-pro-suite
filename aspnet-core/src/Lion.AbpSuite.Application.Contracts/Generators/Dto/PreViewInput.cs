namespace Lion.AbpSuite.Generators.Dto;

public class PreViewInput
{
    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateId { get; set; }

    /// <summary>
    /// 模板组id
    /// </summary>
    public Guid TemplateId { get; set; }
    
    /// <summary>
    /// 模板明细id
    /// </summary>
    public Guid TemplateDetailId { get; set; }
}