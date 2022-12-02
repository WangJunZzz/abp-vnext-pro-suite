namespace Lion.AbpSuite.EnumTypes.Dto;

public class PageEnumTypeInput:PagingBase
{
    
    public Guid Id { get; set; }
    
    public string Filter { get; set; }
}