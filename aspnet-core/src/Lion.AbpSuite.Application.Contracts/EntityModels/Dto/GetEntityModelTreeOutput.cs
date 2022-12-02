namespace Lion.AbpSuite.EntityModels.Dto;

public class GetEntityModelTreeOutput
{
    /// <summary>
    /// 模板id
    /// </summary>
    public Guid Key { get; set; }
    
    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }
    
    /// <summary>
    /// 描述
    /// </summary>
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 父类Id
    /// </summary>
    public Guid? ParentId { get;  set; }
    
    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
    /// <summary>
    /// 实体关系
    /// </summary>
    public RelationalType? RelationalType { get; set; }
    
    public List<GetEntityModelTreeOutput> Children { get; set; }

    public GetEntityModelTreeOutput()
    {
        Children = new List<GetEntityModelTreeOutput>();
    }
}

