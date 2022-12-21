using Lion.AbpSuite.Projects.Dto.Generators;
using Scriban;
using Scriban.Runtime;
using Template = Scriban.Template;

namespace Lion.AbpSuite.Generators;

public class GeneratorManager : AbpSuiteDomainService
{
    /// <summary>
    /// 模板生成
    /// </summary>
    /// <param name="context">实体上下文信息</param>
    /// <param name="template">模板</param>
    public async Task<List<TemplateTreeDto>> RenderTemplateAsync(GeneratorProjectTemplateContext context, TemplateDetailDto template)
    {
        var result = new List<TemplateTreeDto>();
        var aggregates = context.TreeEntityModels.Where(e => e.IsRoot);
        foreach (var aggregate in aggregates)
        {
            var folder = await GeneratorFolderAsync(aggregate.CodePluralized);
            result.Add(folder);
            switch (template.ControlType)
            {
                case ControlType.Aggregate:
                    var code = await RenderAggregateAsync(template, context.Project, aggregate);
                    folder.Children.Add(code);
                    break;
                case ControlType.Entity:
                    folder.Children.AddRange(await RenderEntityAsync(template, context.Project, aggregate.EntityModels));
                    break;
                case ControlType.Enum:
                    folder.Children.AddRange(await RenderEnumAsync(template, context.Project, aggregate));
                    break;
                case ControlType.Global:
                    result.Add(await RenderGlobalAsync(template, context.Project, context.EntityModels));
                    break;
            }
        }

        return result;
    }

    private async Task<TemplateTreeDto> RenderAggregateAsync(TemplateDetailDto template, GeneratorProjectContext project, GeneratorTreeEntityModelContext treeEntityModel)
    {
        var fileName = await RenderFileNameAsync(template.Name, project.Name, treeEntityModel.AggregateCode, treeEntityModel.Code, null);
        var generatorContext = new GeneratorTemplateContext()
        {
            Project = project,
            EntityModel = treeEntityModel,
        };
        var result = new TemplateTreeDto()
        {
            Key = GuidGenerator.Create(),
            Name = fileName,
            Title = fileName,
            Description = template.Description,
            Content = await RenderAsync(template.Content, new { context = generatorContext }),
            TemplateType = template.TemplateType,
            Icon = AbpSuiteConst.AntIconFile,
            IsFolder = false
        };

        return result;
    }

    /// <summary>
    /// 实体模板生成
    /// </summary>
    /// <param name="template">模板</param>
    /// <param name="project">项目上下文信息</param>
    /// <param name="entityModelContexts">具体聚合根下实体集合</param>
    private async Task<List<TemplateTreeDto>> RenderEntityAsync(TemplateDetailDto template, GeneratorProjectContext project, List<GeneratorTreeEntityModelContext> entityModelContexts)
    {
        var result = new List<TemplateTreeDto>();
        if (template.ControlType != ControlType.Entity) return result;
        foreach (var entity in entityModelContexts)
        {
            var code = await GeneratorCodeAsync(template, project, entity);
            result.Add(code);
            result.AddRange(await RenderEntityAsync(template, project, entity.EntityModels));
        }

        return result;
    }


    /// <summary>
    /// 枚举模板生成
    /// </summary>
    /// <param name="template">模板</param>
    /// <param name="project">项目上下文信息</param>
    /// <param name="treeEntityModelContexts">当前实体</param>
    private async Task<List<TemplateTreeDto>> RenderEnumAsync(TemplateDetailDto template, GeneratorProjectContext project, GeneratorTreeEntityModelContext treeEntityModelContexts)
    {
        var result = new List<TemplateTreeDto>();
        if (template.ControlType != ControlType.Enum) return result;
        foreach (var entity in treeEntityModelContexts.EnumTypes)
        {
            var code = await GeneratorCodeAsync(template, project, treeEntityModelContexts, entity);
            result.Add(code);
        }

        return result;
    }


    /// <summary>
    /// 全局模板生成
    /// </summary>
    /// <param name="template">模板</param>
    /// <param name="project">项目上下文信息</param>
    /// <param name="entityModels">当前实体</param>
    private async Task<TemplateTreeDto> RenderGlobalAsync(TemplateDetailDto template, GeneratorProjectContext project, List<GeneratorEntityModelContext> entityModels)
    {
        var result = await GeneratorCodeAsync(template, project, allEntityModels: entityModels);
        return result;
    }

    private async Task<TemplateTreeDto> GeneratorCodeAsync(
        TemplateDetailDto template,
        GeneratorProjectContext project,
        GeneratorTreeEntityModelContext entityModel = null,
        GeneratorEnumTypeContext enumType = null,
        List<GeneratorEntityModelContext> allEntityModels = null)
    {
        var fileName = await RenderFileNameAsync(template.Name, project.ProjectName, entityModel?.AggregateCode, entityModel?.Code, enumType?.Code);
        var generatorContext = new GeneratorTemplateContext()
        {
            Project = project,
            EntityModel = entityModel,
            EnumType = enumType,
            AllEntityModels = allEntityModels
        };
        var result = new TemplateTreeDto()
        {
            Key = GuidGenerator.Create(),
            Name = fileName,
            Title = fileName,
            Description = template.Description,
            Content = await RenderAsync(template.Content, new { context = generatorContext }),
            TemplateType = template.TemplateType,
            Icon = AbpSuiteConst.AntIconFile,
            IsFolder = false
        };

        return result;
    }

    private async Task<string> RenderFileNameAsync(string name, string projectName, string aggregateCode, string entityCode, string enumCode)
    {
        var fileName = await RenderAsync(name, new { projectName, aggregateCode, entityCode, enumCode });
        fileName = fileName.Replace("txt", "cs");
        return fileName;
    }

    /// <summary>
    /// 生成文件夹
    /// </summary>
    /// <param name="name">文件夹名称</param>
    public async Task<TemplateTreeDto> GeneratorFolderAsync(string name)
    {
        var result = new TemplateTreeDto()
        {
            //Key = detail.Id,
            Key = GuidGenerator.Create(),
            Name = name,
            Title = name,
            TemplateType = TemplateType.Folder,
            Icon = AbpSuiteConst.AntIconFolder,
            IsFolder = true,
            Content = string.Empty
        };
        return await Task.FromResult(result);
    }

    public async Task<string> RenderAsync(string templateContent, object model)
    {
        try
        {
            var template = Template.Parse(templateContent);
            var context = new TemplateContext();
            var scriptObject = new ScriptObject();
            scriptObject.Import(model, renamer: member => member.Name);
            context.PushGlobal(scriptObject);
            context.MemberRenamer = member => member.Name;
            var result = await template.RenderAsync(context);
            return result;
        }
        catch (Exception e)
        {
            return $"请检查模板是否正确:{e.Message}";
        }
    }
}