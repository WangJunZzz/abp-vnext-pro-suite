namespace Lion.AbpSuite.EntityModels;

public enum RelationalType
{
    /// <summary>
    /// 一对一
    /// </summary>
    [Description("一对一")]
    OnoToOne = 10,
    /// <summary>
    /// 一对多
    /// </summary>
    [Description("一对多")]
    OneToMany = 20,
}