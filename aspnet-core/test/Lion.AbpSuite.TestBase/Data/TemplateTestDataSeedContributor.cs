// using Lion.AbpSuite.Files;
// using Lion.AbpSuite.Templates;
// using Lion.AbpSuite.Templates.Aggregates;
//
// namespace Lion.AbpSuite.Data;
//
// public class TemplateTestDataSeedContributor : IDataSeedContributor, ITransientDependency
// {
//     private readonly ITemplateRepository _templateRepository;
//     private readonly IFileLoader _fileLoader;
//
//     public TemplateTestDataSeedContributor(ITemplateRepository templateRepository, IFileLoader fileLoader)
//     {
//         _templateRepository = templateRepository;
//         _fileLoader = fileLoader;
//     }
//
//     public async Task SeedAsync(DataSeedContext context)
//     {
//         var template = await _templateRepository.FindAsync(AbpSuiteTestConst.TemplateId);
//         if (template == null)
//         {
//             template = new Template(AbpSuiteTestConst.TemplateId, "System", "系统管理模板");
//             template.AddTemplateDetail(AbpSuiteTestConst.TemplateDetailOwnId, TemplateType.Folder, null, "Domain", "领域层", null, null);
//             var path = "/Lion.AbpSuite/Data/Templates/Standard/Domain/Aggregate.txt";
//             var content = await _fileLoader.LoadAsync(path);
//             template.AddTemplateDetail(AbpSuiteTestConst.TemplateDetailTwoId, TemplateType.File, ControlType.Aggregate, "Entity.txt", "实体模板", content,
//                 AbpSuiteTestConst.TemplateDetailOwnId);
//             await _templateRepository.InsertAsync(template);
//         }
//     }
// }