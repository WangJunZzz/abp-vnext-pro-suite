namespace Lion.AbpSuite.Templates.Aggregates;

/// <summary>
/// 模板明细 
/// </summary>
public class TemplateDetail : FullAuditedEntity<Guid>
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid TemplateId { get; private set; }

    /// <summary>
    ///  模板类型
    /// </summary>
    public TemplateType TemplateType { get; private set; }

    /// <summary>
    /// 模板控制类型
    /// </summary>
    public ControlType? ControlType { get; private set; }

    /// <summary>
    /// 父级id
    /// </summary>
    public Guid? ParentId { get; private set; }

    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; private set; }


    private TemplateDetail()
    {
    }

    public TemplateDetail(
        Guid id,
        Guid templateId,
        TemplateType templateType,
        ControlType? controlType,
        string name,
        string description,
        string content,
        Guid? parentId = null
    ) : base(id)
    {
           
        SetControlType(controlType);
        TemplateId = templateId;
        TemplateType = templateType;
        ParentId = parentId;
        SetName(name);
        SetDescription(description);
        SetContent(content);
    }


    private void SetName(string name)
    {
        Guard.NotNullOrWhiteSpace(name, nameof(name), AbpSuiteDomainSharedConsts.MaxLength128);
        Name = name;
    }

    private void SetDescription(string description)
    {
        Guard.NotNullOrWhiteSpace(description, nameof(description), AbpSuiteDomainSharedConsts.MaxLength128);
        Description = description;
    }

    private void SetContent(string content)
    {
        Content = content.IsNullOrWhiteSpace() ? string.Empty : content;
    }

    private void SetControlType(ControlType? controlType)
    {
        if (TemplateType == TemplateType.Folder)
        {
            ControlType =null;
        }
        else
        {
            ControlType = controlType;
        }
    }

    public void Update(string content)
    {
        SetContent(content);
    }

    public void Update(string name, string description, string content)
    {
        SetName(name);
        SetContent(content);
        SetDescription(description);
    }

    public void Update(string name, string description,ControlType controlType)
    {
        SetName(name);
        SetDescription(description);
        SetControlType(controlType);
    }
}