//
// using Lion.AbpSuite.Files;
// using Lion.AbpSuite.Generators;
// using Lion.AbpSuite.Templates;
//
// namespace Lion.AbpSuite.FileLoader;
//
// public sealed class DefaultFileLoaderTests : AbpSuiteDomainTestBase
// {
//     private readonly IFileLoader _fileLoader;
//     private readonly GeneratorManager _generatorManager;
//
//     public DefaultFileLoaderTests()
//     {
//         _fileLoader = GetRequiredService<IFileLoader>();
//         _generatorManager = GetRequiredService<GeneratorManager>();
//     }
//
//     [Fact]
//     public async Task Load_File_Shuold_Ok()
//     {
//         var path = "/Lion.AbpSuite/Data/Templates/Standard/Application/ApplicationService.liquid";
//         var result = await _fileLoader.LoadAsync(path);
//         var t = new List<Product>()
//         {
//             new Product()
//             {
//                 Name = "!23",
//                 Price = "2",
//                 Description = "tt"
//             }
//         };
//         var s = _generatorManager.RenderAsync(result, new { products = t });
//         result.ShouldNotBeNull();
//     }
// }
//
// public class Product
// {
//     public string Name { get; set; }
//     public string Price { get; set; }
//     public string Description { get; set; }
// }