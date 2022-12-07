namespace Lion.AbpSuite.Data;

public class TemplateDataSeedConst
{
    public static Guid TemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc7c");
    public static Guid SrcId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc7a");
    
    /// <summary>
    /// 领域层
    /// </summary>
    public static class  Domain
    {
        public static Guid DomainTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc70");
        public static Guid AggregateTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc71");
        public static readonly string AggregateTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}.Aggregates.{{aggregateCode}}.txt";
        public static readonly string AggregateTemplateName = "{{aggregateCode}}.Aggregates.{{aggregateCode}}.txt";
        
        public static Guid EntityTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc72");
        public static readonly string EntityTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}.Aggregates.{{entityCode}}.txt";
        public static readonly string EntityTemplateName = "{{aggregateCode}}.Aggregates.{{entityCode}}.txt";
        
        public static Guid ManagerTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc73");
        public static readonly string ManagerTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}.{{aggregateCode}}Manager.txt";
        public static readonly string ManagerTemplateName = "{{aggregateCode}}.{{aggregateCode}}Manager.txt";
        
        public static Guid RepositoryTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc74");
        public static readonly string RepositoryTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}.I{{aggregateCode}}Repository.txt";
        public static readonly string RepositoryTemplateName = "{{aggregateCode}}.I{{aggregateCode}}Repository.txt";
        
        public static Guid AutoMapperTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44c274");
        public static readonly string AutoMapperTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{NameSpace}}DomainAutoMapperProfile.txt";
        public static readonly string AutoMapperTemplateName = "{{NameSpace}}DomainAutoMapperProfile.txt";
    }
    
        
    /// <summary>
    /// 领域共享层
    /// </summary>
    public static class  DomainShared
    {
        public static Guid DomainSharedTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf441c70");
        public static Guid AggregateTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf441c71");
        public static readonly string AggregateTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/DomainShared/{{aggregateCode}}.Dto.{{aggregateCode}}Dto.txt";
        public static readonly string AggregateTemplateName = "{{aggregateCode}}.Dto.{{aggregateCode}}Dto.txt";
        
        public static Guid EntityTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf441c72");
        public static readonly string EntityTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/DomainShared/{{aggregateCode}}.Dto.{{entityCode}}Dto.txt";
        public static readonly string EntityTemplateName = "{{aggregateCode}}.Dto.{{entityCode}}Dto.txt";
    }
    
    /// <summary>
    /// 应用层
    /// </summary>
    public static class  EntityFramework
    {
        public static Guid EntityFrameworkTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cb75");
        public static Guid EntityFrameworkTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cb76");
        public static readonly string EntityFrameworkTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/EntityFramework/{{aggregateCode}}.EfCore{{aggregateCode}}Repository.txt";
        public static readonly string EntityFrameworkTemplateName = "{{aggregateCode}}.EfCore{{aggregateCode}}Repository.txt";
    }
    
    /// <summary>
    /// 应用层
    /// </summary>
    public static class  Application
    {
        public static Guid ApplicationTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc75");
        public static Guid ApplicationTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc76");
        public static readonly string ApplicationTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Application/{{aggregateCode}}.{{aggregateCode}}ApplicationService.txt";
        public static readonly string ApplicationTemplateName = "{{aggregateCode}}.{{aggregateCode}}ApplicationService.txt";
    }
    
    /// <summary>
    /// 应用抽象层
    /// </summary>
    public static class  ApplicationContract
    {
        public static Guid ApplicationContractTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf24cc76");
        public static Guid ApplicationContractTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc77");
        public static readonly string ApplicationContractTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContract/{{aggregateCode}}.I{{aggregateCode}}AppService.txt";
        public static readonly string ApplicationContractTemplateName = "{{aggregateCode}}.I{{aggregateCode}}AppService.txt";
    }
    
    /// <summary>
    /// 应用抽象层
    /// </summary>
    public static class  Controller
    {
        public static Guid ControllerTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc78");
        public static Guid ControllerTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc79");
        public static readonly string ControllerTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Controller/{{aggregateCode}}.{{aggregateCode}}Controller.txt";
        public static readonly string ControllerTemplateName = "{{aggregateCode}}.{{aggregateCode}}Controller.txt";
    }
}