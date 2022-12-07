namespace Lion.AbpSuite.Projects.Dto;

public class ProjectDto : AggregateDtoBase<Guid>
{
    public Guid? TenantId { get;  set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get;  set; }

    /// <summary>
    /// 负责人
    /// </summary>
    public string Owner { get;  set; }

    /// <summary>
    /// 名称空间
    /// </summary>
    public string NameSpace { get;  set; }

    public string CompanyName { get;  set; }

    public string ProjectName { get;   set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get;  set; }
}