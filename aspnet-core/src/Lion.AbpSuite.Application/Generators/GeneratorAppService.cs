namespace Lion.AbpSuite.Generators;

public class GeneratorAppService : AbpSuiteAppService, IGeneratorAppService
{
    private readonly GeneratorManager _generatorManager;
    private readonly TemplateManager _templateManager;
    private readonly ProjectEntityManager _projectEntityManager;
    private readonly EntityModelManager _entityModelManager;
    private readonly ProjectManager _projectManager;
    private readonly TreeManager _treeManager;

    public GeneratorAppService(GeneratorManager generatorManager, TemplateManager templateManager, ProjectEntityManager projectEntityManager,
        EntityModelManager entityModelManager,
        ProjectManager projectManager, TreeManager treeManager)
    {
        _generatorManager = generatorManager;
        _templateManager = templateManager;
        _projectEntityManager = projectEntityManager;
        _entityModelManager = entityModelManager;
        _projectManager = projectManager;
        _treeManager = treeManager;
    }

    /// <summary>
    /// 预览代码生成
    /// </summary>
    public async Task<string> PreViewAsync(PreViewInput input)
    {
        var template = await _templateManager.GetAsync(input.TemplateId);
        var detail = template.TemplateDetails.FirstOrDefault(e => e.Id == input.TemplateDetailId);
        if (detail == null) throw new UserFriendlyException(message: "模板不存在");
        var entities = await _projectEntityManager.GetAggregateContextAsync(input.AggregateId);
        var result = await _generatorManager.RenderAsync(detail.Content, new { context = entities });
        return result;
    }

    /// <summary>
    /// 预览代码生成
    /// </summary>
    public async Task<List<TemplateTreeDto>> PreViewCodeAsync(PreViewCodeInput input)
    {
        var template = await _templateManager.GetAsync(input.TemplateId);
        if (template.TemplateDetails.Count == 0)
        {
            throw new UserFriendlyException("模板不存在");
        }

        var context = await _projectEntityManager.GetProjectContextAsync(input.ProjectId);
        var result = await RecursionTemplate(template.TemplateDetails, context);
        return FormatResult(result);
    }

    /// <summary>
    /// 合并重复节点
    /// </summary>
    /// <returns></returns>
    private List<TemplateTreeDto> FormatResult(List<TemplateTreeDto> list)
    {
        var treeNodes = ObjectMapper.Map<List<TemplateTreeDto>, List<TreeNode>>(list);
        var distinctResult = _treeManager.Distinct(treeNodes);
        return ObjectMapper.Map<List<TreeNode>, List<TemplateTreeDto>>(distinctResult);
    }

    /// <summary>
    /// 遍历模板
    /// </summary>
    private async Task<List<TemplateTreeDto>> RecursionTemplate(List<TemplateDetailDto> templateDetails, GeneratorProjectTemplateContext context,
        Guid? parentId = null)
    {
        var tree = new List<TemplateTreeDto>();
        var templates = templateDetails.Where(e => e.ParentId == parentId);
        foreach (var template in templates)
        {
            if (template.TemplateType == TemplateType.Folder)
            {
                var code = await GeneratorFolderAsync(template.Name);
                tree.Add(code);
                code.Children.AddRange(await RecursionTemplate(templateDetails, context, template.Id));
            }
            else
            {
                tree.AddRange(await RenderAggregateAsync(context, template));
            }
        }

        return tree;
    }

    /// <summary>
    /// 聚合根模板生成
    /// </summary>
    /// <param name="context">实体上下文信息</param>
    /// <param name="template">模板</param>
    private async Task<List<TemplateTreeDto>> RenderAggregateAsync(GeneratorProjectTemplateContext context, TemplateDetailDto template)
    {
        var result = new List<TemplateTreeDto>();
        var aggregates = context.EntityModels.Where(e => e.IsRoot);
        foreach (var aggregate in aggregates)
        {
            var folder = result.FirstOrDefault(e => e.Name == aggregate.CodePluralized);
            if (folder == null)
            {
                folder = await GeneratorFolderAsync(aggregate.CodePluralized);
            }


            result.Add(folder);
            if (template.ControlType == ControlType.Aggregate)
            {
                var code = await GeneratorCodeAsync(template, context.Projects, aggregate);
                folder.Children.Add(code);
                // 找到模板的子项
                // var ss = templateDto.TemplateDetails.Where(e => e.ParentId == template.ParentId).Where(e => e.Id != template.Id).ToList();
                //
                // foreach (var templateDetailDto in ss)
                // {
                //     folder.Children.AddRange(await RenderEntityAsync(context, templateDetailDto, aggregate.EntityModels));
                // }
            }
            else
            {
                folder.Children.AddRange(await RenderEntityAsync(context, template, aggregate.EntityModels));
            }
        }

        return result;
    }

    /// <summary>
    /// 实体模板生成
    /// </summary>
    /// <param name="context">实体上下文信息</param>
    /// <param name="template">模板</param>
    /// <param name="entityModelContexts">当前实体</param>
    private async Task<List<TemplateTreeDto>> RenderEntityAsync(GeneratorProjectTemplateContext context, TemplateDetailDto template,
        List<GeneratorEntityModelContext> entityModelContexts)
    {
        var result = new List<TemplateTreeDto>();
        if (template.ControlType != ControlType.Entity) return result;
        foreach (var entity in entityModelContexts)
        {
            var code = await GeneratorCodeAsync(template, context.Projects, entity);
            result.Add(code);
            result.AddRange(await RenderEntityAsync(context, template, entity.EntityModels));
        }

        return result;
    }

    private async Task<TemplateTreeDto> GeneratorFolderAsync(string name)
    {
        var folderName = name; //await RenderFolderNameAsync(name, entityModel?.CodePluralized, entityModel?.CodePluralized);
        var result = new TemplateTreeDto()
        {
            //Key = detail.Id,
            Key = GuidGenerator.Create(),
            Name = folderName,
            Title = folderName,
            TemplateType = TemplateType.Folder,
            Icon = "ant-design:folder-open-outlined",
            IsFolder = true
        };
        return result;
    }

    private async Task<TemplateTreeDto> GeneratorCodeAsync(TemplateDetailDto template, GeneratorProjectContext project, GeneratorEntityModelContext entityModel)
    {
        var fileName = await RenderFileNameAsync(template.Name, project.Name, entityModel.AggregateCode, entityModel.Code);
        var generatorContext = new GeneratorTemplateContext()
        {
            Project = project,
            EntityModel = entityModel
        };
        var result = new TemplateTreeDto()
        {
            //Key = template.Id,
            Key = GuidGenerator.Create(),
            Name = fileName,
            Title = fileName,
            Description = template.Description,
            Content = await _generatorManager.RenderAsync(template.Content, new { context = generatorContext }),
            TemplateType = template.TemplateType,
            Icon = "ant-design:file-outlined",
            IsFolder = false
        };

        return result;
    }

    private async Task<string> RenderFileNameAsync(string name, string projectName, string aggregateCode, string entityCode)
    {
        var fileName = await _generatorManager.RenderAsync(name, new { projectName, aggregateCode, entityCode });
        fileName = fileName.Replace("txt", "cs");
        return fileName;
    }

    private async Task<string> RenderFolderNameAsync(string name, string aggregateCode, string entityCode)
    {
        var fileName = await _generatorManager.RenderAsync(name, new { aggregateCode, entityCode });
        return fileName;
    }

    private string GetFileName(string text)
    {
        if (text.IsNullOrWhiteSpace()) throw new UserFriendlyException("文件名为空");
        var temp = text.Split(".", StringSplitOptions.RemoveEmptyEntries).ToList();
        if (temp == null || temp.Count < 1) throw new UserFriendlyException("文件名格式不正确");

        return temp[temp.Count - 2] + "." + temp.Last();
    }

    private List<string> GetDirectory(string text)
    {
        var result = new List<string>();
        if (text.IsNullOrWhiteSpace()) throw new UserFriendlyException("文件名为空");
        var temp = text.Split(".", StringSplitOptions.RemoveEmptyEntries).ToList();
        if (temp == null || temp.Count < 1) throw new UserFriendlyException("文件名格式不正确");
        for (int i = 0; i < temp.Count - 2; i++)
        {
            result.Add(temp[i]);
        }

        return result;
    }
}