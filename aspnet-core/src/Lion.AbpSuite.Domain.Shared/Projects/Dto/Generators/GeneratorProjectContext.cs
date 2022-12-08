

namespace Lion.AbpSuite.Projects.Dto.Generators;

public class GeneratorProjectContext 
{
    public Guid Id { get; set; }

    public DateTime CreationTime { get; set; }

    public Guid? TenantId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 负责人
    /// </summary>
    public string Owner { get; set; }

    /// <summary>
    /// 名称空间
    /// </summary>
    public string NameSpace { get; set; }
    
    /// <summary>
    /// 公司名称
    /// </summary>
    public string CompanyName { get;  set; }

    /// <summary>
    /// 项目英文名称
    /// </summary>
    public string ProjectName { get;   set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }
}