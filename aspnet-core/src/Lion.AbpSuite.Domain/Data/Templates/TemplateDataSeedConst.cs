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
        public static readonly string AggregateTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}.txt";
        public static readonly string AggregateTemplateName = "{{aggregateCode}}.txt";
        
        public static Guid EntityTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc72");
        public static readonly string EntityTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{entityCode}}.txt";
        public static readonly string EntityTemplateName = "{{entityCode}}.txt";
        
        public static Guid ManagerTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc73");
        public static readonly string ManagerTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}Manager.txt";
        public static readonly string ManagerTemplateName = "{{aggregateCode}}Manager.txt";
        
        public static Guid RepositoryTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc74");
        public static readonly string RepositoryTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/I{{aggregateCode}}Repository.txt";
        public static readonly string RepositoryTemplateName = "I{{aggregateCode}}Repository.txt";
    }
    
    /// <summary>
    /// 领域层
    /// </summary>
    public static class  Application
    {
        public static Guid ApplicationTemplateFolderId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc75");
        public static Guid ApplicationTemplateId = Guid.Parse("36bf1a46-bc97-f466-b67e-3a07cf44cc76");
        public static readonly string ApplicationTemplatePath = "/Lion.AbpSuite/Data/Templates/Standard/Application/{{aggregateCode}}ApplicationService.txt";
        public static readonly string ApplicationTemplateName = "{{aggregateCode}}ApplicationService.txt";
    }
}