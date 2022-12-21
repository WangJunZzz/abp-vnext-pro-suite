namespace Lion.AbpSuite.EnumTypes.Aggregates;

public class EnumTypeProperty : FullAuditedEntity<Guid>
{
    public Guid EnumTypeId { get; private set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// 枚举值
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; private set; }

    private EnumTypeProperty()
    {
        
    }
    
    public EnumTypeProperty(Guid id, Guid enumTypeId, string code, int value, string description) : base(id)
    {
        SetCode(code);
        SetValue(value);
        SetDescription(description);
        SetEnumTypeId(enumTypeId);
    }
    
    private void SetCode(string code)
    {
        Guard.NotNullOrWhiteSpace(code, nameof(code), AbpSuiteDomainSharedConsts.MaxLength128);
        Code = code;
    }

    private void SetValue(int value)
    {
        Value = value;
    }

    private void SetDescription(string description)
    {
        Guard.NotNullOrWhiteSpace(description, nameof(description), AbpSuiteDomainSharedConsts.MaxLength128);
        Description = description;
    }

    private void SetEnumTypeId(Guid enumTypeId)
    {
        EnumTypeId = enumTypeId;
    }
    
    public void Delete()
    {
        IsDeleted = true;
        DeletionTime = DateTime.Now;
    }
    
    public void Update(string code,int value, string description)
    {
        SetCode(code);
        SetValue(value);
        SetDescription(description);
    }
}