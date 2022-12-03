namespace Lion.AbpSuite.Templates;

/// <summary>
/// 控制策略
/// </summary>
public enum ControlType
{
    [Description("默认值")] Default = 0,
    [Description("聚合根")] Aggregate = 10,
    [Description("实体")] Entity = 20,
    [Description("枚举")] Enum = 30,
}