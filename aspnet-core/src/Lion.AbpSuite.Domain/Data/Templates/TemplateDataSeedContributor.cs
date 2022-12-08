using Lion.AbpSuite.Files;
using Lion.AbpSuite.Templates;
using Lion.AbpSuite.Templates.Aggregates;
using Volo.Abp.Timing;

namespace Lion.AbpSuite.Data;

public class TemplateDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ITemplateRepository _templateRepository;
    private readonly IFileLoader _fileLoader;
    private readonly IClock _clock;
    public TemplateDataSeedContributor(ITemplateRepository templateRepository, IFileLoader fileLoader, IClock clock)
    {
        _templateRepository = templateRepository;
        _fileLoader = fileLoader;
        _clock = clock;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var template = await _templateRepository.FindAsync(TemplateDataSeedConst.TemplateId);
        if (template == null)
        {
            template = new Template(TemplateDataSeedConst.TemplateId, "默认模板", "标准模板");

            template.AddTemplateDetail(TemplateDataSeedConst.SrcId, TemplateType.Folder, null, "src", "src", null, null);
            // 控制器层
            template.AddTemplateDetail(TemplateDataSeedConst.Controller.ControllerTemplateFolderId, TemplateType.Folder, null, "Controller", "控制器", null,
                TemplateDataSeedConst.SrcId);
            var controllerContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Controller.ControllerTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.Controller.ControllerTemplateId, TemplateType.File, ControlType.Aggregate,
                TemplateDataSeedConst.Controller.ControllerTemplateName, "控制器", controllerContent, TemplateDataSeedConst.Controller.ControllerTemplateFolderId);

            // 应用层
            template.AddTemplateDetail(TemplateDataSeedConst.Application.ApplicationTemplateFolderId, TemplateType.Folder, null, "Application", "应用层", null,
                TemplateDataSeedConst.SrcId);
            var applicationServiceContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Application.ApplicationTemplatePath);
            template.AddTemplateDetail(
                TemplateDataSeedConst.Application.ApplicationTemplateId,
                TemplateType.File, ControlType.Aggregate,
                TemplateDataSeedConst.Application.ApplicationTemplateName,
                "应用层", applicationServiceContent,
                TemplateDataSeedConst.Application.ApplicationTemplateFolderId);
            
            // 应用抽象层
            template.AddTemplateDetail(TemplateDataSeedConst.ApplicationContract.ApplicationContractTemplateFolderId, TemplateType.Folder, null, "Application.Contracts", "应用抽象层",
                null, TemplateDataSeedConst.SrcId);
            var applicationServiceContentContract = await _fileLoader.LoadAsync(TemplateDataSeedConst.ApplicationContract.ApplicationContractTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.ApplicationContract.ApplicationContractTemplateId, TemplateType.File, ControlType.Aggregate,
                TemplateDataSeedConst.ApplicationContract.ApplicationContractTemplateName, "应用抽象层",
                applicationServiceContentContract, TemplateDataSeedConst.ApplicationContract.ApplicationContractTemplateFolderId);

            // 领域层
            template.AddTemplateDetail(
                TemplateDataSeedConst.Domain.DomainTemplateFolderId,
                TemplateType.Folder,
                null,
                "Domain",
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
            
            // var domainAutoMapperContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.Domain.AutoMapperTemplatePath);
            // template.AddTemplateDetail(TemplateDataSeedConst.Domain.RepositoryTemplateId,
            //     TemplateType.File,
            //     ControlType.Aggregate,
            //     TemplateDataSeedConst.Domain.AutoMapperTemplateName,
            //     "聚合根仓储接口", domainAutoMapperContent,
            //     TemplateDataSeedConst.Domain.DomainTemplateFolderId);
            // 领域共享层
            template.AddTemplateDetail(TemplateDataSeedConst.DomainShared.DomainSharedTemplateFolderId, TemplateType.Folder, null, "Domain.Shared", "领域共享层",
                null, TemplateDataSeedConst.SrcId);
            var domainSharedAggregateContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.DomainShared.AggregateTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.DomainShared.AggregateTemplateId,
                TemplateType.File,
                ControlType.Aggregate,
                TemplateDataSeedConst.DomainShared.AggregateTemplateName,
                "聚合根Dto", domainSharedAggregateContent,
                TemplateDataSeedConst.DomainShared.DomainSharedTemplateFolderId);
            
            var domainSharedEntityContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.DomainShared.EntityTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.DomainShared.EntityTemplateId,
                TemplateType.File,
                ControlType.Entity,
                TemplateDataSeedConst.DomainShared.EntityTemplateName,
                "实体Dto", domainSharedEntityContent,
                TemplateDataSeedConst.DomainShared.DomainSharedTemplateFolderId);
            
            var enumSharedEntityContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.DomainShared.EnumTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.DomainShared.EnumTemplateId,
                TemplateType.File,
                ControlType.Enum,
                TemplateDataSeedConst.DomainShared.EnumTemplateName,
                "枚举", enumSharedEntityContent,
                TemplateDataSeedConst.DomainShared.DomainSharedTemplateFolderId);
            // ef 层
            template.AddTemplateDetail(TemplateDataSeedConst.EntityFramework.EntityFrameworkTemplateFolderId, TemplateType.Folder, null, "EntityFrameworkCore", "EF层",
                null, TemplateDataSeedConst.SrcId);
            var efAggregateContent = await _fileLoader.LoadAsync(TemplateDataSeedConst.EntityFramework.EntityFrameworkTemplatePath);
            template.AddTemplateDetail(TemplateDataSeedConst.EntityFramework.EntityFrameworkTemplateId,
                TemplateType.File,
                ControlType.Aggregate,
                TemplateDataSeedConst.EntityFramework.EntityFrameworkTemplateName,
                "EF仓储实现", efAggregateContent,
                TemplateDataSeedConst.EntityFramework.EntityFrameworkTemplateFolderId);
            
            await _templateRepository.InsertAsync(template);
        }
    }
}