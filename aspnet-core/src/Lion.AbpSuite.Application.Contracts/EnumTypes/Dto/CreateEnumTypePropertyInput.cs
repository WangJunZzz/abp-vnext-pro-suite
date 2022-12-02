namespace Lion.AbpSuite.EnumTypes.Dto;

public class CreateEnumTypePropertyInput
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid EnumTypeId { get; set; }
    
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public string Code { get; set; }

    /// <summary>
    /// 枚举值
    /// </summary>
    public int Value { get; set; }
    
    /// <summary>
    /// 描述
    /// </summary>
    [Required(ErrorMessage = "描述不能为空")]
    public string Description { get; set; }
    
}