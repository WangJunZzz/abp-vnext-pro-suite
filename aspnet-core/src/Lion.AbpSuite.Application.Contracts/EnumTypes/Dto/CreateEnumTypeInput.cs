namespace Lion.AbpSuite.EnumTypes.Dto;

public class CreateEnumTypeInput
{
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public string Code { get; set; }


    /// <summary>
    /// 描述
    /// </summary>
    [Required(ErrorMessage = "描述不能为空")]
    public string Description { get; set; }

    /// <summary>
    /// 实体模型Id
    /// </summary>
    public Guid EntityModelId { get; set; }
    
    public Guid ProjectId { get; set; }
}