namespace Lion.AbpSuite.Templates;

public interface ITemplateAppService : IApplicationService
{
    Task<PagedResultDto<TemplateDto>> PageAsync(PageTemplateInput input);

    Task CreateAsync(CreateTemplateInput input);

    Task UpdateAsync(UpdateTemplteInput input);

    Task DeleteAsync(DeleteTemplateInput input);
}