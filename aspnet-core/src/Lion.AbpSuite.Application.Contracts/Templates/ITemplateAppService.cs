namespace Lion.AbpSuite.Templates;

public interface ITemplateAppService : IApplicationService
{
    Task<List<TemplateDto>> AllAsync();
    Task<PagedResultDto<TemplateDto>> PageAsync(PageTemplateInput input);

    Task CreateAsync(CreateTemplateInput input);

    Task UpdateAsync(UpdateTemplateInput input);

    Task DeleteAsync(DeleteTemplateInput input);

    Task CreateDetailAsync(CreateTemplateDetailInput input);
    
    Task UpdateDetailAsync(UpdateTemplateDetailInput input);

    Task UpdateDetailAsync(UpdateTemplateDetailContentInput input);
    Task DeleteDetailAsync(DeleteTemplateDetailInput input);

    Task<List<GetTemplateTreeOutput>> TemplateTreeAsync(GetTemplteTreeInput input);

    /// <summary>
    /// 获取所有模板
    /// </summary>
    /// <returns></returns>
    Task<List<TemplateDto>> ListAsync();

    List<KeyValuePair<string, int>> GetControlTypeAsync();
    
    List<KeyValuePair<string, int>> GetTemplateTypeAsync();

    Task CopyTemplateAsync(CopyTemplateInput input);
}