namespace Lion.AbpSuite.Templates.Aggregates;

/// <summary>
/// 模板 
/// </summary>
public class Template : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    /// <summary>
    /// 租户id
    /// </summary>
    public Guid? TenantId { get; private set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; private set; }

    /// <summary>
    /// 模板明细集合
    /// </summary>
    public List<TemplateDetail> TemplateDetails { get; private set; }

    private Template()
    {
        TemplateDetails = new List<TemplateDetail>();
    }

    public Template(
        Guid id,
        string name,
        string remark,
        Guid? tenantId = null
    ) : base(id)
    {
        TemplateDetails = new List<TemplateDetail>();

        SetName(name);
        SetRemark(remark);
        TenantId = tenantId;
    }


    private void SetName(string name)
    {
        Guard.NotNullOrWhiteSpace(name, nameof(name), AbpSuiteDomainSharedConsts.MaxLength128);
        Name = name;
    }

    private void SetRemark(string remark)
    {
        Guard.Length(remark, nameof(remark), AbpSuiteDomainSharedConsts.MaxLength512);
        Remark = remark;
    }

    public void Update(string name, string remark)
    {
        SetName(name);
        SetRemark(remark);
    }

    /// <summary>
    /// 新增模板明细
    /// </summary>
    public TemplateDetail AddTemplateDetail(Guid id, TemplateType templateType, ControlType? controlType, string name, string description, string content, Guid? parentId)
    {
        // if (TemplateDetails.Any(e => e.Name == name))
        // {
        //     throw new UserFriendlyException("模板已存在");
        // }

        var detail = new TemplateDetail(id, Id, templateType, controlType, name, description, content, parentId);
        TemplateDetails.Add(detail);
        return detail;
    }

    public void UpdateDetailContent(Guid id, string content)
    {
        var detail = TemplateDetails.FirstOrDefault(e => e.Id == id);
        if (detail == null)
        {
            throw new UserFriendlyException("模板不存在");
        }

        detail.Update(content);
    }

    public void UpdateDetail(Guid id, string name, string description, string content)
    {
        var detail = TemplateDetails.FirstOrDefault(e => e.Id == id);
        if (detail == null)
        {
            throw new UserFriendlyException("模板不存在");
        }

        detail.Update(name, description, content);
    }

    public void UpdateDetail(Guid id, string name, string description, ControlType controlType)
    {
        var detail = TemplateDetails.FirstOrDefault(e => e.Id == id);
        if (detail == null)
        {
            throw new UserFriendlyException("模板不存在");
        }

        detail.Update(name, description, controlType);
    }

    public void DeleteDetail(Guid id)
    {
        var detail = TemplateDetails.FirstOrDefault(e => e.Id == id);
        if (detail == null)
        {
            throw new UserFriendlyException("模板不存在");
        }

        TemplateDetails.Remove(detail);
    }
}