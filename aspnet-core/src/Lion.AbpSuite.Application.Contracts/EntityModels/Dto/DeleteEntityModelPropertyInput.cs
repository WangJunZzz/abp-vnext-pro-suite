namespace Lion.AbpSuite.EntityModels.Dto;

public class DeleteEntityModelPropertyInput
{
    public Guid Id { get; set; }
    
    public Guid PropertyId { get; set; }
}