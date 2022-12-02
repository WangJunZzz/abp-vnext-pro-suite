namespace Lion.AbpSuite.DataTypes.Dto;

public class DataTypeDto
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get;  set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }

    /// <summary>
    /// 是否是枚举
    /// </summary>
    public bool IsEnum { get; set; }
}