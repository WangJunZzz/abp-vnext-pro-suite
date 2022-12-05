using Lion.AbpSuite.Files;
using Lion.AbpSuite.Templates;
using Lion.AbpSuite.Templates.Aggregates;

namespace Lion.AbpSuite.Data;

public class TemplateDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ITemplateRepository _templateRepository;
    private readonly IFileLoader _fileLoader;

    public TemplateDataSeedContributor(ITemplateRepository templateRepository, IFileLoader fileLoader)
    {
        _templateRepository = templateRepository;
        _fileLoader = fileLoader;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var template = await _templateRepository.FindAsync(TemplateDataSeedConst.TemplateId);
        if (template == null)
        {
            template = new Template(TemplateDataSeedConst.TemplateId, "默认模板", "标准模板");
            // src
            //   -- applications
            //     
            template.AddTemplateDetail(TemplateDataSeedConst.SrcId, TemplateType.Folder, null, "src", "src", null, null);
            template.AddTemplateDetail(TemplateDataSeedConst.Application.ApplicationTemplateFolderId, TemplateType.Folder, null, "ApplicationService", "应用层", null, TemplateDataSeedConst.SrcId);
            var applicationServiceContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Application.ApplicationTemplatePath);
            template.AddTemplateDetail(
                TemplateDataSeedConst.Application.ApplicationTemplateId,
                TemplateType.File, ControlType.Aggregate, 
                TemplateDataSeedConst.Application.ApplicationTemplateName, 
                "应用层", applicationServiceContent, 
                TemplateDataSeedConst.Application.ApplicationTemplateFolderId);
            
            template.AddTemplateDetail(
                TemplateDataSeedConst.Domain.DomainTemplateFolderId, 
                TemplateType.Folder, 
                null, 
                "DomainService", 
                "领域层", 
                null, 
                TemplateDataSeedConst.SrcId);
            
            var aggregateServiceContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Domain.AggregateTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.Domain.AggregateTemplateId, 
                TemplateType.File, 
                ControlType.Aggregate, 
                TemplateDataSeedConst.Domain.AggregateTemplateName, 
                "聚合根", aggregateServiceContent, 
                TemplateDataSeedConst.Domain.DomainTemplateFolderId);
            
            var entityServiceContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Domain.EntityTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.Domain.EntityTemplateId, 
                TemplateType.File, 
                ControlType.Entity, 
                TemplateDataSeedConst.Domain.EntityTemplateName, 
                "实体", entityServiceContent, 
                TemplateDataSeedConst.Domain.DomainTemplateFolderId);
            var managerServiceContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Domain.ManagerTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.Domain.ManagerTemplateId, 
                TemplateType.File, 
                ControlType.Aggregate, 
                TemplateDataSeedConst.Domain.ManagerTemplateName, 
                "领域服务", managerServiceContent, 
                TemplateDataSeedConst.Domain.DomainTemplateFolderId);
            var repositoryServiceContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Domain.RepositoryTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.Domain.RepositoryTemplateId, 
                TemplateType.File, 
                ControlType.Aggregate, 
                TemplateDataSeedConst.Domain.RepositoryTemplateName, 
                "聚合根仓储接口", repositoryServiceContent, 
                TemplateDataSeedConst.Domain.DomainTemplateFolderId);
            await _templateRepository.InsertAsync(template);
        }
    }
}