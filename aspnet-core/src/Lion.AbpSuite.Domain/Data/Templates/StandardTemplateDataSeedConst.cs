namespace Lion.AbpSuite.Data.Templates;

public class StandardTemplateDataSeedConst
{
    public const string TemplateGroupName = "Lion.AbpPro标准模板";
    /// <summary>
    /// AspNetCore
    /// </summary>
    public static class  AspNetCore
    {
        public static string Name = "AspNetCore";
        
        public static class  Src
        {
            public static string Name = "src";
            public static class  Controller
            {
                public static string Name = "Controller";
                // 聚合根Controller模板
                public static string ControllerName = "{{aggregateCode}}Controller.txt";
                public static string ControllerPath = "/Lion.AbpSuite/Data/Templates/Standard/Controller/{{aggregateCode}}Controller.txt";
            }
            
            public static class  Application
            {
                public static string Name = "Application";
                // 聚合根ApplicationService模板
                public static string ApplicationServiceName = "{{aggregateCode}}AppService.txt";
                public static string ApplicationServicePath = "/Lion.AbpSuite/Data/Templates/Standard/Application/{{aggregateCode}}AppService.txt";
                // ApplicationService AutoMapper模板
                public static string AutoMapperName = "{{projectName}}ApplicationAutoMapperProfile.txt";
                public static string AutoMapperPath = "/Lion.AbpSuite/Data/Templates/Standard/Application/{{projectName}}ApplicationAutoMapperProfile.txt";
            }
            public static class  ApplicationContracts
            {
                public static string Name = "Application.Contracts";
                // 聚合根IApplicationService模板
                public static string IApplicationServiceName = "I{{aggregateCode}}AppService.txt";
                public static string IApplicationServicePath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContracts/I{{aggregateCode}}AppService.txt";
               
                public static string CreateInputName = "Create{{aggregateCode}}Input.txt";
                public static string CreateInputPath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContracts/Create{{aggregateCode}}Input.txt";
                
                public static string UpdateInputName = "Update{{aggregateCode}}Input.txt";
                public static string UpdateInputPath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContracts/Update{{aggregateCode}}Input.txt";
                
                public static string DeleteInputName = "Delete{{aggregateCode}}Input.txt";
                public static string DeleteInputPath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContracts/Delete{{aggregateCode}}Input.txt";
                
                public static string PageInputName = "Page{{aggregateCode}}Input.txt";
                public static string PageInputPath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContracts/Page{{aggregateCode}}Input.txt";
                
                public static string PageOutputName = "Page{{aggregateCode}}Output.txt";
                public static string PageOutputPath = "/Lion.AbpSuite/Data/Templates/Standard/ApplicationContracts/Page{{aggregateCode}}Output.txt";
                
            }
            
            public static class  Domain
            {
                public static string Name = "Domain";
                public static string AggregateCodeName = "{{aggregateCode}}.txt";
                public static string AggregateCodePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}.txt";
               
                public static string EntityCodeName = "{{entityCode}}.txt";
                public static string EntityCodePath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{entityCode}}.txt";
                
                public static string AggregateCodeRepositoryName = "I{{aggregateCode}}Repository.txt";
                public static string AggregateCodeRepositoryPath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/I{{aggregateCode}}Repository.txt";
                
                public static string AggregateCodeManagerName = "{{aggregateCode}}Manager.txt";
                public static string AggregateCodeManagerPath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{aggregateCode}}Manager.txt";
                
                public static string AutoMapperName = "{{projectName}}DomainAutoMapperProfile.txt";
                public static string AutoMapperPath = "/Lion.AbpSuite/Data/Templates/Standard/Domain/{{projectName}}DomainAutoMapperProfile.txt";
                
            }
            
            public static class  DomainShared
            {
                public static string Name = "Domain.Shared";
                public static string AggregateCodeName = "{{aggregateCode}}Dto.txt";
                public static string AggregateCodePath = "/Lion.AbpSuite/Data/Templates/Standard/DomainShared/{{aggregateCode}}Dto.txt";
               
                public static string EntityCodeName = "{{entityCode}}Dto.txt";
                public static string EntityCodePath = "/Lion.AbpSuite/Data/Templates/Standard/DomainShared/{{entityCode}}Dto.txt";
                
                public static string EnumName = "{{enumCode}}.txt";
                public static string EnumPath = "/Lion.AbpSuite/Data/Templates/Standard/DomainShared/{{enumCode}}.txt";
            }
            
            public static class  EntityFrameworkCore
            {
                public static string Name = "EntityFrameworkCore";
                public static string IDbContextName = "I{{projectName}}DbContext.txt";
                public static string IDbContextPath = "/Lion.AbpSuite/Data/Templates/Standard/EntityFrameworkCore/I{{projectName}}DbContext.txt";
               
                public static string DbContextName = "{{projectName}}DbContext.txt";
                public static string DbContextPath = "/Lion.AbpSuite/Data/Templates/Standard/EntityFrameworkCore/{{projectName}}DbContext.txt";
                
                public static string RepositoryName = "EfCore{{aggregateCode}}Repository.txt";
                public static string RepositoryPath = "/Lion.AbpSuite/Data/Templates/Standard/EntityFrameworkCore/EfCore{{aggregateCode}}Repository.txt";
                
                public static string DbContextModelCreatingName = "{{projectName}}DbContextModelCreatingExtensions.txt";
                public static string DbContextModelCreatingPath = "/Lion.AbpSuite/Data/Templates/Standard/EntityFrameworkCore/{{projectName}}DbContextModelCreatingExtensions.txt";                
            }
        }
    }

    public static class Vue3
    {
        public static string Name = "Vue3";

        public static class Src
        {
            public static string Name = "src";
            public static class  Routes
            {
                public static string Name = "routes";
                public static string RouteName = "{{aggregateCode}}.ts";
                public static string RoutePath = "/Lion.AbpSuite/Data/Templates/Standard/Vue3/routes/{{aggregateCode}}.ts";
            }
            public static class  Views
            {
                public static string Name = "views";
                public static string IndexName = "Index.ts";
                public static string IndexPath = "/Lion.AbpSuite/Data/Templates/Standard/Vue3/views/Index.ts";
                public static string IndexVueName = "Index.vue";
                public static string IndexVuePath = "/Lion.AbpSuite/Data/Templates/Standard/Vue3/views/Index.vue";
                public static string CreateVueName = "Create{{aggregateCode}}.vue";
                public static string CreateVuePath = "/Lion.AbpSuite/Data/Templates/Standard/Vue3/views/Create{{aggregateCode}}.vue";
                public static string UpdateVueName = "Update{{aggregateCode}}.vue";
                public static string UpdateVuePath = "/Lion.AbpSuite/Data/Templates/Standard/Vue3/views/Update{{aggregateCode}}.vue";
            }

        }
    }
}