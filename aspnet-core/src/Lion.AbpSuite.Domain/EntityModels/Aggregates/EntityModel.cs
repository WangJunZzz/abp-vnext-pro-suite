namespace Lion.AbpSuite.EntityModels.Aggregates;

/// <summary>
/// 实体 
/// </summary>
public class EntityModel : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; private set; }

    public Guid ProjectId { get; private set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// 实体关系
    /// </summary>
    public RelationalType? RelationalType { get; private set; }

    /// <summary>
    /// 父类Id
    /// </summary>
    public Guid? ParentId { get; private set; }

    /// <summary>
    /// 聚合根Id
    /// </summary>
    public Guid AggregateId { get; private set; }

    /// <summary>
    /// 实体模型属性集合
    /// </summary>
    public List<EntityModelProperty> EntityModelProperties { get; private set; }

    private EntityModel()
    {
        EntityModelProperties = new List<EntityModelProperty>();
    }

    public EntityModel(
        Guid id,
        Guid projectId,
        string code,
        string description,
        Guid aggregateId,
        RelationalType? relationalType = null,
        Guid? parentId = null,
        Guid? tenantId = null
    ) : base(id)
    {
        EntityModelProperties = new List<EntityModelProperty>();
        TenantId = tenantId;
        ProjectId = projectId;
        AggregateId = aggregateId;
        SetCode(code);
        SetDescription(description);
        SetRelationalType(relationalType);
        SetParentId(parentId);
    }


    public void Add(
        Guid id,
        string code,
        string description,
        RelationalType relationalType,
        Guid parentId,
        Guid? tenantId)
    {
        Id = id;
        TenantId = tenantId;
        SetCode(code);
        SetDescription(description);
        SetRelationalType(relationalType);
        SetParentId(parentId);
    }

    /// <summary>
    /// 新增实体属性
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public void AddProperty(
        Guid id,
        string code,
        string description,
        bool isRequired = false,
        int? maxLength = null,
        int? minLength = null,
        int? decimalPrecision = null,
        int? decimalScale = null,
        Guid? enumTypeId = null,
        Guid? dataTypeId = null)
    {
        if (EntityModelProperties.Any(e => e.Code == code))
        {
            throw new UserFriendlyException($"属性{code}已存在");
        }

        EntityModelProperties.Add(new EntityModelProperty(id, code, description, isRequired, maxLength, minLength, decimalPrecision, decimalScale,
            enumTypeId, dataTypeId, Id));
    }

    /// <summary>
    /// 更新实体属性
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public void UpdateProperty(
        Guid propertyId,
        string code,
        string description,
        bool isRequired,
        int? maxLength,
        int? minLength,
        int? decimalPrecision,
        int? decimalScale,
        Guid? enumTypeId,
        Guid? dataTypeId)
    {
        var property = EntityModelProperties.FirstOrDefault(e => e.Id == propertyId);
        if (property == null)
        {
            throw new UserFriendlyException($"属性不存在");
        }

        property.Update(code, description, isRequired, maxLength, minLength, decimalPrecision, decimalScale, enumTypeId, dataTypeId);
    }

    /// <summary>
    /// 删除实体属性
    /// </summary>
    /// <exception cref="UserFriendlyException"></exception>
    public void DeleteProperty(Guid propertyId)
    {
        var property = EntityModelProperties.FirstOrDefault(e => e.Id == propertyId);
        if (property == null)
        {
            throw new UserFriendlyException($"属性不存在");
        }

        property.Delete();
    }

    /// <summary>
    /// 更新实体
    /// </summary>
    public void Update(string code, string description, RelationalType relationalType)
    {
        SetCode(code);
        SetDescription(description);
        SetRelationalType(relationalType);
    }

    /// <summary>
    /// 更新实体
    /// </summary>
    public void Update(string code, string description)
    {
        SetCode(code);
        SetDescription(description);
    }

    #region 私有方法

    private void SetCode(string code)
    {
        Guard.NotNullOrWhiteSpace(code, nameof(code), AbpSuiteDomainSharedConsts.MaxLength128);
        Code = code;
    }

    private void SetDescription(string description)
    {
        Guard.NotNullOrWhiteSpace(description, nameof(description), AbpSuiteDomainSharedConsts.MaxLength128);
        Description = description;
    }

    private void SetRelationalType(RelationalType? relationalType)
    {
        RelationalType = relationalType;
    }

    private void SetParentId(Guid? parentId)
    {
        ParentId = parentId;
    }

    #endregion
}