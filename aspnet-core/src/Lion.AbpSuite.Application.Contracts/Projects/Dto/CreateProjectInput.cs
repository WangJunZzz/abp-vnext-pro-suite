namespace Lion.AbpSuite.Projects.Dto;

public class CreateProjectInput
{

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get;  set; }

    /// <summary>
    /// 负责人
    /// </summary>
    public string Owner { get;  set; }

    public string CompanyName { get;  set; }

    public string ProjectName { get;   set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get;  set; }
}