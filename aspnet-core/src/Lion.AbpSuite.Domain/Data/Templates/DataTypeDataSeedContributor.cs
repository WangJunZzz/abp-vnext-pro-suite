// using Lion.AbpSuite.Files;
// using Volo.Abp.Guids;
//
// namespace Lion.AbpSuite.Data.Templates;
//
// public class TemplateDataSeedContributor : IDataSeedContributor, ITransientDependency
// {
//     private readonly ITemplateRepository _templateRepository;
//     private readonly IGuidGenerator _guidGenerator;
//     private readonly ICurrentTenant _currentTenant;
//     private readonly IFileLoader _fileLoader;
//
//     /// <summary>
//     /// 默认模板Id
//     /// </summary>
//     private readonly Guid _defaultTemplateId = Guid.Parse("3a071f8f-e01f-6f0c-6f93-6573e4253eb0");
//
//     /// <summary>
//     /// 默认聚合根模板明细Id
//     /// </summary>
//     private readonly Guid _defaultAggregateTemplateDetailId = Guid.Parse("3a071f8f-e01f-6f0c-6f93-6573e4253eb1");
//
//     public TemplateDataSeedContributor(IGuidGenerator guidGenerator, ITemplateRepository templateRepository, ICurrentTenant currentTenant, IFileLoader fileLoader)
//     {
//         _guidGenerator = guidGenerator;
//         _templateRepository = templateRepository;
//         _currentTenant = currentTenant;
//         _fileLoader = fileLoader;
//     }
//
//
//     public async Task SeedAsync(DataSeedContext context)
//     {
//         using (_currentTenant.Change(context?.TenantId))
//         {
//             var entity = await _templateRepository.FindAsync(_defaultTemplateId);
//             if (entity == null)
//             {
//                 var path = "/Lion.AbpSuite/Data/Templates/Standard/Domain/Aggregate.liquid";
//                 var content = await _fileLoader.LoadAsync(path);
//                 entity = new Template(_defaultTemplateId, "默认标准模板", "非必要不要删除", _currentTenant.Id);
//                 entity.AddDetail(_defaultAggregateTemplateDetailId, TemplateType.File, "Aggregate.liquid", "种子数据", content, null);
//                 await _templateRepository.InsertAsync(entity);
//             }
//         }
//     }
// }