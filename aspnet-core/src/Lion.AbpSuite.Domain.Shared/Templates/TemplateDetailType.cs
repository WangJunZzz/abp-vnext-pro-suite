namespace Lion.AbpSuite.Templates;

/// <summary>
/// 控制策略
/// </summary>
public enum ControlType
{
    [Description("聚合根")] Aggregate = 10,
    [Description("实体")] Entity = 20,
    [Description("枚举")] Enum = 30,
    [Description("全局")] Global = 40,
}